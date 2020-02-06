namespace OD_Stat.Modules.Geo.Cities
{
    public class CityViewModelGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }
    }
    
    public class CityViewModelPost
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}