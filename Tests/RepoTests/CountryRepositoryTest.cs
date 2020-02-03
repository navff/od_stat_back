using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;

namespace Tests.RepoTests
{
    [TestClass]
    public class CountryRepositoryTest : BaseTest, IRepoTest
    {
        private IUnitOfWork _unitOfWork;
        private OdContext _context;
        public CountryRepositoryTest()
        {
            _unitOfWork = _serviceBuilder.GetService<IUnitOfWork>();
            _context = _serviceBuilder.GetService<OdContext>();
        }

        private async Task<IEnumerable<Country>> CreateCountries(int count=100)
        {
            var countries = new List<Country>();
            for (int i = 0; i < count; i++)
            {
                countries.Add(new Country
                {
                    Code = "cntr",
                    Name = "TestCountry"
                });
            }

            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
            return countries;
        }
        
        private async Task<Country> CreateCountry()
        {
                var country = new Country
                {
                    Code = "cntr",
                    Name = "TestCountry"
                };
            
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }
        
        [TestMethod]
        public async Task GetById_Ok_Test()
        {
            var country = await CreateCountry();
            var result = await _unitOfWork.CountryRepository
                .GetById(country.Id);
            Assert.AreEqual("cntr", result.Code);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual("TestCountry", result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException<Country>))]
        public async Task GetById_WrongId_Test()
        {
            await _unitOfWork.CountryRepository.GetById(123545687);
        }

        [TestMethod]
        public async Task Search_Ok_Test()
        {
            var countries = await CreateCountries(10);
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
            var countries = await CreateCountries(10);
            var result = await _unitOfWork.CountryRepository.Search(
                code: "kjadfkahsdfkjhaskdsjfhkajsdfh"
            );
            Assert.IsTrue(!result.Items.Any());
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var country = await CreateCountry();
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

        public async Task Delete_Ok_Test()
        {
            throw new System.NotImplementedException();
        }
    }
}