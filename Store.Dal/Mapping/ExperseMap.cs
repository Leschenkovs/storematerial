using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class ExperseMap:EntityTypeConfiguration<Experse>
    {
        public ExperseMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Count).IsRequired();
            Property(t => t.MaterialInStoreId).IsRequired();
            Property(t => t.CostumerId).IsRequired();
            Property(t => t.UserId);

            // Table & Column Mappings
            ToTable("Experse");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Count).HasColumnName("Count");
            Property(t => t.MaterialInStoreId).HasColumnName("MaterialInStoreId");
            Property(t => t.CostumerId).HasColumnName("CostumerId");
            Property(t => t.UserId).HasColumnName("UserId");

            // Relationships  
            HasRequired(t => t.MaterialInStoreObj).WithMany(t => t.Experses).HasForeignKey(d => d.MaterialInStoreId).WillCascadeOnDelete(true);
            HasRequired(t => t.CostumerObj).WithMany(t => t.Experses).HasForeignKey(d => d.CostumerId).WillCascadeOnDelete(false);
            HasRequired(t => t.UserObj).WithMany(t => t.Experses).HasForeignKey(d => d.UserId).WillCascadeOnDelete(false);

        }
    }
}
