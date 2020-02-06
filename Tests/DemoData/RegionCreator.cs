using System.Collections.Generic;
using System.Threading.Tasks;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Regions;

namespace Tests.DemoData
{
    public class RegionCreator: BaseCreator, ICreator<Region>
    {
        public RegionCreator(OdContext context) : base(context)
        {
        }

        public async Task<Region> CreateOne()
        {
            var region = NewRegion();
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> CreateMany(int count)
        {
            var regions = new List<Region>();
            for (int i = 0; i < count; i++)
            {
                regions.Add(NewRegion());
            }
            _context.Regions.AddRange(regions);
            await _context.SaveChangesAsync();
            return regions;
        }

        public static Region NewRegion()
        {
            return new Region
            {
                Code = "region_code",
                Country = CountryCreator.NewCountry(),
                Name = "region_name",
                CountryId = 0
            };
        }
    }
}