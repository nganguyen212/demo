using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tntnews.Areas.Admin.Models
{
    public class AccountModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}