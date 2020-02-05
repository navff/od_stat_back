using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using Tests.DemoData;

namespace Tests.RepoTests
{
    [TestClass]
    public class CityRepositoryTest : BaseTest, IRepoTest
    {
        private IUnitOfWork _unitOfWork;
        private Creators _creators;

        public CityRepositoryTest()
        {
            _unitOfWork = DiServiceBuilder.GetService<IUnitOfWork>();
            _creators = new Creators();
        }

        [TestMethod]
        public async Task GetById_Ok_Test()
        {
            var city = await _creators.CityCreator.CreateOne();
            var result = await _unitOfWork.CityRepository.GetById(city.Id);
            Assert.AreEqual(result.Id, city.Id);
            Assert.AreEqual(result.Name, city.Name);
            Assert.AreEqual(result.Region.Name, city.Region.Name);
        }

        [TestMethod]
        public async Task GetById_WrongId_Test()
        {
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<City>>(async () => 
                await _unitOfWork.CityRepository.GetById(999999999)
            );
        }

        [TestMethod]
        public async Task Search_Ok_Test()
        {
            var cities = await _creators.CityCreator.CreateMany(30);
            var firstCity = cities.First();
            var result = await _unitOfWork.CityRepository.Search(new CitySearchParams
            {
                Name = firstCity.Name,
                RegionId = firstCity.RegionId,
                Page = 1,
                Take = 11
            });
            
            Assert.IsFalse(result.HasNextPage);
            Assert.IsFalse(result.HasPreviousPage);
            Assert.AreEqual(firstCity.Name, result.Items.First().Name);

        }

        [TestMethod]
        public async Task Add_Ok_Test()
        {
            var city = CityCreator.NewCity();
            var result = await _unitOfWork.CityRepository.Add(city);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual(city.Name, result.Name);
            Assert.IsTrue(result.Region.Id != 0);
        }

        [TestMethod]
        public async Task Search_NotFound_Test()
        {
            await _creators.CityCreator.CreateMany(30);
            var result = await _unitOfWork.CityRepository.Search(new CitySearchParams
            {
                Name = "abrvalg"
            });
            Assert.IsFalse(result.Items.Any());
            Assert.IsFalse(result.HasNextPage);
            Assert.IsFalse(result.HasPreviousPage);
            Assert.IsTrue(result.ItemsCount == 0);
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var city = await _creators.CityCreator.CreateOne();
            var result = await _unitOfWork.CityRepository.Update(new City
            {
                Name = "updated_name",
                Id = city.Id
            });
            Assert.AreEqual(city.Id, result.Id);
            Assert.AreEqual("updated_name", result.Name);
        }

        [TestMethod]
        public async Task Delete_Ok_Test()
        {
            var city = await _creators.CityCreator.CreateOne();
            await _unitOfWork.CityRepository.Delete(city.Id);
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<City>>(async () => 
                await _unitOfWork.CityRepository.GetById(city.Id)
            );
        }
    }
}