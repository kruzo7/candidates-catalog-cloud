using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;
using CVGatorBeta.DTO.CandidateDetails;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Employers
{
    public class CreateEmployerCommand : ICommand<Guid>
    {
        public EmployerDto Employer { get; set; }

        public CreateEmployerCommand(EmployerDto employer)
        {
            Employer = employer;
        }
    }
}
