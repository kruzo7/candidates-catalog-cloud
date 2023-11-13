using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class CreateCategoryCommand : ICommand<Guid>
    {
        public CategoryDto Category { get; set; }

        public CreateCategoryCommand(CategoryDto category)
        {
            Category = category;
        }
    }
}
