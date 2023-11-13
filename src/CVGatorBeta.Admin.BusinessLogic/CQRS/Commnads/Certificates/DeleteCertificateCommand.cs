using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Certificates
{
    public class DeleteCertificateCommand : ICommand
    {
        public Guid CertificateId { get; set; }

        public DeleteCertificateCommand(Guid certificateId)
        {
            CertificateId = certificateId;
        }
    }
}
