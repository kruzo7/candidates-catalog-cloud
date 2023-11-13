using CVGatorBeta.DTO.Commons;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.CandidateDetails
{
    [DataContract]
    public class CandidatesAddressDto
    {
        [DataMember]
        public Guid CandidateAddressId { get; set; }
        [DataMember]
        public Guid? CandidateId { get; set; }
        [DataMember]
        public CountryDto? Country { get; set; }
        [DataMember]
        public string? CityName { get; set; }
        [DataMember]
        public string? StreetName { get; set; }
        [DataMember]
        public string? StreetNumber { get; set; }
        [DataMember]
        public string? PostCode { get; set; }
     
    }
}