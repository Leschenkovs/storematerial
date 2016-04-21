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
				new Unit {Name = "штука", ShortName = "шт"},
				new Unit {Name = "тонна", ShortName = "т"},
				new Unit {Name = "килоамм", ShortName = "кг"},
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
				new Provider {Name = "СтроМинск", Address = "Минск", Telephone = "0336245675", Description = "Описание"},
				new Provider {Name = "ГводиМагазин", Address = "Гродно", Telephone = "0294586974", Description = ""},
				new Provider {Name = "ОбоЛаки", Address = "Бобруйск", Telephone = "0274512365", Description = "Описание 2"},
                new Provider {Name = "1Мага", Address = "Лев", Telephone = "0000", Description = "Описание"},
				new Provider {Name = "2Маг", Address = "Птер", Telephone = "7785758", Description = ""},
				new Provider {Name = "3мага", Address = "Бобруйск", Telephone = "222", Description = " 2"}

			});
            context.SaveChanges();

            context.Costumers.AddRange(new List<Costumer>
			{
				new Costumer {Name = "ЗаводМетала", Address = "Минск", Telephone = "1265478569", Description = "Описание"},
				new Costumer {Name = "ЗаводМосква", Address = "Минск", Telephone = "1265478569", Description = "Описание"},
				new Costumer {Name = "ЗаводХлодильников", Address = "Минск", Telephone = "1265478569", Description = "Описание"}
			});
            context.SaveChanges();

			context.KindMaterials.AddRange(new List<KindMaterial>
			{
				new KindMaterial {Articul = "102938499999", Name = "Доски"},
				new KindMaterial {Articul = "102953245347", Name = "Краска"},
				new KindMaterial {Articul = "324293849944", Name = "Гвозди"},
			});
			context.SaveChanges();

            context.UnitMaterials.AddRange(new List<UnitMaterial>
			{
				new UnitMaterial {Id=1,KindMaterialId = context.KindMaterials.First(x => x.Name == "Доски").Id, UnitId = context.Units.First(x => x.ShortName == "шт").Id},
				new UnitMaterial {Id=2,KindMaterialId = context.KindMaterials.First(x => x.Name == "Доски").Id, UnitId = context.Units.First(x => x.ShortName == "л").Id},
				new UnitMaterial {Id=3,KindMaterialId = context.KindMaterials.First(x => x.Name == "Краска").Id, UnitId = context.Units.First(x => x.ShortName == "рулон").Id},
                new UnitMaterial {Id=4,KindMaterialId = context.KindMaterials.First(x => x.Name == "Краска").Id, UnitId = context.Units.First(x => x.ShortName == "шт").Id},
				new UnitMaterial {Id=5,KindMaterialId = context.KindMaterials.First(x => x.Name == "Краска").Id, UnitId = context.Units.First(x => x.ShortName == "л").Id},
				new UnitMaterial {Id=6,KindMaterialId = context.KindMaterials.First(x => x.Name == "Гвозди").Id, UnitId = context.Units.First(x => x.ShortName == "рулон").Id}

			});
            context.SaveChanges();

			//********************
			// Test data
			context.Users.AddRange(new List<User>
			{
				new User {Login = "111111", Password = "1", Fio = "Кууруза А.В.", RoleId = context.Roles.First(x => x.Code == "admin").Id, Position = "Оператор", Department = "Склад"},
                new User {Login = "122222", Password = "1", Fio = "Новикова А.В.", RoleId = context.Roles.First(x => x.Code == "read").Id, Position = "Кладовщик", Department = "Склад 203"},
				new User {Login = "155555", Password = "1", Fio = "Лещенко А.В.", RoleId = context.Roles.First(x => x.Code == "read_write").Id, Position = "Кладовщик", Department = "Склад 3"},
                new User {Login = "188888", Password = "1", Fio = "Петров А.В.", RoleId = context.Roles.First(x => x.Code == "read").Id, Position = "Грузчик", Department = "Склад 203"},
				new User {Login = "200000", Password = "1", Fio = "Вадим А.В.", RoleId = context.Roles.First(x => x.Code == "read_write").Id, Position = "Бухгалетр", Department = "Склад 3"}

			});
			context.SaveChanges();
		}
	}
}
