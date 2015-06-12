using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCTEST.Models
{
 public    class Account
    {
        public string email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Workspace { get; set; }
    }

}
