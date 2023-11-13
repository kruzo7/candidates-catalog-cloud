using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Categorys
{
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryDto>>
    {
        public GetCategoriesQuery()
        {
        }
    }
}
