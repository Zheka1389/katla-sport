using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class DeliveryConfiguration : EntityTypeConfiguration<Delivery>
    {
        public DeliveryConfiguration()
        {
            ToTable("delivery");
            HasKey(i => i.DeliveryId);
            HasRequired(i => i.Order).WithMany(i => i.Deliveries).HasForeignKey(i => i.OrderId);
            Property(i => i.DeliveryId).HasColumnName("delivery_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Address).HasColumnName("delivery_address");
            Property(i => i.OrderId).HasColumnName("delivery_order_id");
            Property(i => i.TelephoneNumber).HasColumnName("delivery_telephoneNumber");
        }
    }
}
