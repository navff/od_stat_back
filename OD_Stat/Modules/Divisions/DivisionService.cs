using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.DaData;
using OD_Stat.Modules.Persons;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionService
    {
        private OdContext _context;
        private DaDataService _daDataService;
        private AddressService _addressService;

        public DivisionService(
            OdContext context,
            DaDataService daDataService,
            AddressService addressService)
        {
            this._context = context;
            _daDataService = daDataService;
            _addressService = addressService;
        }

        public async Task<Division> Get(int id)
        {
            return await _context.Divisions.Include(d => d.Address)
                .FirstAsync(d => d.Id == id);
        }

        public async Task<Division> Create(int directorUseerId,
            string fiasId,
            DivisionType divisionType,
            string name,
            int? parentDivisionId)
        {
            var director = await GetAndCheckDirectorUser(directorUseerId);
            var fiasAddress = await _daDataService.GetAddressByFiasId(fiasId);
            await _addressService.Create(fiasAddress);
            
            var division = new Division()
            {
                DirectorUserId = director.Id,
                Name = name,
                AddressId = 212121, // TODO: настоящий адрес!
                DivisionType = divisionType,
                ParentDivisionId = parentDivisionId
            };
            _context.Divisions.Add(division);
            await _context.SaveChangesAsync();
            return division;
        }

        private async Task<User> GetAndCheckDirectorUser(int directorUserId)
        {
            var director = await _context.Users.FirstOrDefaultAsync(u => u.Id == directorUserId);
            if (director == null)
            {
                throw new EntityNotFoundException<User>(directorUserId,
                    "Cannot find DirectorUser for creating Division");
            }

            return director;
        }

        public async Task<Division> Update(Division entity)
        {
            var dbEntity = _context.Divisions.First(d => d.Id == entity.Id);
            dbEntity.AddressId = entity.AddressId;
            dbEntity.Name = entity.Name;
            dbEntity.DivisionType = entity.DivisionType;
            dbEntity.DirectorUserId = entity.DirectorUserId;
            dbEntity.ParentDivisionId = entity.ParentDivisionId;

            await _context.SaveChangesAsync();
            return dbEntity;
        }

        public async Task Delete(int id)
        {
            var division = await _context.Divisions.FirstAsync(d => d.Id == id);
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
        }

        public async Task<PageView<DivisionShort>> Search(DivisionSearchParams searchParams)
        {
            var query = _context.Divisions.AsQueryable();

            if (!string.IsNullOrEmpty(searchParams.Word))
            {
                var word = searchParams.Word.ToLower();
                query = query.Where(d => d.Address.City.ToLower().Contains(word)
                                         || d.Address.Region.ToLower().Contains(word)
                                         || d.Address.Settlement.ToLower().Contains(word)
                                         || d.Name.ToLower().Contains(word));
            }

            if (searchParams.DivisionType.HasValue)
            {
                query = query.Where(d => d.DivisionType == searchParams.DivisionType);
            }

            if (!string.IsNullOrEmpty(searchParams.FiasId))
            {
                query = query.Where(d => d.Address.CityFiasId == searchParams.FiasId
                                         || d.Address.FiasId == searchParams.FiasId
                                         || d.Address.RegionFiasId == searchParams.FiasId
                                         || d.Address.SettlementFiasId == searchParams.FiasId);
            }

            if (searchParams.AdminUserId.HasValue)
            {
                query = query.Where(d => d.Admins.Any(u => u.Id == searchParams.AdminUserId.Value));
            }

            if (searchParams.DirectorUserId.HasValue)
            {
                query = query.Where(d => d.Admins.Any(u => u.Id == searchParams.DirectorUserId.Value));
            }

            if (searchParams.ParentDivisionId.HasValue)
            {
                query = query.Where(d => d.ParentDivisionId == searchParams.ParentDivisionId.Value);
            }

            int skipCount = (searchParams.Page - 1) * HARDCODED_SETTINGS.ITEMS_PER_PAGE;
            query = query.OrderBy(d => d.Name)
                .Skip(skipCount)
                .Take(searchParams.Take);

            var pageView = new PageView<DivisionShort>
            {
                Items = await query.Select(d => new DivisionShort()
                {
                    Id = d.Id,
                    Address = d.Address.ToString(),
                    Name = d.Name,
                    DirectorId = d.DirectorUserId,
                    DirectorName = d.Director.Name,
                    DivisionType = d.DivisionType,
                    ParentDivisionId = d.ParentDivisionId
                }).ToListAsync(),
                CurrentPage = searchParams.Page
            };
            return pageView;
        }
    }
}