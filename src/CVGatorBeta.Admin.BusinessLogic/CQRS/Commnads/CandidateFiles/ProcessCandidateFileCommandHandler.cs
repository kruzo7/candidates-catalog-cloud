using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.BusinessLogic.Process;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class ProcessCandidateFileCommandHandler : ICommandHandler<ProcessCandidateFileCommand>
    {        
        private readonly ProcessFileUploadMainDirector _processFileDirector;

        public ProcessCandidateFileCommandHandler(ProcessFileUploadMainDirector processFileDirector)
        {   
            _processFileDirector = processFileDirector;
        }

        public async Task<Unit> Handle(ProcessCandidateFileCommand command, CancellationToken cancellationToken)
        {
            await _processFileDirector.BuildFileUploadProcess(command.FileDto);

            return Unit.Value;
        }
    }
}
