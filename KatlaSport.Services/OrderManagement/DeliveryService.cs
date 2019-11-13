using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OrderCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbDelivery = KatlaSport.DataAccess.OrderCatalogue.Delivery;

namespace KatlaSport.Services.OrderManagement
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IOrderContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryService"/> class with specified <see cref="IDeliveryContext"/> and <see cref="IDeliveryContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IDeliveryContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public DeliveryService(IOrderContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<Delivery>> GetDeliveriesAsync()
        {
            var dbDeliveries = await _context.Deliveries.OrderBy(o => o.DeliveryId).ToArrayAsync();
            var orders = dbDeliveries.Select(o => Mapper.Map<Delivery>(o)).ToList();
            return orders;
        }

        /// <inheritdoc/>
        public async Task<Delivery> GetDeliveryAsync(int deliveryId)
        {
            var dbDeliveries = await _context.Deliveries.Where(o => o.OrderId == deliveryId).ToArrayAsync();
            if (dbDeliveries.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbDelivery, Delivery>(dbDeliveries[0]);
        }

        /// <inheritdoc/>
        public async Task<Delivery> CreateDeliveryAsync(UpdateDeliveryRequest createRequest)
        {
            var dbDeliveries = await _context.Deliveries.Where(h => h.Address == createRequest.Address).ToArrayAsync();
            if (dbDeliveries.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbDelivery = Mapper.Map<UpdateDeliveryRequest, DbDelivery>(createRequest);

            _context.Deliveries.Add(dbDelivery);

            await _context.SaveChangesAsync();

            return Mapper.Map<Delivery>(dbDelivery);
        }

        /// <inheritdoc/>
        public async Task<Delivery> UpdateDeliveryAsync(int deliveryId, UpdateDeliveryRequest updateRequest)
        {
            var dbDeliveries = await _context.Deliveries.Where(o => o.Address == updateRequest.Address).ToArrayAsync();
            if (dbDeliveries.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbDeliveries = await _context.Deliveries.Where(o => o.DeliveryId == deliveryId).ToArrayAsync();
            var dbDelivery = dbDeliveries.FirstOrDefault();
            if (dbDeliveries == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbDelivery);
            //dbOrder.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            return Mapper.Map<Delivery>(dbDelivery);
        }

        /// <inheritdoc/>
        public async Task DeleteDeliveryAsync(int deliveryId)
        {
            var dbDeliveries = await _context.Deliveries.Where(o => o.DeliveryId == deliveryId).ToArrayAsync();
            if (dbDeliveries.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbDelivery = dbDeliveries[0];

            _context.Deliveries.Remove(dbDelivery);
            await _context.SaveChangesAsync();
        }
    }
}
