using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateCategoryId", Name = "Index_CandidatesCategories_1", IsUnique = true)]
    public partial class CandidatesCategory : IEntityBase
    {
        [Key]
        public Guid CandidateCategoryId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CandidateId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [ForeignKey("CandidateId")]
        [InverseProperty("CandidatesCategories")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("CategoryId")]
        [InverseProperty("CandidatesCategories")]
        public virtual Category Category { get; set; } = null!;
    }
}
