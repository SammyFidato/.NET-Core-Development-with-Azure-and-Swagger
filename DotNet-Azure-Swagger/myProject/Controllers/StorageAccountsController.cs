using myProject.Services.StorageAccount_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Controllers
{
    public class StorageAccountsController : Controller
    {

        [HttpDelete]
        [Route("DeleteAllBlobs(Clear_A_Container)")]
        public void ALLBlobs([Required()] string Connection_String, [Required()] string Container)
        {

            CloudStorageAccount account = CloudStorageAccount.Parse(Connection_String);

            CloudBlobClient client = account.CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference(Container);

            foreach (IListBlobItem blob in container.GetDirectoryReference("").ListBlobs(true))
            {
                if (blob.GetType() == typeof(CloudBlob) || blob.GetType().BaseType == typeof(CloudBlob))
                {
                    ((CloudBlob)blob).DeleteIfExists();
                }
            }

        }

        [HttpDelete]
        [Route("DeleteAllBlobsWithInAFolder")]
        public void FolderBlobs([Required()] string StorageAccount_Connection_String, [Required()] string Container, [Required()] string Foldername)
        {

            CloudStorageAccount account = CloudStorageAccount.Parse(StorageAccount_Connection_String);

            CloudBlobClient client = account.CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference(Container);

            foreach (IListBlobItem blob in container.GetDirectoryReference(Foldername).ListBlobs(true))
            {
                if (blob.GetType() == typeof(CloudBlob) || blob.GetType().BaseType == typeof(CloudBlob))
                {
                    ((CloudBlob)blob).DeleteIfExists();
                }
            }

        }

        [HttpDelete]
        [Route("DeleteAllBlobsInRootFolder")]
        public void RootFolderDelete([Required()] string Connection_String, [Required()] string Container)
        {

            CloudStorageAccount account = CloudStorageAccount.Parse(Connection_String);

            CloudBlobClient client = account.CreateCloudBlobClient();

            CloudBlobContainer container = client.GetContainerReference(Container);

            var blobs = container.ListBlobs().OfType<CloudBlockBlob>().ToList();

            foreach (var blob in blobs)
            {
                blob.DeleteIfExistsAsync();
            }

        }

        // PUT api/
        [HttpPost]
        [Route("UploadFiles")]
        public async Task<string> uploadImageAsync([Required()] string Connection_String, [Required()] string Container, [Required()] string fileName, IFormFile UploadImage)
        {

            var file = Request.Form.Files[0];

            FileUpload iu = new FileUpload();
            string resp = iu.uploadImage(Connection_String, Container, fileName, file);

            return resp;

        }

    }
}
