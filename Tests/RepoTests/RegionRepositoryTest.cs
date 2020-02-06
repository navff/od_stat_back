using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Geo;
using OD_Stat.Modules.Geo.Regions;
using Tests.DemoData;

namespace Tests.RepoTests
{
    [TestClass]
    public class RegionRepositoryTest : BaseTest, IRepoTest
    {
        private IUnitOfWork _unitOfWork;
        private Creators _creators;
        public RegionRepositoryTest()
        {
            _unitOfWork = DiServiceBuilder.GetService<IUnitOfWork>();
            _creators = new Creators();
        }

        [TestMethod]
        public async Task  GetById_Ok_Test()
        {
            var region = await _creators.RegionCreator.CreateOne();
            var result = await _unitOfWork.RegionRepository.GetById(region.Id);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual(region.Code, result.Code);
            Assert.AreEqual(region.Country.Code, result.Country.Code);
            Assert.AreEqual(region.Name, result.Name);
        }

        [TestMethod]
        public async Task GetById_WrongId_Test()
        {
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<Region>>(async () => 
                await _unitOfWork.RegionRepository.GetById(111234569)
            );
        }

        [TestMethod]
        public async  Task Search_Ok_Test()
        {
            var regions = await  _creators.RegionCreator.CreateMany(101);
            var firstRegion = regions.First();
            var result = await _unitOfWork.RegionRepository.Search(
                    new RegionSearchParams
                    {
                        Code = firstRegion.Code,
                        Word = firstRegion.Name.ToUpper(),
                        Page = 1,
                        Take = 150,
                        CountryId = firstRegion.CountryId
                    }
                );
            Assert.IsTrue(result.ItemsCount == 1);
            Assert.IsTrue(result.Items.Any(c => c.Code == firstRegion.Code));
        }

        [TestMethod]
        public async Task Add_Ok_Test()
        {
            var region = RegionCreator.NewRegion();
            var result = await _unitOfWork.RegionRepository.Add(region);
            Assert.IsTrue(result.Id != 0);
            Assert.AreEqual(region.Code, result.Code);
            Assert.AreEqual(region.Country.Name, result.Country.Name);
            Assert.AreEqual(region.Name, result.Name);
        }

        [TestMethod]
        public async Task Search_NotFound_Test()
        {
            await _creators.RegionCreator.CreateMany(10);
            var result = await _unitOfWork.RegionRepository.Search(
                new RegionSearchParams
                {
                    Code = "84br8h3ubskdjfbws84bf"
                }
            );
            Assert.IsTrue(result.Items != null);
            Assert.IsTrue(!result.Items.Any());
        }

        [TestMethod]
        public async Task Update_Ok_Test()
        {
            var oldRegion = await _creators.RegionCreator.CreateOne();
            oldRegion.Code = "abra";
            oldRegion.Name = "kadabra";
            var result = await _unitOfWork.RegionRepository.Update(oldRegion);
            Assert.AreEqual(oldRegion.Code, result.Code);
            Assert.AreEqual(oldRegion.Name, result.Name);
            Assert.AreEqual(oldRegion.Id, result.Id);
        }

        [TestMethod]
        public async Task Delete_Ok_Test()
        {
            var region = _creators.RegionCreator.CreateOne();
            await _unitOfWork.RegionRepository.Delete(region.Id);
            
            await Assert.ThrowsExceptionAsync<EntityNotFoundException<Region>>(async () =>
                await _unitOfWork.RegionRepository.GetById(region.Id), "Не было нужного исключения"
            );
        }
    }
}