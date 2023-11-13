using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Categorys
{
    public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<CategoryDto> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == query.CategoryId);
            return Task.FromResult(_mapper.Map<CategoryDto>(category)); 
        }
    }
}
