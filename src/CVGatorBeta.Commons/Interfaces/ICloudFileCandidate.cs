using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Commons.Interfaces
{
    public interface ICloudFileCandidate
    {
        Task UploadToTempAsync(FileDto fileDto, Stream fileStream);
        Task DeleteFromTempAsync(FileDto fileDto);
        Task CopyToFinalAsync(FileDto fileDto);
        Task<Stream> GetFromTempAsync(FileDto fileDto);
        Task<Stream> GetFromFinalAsync(string fileName);
    }
}
