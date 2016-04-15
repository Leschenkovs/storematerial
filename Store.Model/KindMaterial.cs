

namespace Store.Model
{
    // Модель описывает виды материалов
    public class KindMaterial
    {
        public KindMaterial()
        {
            //Units = new Collection<Unit>();
            //MaterialInStores = new Collection<MaterialInStore>();
        }

        // Артикул (ID)
        public string Articul { get; set; }
        // Название
        public string Name { get; set; }

        // Список ед. измерения
        //public virtual ICollection<Unit> Units { get; set; }

        // Список материалов на складе
        //public virtual ICollection<MaterialInStore> MaterialInStores { get; set; }

    }
}
