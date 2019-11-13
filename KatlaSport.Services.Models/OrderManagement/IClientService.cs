using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IClientService
    {
        /// <summary>
        /// Gets a Client list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Client}}"/>.</returns>
        Task<List<Client>> GetClientsAsync();

        /// <summary>
        /// Gets a Order with specified identifier.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <returns>A <see cref="Task{Client}"/>.</returns>
        Task<Client> GetClientAsync(int hiveId);

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateClientRequest"/>.</param>
        /// <returns>A <see cref="Task{Delivery}"/>.</returns>
        Task<Client> CreateClientAsync(UpdateClientRequest createRequest);

        /// <summary>
        /// Updates an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateClientRequest"/>.</param>
        /// <returns>A <see cref="Task{Client}"/>.</returns>
        Task<Client> UpdateClientAsync(int hiveId, UpdateClientRequest updateRequest);

        /// <summary>
        /// Deletes an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// /// <returns>A <see cref="Task"/></returns>
        Task DeleteClientAsync(int hiveId);
    }
}
