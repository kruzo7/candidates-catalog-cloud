using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateSchoolId", Name = "Index_CandidatesSchools_1", IsUnique = true)]
    public partial class CandidatesSchool : IEntityBase
    {
        [Key]
        public Guid CandidateSchoolId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid SchoolId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [ForeignKey("CandidateId")]
        [InverseProperty("CandidatesSchools")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("SchoolId")]
        [InverseProperty("CandidatesSchools")]
        public virtual School School { get; set; } = null!;
    }
}
