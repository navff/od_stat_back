using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    class CountryRepository : AbstractRepo, ICountryRepository
    {
        private OdContext _context { get; set; }
        public CountryRepository(OdContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Country> GetById(int id)
        {
            var country =  await _context.Countries.FindAsync(id);
            if (country == null)
            {
                throw new EntityNotFoundException<Country>(id.ToString());
            }

            return country;
        }

        public Task<Country> Add(Country country)
        {
            throw new System.NotImplementedException();
        }

        public Task<Country> Update(Country country)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PageView<Country>> Search(string? code = null, 
                                                    string? name = null, 
                                                    int? page = 1,
                                                    int? take = 100)
        {
            int skipCount = (page.Value - 1) * HARDCODED_SETTINGS.ITEMS_PER_PAGE;
            
            IQueryable<Country> query = _context.Countries.AsQueryable();
            query = query.FilterBy(c => c.Code.ToLower().Contains(code.ToLower()), code)
                .FilterBy(c => c.Name.ToLower().Contains(name.ToLower()), name)
                .Skip(skipCount)
                .Take(HARDCODED_SETTINGS.ITEMS_PER_PAGE)
                .OrderBy(c => c.Name);
            
            var pageView = new PageView<Country>
            {
                Items = await query.ToListAsync(),
                CurrentPage = page.Value
            };
            return pageView;
        }

        


    }
}