using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesCertificateDto
    {
        [DataMember]
        public Guid CandidateCertificateId { get; set; }

        [DataMember]
        public CertificateDto? Certificate { get; set; }

        [DataMember]
        public DateTime? StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}