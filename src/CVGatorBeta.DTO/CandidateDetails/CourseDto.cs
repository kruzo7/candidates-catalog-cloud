using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CourseDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "course";

        [DataMember]
        public Guid? CourseId { get; set; }
        [DataMember]
        public string? CourseName { get; set; }
        [DataMember]
        public DateTime? StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }

    }
}