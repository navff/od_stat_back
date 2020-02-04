using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OD_Stat.Modules.Geo
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        
    }
}