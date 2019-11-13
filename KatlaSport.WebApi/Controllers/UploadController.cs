using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/test")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class UploadController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("")]
        public async Task<IHttpActionResult> Create()
        {
            var image = WebImage.GetImageFromRequest();
            var imageName = image.FileName;
            var imageBytes = image.GetBytes();
            await UploadFileToStorage(imageBytes, imageName);
            return Ok();
        }

        public async Task<bool> UploadFileToStorage(byte[] fileStream, string fileName)
        {
            // Create storagecredentials object by reading the values from the configuration (appsettings.json)
            StorageCredentials storageCredentials = new StorageCredentials("katlasportstorage", "crmjKYr5uwPOTgqe9vrLliK5ZYRnrh6IOJmHa1phf7lgCgVyCVJatNlqaXFYo3quXIOJlTteLwTDqqiW8M/kXw==");

            // Create cloudstorage account by passing the storagecredentials
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get reference to the blob container by passing the name by reading the value from the configuration (appsettings.json)
            CloudBlobContainer container = blobClient.GetContainerReference("katlasportcontainer");

            // Get the reference to the block blob from the container
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            // Upload the file
            await blockBlob.UploadFromByteArrayAsync(fileStream, 0 , fileStream.Length);

            return await Task.FromResult(true);
        }
    }
}