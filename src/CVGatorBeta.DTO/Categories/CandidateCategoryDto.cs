using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Categories
{
    [DataContract]
    public class CandidateCategoryDto
    {
        [DataMember]
        public Guid CandidateCategoryId { get; set; }

        [DataMember]
        public CategoryDto? Category { get; set; }
        
    }
}
