using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class UpdateSchoolCommandHandler : ICommandHandler<UpdateSchoolCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public UpdateSchoolCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Unit> Handle(UpdateSchoolCommand command, CancellationToken cancellationToken)
        {
            var school = _mapper.Map<School>(command.School);

            _context.Schools.Update(school);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
