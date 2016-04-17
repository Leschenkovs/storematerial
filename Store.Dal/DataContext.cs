using System.Data.Entity;
using Store.Dal.Mapping;
using Store.Model;

namespace Store.Dal
{
	public class DataContext : DbContext
	{
		public DataContext()
			: this("DataContext")
		{ }

		public DataContext(string nameContext)
			: base(nameContext)
		{
			Configuration.AutoDetectChangesEnabled = true;
			Configuration.LazyLoadingEnabled = true;
			Configuration.ProxyCreationEnabled = true;
			Configuration.ValidateOnSaveEnabled = true;

			Database.SetInitializer<DataContext>(new DataContextDbInitializer());
		}

		protected override void Dispose(bool disposing)
		{
			Configuration.LazyLoadingEnabled = false;
			base.Dispose(disposing);
		}

		public DbSet<Costumer> Costumers { get; set; } // таблица потребителей
		public DbSet<Experse> Experses { get; set; } // таблица расходов
		public DbSet<KindMaterial> KindMaterials { get; set; } // таблица видов материалов
		public DbSet<MaterialInStore> MaterialInStores { get; set; } // таблица материалов на складе
		public DbSet<Price> Prices { get; set; } // таблица цен реализации материалов
		public DbSet<Provider> Providers { get; set; } // таблица поставщиков
		public DbSet<Role> Roles { get; set; } // таблица ролей пользователей 
		public DbSet<Supply> Supplies { get; set; } // таблица поставок
		public DbSet<Unit> Units { get; set; } // таблица ед изм
		public DbSet<UnitMaterial> UnitMaterials { get; set; } // таблица ед изм для видов материалов
		public DbSet<User> Users { get; set; } // таблица пользователей

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new CostumerMap());
			modelBuilder.Configurations.Add(new ExperseMap());
			modelBuilder.Configurations.Add(new KindMaterialMap());
			modelBuilder.Configurations.Add(new MaterialInStoreMap());
			modelBuilder.Configurations.Add(new PriceMap());
			modelBuilder.Configurations.Add(new ProviderMap());
			modelBuilder.Configurations.Add(new RoleMap());
			modelBuilder.Configurations.Add(new SupplyMap());
			modelBuilder.Configurations.Add(new UnitMap());
			modelBuilder.Configurations.Add(new UnitMaterialMap());
			modelBuilder.Configurations.Add(new UserMap());
		}
	}
}
