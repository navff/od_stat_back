using OD_Stat.DataAccess;

namespace Tests.DemoData
{
    public class Creators
    {
        public CountryCreator CountryCreator { get; }

        public Creators()
        {
            DIServiceBuilder builder = new DIServiceBuilder();
            var context = builder.GetService<OdContext>(); 
            CountryCreator = new CountryCreator(context);
        }
    }
}