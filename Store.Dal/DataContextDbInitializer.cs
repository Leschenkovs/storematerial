﻿using System.Collections.Generic;
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

			//********************
			// Test data
			context.Users.AddRange(new List<User>
			{
				new User {Tn = "11", Fio = "Кукуруза А.В.", RoleId = context.Roles.First(x => x.Code == "admin").Id, Position = "Оператор", Department = "Склад"}
			});
			context.SaveChanges();
		}
	}
}
