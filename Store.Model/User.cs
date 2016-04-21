using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Model
{
	// Модель описывает работника
	public class User : BaseModel<int>
	{
		public User()
		{
			Experses = new Collection<Experse>();
		}

		// UserName
		public string Login { get;set; }

        // Пароль
        public string Password { get; set; }

		// ФИО
		public string Fio { get; set; }

		// Отдел
		public string Department { get; set; }

		// Должность
		public string Position { get; set; }

		// Список оформленных отгрузок (расходов)
		public virtual ICollection<Experse> Experses { get; set; }

		// Идентификатор роли
		public virtual int RoleId { get; set; }
		public virtual Role RoleObj { get; set; }
	}
}
