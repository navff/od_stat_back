using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OD_Stat.Modules.Geo
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