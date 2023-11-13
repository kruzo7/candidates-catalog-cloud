using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries
{
    public class DeleteCountryCommandHandler : ICommandHandler<DeleteCountryCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteCountryCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCountryCommand command, CancellationToken cancellationToken)
        {
            var country = _context.Countries.First(x => x.CountryId == command.CountryId);
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
