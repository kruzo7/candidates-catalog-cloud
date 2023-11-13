using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("EmployerId", Name = "Index_Employers_1")]
    public partial class Employer : IEntityBase
    {
        public Employer()
        {
            CandidatesEmployers = new HashSet<CandidatesEmployer>();
        }

        [Key]        
        public Guid EmployerId { get; set; }
        [StringLength(1000)]
        
        public string EmployerName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("Employer")]
        public virtual ICollection<CandidatesEmployer> CandidatesEmployers { get; set; }
    }
}
