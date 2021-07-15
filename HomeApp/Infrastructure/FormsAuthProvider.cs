﻿using HomeApp.Concrete;
using HomeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HomeApp.Infrastructure
{
    public class FormsAuthProvider : IAuthProvider
    {
        HomeContext context = new HomeContext();
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
        public bool AuthenticateUser(string username, string password)
        {
            User user = context.Users.Where(u => u.Name == username).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            if (user.Password == password)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }
            return false;
        }
        public bool SignOut()
        {

            FormsAuthentication.SignOut();
            return true;
        }
    }
}
