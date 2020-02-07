using System.ComponentModel.DataAnnotations;

namespace OD_Stat.Modules.Geo.Countries
{
    public class Country
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MinLength(2), MaxLength(200)]
        public string Name { get; set; }
        
        [Required]
        public string Code { get; set; }


        public void CloneToSelf(Country country)
        {
            this.Code = country.Code;
            this.Name = country.Name;
        }
    }
}