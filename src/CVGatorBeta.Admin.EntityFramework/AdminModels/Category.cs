using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CategoryId", Name = "Index_Categories_1", IsUnique = true)]
    public partial class Category : IEntityBase
    {
        public Category()
        {
            CandidatesCategories = new HashSet<CandidatesCategory>();
        }

        [Key]
        public Guid CategoryId { get; set; }
        [StringLength(500)]
        
        public string CategoryName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("Category")]
        public virtual ICollection<CandidatesCategory> CandidatesCategories { get; set; }
    }
}
