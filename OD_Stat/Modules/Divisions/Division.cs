using System.Collections.Generic;
using OD_Stat.Modules.Geo.Addresses;
using OD_Stat.Modules.Persons;

namespace OD_Stat.Modules.Divisions
{
    public class Division
    {
        public string Id { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Person Director { get; set; }
        public Address Address { get; set; }
        public Division ParentDivision { get; set; }
        public DivisionType DivisionType { get; set; }    
    }

    public enum DivisionType
    {
        Area = 1,
        Region = 2,
        Settlement = 3
    }
    
}