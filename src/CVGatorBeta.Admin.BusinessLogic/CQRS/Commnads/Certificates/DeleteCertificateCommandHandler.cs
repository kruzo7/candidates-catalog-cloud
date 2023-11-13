using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates
{
    public class DeleteCertificateCommandHandler : ICommandHandler<DeleteCertificateCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteCertificateCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCertificateCommand command, CancellationToken cancellationToken)
        {
            var certificate = _context.Certificates.First(x => x.CertificateId == command.CertificateId);
            _context.Certificates.Remove(certificate);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
