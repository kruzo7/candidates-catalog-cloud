using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Courses;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Course
{
    public class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<CourseDto>>(_context.Courses));
        }
    }
}
