using Microsoft.AspNetCore.Mvc;

namespace OD_Stat.Modules.Geo
{
    [ApiController]
    [Route("[controller]")]
    public class GeoController : ControllerBase
    {
        [HttpGet]
        public CountryViewModel GetCountry()
        {
            return new CountryViewModel
            {
                Code = "rus",
                Id = 123,
                Name = "Russia"
            };
        }
    }
}