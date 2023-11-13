using CVGatorBeta.AzureStorage.Blobs;
using CVGatorBeta.AzureStorage.Queue;
using CVGatorBeta.Commons.Interfaces;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace CVGatorBeta.AzureStorage
{
    public static class AzureStorageExtension
    {
        public static IServiceCollection AddAzureStorage(this IServiceCollection services, string? storageConnectionString)
        {
            if (string.IsNullOrEmpty(storageConnectionString)) throw new ArgumentNullException(nameof(storageConnectionString));

            services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.AddBlobServiceClient(storageConnectionString);
                clientBuilder.AddQueueServiceClient(storageConnectionString);
            });

            services.AddTransient<ICloudFileCandidate, CloudFileCandidate>();
            services.AddTransient<IUploadFileQueue, UploadFileMessageQueue>();

            return services;
        }
    }
}
