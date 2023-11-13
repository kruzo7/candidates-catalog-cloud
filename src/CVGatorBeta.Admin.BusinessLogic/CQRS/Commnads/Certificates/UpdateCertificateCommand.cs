using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates
{
    public class UpdateCertificateCommand : ICommand
    {
        public Guid CertificateId { get; set; }
        public CertificateDto Certificate { get; set; }

        public UpdateCertificateCommand(Guid certificateId, CertificateDto certificate)
        {
            CertificateId = certificateId;
            Certificate = certificate;
        }
    }
}
