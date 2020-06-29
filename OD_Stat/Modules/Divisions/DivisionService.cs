using System;
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
        private readonly OdContext _context;
        private readonly DaDataService _daDataService;
        private readonly AddressService _addressService;

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
            var result =  await _context.Divisions.Include(d => d.Address)
                .FirstOrDefaultAsync(d => d.Id == id);
            
            if (result == null)
                throw new EntityNotFoundException<Division>(id);

            return result;
        }

        public async Task<Division> Create(int directorUserId,
            string fiasId,
            DivisionType divisionType,
            string name,
            int? parentDivisionId)
        {
            var director = await GetAndCheckDirectorUser(directorUserId);
            var fiasAddress = await _daDataService.GetAddressByFiasId(fiasId);
            fiasAddress = await _addressService.Create(fiasAddress);
            
            var division = new Division()
            {
                DirectorUserId = director.Id,
                Name = name,
                AddressId = fiasAddress.Id,
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
            var division = await _context.Divisions.FirstOrDefaultAsync(d => d.Id == id);
            if (division == null)
                throw new EntityNotFoundException<Division>(id);
            
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
        }

        public async Task<PageView<DivisionShort>> Search(DivisionBaseSearchParams baseSearchParams)
        {
            var query = _context.Divisions.AsQueryable();

            if (!string.IsNullOrEmpty(baseSearchParams.Word))
            {
                var word = baseSearchParams.Word.ToLower();
                query = query.Where(d => d.Address.City.ToLower().Contains(word)
                                         || d.Address.RegionWithType.ToLower().Contains(word)
                                         || d.Address.Settlement.ToLower().Contains(word)
                                         || d.Name.ToLower().Contains(word));
            }

            if (baseSearchParams.DivisionType.HasValue)
            {
                query = query.Where(d => d.DivisionType == baseSearchParams.DivisionType);
            }

            if (!string.IsNullOrEmpty(baseSearchParams.FiasId))
            {
                query = query.Where(d => d.Address.CityFiasId == baseSearchParams.FiasId
                                         || d.Address.FiasId == baseSearchParams.FiasId
                                         || d.Address.RegionFiasId == baseSearchParams.FiasId
                                         || d.Address.SettlementFiasId == baseSearchParams.FiasId);
            }

            if (baseSearchParams.AdminUserId.HasValue)
            {
                query = query.Where(d => d.Admins.Any(u => u.Id == baseSearchParams.AdminUserId));
            }

            if (baseSearchParams.DirectorUserId.HasValue)
            {
                query = query.Where(d => d.Admins.Any(u => u.Id == baseSearchParams.DirectorUserId));
            }

            if (baseSearchParams.ParentDivisionId.HasValue)
            {
                query = query.Where(d => d.ParentDivisionId == baseSearchParams.ParentDivisionId.Value);
            }

            int skipCount = (baseSearchParams.Page - 1) * HARDCODED_SETTINGS.ITEMS_PER_PAGE;
            query = query.OrderBy(d => d.Name)
                .Skip(skipCount)
                .Take(baseSearchParams.Take);

            var pageView = new PageView<DivisionShort>
            {
                Items = await query.Select(d => new DivisionShort()
                {
                    Id = d.Id,
                    Address = d.Address.ToString(),
                    Name = d.Name,
                    DirectorUserId = d.DirectorUserId,
                    DirectorName = d.Director.Name,
                    DivisionType = d.DivisionType,
                    ParentDivisionId = d.ParentDivisionId
                }).ToListAsync(),
                CurrentPage = baseSearchParams.Page
            };
            return pageView;
        }
    }
}