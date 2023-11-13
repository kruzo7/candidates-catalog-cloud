using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class InsertFileForPreProcessingCommand : ICommand
    {
        public FileDto FileDto { get; set; }

        public Stream FileStream { get; set; }

        public InsertFileForPreProcessingCommand(FileDto fileDto, Stream fileStream)
        {
            FileDto = fileDto;
            FileStream = fileStream;
        }
    }
}
