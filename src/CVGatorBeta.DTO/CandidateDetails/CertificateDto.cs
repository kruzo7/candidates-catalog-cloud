using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CertificateDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "certificate";

        [DataMember]
        public Guid? CertificateId { get; set; }
        [DataMember]
        public string? CertificateName { get; set; }
    }
}