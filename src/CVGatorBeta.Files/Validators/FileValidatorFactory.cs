using CVGatorBeta.Commons.Interfaces;

namespace CVGatorBeta.Files.Validators
{
    internal class FileValidatorFactory : IFileValidatorFactory
    {
        private readonly ICollection<IFileValidator> _validators = new List<IFileValidator>();

        public ICollection<IFileValidator> GetValidatorsDocument()
        {
            AddCommons();
            AddDocuments();
            return _validators;
        }
        public ICollection<IFileValidator> GetValidatorsImage()
        {
            AddCommons();
            AddImages();
            return _validators;
        }

        private void AddCommons()
        {
            _validators.Add(new CommonFileValidator());
        }
        private void AddDocuments()
        {
            _validators.Add(new DocumentFileValidator());
        }
        private void AddImages()
        {
            _validators.Add(new ImageFileValidator());
        }
    }
}
