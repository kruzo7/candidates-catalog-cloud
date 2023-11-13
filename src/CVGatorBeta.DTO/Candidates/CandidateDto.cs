using CVGatorBeta.DTO.CandidateDetails;
using CVGatorBeta.DTO.Categories;
using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Candidates
{
    [DataContract]
    public class CandidateDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "candidate";    

        [DataMember]
        public Guid? CandidateId { get; set; }
        [DataMember]
        public string? CandidateFirstName { get; set; }
        [DataMember]
        public string? CandidateLastName { get; set; }
        [DataMember]
        public DateTime? BirthDate { get; set; }
        [DataMember]
        public CandidatesAddressDto? CandidatesAddress { get; set; }
        [DataMember]
        public List<CandidateCategoryDto>? CandidatesCategories { get; set; }
        [DataMember]
        public List<CandidatesEmployerDto>? CandidatesEmployers { get; set; }
        [DataMember]
        public List<CandidatesCourseDto>? CandidatesCourses { get; set; }
        [DataMember]
        public List<CandidatesCertificateDto>? CandidatesCertificates { get; set; }

        [DataMember]
        public List<CandidatesSchoolDto>? CandidatesSchools { get; set; }

        [DataMember]
        public List<CandidatesFileDto>? CandidatesFiles { get; set; }


        public CandidateDto()
        {
            CandidatesAddress = new CandidatesAddressDto();
            CandidatesCategories = new List<CandidateCategoryDto>();
            CandidatesCertificates = new List<CandidatesCertificateDto>();
            CandidatesCourses = new List<CandidatesCourseDto>();
            CandidatesEmployers = new List<CandidatesEmployerDto>();
            CandidatesSchools = new List<CandidatesSchoolDto>();
            CandidatesFiles = new List<CandidatesFileDto>();
        }
    }
}
