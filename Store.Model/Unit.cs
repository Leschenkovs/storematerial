using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
    // Модель описывает единицы измерения
    public class Unit: BaseModel<int>
    {
        public Unit()
        {
            UnitMaterials = new Collection<UnitMaterial>();
        }

        // Название
        public string Name { get; set; }

        // Краткое название
        public string ShortName { get; set; }

        // Список ед изм для материалов
        public virtual ICollection<UnitMaterial> UnitMaterials { get; set; }

    }
}
