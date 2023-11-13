using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class EmployerDto : IHttpClientDto
    {

        [IgnoreDataMember]
        public string ObjRoute => "employer";

        [DataMember]
        public Guid? EmployerId { get; set; }
        [DataMember]
        public string? EmployerName { get; set; }

    }
}
