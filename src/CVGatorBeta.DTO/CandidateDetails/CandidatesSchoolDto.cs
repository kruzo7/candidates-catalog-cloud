using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesSchoolDto
    {
        [DataMember]
        public Guid CandidateSchoolId { get; set; }

        [DataMember]
        public SchoolDto? School { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}