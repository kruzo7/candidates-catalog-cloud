using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Search
{
    [DataContract]
    public class SearchCandidateDto
    { 
    
        [DataMember]
        public Guid? CandidateId { get; set; }
        [DataMember]
        public string? CandidateFirstName { get; set; }
        [DataMember]
        public string? CandidateLastName { get; set; }
        [DataMember]
        public DateTimeOffset? BirthDate { get; set; }
        [DataMember]
        public string CandidateCity { get; set; } = null!;
        [DataMember]
        public List<string>? CandidateCategories { get; set; }
        [DataMember]
        public List<string>? CandidateEmployers { get; set; }
        [DataMember]
        public List<string>? CandidateActualEmployers { get; set; }
        [DataMember]
        public List<string>? CandidateCourses { get; set; }
        [DataMember]
        public List<string>? CandidateCertificates { get; set; }
        [DataMember]
        public List<string>? CandidateSchools { get; set; }
    }
}
