namespace OD_Stat.Modules.Geo
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
    }
}