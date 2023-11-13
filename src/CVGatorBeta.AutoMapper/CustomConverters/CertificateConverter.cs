using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class CertificateConverter : IValueConverter<ICollection<CandidatesCertificate>, string>
    {
        public string Convert(ICollection<CandidatesCertificate> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Select(x => x.Certificate.CertificateName));
        }
    }
}
