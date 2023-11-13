using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Categorys
{
    public class GetCategoryQuery : IQuery<CategoryDto>
    {
        public Guid CategoryId { get; set; }

        public GetCategoryQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
