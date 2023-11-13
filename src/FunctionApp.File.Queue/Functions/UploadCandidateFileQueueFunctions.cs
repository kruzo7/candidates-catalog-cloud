using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles;
using CVGatorBeta.Commons.Constatns;
using CVGatorBeta.Commons.Enums;
using CVGatorBeta.DTO.Commons;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp.File.Queue.Functions
{
    public class UploadCandidateFileQueueFunctions
    {
        private const string _connection = "AzureStorage:cvgatorbetauserfiles";

        private readonly ILogger<UploadCandidateFileQueueFunctions> _logger;
        private readonly IMediator _mediator;

        public UploadCandidateFileQueueFunctions(ILogger<UploadCandidateFileQueueFunctions> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Function(nameof(UploadCandidateFileQueueProcess))]
        public async Task UploadCandidateFileQueueProcess([QueueTrigger(AzureStorageConsts.UserFilesTemporary, Connection = _connection)] FileDto fileDtoMessage)
        {
            _logger.LogInformation("C# Queue trigger function processed.");

            try
            {
                await _mediator.Send(new ProcessCandidateFileCommand(fileDtoMessage));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _mediator.Send(new UpdateCandidateFileCommand(fileDtoMessage.FileId!.Value, UploadStatus.Error, ex.Message));
            }
        }
    }
}
