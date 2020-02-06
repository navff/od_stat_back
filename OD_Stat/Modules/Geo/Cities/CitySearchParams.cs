﻿using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Cities
{
    public class CitySearchParams: ISearchParams
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = HARDCODED_SETTINGS.ITEMS_PER_PAGE;
        public string Name { get; set; } = null;
        public int? RegionId { get; set; } = null;
    }
}