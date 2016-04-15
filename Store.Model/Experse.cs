using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    // Модель описывает расходы (отгрузки) со склада
    public class Experse: BaseModel<int>
    {
        public Experse() { }

        // Идентификатор материала на складе
        //public virtual int MaterialId { get; set; }
        //public virtual Material MaterialObj { get; set; }

        // Идентификатор организации-потребителя
        public virtual int CostumerId { get; set; }
        public virtual Costumer CostumerObj { get; set; }

        // Идентификатор работника, который оформил отгрузку
        //public virtual int UserId { get; set; }
        //public virtual User UserObj { get; set; }

        // Кол-во
        public decimal Count { get; set; }
    }
}
