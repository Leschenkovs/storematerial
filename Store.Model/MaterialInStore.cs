

namespace Store.Model
{
    // Модель описывает материалы на складе
    public class MaterialInStore: BaseModel<int>
    {
        public MaterialInStore()
        {
            //Prices = new Collection<Price>();
        }

        // Идентификатор вида материала
        //public virtual int KindMaterialId { get; set; }
        //public virtual KindMaterial KindMaterialObj { get; set; }

        // Идентификатор работника(для цены реализации)
        //public virtual int UserId { get; set; }
        //public virtual User UserObj { get; set; }

        // Список цен реализации
        //public virtual ICollection<Price> Prices { get; set; }


        // Кол-во
        public int Count { get; set; }

        // Цена закупочная
        public decimal PriceSupply { get; set; }

    }
}
