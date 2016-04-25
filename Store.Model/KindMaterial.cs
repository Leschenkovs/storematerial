using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
	// Модель описывает виды материалов
	public class KindMaterial : BaseModel<int>
	{
		public KindMaterial()
		{
			UnitMaterials = new Collection<UnitMaterial>();
		}

		// Артикул
		public string Articul { get; set; }
		// Название
		public string Name { get; set; }

		// Список ед. измерения
		public virtual ICollection<UnitMaterial> UnitMaterials { get; set; }
	}
}
