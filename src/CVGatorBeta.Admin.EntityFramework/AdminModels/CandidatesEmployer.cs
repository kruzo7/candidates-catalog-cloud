using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidatesEmployersId", Name = "Index_CandidatesEmployers_1", IsUnique = true)]
    public partial class CandidatesEmployer : IEntityBase
    {
        [Key]
        public Guid CandidatesEmployersId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid EmployerId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        public short EmploymentStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [ForeignKey("CandidateId")]
        [InverseProperty("CandidatesEmployers")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("EmployerId")]
        [InverseProperty("CandidatesEmployers")]
        public virtual Employer Employer { get; set; } = null!;
    }
}
