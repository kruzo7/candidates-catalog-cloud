using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificates
{
    public class GetCertificateQueryHandler : IQueryHandler<GetCertificateQuery, CertificateDto>
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;

        public GetCertificateQueryHandler(CVGatorBetaAdminContext context, IMapper maper)
        {
            _context = context;
            _mapper = maper;
        }

        public Task<CertificateDto> Handle(GetCertificateQuery query, CancellationToken cancellationToken)
        {
            var certificate = _context.Certificates.FirstOrDefault(x => x.CertificateId == query.CertificateId);
            return Task.FromResult(_mapper.Map<CertificateDto>(certificate)); 
        }
    }
}
