using AutoMapper;
using KatlaSport.DataAccess;
using KatlaSport.DataAccess.OrderCatalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbClient = KatlaSport.DataAccess.OrderCatalogue.Client;

namespace KatlaSport.Services.OrderManagement
{
    public class ClientService : IClientService
    {
        private readonly IOrderContext _context;
        private readonly IUserContext _userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class with specified <see cref="IClientContext"/> and <see cref="IClientContext"/>.
        /// </summary>
        /// <param name="context">A <see cref="IClientContext"/>.</param>
        /// <param name="userContext">A <see cref="IUserContext"/>.</param>
        public ClientService(IOrderContext context, IUserContext userContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userContext = userContext ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public async Task<List<Client>> GetClientsAsync()
        {
            var dbClients = await _context.Clients.OrderBy(o => o.ClientId).ToArrayAsync();
            var clients = dbClients.Select(o => Mapper.Map<Client>(o)).ToList();
            return clients;
        }

        /// <inheritdoc/>
        public async Task<Client> GetClientAsync(int clientId)
        {
            var dbClients = await _context.Clients.Where(o => o.ClientId == clientId).ToArrayAsync();
            if (dbClients.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<DbClient, Client>(dbClients[0]);
        }

        /// <inheritdoc/>
        public async Task<Client> CreateClientAsync(UpdateClientRequest createRequest)
        {
            var dbClients = await _context.Clients.Where(h => h.FirstName == createRequest.FirstName).ToArrayAsync();
            if (dbClients.Length > 0)
            {
                throw new RequestedResourceHasConflictException("Client");
            }

            var dbClient = Mapper.Map<UpdateClientRequest, DbClient>(createRequest);

            _context.Clients.Add(dbClient);

            await _context.SaveChangesAsync();

            return Mapper.Map<Client>(dbClient);
        }

        /// <inheritdoc/>
        public async Task<Client> UpdateClientAsync(int clentId, UpdateClientRequest updateRequest)
        {
            var dbClients = await _context.Clients.Where(o => o.Address == updateRequest.Address && o.ClientId != clentId).ToArrayAsync();
            if (dbClients.Length > 0)
            {
                throw new RequestedResourceHasConflictException("code");
            }

            dbClients = await _context.Clients.Where(o => o.ClientId == clentId).ToArrayAsync();
            var dbClient = dbClients.FirstOrDefault();
            if (dbClients == null)
            {
                throw new RequestedResourceNotFoundException();
            }

            Mapper.Map(updateRequest, dbClient);
            //dbOrder.LastUpdatedBy = _userContext.UserId;

            await _context.SaveChangesAsync();

            return Mapper.Map<Client>(dbClient);
        }

        /// <inheritdoc/>
        public async Task DeleteClientAsync(int clentId)
        {
            var dbClients = await _context.Clients.Where(o => o.ClientId == clentId).ToArrayAsync();
            if (dbClients.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbClient = dbClients[0];

            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();
        }
    }
}
