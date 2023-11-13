using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class DeleteEmployerCommandHandler : ICommandHandler<DeleteEmployerCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteEmployerCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployerCommand command, CancellationToken cancellationToken)
        {
            var employer = _context.Employers.First(x => x.EmployerId == command.EmployerId);
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
