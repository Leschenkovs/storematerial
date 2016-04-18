using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Model;

namespace Store.Web.ViewModel
{
    public class UserVm
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; } 
    }
}