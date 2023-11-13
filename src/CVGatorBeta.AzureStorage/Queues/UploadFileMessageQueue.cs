using Azure.Storage.Queues;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;
using Newtonsoft.Json;

namespace CVGatorBeta.AzureStorage.Queue
{
    internal class UploadFileMessageQueue : IUploadFileQueue
    {
        private readonly QueueClient _queueClient;
        public UploadFileMessageQueue(QueueServiceClient queueServiceClient)
        {
            _queueClient = queueServiceClient.GetQueueClient(AzureStorageConsts.UserFilesTemporary);
        }
        public async Task SendMessage(FileDto fileDto)
        {
            await _queueClient.SendMessageAsync(JsonConvert.SerializeObject(fileDto));
        }
        public async Task DeleteMessage(FileDto fileDto)
        {
            await _queueClient.DeleteMessageAsync("", "");
        }
    }
}
