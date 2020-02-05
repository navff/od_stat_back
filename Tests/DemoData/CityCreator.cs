using System.Collections.Generic;
using System.Threading.Tasks;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.DemoData
{
    public class CityCreator : BaseCreator, ICreator<City>
    {
        public CityCreator(OdContext context) : base(context)
        {
        }
        
        public async Task<City> CreateOne()
        {
            var region = RegionCreator.NewRegion();
            var city = NewCity();
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<IEnumerable<City>> CreateMany(int count)
        {
            var cities = new List<City>();
            for (int i = 0; i < count; i++)
            {
                cities.Add(NewCity());
            }
            _context.Cities.AddRange(cities);
            await _context.SaveChangesAsync();
            return cities;
        }

        public static City NewCity()
        {
            var region = RegionCreator.NewRegion();
            return new City
            {
                Name = "test_city",
                Region = region,
                RegionId = 0,
                Id = 0
            };

        }


    }
}