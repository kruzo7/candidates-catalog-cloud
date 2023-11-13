using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.Process.FileUpload
{
    public interface IProcessFileUploadBuilder
    {
        FileDto FileDto { get; set; }
        Task Validate();
        Task Process();
        Task Cleanup();
    }
}
