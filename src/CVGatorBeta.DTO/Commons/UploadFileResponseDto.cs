using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Commons
{
    [DataContract]
    public class UploadFileResponseDto
    {
        [DataMember]
        public string Message { get; set; } = null!;

        [DataMember]
        public FileDto File { get; set; } = null!;
    }
}
