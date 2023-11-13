using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.CandidateFiles
{
    public class UpdateCandidateFileCommandHandler : ICommandHandler<UpdateCandidateFileCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public UpdateCandidateFileCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCandidateFileCommand command, CancellationToken cancellationToken)
        {
            var fileToUpdate = _context.Files.SingleOrDefault(x => x.FileId == command.FileId);

            if (fileToUpdate != null)
            {
                fileToUpdate.Message = command.Message;
                fileToUpdate.UploadFileStatus = (int)command.UploadFileStatus;

                _context.Files.Update(fileToUpdate);

                _context.ChangeTracker.AddAudit();
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }

    }
}
