using Common;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public interface ISearchParams
    {
        public int Page { get; set; }
        public int Take { get; set; }
    }
}