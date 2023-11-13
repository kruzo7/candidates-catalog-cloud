using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class DeleteSchoolCommandHandler : ICommandHandler<DeleteSchoolCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteSchoolCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSchoolCommand command, CancellationToken cancellationToken)
        {
            var school = _context.Schools.First(x => x.SchoolId == command.SchoolId);
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
