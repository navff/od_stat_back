using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Regions
{
    public interface IRegionRepository : ICrudOperations<Region>
    {
        Task<PageView<Region>> Search(RegionSearchParams searchParams);
    }

    
}