using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OD_Stat.Modules.Geo
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
        
    }
}