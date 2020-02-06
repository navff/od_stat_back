using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Countries;
using Tests.DemoData;

namespace Tests.RepoTests
{
    [TestClass]
    public class CountryRepositoryTest : BaseTest, IRepoTest
    {
        private IUnitOfWork _unitOfWork;
        private Creators _creators;
        public CountryRepositoryTest()
        {
            _unitOfWork = DiServiceBuilder.GetService<IUnitOfWork>();
            _creators = new Creators();
        }
        
        [TestMethod]
        public async Task GetById_Ok_Test()
        {
            var country = await _creators.CountryCreator.CreateOne();
            var result = await _unitOfWork.CountryRepository
                .GetById(country.Id);
            Assert.AreEqual("cntr", result.Code);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual("TestCountry", result.Name);
        }

        [TestMethod]
        public async Task GetById_WrongId_Test()
        {
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<Country>>(async () => 
                    await _unitOfWork.CountryRepository.GetById(123545687)
            );
        }

        [TestMethod]
        public async Task Search_Ok_Test()
        {
            await _creators.CountryCreator.CreateMany(10);
            var result = await _unitOfWork.CountryRepository.Search(
                new CountrySearchParams
                {
                    Code = "cntr",
                    Name = "test",
                    Page = 1,
                    Take = 100
                }
            );
            
            Assert.IsTrue(result.ItemsCount > 0);
            Assert.AreEqual("TestCountry", result.Items.First().Name);
            Assert.IsTrue(result.Items.All(c => c.Id != 0));
        }

        [TestMethod]
        public async Task Add_Ok_Test()
        {
            var country = new Country
            {
                Code = "this_is_code",
                Name = "country_name"
            };
            var result = await _unitOfWork.CountryRepository.Add(country);
            Assert.AreEqual("this_is_code", result.Code);
            Assert.IsTrue(result.Id != 0);
        }
        

        [TestMethod]
        public async Task Search_NotFound_Test()
        {
            await _creators.CountryCreator.CreateMany(10);
            var result = await _unitOfWork.CountryRepository.Search(
                new CountrySearchParams
                {
                    Code = "kjadfkahsdfkjhaskdsjfhkajsdfh" 
                }
            );
            Assert.IsTrue(!result.Items.Any());
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var country = await _creators.CountryCreator.CreateOne();
            var updated = await _unitOfWork.CountryRepository
                .Update(new Country
                {
                    Code = "jopa",
                    Id = country.Id,
                    Name = "Jopa with hands"
                });
            
            Assert.AreEqual(country.Id, updated.Id);
            Assert.AreEqual("jopa", updated.Code);
            Assert.AreEqual("Jopa with hands", updated.Name);
        }

        [TestMethod]
        public async Task Delete_Ok_Test()
        {
            var country = await _creators.CountryCreator.CreateOne();
            await _unitOfWork.CountryRepository.Delete(country.Id);
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<Country>>(async () => 
                await _unitOfWork.CountryRepository.GetById(country.Id)    
            );
        }
    }
}