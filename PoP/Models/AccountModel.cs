using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoP.Models
{
    public class AccountModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public int id { get; set; }
        public string securityQuestion { get; set; }
        public string securityAnswer { get; set; }
    }
}