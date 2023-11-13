using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateId", Name = "Index_Candidates_1", IsUnique = true)]
    public partial class Candidate : IEntityBase
    {
        public Candidate()
        {
            CandidatesCategories = new HashSet<CandidatesCategory>();
            CandidatesCertificates = new HashSet<CandidatesCertificate>();
            CandidatesCourses = new HashSet<CandidatesCourse>();
            CandidatesEmployers = new HashSet<CandidatesEmployer>();
            CandidatesSchools = new HashSet<CandidatesSchool>();
            CandidatesFiles = new HashSet<CandidatesFile>();
        }

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

        [InverseProperty("Candidate")]
        public virtual CandidatesAddress? CandidatesAddress { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesCategory> CandidatesCategories { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesCertificate> CandidatesCertificates { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesCourse> CandidatesCourses { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesEmployer> CandidatesEmployers { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesSchool> CandidatesSchools { get; set; }

        [InverseProperty("Candidate")]
        public virtual ICollection<CandidatesFile> CandidatesFiles { get; set; }
    }
}
