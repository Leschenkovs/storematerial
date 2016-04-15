

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает виды материалов
    public class KindMaterial
    {
        public KindMaterial()
        {
            UnitMaterials = new Collection<UnitMaterial>();
            MaterialInStores = new Collection<MaterialInStore>();
        }

        // Артикул (ID)
        public string Articul { get; set; }
        // Название
        public string Name { get; set; }

        // Список ед. измерения
        public virtual ICollection<UnitMaterial> UnitMaterials { get; set; }

        // Список материалов на складе
        public virtual ICollection<MaterialInStore> MaterialInStores { get; set; }

    }
}
