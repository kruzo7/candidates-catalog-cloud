using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Commons.Interfaces
{
    public interface IUploadFileQueue
    {
        Task SendMessage(FileDto fileDto);

        Task DeleteMessage(FileDto fileDto);
    }
}
