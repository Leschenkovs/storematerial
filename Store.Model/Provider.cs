using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает организации-поставщиков
    public class Provider: BaseModel<int>
    {
        public Provider()
        {
            Supplies = new Collection<Supply>();
        }

        // Название 
        public string Name { get; set; }
        // Адрес
        public string Address { get; set; }
        // Телефон
        public string Telephone { get; set; }
        // Описание
        public string Description { get; set; }

        // Список поставок на склад
        public virtual ICollection<Supply> Supplies { get; set; }

    }
}
