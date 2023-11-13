using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Courses
{
    public class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteCourseCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            var course = _context.Courses.First(x => x.CourseId == command.CourseId);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
