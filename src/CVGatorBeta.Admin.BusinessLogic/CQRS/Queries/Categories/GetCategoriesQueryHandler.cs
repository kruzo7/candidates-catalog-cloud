using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Categorys;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Category
{
    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<CategoryDto>>(_context.Categories));
        }
    }
}
