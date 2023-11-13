using System.Runtime.Serialization;

namespace CVGatorBeta.DTO.Commons
{
    [DataContract]
    public class FileDto
    { 
        [DataMember]
        public Guid? FileId { get; set; }

        [DataMember]
        public Guid CandidateId { get; set; }

        [DataMember]
        public string FileName { get; set; } = null!;

        [DataMember]
        public string CautionUserFileName { get; set; } = null!;

        [DataMember]
        public int FileResource { get; set; }

        [DataMember]
        public int FileType { get; set; }

        [DataMember]
        public string MimeContentType { get; set; } = null!;

        [DataMember]
        public int UploadFileStatus { get; set; }

        [DataMember]
        public string Message { get; set; } = null!;

        [DataMember]
        public string Url { get; set; } = null!;

        [DataMember]
        public string BlobUrl { get; set; } = null!;
    }
}
