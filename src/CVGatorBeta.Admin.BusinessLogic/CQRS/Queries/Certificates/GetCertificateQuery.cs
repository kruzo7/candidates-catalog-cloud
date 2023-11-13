using CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Queries.Certificates
{
    public class GetCertificateQuery : IQuery<CertificateDto>
    {
        public Guid CertificateId { get; set; }

        public GetCertificateQuery(Guid certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
