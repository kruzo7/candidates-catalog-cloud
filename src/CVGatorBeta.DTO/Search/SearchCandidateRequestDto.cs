using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Search
{
    [DataContract]
    public class SearchCandidateRequestDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "searchcandidate";
    
        [DataMember]
        public string SearchText { get; set; } = null!;
        
        [DataMember]
        public int PageNumber { get; set; }
    }
}
