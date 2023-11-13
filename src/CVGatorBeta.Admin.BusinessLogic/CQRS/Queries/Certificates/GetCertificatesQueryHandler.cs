using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificates;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificate
{
    public class GetCertificatesQueryHandler : IQueryHandler<GetCertificatesQuery, IEnumerable<CertificateDto>>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCertificatesQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<IEnumerable<CertificateDto>> Handle(GetCertificatesQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IEnumerable<CertificateDto>>(_context.Certificates));
        }
    }
}
