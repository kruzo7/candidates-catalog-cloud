using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Base;

namespace CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Schools
{
    public class DeleteSchoolCommand : ICommand
    {
        public Guid SchoolId { get; set; }

        public DeleteSchoolCommand(Guid schoolId)
        {
            SchoolId = schoolId;
        }
    }
}
