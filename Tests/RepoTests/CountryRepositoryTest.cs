using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.RepoTests
{
    [TestClass]
    public class CountryRepositoryTest : BaseTest, IRepoTest
    {
        private IUnitOfWork _unitOfWork;

        public CountryRepositoryTest()
        {
            _unitOfWork = _serviceBuilder.GetService<IUnitOfWork>();
        }

        private async Task<City> CreateCity()
        {
            return await _unitOfWork.CityRepository.Add(new City
            {
                Name = "TestCity",
                Region = new Region
                {
                    Code = "code",
                    Name = "TestRegion",
                    Country = new Country
                    {
                        Code = "cc",
                        Name = "Test Country"
                    }
                }
            });
        }

        [TestMethod]
        public async Task GetById_Ok_Test()
        {
            var city = await CreateCity();
            var result = await _unitOfWork.CityRepository.GetById(city.Id);
            Assert.AreEqual(result.Id, city.Id);
            Assert.AreEqual(result.Name, city.Name);
            Assert.AreEqual(result.Region.Name, city.Region.Name);
        }

        public Task GetById_WrongId_Test()
        {
            throw new System.NotImplementedException();
        }

        public Task Search_Ok_Test()
        {
            throw new System.NotImplementedException();
        }

        public Task Search_NotFound_Test()
        {
            throw new System.NotImplementedException();
        }

        public Task Update_Ok_Test()
        {
            throw new System.NotImplementedException();
        }

        public Task Delete_Ok_Test()
        {
            throw new System.NotImplementedException();
        }
    }
}