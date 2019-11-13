using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("order");
            HasKey(i => i.OrderId);
            Property(i => i.OrderId).HasColumnName("order_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("order_Name");
            Property(i => i.DateAccommodation).HasColumnName("order_dateAccommodation");
            Property(i => i.IsDeleted).HasColumnName("deleted").IsRequired();
            Property(i => i.DateDestination).HasColumnName("order_dateDestination");
            Property(i => i.DateExecution).HasColumnName("order_dateExecution");
        }
    }
}
