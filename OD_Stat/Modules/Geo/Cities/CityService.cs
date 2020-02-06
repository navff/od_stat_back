using System.Threading.Tasks;
using Common;
using OD_Stat.DataAccess;

namespace OD_Stat.Modules.Geo.Cities
{
    public class CityService : ICityService
    {
        private IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<City> GetById(int id)
        {
            return await _unitOfWork.CityRepository.GetById(id);
        }

        public async Task<City> Add(City entity)
        {
            return await _unitOfWork.CityRepository.Add(entity);
        }

        public async Task<City> Update(City city)
        {
            return await _unitOfWork.CityRepository.Update(city);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CityRepository.Delete(id);
        }

        public async Task<PageView<City>> Search(CitySearchParams searchParams)
        {
            return await _unitOfWork.CityRepository.Search(searchParams);
        }
    }
}