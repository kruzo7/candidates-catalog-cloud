using AutoMapper;
using CVGatorBeta.Admin.BusinessLogic.CQRS.Commnads.Candidates;
using CVGatorBeta.Admin.EntityFramework.AdminModels;
using CVGatorBeta.Admin.EntityFramework.ContextData;
using CVGatorBeta.Admin.EntityFramework.Extensions;

namespace CVGatorBeta.Application.Initialize.TestData
{
    public class TestDataMain
    {
        private readonly CVGatorBetaAdminContext _context;
        private readonly IMapper _mapper;
        private readonly CancellationToken _cancellationToken;

        private readonly Candidates _candidates;
        private readonly Categories _categories;
        private readonly Certificates _certificates;
        private readonly Countries _countries;
        private readonly Courses _courses;
        private readonly Employers _employers;
        private readonly Schools _schools;

        public TestDataMain(CVGatorBetaAdminContext context, IMapper mapper, CancellationToken cancellationToken)
        {
            _context = context;
            _mapper = mapper;
            _cancellationToken = cancellationToken;

            _candidates = new Candidates();
            _categories = new Categories();
            _certificates = new Certificates();
            _countries = new Countries();
            _courses = new Courses();
            _employers = new Employers();
            _schools = new Schools();
        }
        public async Task InserSampleDataToApplication()
        {
            var countries = _countries.GetCountries();
            var categories = _categories.CreateSampleData();
            var schools = _schools.CreateSampleData();
            var certificates = _certificates.CreateSampleData();
            var courses = _courses.CreateSampleData();
            var employers = _employers.CreateSampleData();

            await AddBaseData(categories, schools, certificates, courses, employers, countries);

            var sampleAddresses = _countries.CreateSampleData(countries);
            var candidates = _candidates.CreateSampleData(categories, certificates, courses, employers, schools, sampleAddresses);

            await AddCandidates(candidates);
        }
        private async Task AddBaseData(List<Category> categories, List<School> schools, List<Certificate> certificates, List<Course> courses, List<Employer> employers, List<Country> countries)
        {
            _context.Countries.AddRange(countries);
            _context.Categories.AddRange(categories);
            _context.Schools.AddRange(schools);
            _context.Certificates.AddRange(certificates);
            _context.Courses.AddRange(courses);
            _context.Employers.AddRange(employers);

            _context.ChangeTracker.AddAudit();

            await _context.SaveChangesAsync();
        }
        private async Task AddCandidates(List<Candidate> candidates)
        {
            var createCommand = new CreateCandidateCommandHandler(_context, _mapper);

            foreach (var candidate in candidates)
            {
                await createCommand.CreateCandidate(candidate, _cancellationToken);
            }
        }
    }
}
