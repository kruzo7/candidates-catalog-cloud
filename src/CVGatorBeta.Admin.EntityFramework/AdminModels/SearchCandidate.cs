using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateId", Name = "Index_SearchCandidates_1", IsUnique = true)]
    public partial class SearchCandidate : IEntityBase
    {

        [Key]
        public Guid CandidateId { get; set; }

        [StringLength(500)]
        
        public string CandidateFirstName { get; set; } = null!;

        [StringLength(500)]
        
        public string CandidateLastName { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }

        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;

        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [StringLength(500)]
        public string CandidateCity { get; set; } = null!;
        
        public string CandidateCategories { get; set; } = null!;

        public string CandidateCertificates { get; set; } = null!;

        public string CandidateCourses { get; set; } = null!;

        public string CandidateEmployers { get; set; } = null!;
        
        [StringLength(4000)]
        public string CandidateActualEmployers { get; set; } = null!;

        public string CandidateSchools { get; set; } = null!;
    }
}
