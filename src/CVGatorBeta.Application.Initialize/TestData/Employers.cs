using CVGatorBeta.Admin.EntityFramework.AdminModels;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Employers
    {
        public Employers()
        {
        }

        public List<Employer> CreateSampleData()
        {
            return new List<Employer>() {
                new Employer() {  EmployerName = "Computer Group" },
                new Employer() {  EmployerName = "Cisco Systems" },
                new Employer() {  EmployerName = "Hilton Worldwide Holdings" },
                new Employer() {  EmployerName = "American Express" },
                new Employer() {  EmployerName = "Atlassian" },
                new Employer() {  EmployerName = "Microsoft" },
                new Employer() {  EmployerName = "Dell" },
                new Employer() {  EmployerName = "BMW Group" },
                new Employer() {  EmployerName = "Amazon" },
                new Employer() {  EmployerName = "SpaceX", },
            };
        }
    }
}
