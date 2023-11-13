using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class SchoolDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "school";
        
        [DataMember]
        public Guid? SchoolId { get; set; }
        [DataMember]
        public string? SchoolName { get; set; }        
    }
}