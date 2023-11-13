using CVGatorBeta.Admin.BusinessLogic.Process.FileUpload;
using CVGatorBeta.Commons.Enums;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.Process
{
    public class ProcessFileUploadMainDirector
    {
        private readonly IProcessFileUploadBuilderFactory _processFileBuilderFactory;

        public ProcessFileUploadMainDirector(IProcessFileUploadBuilderFactory processFileBuilderFactory)
        {
            _processFileBuilderFactory = processFileBuilderFactory;
        }
        public async Task BuildFileUploadProcess(FileDto fileDto)
        {
            var builder = _processFileBuilderFactory.CreateProcessBuilder((FileResource)fileDto.FileResource);

            builder.FileDto = fileDto;
            await builder.Validate();
            await builder.Process();
            await builder.Cleanup();
        }
    }
}
