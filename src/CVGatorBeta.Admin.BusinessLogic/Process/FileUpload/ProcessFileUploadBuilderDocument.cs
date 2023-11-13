using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles;
using CVGatorBeta.Commons.Enums;
using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.Process.FileUpload
{
    public class ProcessFileUploadBuilderDocument : IProcessFileUploadBuilder
    {
        private readonly IFileValidatorFactory _validatorFactory;
        private readonly IUploadFileQueue _uploadFileQueue;
        private readonly ICloudFileCandidate _cloudFileCandidate;
        private readonly IMediator _mediator;
        public FileDto FileDto { get; set; } = null!;
        public ProcessFileUploadBuilderDocument(
            IFileValidatorFactory validatorFactory,
            IUploadFileQueue uploadFileQueue,
            ICloudFileCandidate cloudFileCandidate,
            IMediator mediator)
        {
            _validatorFactory = validatorFactory;
            _uploadFileQueue = uploadFileQueue;
            _cloudFileCandidate = cloudFileCandidate;
            _mediator = mediator;
        }

        public async Task Validate()
        {
            var fileStream = await _cloudFileCandidate.GetFromTempAsync(FileDto);
            var validators = _validatorFactory.GetValidatorsDocument();

            using (fileStream)
            {
                foreach (var validator in validators)
                {
                    if (!await validator.ValidateFileAsync(FileDto, fileStream))
                    {
                        throw new FileLoadException($"Error: validate file fail on {validator.ValidatorName}");
                    }
                }
            }
        }
        public async Task Process()
        {
            await _cloudFileCandidate.CopyToFinalAsync(FileDto);
            await _mediator.Send(new UpdateCandidateFileCommand(FileDto.FileId!.Value, UploadStatus.Processed, string.Empty));
        }
        public Task Cleanup()
        {
            _cloudFileCandidate.DeleteFromTempAsync(FileDto);
            _uploadFileQueue.DeleteMessage(FileDto);

            return Task.CompletedTask;
        }
    }
}
