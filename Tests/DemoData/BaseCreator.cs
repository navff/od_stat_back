using OD_Stat.DataAccess;

namespace Tests.DemoData
{
    public class BaseCreator
    {
        protected OdContext _context { get; private set; }

        public BaseCreator(OdContext context)
        {
            _context = context;
        }
    }
}