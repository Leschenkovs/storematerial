using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class UnitMaterialMap : EntityTypeConfiguration<UnitMaterial>
    {
        public UnitMaterialMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.KindMaterialId).IsRequired();
            Property(t => t.UnitId).IsRequired();

            // Table & Column Mappings
            ToTable("UnitMaterial");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.KindMaterialId).HasColumnName("KindMaterialId").IsRequired();
            Property(t => t.UnitId).HasColumnName("UnitId").IsRequired();

            // Relationships
            HasRequired(t => t.KindMaterialObj).WithMany(t => t.UnitMaterials).HasForeignKey(d => d.KindMaterialId).WillCascadeOnDelete(false);
            HasRequired(t => t.UnitObj).WithMany(t => t.UnitMaterials).HasForeignKey(d => d.UnitId).WillCascadeOnDelete(false);
        }
    }
}
