namespace OD_Stat.Modules.Addresses
{
    public class Address
    {
        public int Id { get; set; }
        
        public string FiasId { get; set; }
        public string UnrestrictedValue { get; set; }
        
        public string Country { get; set; }
        
        public string Region { get; set; }
        public string RegionFiasId { get; set; }
        
        public string Settlement { get; set; }
        public string SettlementFiasId { get; set; }

        public string City { get; set; }
        public string CityFiasId { get; set; }
        
        public override string ToString()
        {
            return UnrestrictedValue;
        }
    }
    
    
}