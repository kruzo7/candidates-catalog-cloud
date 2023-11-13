﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CertificateId", Name = "Index_Certificates_1", IsUnique = true)]
    public partial class Certificate : IEntityBase
    {
        public Certificate()
        {
            CandidatesCertificates = new HashSet<CandidatesCertificate>();
        }

        [Key]
        public Guid CertificateId { get; set; }
        [StringLength(1000)]
        
        public string CertificateName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("Certificate")]
        public virtual ICollection<CandidatesCertificate> CandidatesCertificates { get; set; }
    }
}
