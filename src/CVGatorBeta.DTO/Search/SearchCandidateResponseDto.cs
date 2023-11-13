using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Search
{
    [DataContract]
    public class SearchCandidateResponseDto
    {
        [DataMember]
        public List<SearchCandidateDto> SearchCandidateDtos { get; set; } = null!;
        
        [DataMember]
        public int TotalPages { get; set; }
        
        [DataMember]
        public int Page { get; set; }
    }
}
