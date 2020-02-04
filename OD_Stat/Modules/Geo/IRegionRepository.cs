using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    public interface IRegionRepository : ICrudRepository<Region>
    {
        Task<PageView<Region>> Search(RegionSearchParams searchParams);
    }

    
}