using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class CreateSchoolCommandHandler : ICommandHandler<CreateSchoolCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public CreateSchoolCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Guid> Handle(CreateSchoolCommand command, CancellationToken cancellationToken)
        {
            var school = _mapper.Map<School>(command.School);

            await _context.Schools.AddAsync(school, cancellationToken);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);
            
            return school.SchoolId;
        }
    }
}
