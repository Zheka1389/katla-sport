using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets a Client list.
        /// </summary>
        /// <returns>A <see cref="Task{List{Employee}}"/>.</returns>
        Task<List<Employee>> GetEmployeesAsync();

        /// <summary>
        /// Gets a Order with specified identifier.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> GetEmployeeAsync(int hiveId);

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateEmployeeRequest"/>.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest);

        /// <summary>
        /// Updates an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateEmployeeRequest"/>.</param>
        /// <returns>A <see cref="Task{Employee}"/>.</returns>
        Task<Employee> UpdateEmployeeAsync(int hiveId, UpdateEmployeeRequest updateRequest);

        /// <summary>
        /// Deletes an existed Order.
        /// </summary>
        /// <param name="hiveId">A Order identifier.</param>
        /// /// <returns>A <see cref="Task"/></returns>
        Task DeleteEmployeeAsync(int hiveId);
    }
}
