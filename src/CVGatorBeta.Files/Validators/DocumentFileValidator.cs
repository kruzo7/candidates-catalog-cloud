using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Files.Validators
{
    internal class DocumentFileValidator : IFileValidator
    {
        public string ValidatorName => nameof(DocumentFileValidator);

        public Task<bool> ValidateFileAsync(FileDto fileDto, Stream stream)
        {
            return Task.FromResult(true);
        }
    }
}
