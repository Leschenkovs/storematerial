
using System.Collections.Generic;
using System.Data.Entity;
using Store.Model;

namespace Store.Dal
{
	//DropCreateDatabaseAlways<DataContext>
	//DropCreateDatabaseIfModelChanges<DataContext>

	public class DataContextDbInitializer : DropCreateDatabaseAlways<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			context.Roles.AddRange(new List<Role>
			{
				new Role {Code = "admin", Name = "администратор"},
				new Role {Code = "read", Name = "просмотр"},
				new Role {Code = "read_write", Name = "просмотр_запись"}
			});
			context.SaveChanges();

			context.Units.AddRange(new List<Unit>
			{
				new Unit {Name = "штуки", ShortName = "шт"},
				new Unit {Name = "т", ShortName = "тонна"},
				new Unit {Name = "кг", ShortName = "киллограм"},
				new Unit {Name = "г", ShortName = "грамм"},
				new Unit {Name = "л", ShortName = "литр"},
				new Unit {Name = "мл", ShortName = "миллилитр"},
				new Unit {Name = "рулон", ShortName = "рулон"},
				new Unit {Name = "м.кв", ShortName = "метр квадратный"},
				new Unit {Name = "м.куб", ShortName = "метр кубический"}
			});
			context.SaveChanges();
		}
	}
}
