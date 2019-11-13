using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            ToTable("client");
            HasKey(i => i.ClientId);
            HasRequired(i => i.Order).WithMany(i => i.Clients).HasForeignKey(i => i.OrderId);
            Property(i => i.ClientId).HasColumnName("client_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.FirstName).HasColumnName("client_firstName");
            Property(i => i.LastName).HasColumnName("client_lastName");
            Property(i => i.Address).HasColumnName("client_address");
            Property(i => i.TelephoneNumber).HasColumnName("client_telephoneNumber");
            Property(i => i.OrderId).HasColumnName("client_order_id");
        }
    }
}
