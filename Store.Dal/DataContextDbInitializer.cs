using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
				new Role {Code = "read_write", Name = "просмотр_запись"},
                new Role {Code = "account", Name = "бухгалтерия"}
			});
			context.SaveChanges();

			context.Units.AddRange(new List<Unit>
			{
				new Unit {Name = "штука", ShortName = "шт"},
				new Unit {Name = "тонна", ShortName = "т"},
				new Unit {Name = "килограмм", ShortName = "кг"},
                new Unit {Name = "палета", ShortName = "палета"},
                new Unit {Name = "упаковка", ShortName = "упк"},
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
				new Provider {Name = "Металлургия", Address = "Минск", Telephone = "0336245675", Description = "Описание"},
				new Provider {Name = "Склад 500", Address = "Гродно", Telephone = "0294586974", Description = ""},
				new Provider {Name = "Склад 880", Address = "Бобруйск", Telephone = "0274512365", Description = "Описание 2"},
                new Provider {Name = "Склад 503", Address = "Лев", Telephone = "0000", Description = "Описание"},
				new Provider {Name = "Филиал 5", Address = "Птер", Telephone = "7785758", Description = ""},
				new Provider {Name = "Филиал 6", Address = "Бобруйск", Telephone = "222", Description = " 2"}

			});
            context.SaveChanges();

            context.Costumers.AddRange(new List<Costumer>
			{
				new Costumer {Name = "Материк", Address = "Минск", Telephone = "1265478569", Description = "Описание"},
				new Costumer {Name = "СтройМастер", Address = "Минск", Telephone = "1265478569", Description = "Описание"},
				new Costumer {Name = "Стройтрест", Address = "Минск", Telephone = "1265478569", Description = "Описание"}
			});
            context.SaveChanges();

			context.KindMaterials.AddRange(new List<KindMaterial>
			{
				new KindMaterial {Articul = "102938499999", Name = "Доски"},
				new KindMaterial {Articul = "102953245347", Name = "Краска"},
				new KindMaterial {Articul = "324293849944", Name = "Гвозди"},
                new KindMaterial {Articul = "235235343455", Name = "Винт"}
			});
			context.SaveChanges();

            context.UnitMaterials.AddRange(new List<UnitMaterial>
            {
                new UnitMaterial {Id=1,KindMaterialId = context.KindMaterials.First(x => x.Name == "Доски").Id, UnitId = context.Units.First(x => x.ShortName == "шт").Id},
                new UnitMaterial {Id=2,KindMaterialId = context.KindMaterials.First(x => x.Name == "Доски").Id, UnitId = context.Units.First(x => x.ShortName == "упк").Id},
                new UnitMaterial {Id=3,KindMaterialId = context.KindMaterials.First(x => x.Name == "Винт").Id, UnitId = context.Units.First(x => x.ShortName == "упк").Id},
                new UnitMaterial {Id=4,KindMaterialId = context.KindMaterials.First(x => x.Name == "Краска").Id, UnitId = context.Units.First(x => x.ShortName == "мл").Id},
                new UnitMaterial {Id=5,KindMaterialId = context.KindMaterials.First(x => x.Name == "Краска").Id, UnitId = context.Units.First(x => x.ShortName == "л").Id},
                new UnitMaterial {Id=6,KindMaterialId = context.KindMaterials.First(x => x.Name == "Гвозди").Id, UnitId = context.Units.First(x => x.ShortName == "упк").Id}

            });
            context.SaveChanges();

            context.MaterialInStores.AddRange(new List<MaterialInStore>
            {
                new MaterialInStore {UnitMaterialId= 1,Count = 0},
                new MaterialInStore {UnitMaterialId= 2,Count = 0},
                new MaterialInStore {UnitMaterialId= 3,Count = 0},
                new MaterialInStore {UnitMaterialId= 4,Count = 0},
                new MaterialInStore {UnitMaterialId= 5,Count = 0},
                new MaterialInStore {UnitMaterialId= 6,Count = 0}

            });
            context.SaveChanges();

			//********************
			// Test data
			context.Users.AddRange(new List<User>
			{
				new User {Login = "admin", Password = "admin", Fio = "Администратор", RoleId = context.Roles.First(x => x.Code == "admin").Id, Position = "программист", Department = "ОИТ"},
                new User {Login = "111111", Password = "1", Fio = "Новикова А.В.", RoleId = context.Roles.First(x => x.Code == "account").Id, Position = "Бухгалтер", Department = "Склад 203"},
				new User {Login = "222222", Password = "1", Fio = "Лещенко А.В.", RoleId = context.Roles.First(x => x.Code == "read_write").Id, Position = "Кладовщик", Department = "Склад 3"},
                new User {Login = "333333", Password = "1", Fio = "Петров А.В.", RoleId = context.Roles.First(x => x.Code == "read").Id, Position = "Грузчик", Department = "Склад 203"}
			});
			context.SaveChanges();
		}
	}
}
