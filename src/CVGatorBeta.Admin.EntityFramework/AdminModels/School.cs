using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("SchoolId", Name = "Index_Schools_1", IsUnique = true)]
    public partial class School : IEntityBase
    {
        public School()
        {
            CandidatesSchools = new HashSet<CandidatesSchool>();
        }

        [Key]
        public Guid SchoolId { get; set; }
        [StringLength(1000)]
        
        public string SchoolName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("School")]
        public virtual ICollection<CandidatesSchool> CandidatesSchools { get; set; }
    }
}
