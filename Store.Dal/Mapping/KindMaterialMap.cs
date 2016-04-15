
using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class KindMaterialMap: EntityTypeConfiguration<KindMaterial>
    {
        public KindMaterialMap()
        {
            // Primary Key
            HasKey(t => t.Articul);

            // Properties
            Property(t => t.Name).HasMaxLength(30).IsRequired();

            // Table & Column Mappings
            ToTable("KindMaterial");
            Property(t => t.Articul).HasColumnName("Articul");
            Property(t => t.Name).HasColumnName("Name");

        }
    }
}
