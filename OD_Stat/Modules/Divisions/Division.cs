using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OD_Stat.Modules.Geo.Addresses;
using OD_Stat.Modules.Persons;

namespace OD_Stat.Modules.Divisions
{
    public class Division
    {
        public int Id { get; set; }
        public IEnumerable<User> Admins { get; set; }
        
        [ForeignKey("Director")]
        public int DirectorUserId { get; set; }
        public User Director { get; set; }
        
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        
        [ForeignKey("ParentDivision")]
        public int? ParentDivisionId { get; set; }
        public Division ParentDivision { get; set; }
        
        public DivisionType DivisionType { get; set; }    
        public string Name { get; set; }
    }

    public enum DivisionType
    {
        Area = 1,
        Region = 2,
        City = 3
    }
    
}