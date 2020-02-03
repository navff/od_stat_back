﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.DemoData
{
    public class CountryCreator : BaseCreator
    {
        public CountryCreator(OdContext context) : base(context)
        {
        }

        public async Task<Country> CreateCountry()
        {
            var country = NewCountry();
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<IEnumerable<Country>> CreateCountries(int count)
        {
            var countries = new List<Country>();
            for (int i = 0; i < count; i++)
            {
                countries.Add(NewCountry());
            }

            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
            return countries;
        }

        private Country NewCountry()
        {
            return new Country
            {
                Code = "cntr",
                Name = "TestCountry"
            };
        }
    }
}