using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificates
{
    public class GetCertificatesQuery : IQuery<IEnumerable<CertificateDto>>
    {
        public GetCertificatesQuery()
        {
        }
    }
}
