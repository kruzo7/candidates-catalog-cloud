using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Courses
{
    public class GetCourseQueryHandler : IQueryHandler<GetCourseQuery, CourseDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<CourseDto> Handle(GetCourseQuery query, CancellationToken cancellationToken)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == query.CourseId);
            return Task.FromResult(_mapper.Map<CourseDto>(course)); 
        }
    }
}
