using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace myProject.Services.StorageAccount_Services
{
    public class FileUpload
    {
        string resp = "";
        public string uploadImage(string Connection_String, string Container, string fileName, IFormFile file)
        {
            try
            {

                CloudStorageAccount account = CloudStorageAccount.Parse(Connection_String);

                CloudBlobClient client = account.CreateCloudBlobClient();

                CloudBlobContainer container = client.GetContainerReference(Container);

                container.CreateIfNotExists();

                CloudBlockBlob blob = container.GetBlockBlobReference(fileName);

                using (var fileStream = file.OpenReadStream())
                {
                    blob.UploadFromStream(fileStream);
                    resp += "File updated in the Storage Account!\n";
                }
            }
            catch (Exception ex)
            {
                resp += "File could not be updated in the Storage Account!\n" + ex;
            }

            return resp;
        }
    }

}
