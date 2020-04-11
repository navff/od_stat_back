using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionService: BaseCrudService<Division, DivisionShort, DivisionSearchParams>
    {
        public DivisionService(OdContext context) : base(context)
        {
        }

        public override async Task<Division> Get(int id)
        {
            return await _context.Divisions.FirstAsync(d => d.Id == id);
        }

        public override async Task<Division> Create(Division entity)
        {
            _context.Divisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Division> Update(Division entity)
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

        public override async Task Delete(int id)
        {
            var division = await _context.Divisions.FirstAsync(d => d.Id == id);
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
        }

        public override async Task<PageView<DivisionShort>> Search(DivisionSearchParams searchParams)
        {
            var query = _context.Divisions.AsQueryable();

            if (!string.IsNullOrEmpty(searchParams.Word))
            {
                var word = searchParams.Word.ToLower();
                query = query.Where(d => d.Address.CityName.ToLower().Contains(word)
                                    || d.Address.RegionName.ToLower().Contains(word)
                                    || d.Address.SettlementName.ToLower().Contains(word)
                                    || d.Name.ToLower().Contains(word) );
            }

            if (searchParams.DivisionType.HasValue)
            {
                query = query.Where(d => d.DivisionType == searchParams.DivisionType);
            }

            if (!string.IsNullOrEmpty(searchParams.FiasId))
            {
                query = query.Where(d => d.Address.CityFiasId == searchParams.FiasId
                                         || d.Address.CountryFiasId == searchParams.FiasId
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