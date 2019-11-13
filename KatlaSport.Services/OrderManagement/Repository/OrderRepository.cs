namespace KatlaSport.Services.OrderManagement.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using KatlaSport.DataAccess;
    using KatlaSport.Services.OrderManagement;
    using DbDelivery = KatlaSport.DataAccess.OrderCatalogue.Delivery;
    using DbOrder = KatlaSport.DataAccess.OrderCatalogue.Order;

    public class OrderRepository : IOrderRepository
    {
        private readonly DataAccess.OrderCatalogue.IOrderContext _context;

        public OrderRepository(DataAccess.OrderCatalogue.IOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> Add(UpdateOrderRequest createRequest)
        {
            var dbOrders = await _context.Orders.Where(h => h.Name == createRequest.Name).ToArrayAsync();
            if (dbOrders.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            var dbOrder = Mapper.Map<UpdateOrderRequest, DbOrder>(createRequest);
            dbOrder.DateAccommodation = DateTime.UtcNow;
            dbOrder.DateDestination = DateTime.UtcNow;
            dbOrder.DateExecution = DateTime.UtcNow;
            _context.Orders.Add(dbOrder);

            await _context.SaveChangesAsync();

            return Mapper.Map<Order>(dbOrder);
        }

        public async Task<List<Order>> GetAll()
        {
            var dbOrders = await _context.Orders.OrderBy(o => o.OrderId).ToArrayAsync();
            var orders = dbOrders.Select(o => Mapper.Map<Order>(o)).ToList();
            return orders;
        }

        public async Task<Delivery> GetDelivery(int orderId)
        {
            var dbOrders = await _context.Deliveries.Where(o => o.OrderId == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbDelivery, Delivery>(dbOrders[0]);
        }

        public async Task<Order> GetOne(int orderId)
        {
            var dbOrders = await _context.Orders.Where(o => o.OrderId == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbOrder, Order>(dbOrders[0]);
        }

        public async Task Remove(int orderId)
        {
            var dbOrders = await _context.Orders.Where(o => o.OrderId == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];
            if (dbOrder.IsDeleted == false)
            {
                throw new RequestedResourceHasConflictException();
            }

            _context.Orders.Remove(dbOrder);
            await _context.SaveChangesAsync();
        }

        public async Task SetStatus(int orderId, bool deletedStatus)
        {
            var dbHives = await _context.Orders.Where(h => orderId == h.OrderId).ToArrayAsync();

            if (dbHives.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbHive = dbHives[0];
            if (dbHive.IsDeleted != deletedStatus)
            {
                dbHive.IsDeleted = deletedStatus;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Order> Update(UpdateOrderRequest updateRequest)
        {
            var dbOrders = await _context.Orders.Where(o => o.Name == updateRequest.Name).ToArrayAsync();
            if (dbOrders.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbOrders = await _context.Orders.Where(o => o.OrderId == updateRequest.OrderId).ToArrayAsync();
            var dbOrder = dbOrders.FirstOrDefault();
            if (dbOrders == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbOrder);

            await _context.SaveChangesAsync();

            return Mapper.Map<Order>(dbOrder);
        }
    }
}
