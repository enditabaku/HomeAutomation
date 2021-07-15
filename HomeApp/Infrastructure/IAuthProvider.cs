
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
        bool AuthenticateUser(string username, string password);
        bool SignOut();
    }
}

