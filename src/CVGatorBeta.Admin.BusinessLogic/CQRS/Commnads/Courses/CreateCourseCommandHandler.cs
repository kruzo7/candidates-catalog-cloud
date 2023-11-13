using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Guid> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(command.Course);

            await _context.Courses.AddAsync(course, cancellationToken);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);
            
            return course.CourseId;
        }
    }
}
