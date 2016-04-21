

namespace Store.Model.DTOObjects
{
    public class UserDTO
    {
        public int id { get; set; }
        public string login { get; set; }
        public string fio { get; set; }
        public string department { get; set; }
        public string position { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string password { get; set; }
    }
}
