using System.Collections.Generic;
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
            var country = await _creators.CountryCreator.CreateCountry();
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
            var countries = await _creators.CountryCreator.CreateCountries(10);
            var result = await _unitOfWork.CountryRepository.Search(
                    code: "cntr",
                    name: "test"
                );
            Assert.IsTrue(result.ItemsCount > 0);
            Assert.AreEqual("TestCountry", result.Items.First().Name);
            Assert.IsTrue(result.Items.All(c => c.Id != 0));
        }

        [TestMethod]
        public async Task Search_NotFound_Test()
        {
            var countries = await _creators.CountryCreator.CreateCountries(10);
            var result = await _unitOfWork.CountryRepository.Search(
                code: "kjadfkahsdfkjhaskdsjfhkajsdfh"
            );
            Assert.IsTrue(!result.Items.Any());
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var country = await _creators.CountryCreator.CreateCountry();
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
            var country = await _creators.CountryCreator.CreateCountry();
            await _unitOfWork.CountryRepository.Delete(country.Id);
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<Country>>(async () => 
                await _unitOfWork.CountryRepository.GetById(country.Id)    
            );
        }
    }
}