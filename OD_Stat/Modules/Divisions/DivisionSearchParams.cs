using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionSearchParams : ISearchParams
    {
        public string Word { get; set; }
        public int? AdminUserId { get; set; }
        public int? DirectorUserId { get; set; }
        public string FiasId { get; set; }
        public int? ParentDivisionId { get; set; }
        public DivisionType? DivisionType { get; set; }
        public int Page { get; set; }
        public int Take { get; set; }
    }
}