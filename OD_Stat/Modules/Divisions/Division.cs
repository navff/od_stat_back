using System.Collections.Generic;
using OD_Stat.Modules.Geo.Addresses;
using OD_Stat.Modules.Persons;

namespace OD_Stat.Modules.Divisions
{
    public class Division
    {
        public int Id { get; set; }
        public IEnumerable<User> Admins { get; set; }
        public User Director { get; set; }
        public Address Address { get; set; }
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