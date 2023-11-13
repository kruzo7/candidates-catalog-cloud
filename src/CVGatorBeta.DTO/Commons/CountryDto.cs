using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Commons
{
    [DataContract]
    public class CountryDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "country";

        [DataMember]
        public Guid? CountryId { get; set; }
        [DataMember]
        public string? CountryName { get; set; }
    }
}
