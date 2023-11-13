using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Countries
{
    public class CreateCountryCommandHandler : ICommandHandler<CreateCountryCommand, Guid>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public async Task<Guid> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(command.Country);

            await _context.Countries.AddAsync(country, cancellationToken);
            _context.ChangeTracker.AddAudit();
            await _context.SaveChangesAsync(cancellationToken);
            
            return country.CountryId;
        }
    }
}
