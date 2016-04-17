using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).HasMaxLength(20);
            Property(t => t.ShortName).HasMaxLength(10).IsRequired();

            // Table & Column Mappings
            ToTable("Unit");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.ShortName).HasColumnName("ShortName");

        }
    }
}
