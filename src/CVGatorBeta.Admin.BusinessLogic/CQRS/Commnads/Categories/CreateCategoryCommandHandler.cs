using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Guid> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command.Category);

            await _context.Categories.AddAsync(category, cancellationToken);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);
            
            return category.CategoryId;
        }
    }
}
