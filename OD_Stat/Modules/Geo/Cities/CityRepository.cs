using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Cities
{
    public class CityRepository : AbstractRepo, ICityRepository
    {
        private readonly IMapper _mapper;
        private OdContext _context { get; set; }
        
        public CityRepository(OdContext context, IMapper mapper) : base(context)
        { 
            _mapper = mapper;
            _context = context;
        }
        
        public async  Task<City> GetById(int id)
        {
            var city = await _context.Cities.Include(c=> c.Region)
                                            .FirstOrDefaultAsync(c => c.Id == id);
            if (city == null) throw new EntityNotFoundException<City>(id.ToString());
            return city;
        }

        public async Task<City> Add(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async  Task<City> Update(City city)
        {
            var dbCity = await GetById(city.Id);
            dbCity =  _mapper.Map<City>(city);
            dbCity.Id = city.Id;
            await _context.SaveChangesAsync();
            return dbCity;
        }

        public async Task Delete(int id)
        {
            var dbCity = await GetById(id);
            _context.Cities.Remove(dbCity);
            await _context.SaveChangesAsync();
        }

        public async Task<PageView<City>> Search(CitySearchParams searchParams)
        {
            int skipCount = (searchParams.Page - 1) * HARDCODED_SETTINGS.ITEMS_PER_PAGE;

            var query = _context.Cities.Include(c => c.Region).AsQueryable();
            query = query.FilterBy(c => c.Name.ToLower()
                    .Contains(searchParams.Name.ToLower()), searchParams.Name)
                .FilterBy(c => c.RegionId == searchParams.RegionId, searchParams.RegionId)
                .OrderBy(c => c.Name)
                .Skip(skipCount)
                .Take(searchParams.Take);
            var pageView = new PageView<City>
            {
                Items = await query.ToListAsync(),
                CurrentPage = searchParams.Page
            };
            return pageView;
        }
    }
}