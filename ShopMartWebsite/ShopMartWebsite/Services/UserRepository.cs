using ShopMartWebsite.Data;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMartWebsite.Services
{
    public class UserRepository : IUserRepository
    {
        private ShopDbContext _ctx;
        public UserRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public User GetUserByUserName(string Username)
        {
            return _ctx.Users.FirstOrDefault(x => x.UserName == Username);
        }
    }
}
