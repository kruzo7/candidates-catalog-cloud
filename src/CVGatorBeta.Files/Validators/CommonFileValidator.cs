using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Files.Validators
{
    internal class CommonFileValidator : IFileValidator
    {
        public string ValidatorName => nameof(CommonFileValidator);

        public Task<bool> ValidateFileAsync(FileDto fileDto, Stream stream)
        {
            return Task.FromResult(true);
        }
    }
}
