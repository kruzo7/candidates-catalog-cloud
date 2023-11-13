using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand>
    {
        private readonly CVGatorBetaAdminContext _context;

        public DeleteCategoryCommandHandler(CVGatorBetaAdminContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var candidateExists = _context.Candidates.Any(x => x.CandidatesCategories.Any(y => y.CategoryId == command.CategoryId));

            if (candidateExists)
            {
                throw new InvalidOperationException("Can't delete: Category is used by Candidate.");
            }

            var category = _context.Categories.First(x => x.CategoryId == command.CategoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
