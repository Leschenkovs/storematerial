using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class MaterialInStoreMap:EntityTypeConfiguration<MaterialInStore>
    {
        public MaterialInStoreMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Count).IsRequired();
            Property(t => t.PriceSupply).IsRequired();
            Property(t => t.UnitMaterialId).IsRequired();

            // Table & Column Mappings
            ToTable("MaterialInStore");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Count).HasColumnName("Count");
            Property(t => t.PriceSupply).HasColumnName("PriceSupply");
            Property(t => t.UnitMaterialId).HasColumnName("UnitMaterialId");

            // Relationships  
            HasRequired(t => t.UnitMaterialObj).WithOptional(t=>t.MaterialInStoreObj);

        }
    }
}
