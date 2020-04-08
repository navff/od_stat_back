using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Regions
{
    class RegionRepository : AbstractRepo, IRegionRepository
    {
        private OdContext _context;
        private IMapper _mapper;
        public RegionRepository(OdContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<Regions.Region> GetById(int id)
        {
            var region = await _context.Regions.Include(r => r.Country)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (region == null) throw new EntityNotFoundException<Regions.Region>(id.ToString());
            return region;
        }

        public async Task<Regions.Region> Add(Regions.Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<Region> Update(Region region)
        {
            var resultRegion = await GetById(region.Id);
            resultRegion.CloneToSelf(region);
            await _context.SaveChangesAsync();
            return resultRegion;
        }

        public async Task Delete(int id)
        {
            var region = await GetById(id);
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
        }

        public async Task<PageView<Regions.Region>> Search([NotNull]RegionSearchParams searchParams)
        {
            var skip = HARDCODED_SETTINGS.ITEMS_PER_PAGE * (searchParams.Page - 1);
            var query = _context.Regions.AsQueryable();
            query = query.FilterBy(r => r.Code == searchParams.Code, searchParams.Code)
                    .FilterBy(r => r.Name.ToLower().Contains(searchParams.Word.ToLower()), searchParams.Word)
                    .FilterBy(r => r.CountryId == searchParams.CountryId, searchParams.CountryId)
                    .OrderBy(r => r.Name)
                .Skip(skip)
                .Take(searchParams.Take);
                ;
            return new PageView<Regions.Region>
            {
                Items = await  query.ToListAsync(),
                CurrentPage = searchParams.Page
            };
        }
    }
}