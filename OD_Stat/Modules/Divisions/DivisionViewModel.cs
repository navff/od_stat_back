using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OD_Stat.Modules.Geo.Addresses;
using OD_Stat.Modules.Persons;

namespace OD_Stat.Modules.Divisions
{
    public class DivisionViewModelGet
    {
        public int Id { get; set; }
        public IEnumerable<int> AdminsIds { get; set; }
        
        public int DirectorUserId { get; set; }
        public string DirectorName { get; set; }
        
        public int AddressId { get; set; }
        public string Address { get; set; }
        
        public int ParentDivisionId { get; set; }
        public string ParentDivisionName { get; set; }
        
        public DivisionType DivisionType { get; set; }    
        public string DivisionTypeName { get; set; }    
        
        public string Name { get; set; }
    }
    
    public class DivisionViewModelPost
    {
        public int DirectorUserId { get; set; }
        
        public string FiasId { get; set; }
        
        public int? ParentDivisionId { get; set; }
        
        public DivisionType DivisionType { get; set; }    
        
        public string Name { get; set; }
    }
    
    public class DivisionViewModelList
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public string Address { get; set; }
        public int ParentDivisionId { get; set; }
        public DivisionType DivisionType { get; set; } 
        public string Name { get; set; }
    }
}