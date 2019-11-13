using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IOrderService
    {
        /// <summary>
        /// Gets a Orders list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Order}}"/>.</returns>
        Task<List<Order>> GetOrdersAsync();

        /// <summary>
        /// Gets a Order with specified identifier.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <returns>A <see cref="Task{Order}"/>.</returns>
        Task<Order> GetOrderAsync(int hiveId);

        /// <summary>
        /// Gets a Order with specified identifier.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <returns>A <see cref="Task{Delivery}"/>.</returns>
        Task<Delivery> GetOrderDeliveryAsync(int hiveId);

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateOrderRequest"/>.</param>
        /// <returns>A <see cref="Task{Order}"/>.</returns>
        Task<Order> CreateOrderAsync(UpdateOrderRequest createRequest);

        /// <summary>
        /// Updates an existed Order.
        /// </summary>
        /// <param name="updateRequest">A <see cref="UpdateOrderRequest"/>.</param>
        /// <returns>A <see cref="Task{Order}"/>.</returns>
        Task<Order> UpdateOrderAsync(UpdateOrderRequest updateRequest);

        /// <summary>
        /// Deletes an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// /// <returns>A <see cref="Task"/></returns>
        Task DeleteOrderAsync(int hiveId);

        /// <summary>
        /// Sets deleted status for a order.
        /// </summary>
        /// <param name="orderId">A hive identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// /// <returns>A <see cref="Task"/> </returns>
        Task SetStatusAsync(int orderId, bool deletedStatus);
    }
}
