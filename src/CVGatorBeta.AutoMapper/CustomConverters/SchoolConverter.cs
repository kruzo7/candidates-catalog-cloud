using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class SchoolConverter : IValueConverter<ICollection<CandidatesSchool>, string>
    {
        public string Convert(ICollection<CandidatesSchool> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Select(x => x.School.SchoolName));
        }
    }
}
