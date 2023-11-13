using CVGatorBeta.Admin.EntityFramework.AdminModels;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Certificates
    {
        public Certificates()
        {
        }
        public List<Certificate> CreateSampleData()
        {
            return new List<Certificate>() {
                new Certificate() {  CertificateName = "Azure Fundametials" },
                new Certificate() { CertificateName = "AWS Certified Solutions Architect" },
                new Certificate() { CertificateName = "Certified Cloud Security Professional" },
                new Certificate() { CertificateName = "Project Management Professional (PMP)" },
                new Certificate() { CertificateName = "Google Professional Cloud Architect" },
            };
        }
    }
}
