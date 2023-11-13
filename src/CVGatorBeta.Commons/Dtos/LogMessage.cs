using CVGatorBeta.Commons.Enums;
using System.Runtime.Serialization;

namespace CVGatorBeta.Commons.Dtos
{
    [DataContract]
    public class LogMessage
    {

        [DataMember]
        public Guid TrackId { get; set; }

        [DataMember]
        public MessageLevel Level { get; set; }

        [DataMember]
        public string Application { get; set; } = null!;

        [DataMember]
        public string Host { get; set; } = null!;

        [DataMember]
        public string Message { get; set; } = null!;

        [DataMember]
        public DateTime DateTime { get; set; }
    }
}
