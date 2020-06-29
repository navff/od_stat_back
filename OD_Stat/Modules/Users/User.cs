namespace OD_Stat.Modules.Persons
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}