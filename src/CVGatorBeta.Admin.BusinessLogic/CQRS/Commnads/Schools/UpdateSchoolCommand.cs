using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class UpdateSchoolCommand : ICommand
    {
        public Guid SchoolId { get; set; }
        public SchoolDto School { get; set; }

        public UpdateSchoolCommand(Guid schoolId, SchoolDto school)
        {
            SchoolId = schoolId;
            School = school;
        }
    }
}
