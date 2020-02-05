using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.DemoData
{
    public class Creators
    {
        public CountryCreator CountryCreator { get; }
        public RegionCreator RegionCreator { get; }
        public CityCreator CityCreator { get; }

        public Creators()
        {
            DIServiceBuilder builder = new DIServiceBuilder();
            var context = builder.GetService<OdContext>(); 
            CountryCreator = new CountryCreator(context);
            RegionCreator = new RegionCreator(context);
            CityCreator = new CityCreator(context);
        }
    }
}