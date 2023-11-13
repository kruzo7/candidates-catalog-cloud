using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class CreateEmployerCommandHandler : ICommandHandler<CreateEmployerCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public CreateEmployerCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Guid> Handle(CreateEmployerCommand command, CancellationToken cancellationToken)
        {
            var employer = _mapper.Map<Employer>(command.Employer);

            await _context.Employers.AddAsync(employer, cancellationToken);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);
            
            return employer.EmployerId;
        }
    }
}
