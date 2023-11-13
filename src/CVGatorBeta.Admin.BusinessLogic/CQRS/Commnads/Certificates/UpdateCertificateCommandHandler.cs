using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates
{
    public class UpdateCertificateCommandHandler : ICommandHandler<UpdateCertificateCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public UpdateCertificateCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Unit> Handle(UpdateCertificateCommand command, CancellationToken cancellationToken)
        {
            var certificate = _mapper.Map<Certificate>(command.Certificate);

            _context.Certificates.Update(certificate);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
