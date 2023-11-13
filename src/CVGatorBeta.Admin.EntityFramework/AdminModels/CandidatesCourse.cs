using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateCourseId", Name = "Index_CandidatesCourses_1", IsUnique = true)]
    public partial class CandidatesCourse : IEntityBase
    {
        [Key]
        public Guid CandidateCourseId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid CourseId { get; set; }
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
        [InverseProperty("CandidatesCourses")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("CourseId")]
        [InverseProperty("CandidatesCourses")]
        public virtual Course Course { get; set; } = null!;
    }
}
