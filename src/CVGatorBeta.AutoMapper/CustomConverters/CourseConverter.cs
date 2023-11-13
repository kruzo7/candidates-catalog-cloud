using AutoMapper;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Newtonsoft.Json;

namespace CVGatorBeta.AutoMapper.CustomConverters
{
    internal class CourseConverter : IValueConverter<ICollection<CandidatesCourse>, string>
    {
        public string Convert(ICollection<CandidatesCourse> source, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Select(x => x.Course.CourseName));
        }
    }
}
