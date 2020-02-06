using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OD_Stat.Modules.Geo.Regions;

namespace OD_Stat.Modules.Geo.Cities
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required] [ForeignKey("Region")] 
        public int RegionId { get; set; }
        public virtual Region Region { get; set; } = null!;
        
    }
}