using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class ClienConfiguration : EntityTypeConfiguration<Employee>
    {
        public ClienConfiguration()
        {
            ToTable("employee");
            HasKey(i => i.EmployeeId);
            HasRequired(i => i.Client).WithMany(i => i.Employees).HasForeignKey(i => i.ClientId);
            Property(i => i.EmployeeId).HasColumnName("employee_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.FirstName).HasColumnName("employee_firstName");
            Property(i => i.LastName).HasColumnName("employee_lastName");
            Property(i => i.Position).HasColumnName("employee_position");
            Property(i => i.Department).HasColumnName("employee_departament");
            Property(i => i.ClientId).HasColumnName("employee_client_id");
        }
    }
}
