

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает материалы на складе
    public class MaterialInStore: BaseModel<int>
    {
        public MaterialInStore()
        {
            Prices = new Collection<Price>();
            Supplies = new Collection<Supply>();
            Experses = new Collection<Experse>();
        }

        // Идентификатор вида материала
        public virtual int KindMaterialId { get; set; }
        public virtual KindMaterial KindMaterialObj { get; set; }


        // Список цен реализации
        public virtual ICollection<Price> Prices { get; set; }

        // Список поставок
        public virtual ICollection<Supply> Supplies { get; set; }

        // Список расходов (отгрузок)
        public virtual ICollection<Experse> Experses { get; set; }



        // Кол-во
        public int Count { get; set; }

        // Цена закупочная
        public decimal PriceSupply { get; set; }

    }
}
