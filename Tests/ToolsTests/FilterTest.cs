using System.Linq;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Divisions;
using OD_Stat.Modules.Persons;
using Tests.DemoData;

namespace Tests.ToolsTests
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
                _context.Divisions.Add(new Division
                {
                    DivisionType = DivisionType.City,
                    Name = "sdfsf",
                    Director = new User
                    {
                        Email = "director@user.ru",
                        Name = "Director"
                    },
                    Address = AddressCreator.NewItem(),
                });
            }
            _context.SaveChanges();
        }
        [TestMethod]
        public void PageViewTest()
        {
            PrepareData(123);
            IQueryable<Division> query = _context.Divisions.AsQueryable();
            
            var pageView = new PageView<Division>
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