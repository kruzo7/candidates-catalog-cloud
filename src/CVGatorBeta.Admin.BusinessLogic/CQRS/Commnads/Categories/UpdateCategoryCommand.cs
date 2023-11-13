using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.Categories;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public UpdateCategoryCommand(Guid categoryId, CategoryDto category)
        {
            CategoryId = categoryId;
            Category = category;
        }
    }
}
