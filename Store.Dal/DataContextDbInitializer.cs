using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Store.Model;

namespace Store.Dal
{
	//DropCreateDatabaseAlways<DataContext>
	//DropCreateDatabaseIfModelChanges<DataContext>

    public class DataContextDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
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
				new Unit {Name = "шт", ShortName = "штуки"},
				new Unit {Name = "тонна", ShortName = "т"},
				new Unit {Name = "киллограм", ShortName = "кг"},
				new Unit {Name = "грамм", ShortName = "г"},
				new Unit {Name = "литр", ShortName = "л"},
				new Unit {Name = "миллилитр", ShortName = "мл"},
				new Unit {Name = "рулон", ShortName = "рулон"},
				new Unit {Name = "метр квадратный", ShortName = "м.кв"},
				new Unit {Name = "метр кубический", ShortName = "м.куб"}
			});
			context.SaveChanges();

            context.Providers.AddRange(new List<Provider>
			{
				new Provider {Name = "СтройМинск", Address = "Минск", Telephone = "0336245675", Description = "Описание"},
				new Provider {Name = "ГвоздиМагазин", Address = "Гродно", Telephone = "0294586974", Description = ""},
				new Provider {Name = "ОбоиЛаки", Address = "Бобруйск", Telephone = "0274512365", Description = "Описание 2"},
			});
            context.SaveChanges();

			//********************
			// Test data
			context.Users.AddRange(new List<User>
			{
				new User {Tn = "11", Fio = "Кууруза А.В.", RoleId = context.Roles.First(x => x.Code == "admin").Id, Position = "Оператор", Department = "Склад"},
                new User {Tn = "12", Fio = "Новикова А.В.", RoleId = context.Roles.First(x => x.Code == "read").Id, Position = "Кладовщик", Department = "Склад 203"},
				new User {Tn = "15", Fio = "Лещенко А.В.", RoleId = context.Roles.First(x => x.Code == "read_write").Id, Position = "Кладовщик", Department = "Склад 3"}
			});
			context.SaveChanges();
		}
	}
}
