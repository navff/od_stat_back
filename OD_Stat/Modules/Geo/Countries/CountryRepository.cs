﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Countries
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
        
        public async Task<Countries.Country> GetById(int id)
        {
            var country =  await _context.Countries.FindAsync(id);
            if (country == null)
            {
                throw new EntityNotFoundException<Countries.Country>(id.ToString());
            }
            return country;
        }

        public async Task<Countries.Country> Add(Countries.Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<Country> Update(Country country)
        {
            var resultCountry = await GetById(country.Id);
            resultCountry.CloneToSelf(country);
            await _context.SaveChangesAsync();
            return resultCountry;
        }

        public async Task Delete(int id)
        {
            var dbCountry = await GetById(id);
            _context.Countries.Remove(dbCountry);
            await _context.SaveChangesAsync();
        }

        public async Task<PageView<Countries.Country>> Search(CountrySearchParams searchParams)
        {
            int skipCount = (searchParams.Page - 1) * HARDCODED_SETTINGS.ITEMS_PER_PAGE;
            
            IQueryable<Countries.Country> query = _context.Countries.AsQueryable();
            query = query.FilterBy(c => c.Code.ToLower()
                                    .Contains(searchParams.Code.ToLower()), searchParams.Code)
                .FilterBy(c => c.Name.ToLower()
                    .Contains(searchParams.Name.ToLower()), searchParams.Name)
                .OrderBy(c => c.Name)
                .Skip(skipCount)
                .Take(searchParams.Take);
            
            var pageView = new PageView<Countries.Country>
            {
                Items = await query.ToListAsync(),
                CurrentPage = searchParams.Page
            };
            return pageView;
        }
    }
}