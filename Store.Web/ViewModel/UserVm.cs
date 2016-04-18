using System.Collections.Generic;
using Store.Model;
using Store.Model.DTOObjects;

namespace Store.Web.ViewModel
{
    public class UserVm
    {
        public List<UserDTO> Users { get; set; }
        public List<Role> Roles { get; set; } 
    }
}