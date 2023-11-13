using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.DTO.Enums;

namespace CVGatorBeta.Application.Initialize.TestData
{
    internal class Candidates
    {
        private readonly int _howManyCandidatesDataToAdd = 233;
        private readonly long _minDate = 618199776000000000;
        private readonly long _maxDate = 632715840000000000;
        public Candidates()
        {   
        }
        public List<Candidate> CreateSampleData(List<Category> categories, List<Certificate> certificates, List<Course> courses, List<Employer> employers, List<School> schools, List<(Country Country, string City, string Street)> sampleAddresses)
        {
            var firsNames = GetFirstNames();
            var firsNamesMax = firsNames.Count - 1;
            var lastNames = GetLastNames();
            var lastNamesMax = lastNames.Count - 1;

            var candidates = new List<Candidate>();
            for (var i = 0; i < _howManyCandidatesDataToAdd; i++)
            {
                var candidate = new Candidate()
                {
                    CandidateFirstName = firsNames[new Random().Next(0, firsNamesMax)],
                    CandidateLastName = lastNames[new Random().Next(0, lastNamesMax)],
                    BirthDate = new DateTime(new Random().NextInt64(_minDate, _maxDate), DateTimeKind.Utc),

                };

                AddAddress(candidate, sampleAddresses);

                AddCategories(candidate, categories);
                AddCertificates(candidate, certificates);
                AddCourses(candidate, courses);
                AddEmployers(candidate, employers);
                AddSchools(candidate, schools);

                candidates.Add(candidate);
            }

            return candidates;
        }

        private void AddAddress(Candidate candidate, List<(Country Country, string City, string Street)> samleAddresses)
        {
            var samleAddressesMax = samleAddresses.Count - 1;
            var samleAddress = samleAddresses[new Random().Next(0, samleAddressesMax)];

            candidate.CandidatesAddress = new CandidatesAddress()
            {
                Candidate = candidate,
                StreetNumber = new Random().Next(999).ToString(),
                PostCode = new Random().Next(11111, 99999).ToString(),
                Country = samleAddress.Country,
                CityName = samleAddress.City,
                StreetName = samleAddress.Street,                
            };
        }

        private void AddSchools(Candidate candidate, List<School> schools)
        {
            var schoolsMax = schools.Count - 1;
            var howManyToAdd = new Random().Next(1, 2);

            candidate.CandidatesSchools = new List<CandidatesSchool>();

            for (int i = 0; i < howManyToAdd; i++)
            {
                var date = candidate.BirthDate.AddYears(new Random().Next(18, 50));
                var candidateSchools = new CandidatesSchool()
                {
                    Candidate = candidate,
                    School = schools[new Random().Next(0, schoolsMax)],
                    StartDate = date,
                    EndDate = date.AddYears(new Random().Next(1, 3)),
                };
                candidate.CandidatesSchools.Add(candidateSchools);
            }
        }

        private void AddEmployers(Candidate candidate, List<Employer> employers)
        {
            var employersMax = employers.Count - 1;
            var howManyToAdd = new Random().Next(1, employers.Count);

            candidate.CandidatesEmployers = new List<CandidatesEmployer>();

            for (int i = 0; i < howManyToAdd; i++)
            {
                var date = candidate.BirthDate.AddYears(new Random().Next(18, 50));
                var candidateEmployer = new CandidatesEmployer()
                {
                    Candidate = candidate,
                    Employer = employers[new Random().Next(0, employersMax)],
                    StartDate = date,
                    EndDate = date.AddYears(new Random().Next(1, 10)),
                    EmploymentStatus = (short)EmploymentStatus.Old,
                };
                candidate.CandidatesEmployers.Add(candidateEmployer);
            }

            candidate.CandidatesEmployers.Last().EmploymentStatus = (short)EmploymentStatus.Actual;
        }

        private void AddCourses(Candidate candidate, List<Course> courses)
        {
            var coursesMax = courses.Count - 1;
            var howManyToAdd = new Random().Next(1, courses.Count);

            candidate.CandidatesCourses = new List<CandidatesCourse>();

            for (int i = 0; i < howManyToAdd; i++)
            {
                var date = candidate.BirthDate.AddYears(new Random().Next(18, 50));
                var candidateCourse = new CandidatesCourse()
                {
                    Candidate = candidate,
                    Course = courses[new Random().Next(0, coursesMax)],
                    StartDate = date,
                    EndDate = date.AddYears(1),
                };
                candidate.CandidatesCourses.Add(candidateCourse);
            }
        }

        private void AddCertificates(Candidate candidate, List<Certificate> certificates)
        {
            var certificatesMax = certificates.Count - 1;
            var howManyToAdd = new Random().Next(1, certificates.Count);

            candidate.CandidatesCertificates = new List<CandidatesCertificate>();

            for (int i = 0; i < howManyToAdd; i++)
            {
                var date = candidate.BirthDate.AddYears(new Random().Next(18, 50));
                var candidateCertificate = new CandidatesCertificate()
                {
                    Candidate = candidate,
                    Certificate = certificates[new Random().Next(0, certificatesMax)],
                    StartDate = date,
                    EndDate = date.AddYears(1),
                };
                candidate.CandidatesCertificates.Add(candidateCertificate);
            }
        }

        private void AddCategories(Candidate candidate, List<Category> categories)
        {
            var categoriesMax = categories.Count - 1;
            candidate.CandidatesCategories = new List<CandidatesCategory>();

            var candidateCategory = new CandidatesCategory()
            {
                Candidate = candidate,
                Category = categories[new Random().Next(0, categoriesMax)],
            };

            candidate.CandidatesCategories.Add(candidateCategory);
        }

        private List<string> GetFirstNames()
        {
            return new List<string>()
            {
                "Błażej",
                "Patryk",
                "Łukasz",
                "Konstanty",
                "Kryspin",
                "Adrian",
                "Klaudiusz",
                "Borys",
                "Borys",
                "Józef",
                "Bartosz",
                "Marian",
                "Florian",
                "Daniel",
                "Edward",
                "Marcel",
                "Ludwik",
                "Fryderyk",
                "Krystian",
                "Diego",
                "Kornel",
                "Bolesław",
                "Ignacy",
                "Bronisław",
                "Fabian",
                "Bronisław",
                "Bolesław",
                "Korneliusz",
                "Marian",
                "Igor",
                "Natan",
                "Janusz",
                "Kornel",
                "Gniewomir",
                "Kuba",
                "Bogumił",
                "Florian",
                "Alex",
                "Juliusz",
                "Arkadiusz",
                "Aureliusz",
                "Roman",
                "Ariel",
                "Remigiusz",
                "Karol",
                "Leonardo",
                "Filip",
                "Przemysław",
                "Allan",
                "Heronim",
                "Eliza",
                "Wiktoria",
                "Berenika",
                "Adela",
                "Felicja",
                "Magda",
                "Dagmara",
                "Jolanta",
                "Wioletta",
                "Joanna",
                "Daria",
                "Bianka",
                "Ewelina",
                "Adela",
                "Jolanta",
                "Eliza",
                "Magda",
                "Felicja",
                "Julita",
                "Bogumiła",
                "Eliza",
                "Elena",
                "Barbara",
                "Kinga",
                "Elwira",
                "Teresa",
                "Agata",
                "Zofia",
                "Angelika",
                "Kamila",
                "Jagoda",
                "Roksana",
                "Asia",
                "Alina",
                "Ada",
                "Marcela",
                "Eliza",
                "Łucja",
                "Julianna",
                "Amalia",
                "Marzanna",
                "Amalia",
                "Bogumiła",
                "Aisha",
                "Ola",
                "Alice",
                "Iga",
                "Małgorzata",
                "Marcelina",
                "Lidia",
            };
        }
        private List<string> GetLastNames()
        {
            return new List<string>()
            {
                "Hurkacz",
                "Zawadzki",
                "Wysocki",
                "Sikora",
                "Sikora",
                "Zakrzewska",
                "Sikora",
                "Czarnecki",
                "Lewandowski",
                "Zalewski",
                "Sawicki",
                "Kucharski",
                "Krajewska",
                "Przybylski",
                "Kowalski",
                "Gajewska",
                "Mazur",
                "Bąk",
                "Sikora",
                "Sadowska",
                "Zawadzki",
                "Wiśniewski",
                "Kaczmarczyk",
                "Lis",
                "Bąk",
                "Kubiak",
                "Górecki",
                "Makowski",
                "Duda",
                "Przybylski",
                "Stępień",
                "Kamiński",
                "Kozłowski",
                "Błaszczyk",
                "Woźniak",
                "Szymański",
                "Malinowski",
                "Maciejewski",
                "Krajewska",
                "Jankowski",
                "Marciniak",
                "Kowalczyk",
                "Kucharski",
                "Marciniak",
                "Sokołowski",
                "Mazurek",
                "Przybylski",
                "Zakrzewska",
                "Kaczmarczyk",
                "Sawicki",
                "Brzeziński",
                "Sadowska",
                "Włodarczyk",
                "Woźniak",
                "Zawadzki",
                "Mazur",
                "Dąbrowski",
                "Michalak",
                "Stępień",
                "Dąbrowski",
                "Szulc",
                "Czerwiński",
                "Kaczmarczyk",
                "Sobczak",
                "Lis",
                "Sobczak",
                "Walczak",
                "Głowacka",
                "Kamiński",
                "Krawczyk",
                "Sikora",
                "Maciejewski",
                "Laskowska",
                "Michalak",
                "Głowacka",
                "Kucharski",
                "Kowalczyk",
                "Michalak",
                "Piotrowski",
                "Baranowski",
                "Gajewska",
                "Lis",
                "Pietrzak",
                "Ostrowski",
                "Głowacka",
                "Krajewska",
                "Ziółkowska",
                "Nowak",
                "Ziółkowska",
                "Gajewska",
                "Wróblewski",
                "Witkowski",
                "Wasilewska",
                "Sobczak",
                "Górecki",
                "Baranowski",
                "Zieliński",
                "Kubiak",
                "Górecki",
                "Kołodziej",
            };
        }
    }
}
