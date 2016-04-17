using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает организации-потребители 
    public class Costumer: BaseModel<int>
    {
        public Costumer()
        {
            Experses = new Collection<Experse>();
        }

        // Название 
        public string Name { get; set; }
        // Адрес
        public string Address { get; set; }
        // Телефон
        public string Telephone { get; set; }
        // Описание
        public string Description { get; set; }

        // Список поставок для потребителей
        public virtual ICollection<Experse> Experses { get; set; }

    }
}
