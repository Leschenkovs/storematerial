using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
	public class UserMap : EntityTypeConfiguration<User>
	{
		public UserMap()
		{
			// Primary Key
			HasKey(t => t.Id);

			// Properties
			Property(t => t.Tn).HasMaxLength(6).IsRequired();
			Property(t => t.Fio).HasMaxLength(30).IsRequired();
			Property(t => t.Department).HasMaxLength(25);
			Property(t => t.Position).HasMaxLength(25).IsRequired();
			Property(t => t.RoleId);

			// Table & Column Mappings
			ToTable("User");
			Property(t => t.Id).HasColumnName("Id");
			Property(t => t.Tn).HasColumnName("Tn");
			Property(t => t.Fio).HasColumnName("Fio");
			Property(t => t.Department).HasColumnName("Department");
			Property(t => t.Position).HasColumnName("Position");
			Property(t => t.RoleId).HasColumnName("RoleId");

			// Relationships  
			HasRequired(t => t.RoleObj).WithMany(t => t.Users).HasForeignKey(d => d.RoleId).WillCascadeOnDelete(false);
		}
	}
}
