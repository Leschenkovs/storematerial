

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
	// Модель описывает работника
	public class User
	{
		public User()
		{
			Experses = new Collection<Experse>();
			Supplies = new Collection<Supply>();
		}
		// Табельный
		public string Tn { get;set; }

		// ФИО
		public string Fio { get; set; }

		// Отдел
		public string Department { get; set; }

		// Должность
		public string Position { get; set; }

		// Список оформленных поставок
		public virtual ICollection<Supply> Supplies { get; set; }

		// Список оформленных отгрузок (расходов)
		public virtual ICollection<Experse> Experses { get; set; }

		// Идентификатор роли
		public virtual int RoleId { get; set; }
		public virtual Role RoleObj { get; set; }


	}
}
