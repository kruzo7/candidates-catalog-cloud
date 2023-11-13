using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class CreateSchoolCommand : ICommand<Guid>
    {
        public SchoolDto School { get; set; }

        public CreateSchoolCommand(SchoolDto school)
        {
            School = school;
        }
    }
}
