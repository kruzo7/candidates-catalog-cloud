using CVGatorBeta.Admin.EntityFramework.AdminModels;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Courses
    {
        public Courses()
        {
        }

        public List<Course> CreateSampleData()
        {
            return new List<Course>() {
                new Course() {  CourseName = "AI and ML Course" },
                new Course() {  CourseName = "AWS Developer Associate Certification" },
                new Course() {  CourseName = "Microsoft Azure Certification" },
                new Course() {  CourseName = "Automation Testing" },
                new Course() {  CourseName = "SQL Database Training " },
                new Course() {  CourseName = "Full Stack Web Developer " },
                new Course() {  CourseName = "DevOps Certification Training " },
                new Course() {  CourseName = "Certified Ethical Hacker Training" },
                new Course() {  CourseName = "PMP Certification Training Course" },
                new Course() {  CourseName = "Google Data Analytics" },
                new Course() {  CourseName = "Modern JavaScript: Iterators and Generators" },
            };
        }
    }
}
