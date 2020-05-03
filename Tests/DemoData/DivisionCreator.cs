using System.Collections.Generic;
using System.Threading.Tasks;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Divisions;
using OD_Stat.Modules.Persons;

namespace Tests.DemoData
{
    public class DivisionCreator : BaseCreator, ICreator<Division>
    {
        private AddressCreator _addressCreator;
        public DivisionCreator(OdContext context) : base(context)
        {
            _addressCreator = new AddressCreator(context);
        }
        
        public async Task<Division> CreateOne()
        {
            var division = NewItem();
            _context.Divisions.Add(division);
            await _context.SaveChangesAsync();
            return division;
        }

        public async Task<IEnumerable<Division>> CreateMany(int count)
        {
            var divisions = new List<Division>();
            for (int i = 0; i < count; i++)
            {
                divisions.Add(NewItem());
            }
            _context.Divisions.AddRange(divisions);
            await _context.SaveChangesAsync();
            return divisions;
        }

        public static Division NewItem()
        {
            var address = AddressCreator.NewItem();
            return new Division
            {
                Name = "test_division",
                Address = address,
                Id = 0,
                Director = new User()
                {
                    Email = "director@user.ru",
                    Name = "Директор — собака"
                },
                DivisionType = DivisionType.City
            };

        }


    }
}