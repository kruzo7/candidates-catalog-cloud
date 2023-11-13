using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates
{
    public class CreateCertificateCommand : ICommand<Guid>
    {
        public CertificateDto Certificate { get; set; }

        public CreateCertificateCommand(CertificateDto certificate)
        {
            Certificate = certificate;
        }
    }
}
