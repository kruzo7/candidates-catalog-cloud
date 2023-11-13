using CVGatorBeta.Commons.Interfaces;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Files.Validators
{
    internal class ImageFileValidator : IFileValidator
    {
        public string ValidatorName => nameof(ImageFileValidator);

        public Task<bool> ValidateFileAsync(FileDto fileDto, Stream stream)
        {
            return Task.FromResult(true);
        }
    }
}
