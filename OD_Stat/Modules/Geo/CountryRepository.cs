using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    public class CountryRepository : AbstractRepo, ICountryRepository
    {
        private readonly IMapper _mapper;
        private OdContext _context { get; set; }
        public CountryRepository(OdContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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

        public async Task<Country> Add(Country country)
        {
            await _context.Countries.AddAsync(country);
            return country;
        }

        public async Task<Country> Update(Country country)
        {
            var dbCountry = await GetById(country.Id);
            dbCountry =  _mapper.Map<Country>(country);
            dbCountry.Id = country.Id;
            await _context.SaveChangesAsync();
            return dbCountry;
        }

        public async Task Delete(int id)
        {
            var dbCountry = await GetById(id);
            _context.Countries.Remove(dbCountry);
            await _context.SaveChangesAsync();
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