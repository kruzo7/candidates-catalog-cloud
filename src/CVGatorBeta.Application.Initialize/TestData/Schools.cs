using CVGatorBeta.Admin.EntityFramework.AdminModels;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Schools
    {
        public Schools()
        { 
        }

        public List<School> CreateSampleData()
        {
            return new List<School>() {
                new School() {  SchoolName = "Harvard University" },
                new School() {  SchoolName = "Massachusetts Institute of Technology (MIT)" },
                new School() {  SchoolName = "Stanford University" },
                new School() {  SchoolName = "University of California Berkeley" },
                new School() {  SchoolName = "University of Oxford" },
                new School() {  SchoolName = "University of Washington Seattle" },
                new School() {  SchoolName = "Columbia University" },
                new School() {  SchoolName = "Yale University" },
                new School() {  SchoolName = "University College London" },
                new School() {  SchoolName = "Uniwersytet Warszawski" },
                new School() {  SchoolName = "Uniwersytet Jagielloński" },
                new School() {  SchoolName = "Akademia Górniczo Hutnicza" },
                new School() {  SchoolName = "Politechnika Łódzka" },
                new School() {  SchoolName = "Uniwersytet Wrocławski" },
                new School() {  SchoolName = "Uniwersytet Gdański" },
                new School() {  SchoolName = "Uniwersytet w Białymstoku" },

            };
        }
    }
}
