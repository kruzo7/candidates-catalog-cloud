using CVGatorBeta.DTO.Interfaces;
using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Categories
{
    [DataContract]
    public class CategoryDto : IHttpClientDto
    {
        [IgnoreDataMember]
        public string ObjRoute => "category";

        [DataMember]
        public Guid? CategoryId { get; set; }
        [DataMember]
        public string? CategoryName { get; set; }
    }
}
