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
        public string Name { get; set; }
        
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Генерирует код автоматически и устанавливает его в поле Code
        /// </summary>
        public void SetAutoCode()
        {
            throw new NotImplementedException(); 
        }
    }
}