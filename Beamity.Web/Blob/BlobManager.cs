using Beamity.Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Sandboxable.Microsoft.WindowsAzure.Storage;
using Sandboxable.Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace Beamity.Web.Blob
{
    public class BlobManager : IBlobManager
    {
        #region PrivateMember
        private string _accountName;
        private string _containerName;
        private string _accountKey;
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;
        private CloudBlockBlob _blockBlob;
        private Stream _stream;
        #endregion

        #region Constructor
        private readonly IConfiguration _configuration;
        public BlobManager(IConfiguration configuration)
        {
            _configuration = configuration;

            _accountName = _configuration["BlobSettings:accountName"];
            _containerName = _configuration["BlobSettings:containerName"];
            _accountKey = _configuration["BlobSettings:accountKey"];

            _storageAccount = new CloudStorageAccount(
                new Sandboxable.Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                    _accountName,
                    _accountKey), true);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference(_containerName);

        }

        #endregion

        public async Task<string> UploadImageAsBlob(IFormFile file)
        {
            if  (file != null && (file.ContentType.StartsWith("image") || file.ContentType.StartsWith("audio") || file.ContentType.StartsWith("video")))
            {
                _stream = file.OpenReadStream();
                string extension = Path.GetExtension(file.FileName);
                _blockBlob = _container.GetBlockBlobReference(FileNameHelper.CreateFileName(extension));
                await _blockBlob.UploadFromStreamAsync(_stream);
                return "/" + _blockBlob.Name;
            }
            return null;
        }

    }

}
