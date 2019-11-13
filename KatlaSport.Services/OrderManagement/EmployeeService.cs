using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OrderCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbEmployee = KatlaSport.DataAccess.OrderCatalogue.Employee;

namespace KatlaSport.Services.OrderManagement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IOrderContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class with specified <see cref="IEmployeeContext"/> and <see cref="IEmployeeContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IEmployeeContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public EmployeeService(IOrderContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var dbEmployees = await _context.Employees.OrderBy(o => o.EmployeeId).ToArrayAsync();
            var employees = dbEmployees.Select(o => Mapper.Map<Employee>(o)).ToList();
            return employees;
        }

        /// <inheritdoc/>
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(o => o.EmployeeId == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbEmployee, Employee>(dbEmployees[0]);
        }

        /// <inheritdoc/>
        public async Task<Employee> CreateEmployeeAsync(UpdateEmployeeRequest createRequest)
        {
            var dbEmployees = await _context.Employees.Where(h => h.ClientId == createRequest.ClientId).ToArrayAsync();
            if (dbEmployees.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbEmployee = Mapper.Map<UpdateEmployeeRequest, DbEmployee>(createRequest);

            _context.Employees.Add(dbEmployee);

            await _context.SaveChangesAsync();

            return Mapper.Map<Employee>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task<Employee> UpdateEmployeeAsync(int employeeId, UpdateEmployeeRequest updateRequest)
        {
            var dbEmployees = await _context.Employees.Where(o => o.FirstName == updateRequest.FirstName && o.EmployeeId != employeeId).ToArrayAsync();
            if (dbEmployees.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbEmployees = await _context.Employees.Where(o => o.EmployeeId == employeeId).ToArrayAsync();
            var dbEmployee = dbEmployees.FirstOrDefault();
            if (dbEmployees == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbEmployee);
            //dbOrder.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            return Mapper.Map<Employee>(dbEmployee);
        }

        /// <inheritdoc/>
        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var dbEmployees = await _context.Employees.Where(o => o.EmployeeId == employeeId).ToArrayAsync();
            if (dbEmployees.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbEmployee = dbEmployees[0];

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }
    }
}
