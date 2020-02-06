using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Countries;

namespace Tests
{
    [TestClass]
    public class FilterTest : BaseTest
    {
        private OdContext _context;
        public FilterTest()
        {
            _context = DiServiceBuilder.GetService<OdContext>();
        }

        private void PrepareData(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _context.Countries.Add(new Country
                {
                    Code = "ads",
                    Name = "sdfsf"
                });
            }
            _context.SaveChanges();
        }
        [TestMethod]
        public void PageViewTest()
        {
            PrepareData(123);
            IQueryable<Country> query = _context.Countries.AsQueryable();
            
            var pageView = new PageView<Country>
            {
                Items = query,
                CurrentPage = 1
            };
            Assert.IsTrue(pageView.ItemsCount >= 123);
            Assert.AreEqual(1,pageView.CurrentPage);
            Assert.AreEqual(2, pageView.PagesCount);
            Assert.AreEqual(true, pageView.HasNextPage);
            Assert.AreEqual(false, pageView.HasPreviousPage);
        }
    }
}