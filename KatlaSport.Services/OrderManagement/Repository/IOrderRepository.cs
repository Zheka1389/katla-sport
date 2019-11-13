using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement.Repository
{
    public interface IOrderRepository : IRepository<Order, UpdateOrderRequest>
    {
        Task SetStatus(int id, bool status);

        Task<Delivery> GetDelivery(int id);
    }
}
