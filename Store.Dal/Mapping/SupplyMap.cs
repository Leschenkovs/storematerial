using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class SupplyMap: EntityTypeConfiguration<Supply>
    {
        public SupplyMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Count).IsRequired();
            Property(t => t.Ttn).HasMaxLength(12).IsRequired();
            Property(t => t.MaterialInStoreId).IsRequired();
            Property(t => t.ProviderId).IsRequired();
            Property(t => t.UserId);

            // Table & Column Mappings
            ToTable("Supply");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Count).HasColumnName("Count");
            Property(t => t.Ttn).HasColumnName("Ttn");
            Property(t => t.MaterialInStoreId).HasColumnName("MaterialInStoreId");
            Property(t => t.ProviderId).HasColumnName("ProviderId");
            Property(t => t.UserId).HasColumnName("UserId");

            // Relationships  
            HasRequired(t => t.MaterialInStoreObj).WithMany(t => t.Supplies).HasForeignKey(d => d.MaterialInStoreId).WillCascadeOnDelete(true);
            HasRequired(t => t.ProviderObj).WithMany(t => t.Supplies).HasForeignKey(d => d.ProviderId).WillCascadeOnDelete(false);
            //HasRequired(t => t.UserObj).WithMany(t => t.Supplies).HasForeignKey(d => d.UserId).WillCascadeOnDelete(false);
        }
    }
}
