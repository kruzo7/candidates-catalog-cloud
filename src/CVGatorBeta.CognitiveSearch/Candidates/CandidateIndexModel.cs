using Azure.Search.Documents.Indexes;

namespace CVGatorBeta.CognitiveSearch.Candidates
{

    public partial class CandidateIndexModel
    {
        [SimpleField(IsKey = true)]
        public string CandidateId { get; set; } = null!;

        [SearchableField(IsFilterable = true, IsSortable = true)]
        public string CandidateFirstName { get; set; } = null!;

        [SearchableField(IsFilterable = true, IsSortable = true)]
        public string CandidateLastName { get; set; } = null!;

        [SimpleField()]
        public DateTimeOffset BirthDate { get; set; }

        [SearchableField(IsFilterable = true, IsSortable = true)]
        public string CandidateCity { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateCategories { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateEmployers { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateActualEmployers { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateCourses { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateCertificates { get; set; } = null!;

        [SearchableField(IsFilterable = true)]
        public string[] CandidateSchools { get; set; } = null!;
    }
}
