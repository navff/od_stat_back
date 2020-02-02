using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests
{
    [TestClass]
    public class DbContextTests : BaseTest
    {
        [TestMethod]
        public void CreateAndDeleteEntity()
        {
            var context = _serviceBuilder.GetService<OdContext>();
            var country = new Country
            {
                Name = "Имя",
                Code = "rus"
            };
            context.Countries.Add(country);
            context.SaveChanges();
            Assert.IsTrue(country.Id!=0);
            context.Countries.Remove(country);
            context.SaveChanges();
        }
    }
}