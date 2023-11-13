using CVGatorBeta.Admin.EntityFramework.AdminModels;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Categories
    {

        public Categories()
        {
        }
        public List<Category> CreateSampleData()
        {
            return new List<Category>() {
                new Category() { CategoryName = "Manager" },
                new Category() { CategoryName = "Software Developer" },
                new Category() { CategoryName = "Software Architect" },
                new Category() { CategoryName = "CEO" },
                new Category() { CategoryName = "Project Manager" },
                new Category() { CategoryName = "Lead" },
                new Category() { CategoryName = "QA" },
                new Category() { CategoryName = "Tester" },
            };
        }
    }
}
