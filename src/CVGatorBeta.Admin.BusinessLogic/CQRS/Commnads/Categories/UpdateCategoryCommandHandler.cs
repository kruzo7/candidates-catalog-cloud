using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;
using MediatR;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Categorys
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(command.Category);

            _context.Categories.Update(category);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
