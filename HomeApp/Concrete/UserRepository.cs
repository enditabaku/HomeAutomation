using HomeApp.Abstract;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApp.Concrete
{
    public class UserRepository : IUserRepository
    {
        public HomeContext context = new HomeContext();
        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }
        public User FindUserByUsername(string username)
        {
            return context.Users.Where(u => u.Name == username).FirstOrDefault();
        }

    }
}