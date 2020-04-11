using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.DemoData
{
    public class Creators
    {
        public DivisionCreator DivisionCreator { get; }
        public AddressCreator AddressCreator { get; }

        public Creators()
        {
            DIServiceBuilder builder = new DIServiceBuilder();
            var context = builder.GetService<OdContext>(); 
            DivisionCreator = new DivisionCreator(context);
            AddressCreator = new AddressCreator(context);
        }
    }
}