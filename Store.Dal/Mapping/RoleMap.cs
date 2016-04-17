using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
	public class RoleMap : EntityTypeConfiguration<Role>
	{
		public RoleMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Name).HasMaxLength(15).IsRequired();
			Property(t => t.Code).HasMaxLength(20).IsRequired();

			// Table & Column Mappings
			ToTable("Role");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Name).HasColumnName("Name");
			Property(t => t.Code).HasColumnName("Code");
		}
	}
}
