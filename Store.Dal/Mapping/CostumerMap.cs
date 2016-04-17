using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Dal.Mapping
{
    public class CostumerMap: EntityTypeConfiguration<Costumer>
    {
        public CostumerMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).HasMaxLength(30).IsRequired();
            Property(t => t.Address).HasMaxLength(30);
            Property(t => t.Telephone);
            Property(t => t.Description).HasMaxLength(50);

            // Table & Column Mappings
            ToTable("Costumer");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Address).HasColumnName("Address");
            Property(t => t.Telephone).HasColumnName("Telephone");
            Property(t => t.Description).HasColumnName("Description");
        }
    }
}
