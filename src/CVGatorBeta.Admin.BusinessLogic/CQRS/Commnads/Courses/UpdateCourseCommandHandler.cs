using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class UpdateCourseCommandHandler : ICommandHandler<UpdateCourseCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Unit> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(command.Course);

            _context.Courses.Update(course);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
