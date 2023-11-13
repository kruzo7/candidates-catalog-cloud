using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CourseId", Name = "Index_Courses_1", IsUnique = true)]
    public partial class Course : IEntityBase
    {
        public Course()
        {
            CandidatesCourses = new HashSet<CandidatesCourse>();
        }

        [Key]
        public Guid CourseId { get; set; }
        [StringLength(1000)]
        
        public string CourseName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("Course")]
        public virtual ICollection<CandidatesCourse> CandidatesCourses { get; set; }
    }
}
