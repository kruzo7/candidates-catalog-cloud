using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesCourseDto
    {
        [DataMember]
        public Guid CandidateCourseId { get; set; }


        [DataMember]
        public CourseDto? Course { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }
    }
}