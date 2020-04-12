namespace OD_Stat.Modules.Divisions
{
    public class DivisionShort
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public string Address { get; set; }
        public int? ParentDivisionId { get; set; }
        public DivisionType DivisionType { get; set; } 
        public string Name { get; set; }
    }
}