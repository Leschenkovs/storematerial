using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает роль
    public class Role:BaseModel<int>
    {
        public Role()
        {
            Users = new Collection<User>();
        }

        // Название
        public string Name { get; set; }

        // Код
        public string Code { get; set; }

        // Список работников
        public virtual ICollection<User> Users { get; set; }

    }
}
