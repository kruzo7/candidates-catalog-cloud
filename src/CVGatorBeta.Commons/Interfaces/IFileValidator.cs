using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Commons.Interfaces
{
    public interface IFileValidator
    {
        string ValidatorName { get; }
        Task<bool> ValidateFileAsync(FileDto fileDto, Stream stream);
    }
}
