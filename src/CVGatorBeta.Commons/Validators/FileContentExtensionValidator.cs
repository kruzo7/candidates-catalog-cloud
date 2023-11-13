using CVGatorBeta.Commons.Enums;

namespace CVGatorBeta.Commons.Validators
{
    public class FileContentExtensionValidator
    {
        private readonly List<string> _documentExtensions = new List<string> { ".pdf" };
        private readonly List<string> _imageExtensions = new List<string> { ".jpg" };

        private readonly string _pdfMime = "application/pdf";
        private readonly string _jpgMime = "image/jpeg";

        public string GetSupportedFileType(FileResource fileResource)
        {
            string message;

            switch (fileResource)
            {
                case FileResource.CandidatePhoto:
                    message = string.Join(",", _imageExtensions);
                    break;
                case FileResource.CandidateCVFile:
                    message = string.Join(",", _documentExtensions);
                    break;
                default:
                    message = $"{fileResource} - unknown?";
                    break;
            }

            return message;
        }

        public bool Validate(string fileContent, string fileName, FileResource fileResource)
        {
            if (ValidateMime(fileContent, fileResource) &&
                ValidateExtension(fileName, fileResource))
            {
                return true;
            }

            return false;
        }

        private bool ValidateMime(string fileContent, FileResource fileResource)
        {
            switch (fileResource)
            {
                case (FileResource.CandidateCVFile):
                    if (!string.Equals(fileContent, _pdfMime, StringComparison.InvariantCultureIgnoreCase))
                        return false;
                    break;

                case (FileResource.CandidatePhoto):
                    if (!string.Equals(fileContent, _jpgMime, StringComparison.InvariantCultureIgnoreCase))
                        return false;
                    break;

                default:
                    return false;
            }

            return true;
        }

        private bool ValidateExtension(string fileName, FileResource fileResource)
        {
            var extension = Path.GetExtension(fileName).ToLower();

            switch (fileResource)
            {
                case (FileResource.CandidateCVFile):
                    if (!_documentExtensions.Contains(extension))
                        return false;
                    break;

                case (FileResource.CandidatePhoto):
                    if (!_imageExtensions.Contains(extension))
                        return false;
                    break;

                default:
                    return false;
            }

            return true;
        }

    }
}
