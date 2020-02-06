﻿using System.Threading.Tasks;
using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Cities
{
    public interface ICityService : ICrudOperations<City>
    {
        public Task<PageView<City>> Search(CitySearchParams searchParams);
    }
}