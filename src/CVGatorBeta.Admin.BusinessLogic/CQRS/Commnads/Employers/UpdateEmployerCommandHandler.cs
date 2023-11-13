using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class UpdateEmployerCommandHandler : ICommandHandler<UpdateEmployerCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public UpdateEmployerCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Unit> Handle(UpdateEmployerCommand command, CancellationToken cancellationToken)
        {
            var employer = _mapper.Map<Employer>(command.Employer);

            _context.Employers.Update(employer);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
