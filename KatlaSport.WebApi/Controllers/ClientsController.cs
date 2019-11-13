using KatlaSport.Services.OrderManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;


namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/clients")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }


        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of orders.", Type = typeof(Client[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{clientId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a order.", Type = typeof(Client))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetClient(int clientId)
        {
            var client = await _clientService.GetClientAsync(clientId);
            return Ok(client);
        }

        [HttpPost]
        [Route("add")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddClient([FromBody] UpdateClientRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _clientService.CreateClientAsync(createRequest);
            var location = string.Format("/api/clients/{0}", client.OrderId);
            return Created<Client>(location, client);
        }

        [HttpPost]
        [Route("update/{update:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateClient([FromUri] int update, [FromBody] UpdateClientRequest updateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientService.UpdateClientAsync(update, updateRequest);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("{delete:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed order.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteClient([FromUri] int delete)
        {
            await _clientService.DeleteClientAsync(delete);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}