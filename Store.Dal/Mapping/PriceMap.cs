using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class PriceMap: EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.MaterialInStoreId).IsRequired();
            Property(t => t.PriceValue).IsRequired();
            Property(t => t.DateOt).IsRequired();
            Property(t => t.DateDo).IsRequired();

            // Table & Column Mappings
            ToTable("Price");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.MaterialInStoreId).HasColumnName("MaterialInStoreId");
            Property(t => t.PriceValue).HasColumnName("PriceValue");
            Property(t => t.DateOt).HasColumnName("DateOt");
            Property(t => t.DateDo).HasColumnName("DateDo");

            // Relationships  
            HasRequired(t => t.MaterialInStoreObj).WithMany(t => t.Prices).HasForeignKey(d => d.MaterialInStoreId).WillCascadeOnDelete(true);

        }
    }
}
