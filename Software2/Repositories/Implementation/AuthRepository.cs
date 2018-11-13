using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2.Repositories.Implementation
{
    //Local class to hold if the user is authenticated
    public class AuthRepository
    {
        public bool UserAuthenticated { get; set; }
        public string Username { get; set; }
    }
}
