using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IDeliveryService
    {
        /// <summary>
        /// Gets a Orders list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Delivery}}"/>.</returns>
        Task<List<Delivery>> GetDeliveriesAsync();

        /// <summary>
        /// Gets a Order with specified identifier.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <returns>A <see cref="Task{Delivery}"/>.</returns>
        Task<Delivery> GetDeliveryAsync(int hiveId);

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateDeliveryRequest"/>.</param>
        /// <returns>A <see cref="Task{Delivery}"/>.</returns>
        Task<Delivery> CreateDeliveryAsync(UpdateDeliveryRequest createRequest);

        /// <summary>
        /// Updates an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateDeliveryRequest"/>.</param>
        /// <returns>A <see cref="Task{Delivery}"/>.</returns>
        Task<Delivery> UpdateDeliveryAsync(int hiveId, UpdateDeliveryRequest updateRequest);

        /// <summary>
        /// Deletes an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// /// <returns>A <see cref="Task"/></returns>
        Task DeleteDeliveryAsync(int hiveId);
    }
}
