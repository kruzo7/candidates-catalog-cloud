using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Commons;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class ProcessCandidateFileCommand : ICommand
    {
        public FileDto FileDto { get; set; }

        public ProcessCandidateFileCommand(FileDto fileDto)
        {
            FileDto = fileDto;            
        }
    }
}
