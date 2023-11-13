using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Commons.Enums;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class UpdateCandidateFileCommand : ICommand
    {
        public Guid FileId { get; set; }
        public UploadStatus UploadFileStatus { get; set; }
        public string Message { get; set; }

        public UpdateCandidateFileCommand(Guid fileId, UploadStatus uploadFileStatus, string message)
        {
            FileId = fileId;
            UploadFileStatus = uploadFileStatus;
            Message = message;
        }
    }
}
