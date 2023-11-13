using CVGatorBeta.DTO.Commons;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesFileDto
    {
        [DataMember]
        public Guid CandidateFilelId { get; set; }

        [DataMember]
        public FileDto? File { get; set; }
        
    }
}