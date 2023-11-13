using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateCertificateId", Name = "Index_CandidatesCertificates_1", IsUnique = true)]
    public partial class CandidatesCertificate : IEntityBase
    {
        [Key]
        public Guid CandidateCertificateId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid CertificateId { get; set; }
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
        [InverseProperty("CandidatesCertificates")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("CertificateId")]
        [InverseProperty("CandidatesCertificates")]
        public virtual Certificate Certificate { get; set; } = null!;
    }
}
