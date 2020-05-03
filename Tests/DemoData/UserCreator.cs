using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OD_Stat.DataAccess;
using OD_Stat.Modules.Persons;

namespace Tests.DemoData
{
    public class UserCreator : BaseCreator, ICreator<User>
    {
        public UserCreator(OdContext context) : base(context)
        {
        }


        public async Task<User> CreateOne()
        {
            var user = NewItem();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> CreateMany(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _context.Users.Add(NewItem());
            }

            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public static User NewItem()
        {
            return new User()
            {
                Email = "user@user.ru",
                Name = "user_name"
            };
        }

    }
}