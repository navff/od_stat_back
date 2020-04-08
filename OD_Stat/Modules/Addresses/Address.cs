namespace OD_Stat.Modules.Geo.Addresses
{
    public class Address
    {
        public int Id { get; set; }
        public string UnrestrictedValue { get; set; }
        
        public string CountryName { get; set; }
        public string CountryFiasId { get; set; }
        
        public string RegionName { get; set; }
        public string RegionFiasId { get; set; }
        
        public string SettlementName { get; set; }
        public string SettlementFiasId { get; set; }

        public string CityName { get; set; }
        public string CityFiasId { get; set; }
    }
}