using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo
{
    public class RegionSearchParams : ISearchParams
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = HARDCODED_SETTINGS.ITEMS_PER_PAGE;
        public string Word { get; set; } = null;
        public string Code { get; set; } = null;
        public int? CountryId { get; set; } = null;
    }
}