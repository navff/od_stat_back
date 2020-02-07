using Common;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Geo.Cities
{
    public class CitySearchParams: ISearchParams
    {
        /// <summary>
        /// Страница постраничной навигации
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int Take { get; set; } = HARDCODED_SETTINGS.ITEMS_PER_PAGE;
        /// <summary>
        /// Часть названия города
        /// </summary>
        public string? Name { get; set; } = null;
        /// <summary>
        /// Id региона, к которому относится город
        /// </summary>
        public int? RegionId { get; set; } = null;
    }
}