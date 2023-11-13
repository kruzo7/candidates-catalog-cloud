using CVGatorBeta.DTO.Enums;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesEmployerDto
    {
        [DataMember]
        public Guid CandidatesEmployersId { get; set; }

        [DataMember]
        public EmployerDto? Employer { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
        [DataMember]
        public short EmploymentStatus { get; set; }
    }
}
