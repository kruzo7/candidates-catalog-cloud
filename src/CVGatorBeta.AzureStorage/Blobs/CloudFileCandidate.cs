using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.AzureStorage.Blobs
{
    internal class CloudFileCandidate : ICloudFileCandidate
    {
        private readonly BlobServiceClient _serviceClient;
        public CloudFileCandidate(BlobServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task UploadToTempAsync(FileDto fileDto, Stream fileStream)
        {            
            var containerClient = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFilesTemporary);
            var blobClient = containerClient.GetBlobClient(fileDto.FileName);

            using (fileStream)
            {
                await blobClient.UploadAsync(fileStream, true);
            }
        }

        public async Task DeleteFromTempAsync(FileDto fileDto)
        {
            var client = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFilesTemporary);

            await client.DeleteBlobIfExistsAsync(fileDto.FileName);
        }

        public async Task CopyToFinalAsync(FileDto fileDto)
        {
            var sourceClient = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFilesTemporary);
            var targetClient = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFiles);

            var file = sourceClient.GetBlobClient(fileDto.FileName);
            await targetClient.GetBlobClient(fileDto.FileName).StartCopyFromUriAsync(file.Uri, new BlobCopyFromUriOptions());
        }

        public async Task<Stream> GetFromTempAsync(FileDto fileDto)
        {
            var client = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFilesTemporary);

            var blobClient = client.GetBlobClient(fileDto.FileName);

            return await blobClient.OpenReadAsync();
        }

        public async Task<Stream> GetFromFinalAsync(string fileName)
        {
            var client = _serviceClient.GetBlobContainerClient(AzureStorageConsts.UserFiles);

            var blobClient = client.GetBlobClient(fileName);

            return await blobClient.OpenReadAsync();
        }
    }
}
