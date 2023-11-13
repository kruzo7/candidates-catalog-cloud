using CVGatorBeta.Commons.Enums;

namespace CVGatorBeta.Admin.BusinessLogic.Process.FileUpload
{
    public class ProcessFileUploadBuilderFactory : IProcessFileUploadBuilderFactory
    {
        private readonly ProcessFileUploadBuilderDocument _processDocumentFileBuilder;
        private readonly ProcessFileUploadBuilderImage _processImageFileBuilder;
        public ProcessFileUploadBuilderFactory(ProcessFileUploadBuilderDocument processDocumentFileBuilder, ProcessFileUploadBuilderImage processImageFileBuilder)
        {
            _processDocumentFileBuilder = processDocumentFileBuilder;
            _processImageFileBuilder = processImageFileBuilder;
        }

        public IProcessFileUploadBuilder CreateProcessBuilder(FileResource fileResource)
        {
            return fileResource switch
            {
                FileResource.CandidatePhoto => _processImageFileBuilder,
                FileResource.CandidateCVFile => _processDocumentFileBuilder,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
