namespace KatlaSport.DataAccess.OrderCatalogue
{
    public interface IOrderContext : IAsyncEntityStorage
    {
        /// <summary>
        /// Gets a set of <see cref="Order"/> entities.
        /// </summary>
        IEntitySet<Order> Orders { get; }

        /// <summary>
        /// Gets a set of <see cref="Delivery"/> entities.
        /// </summary>
        IEntitySet<Delivery> Deliveries { get; }

        /// <summary>
        /// Gets a set of <see cref="Employee"/> entities.
        /// </summary>
        IEntitySet<Employee> Employees { get; }

        /// <summary>
        /// Gets a set of <see cref="Client"/> entities.
        /// </summary>
        IEntitySet<Client> Clients { get; }
    }
}
