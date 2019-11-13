namespace KatlaSport.DataAccess.OrderCatalogue
{
    internal sealed class OrderContext : DomainContextBase<ApplicationDbContext>, IOrderContext
    {
        public OrderContext(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEntitySet<Order> Orders => GetDbSet<Order>();

        public IEntitySet<Delivery> Deliveries => GetDbSet<Delivery>();

        public IEntitySet<Client> Clients => GetDbSet<Client>();

        public IEntitySet<Employee> Employees => GetDbSet<Employee>();
    }
}
