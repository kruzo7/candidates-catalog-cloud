using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid CategoryId { get; set; }

        public DeleteCategoryCommand(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
