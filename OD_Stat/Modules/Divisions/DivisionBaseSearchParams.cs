using System;
using System.ComponentModel.DataAnnotations;
using OD_Stat.Modules.CommonModulesHelpings;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionBaseSearchParams : BaseSearchParams
    {
        public string Word { get; set; }
        public int? AdminUserId { get; set; }
        public int? DirectorUserId { get; set; }
        public string FiasId { get; set; }
        public int? ParentDivisionId { get; set; }
        public DivisionType? DivisionType { get; set; }
    }
}