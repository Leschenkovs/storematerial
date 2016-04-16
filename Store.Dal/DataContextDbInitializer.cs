
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
		}
	}
}
