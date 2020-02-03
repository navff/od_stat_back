using System;
using System.Linq;
using OD_Stat.Modules.Geo;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public static class FilterHelpers
    {
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> queryable, 
                                                    Expression<Func<T,bool>> filter,
                                                    object filterParameter)
        {
            return filterParameter != null ? queryable.Where(filter) : queryable;
        }
    }
}