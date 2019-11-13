namespace KatlaSport.Services.OrderManagement
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using KatlaSport.DataAccess.OrderCatalogue;
    using KatlaSport.Services.OrderManagement.Repository;

    /// <summary>
    /// Represents a hive service.
    /// </summary>
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderContext context)
        {
            _orderRepository = new OrderRepository(context);
        }

        /// <inheritdoc/>
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetAll();
        }

        /// <inheritdoc/>
        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _orderRepository.GetOne(orderId);
        }

        /// <inheritdoc/>
        public async Task<Delivery> GetOrderDeliveryAsync(int orderId)
        {
            return await _orderRepository.GetDelivery(orderId);
        }

        /// <inheritdoc/>
        public async Task<Order> CreateOrderAsync(UpdateOrderRequest createRequest)
        {
            return await _orderRepository.Add(createRequest);
        }

        /// <inheritdoc/>
        public async Task<Order> UpdateOrderAsync(UpdateOrderRequest updateRequest)
        {
            return await _orderRepository.Update(updateRequest);
        }

        /// <inheritdoc/>
        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.Remove(orderId);
        }

        /// <inheritdoc/>
        public async Task SetStatusAsync(int orderId, bool deletedStatus)
        {
            await _orderRepository.SetStatus(orderId, deletedStatus);
        }
    }
}
