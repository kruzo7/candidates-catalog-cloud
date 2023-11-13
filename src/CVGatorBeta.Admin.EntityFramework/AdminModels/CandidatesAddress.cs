using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateAddressId", Name = "Index_CandidatesAddresses_1", IsUnique = true)]
    [Index("CandidateId", Name = "UQ__Candidat__DF539B9D80D53A1E", IsUnique = true)]
    public partial class CandidatesAddress : IEntityBase
    {
        [Key]
        public Guid CandidateAddressId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid CountryId { get; set; }
        [StringLength(500)]
        
        public string CityName { get; set; } = null!;
        [StringLength(500)]
        
        public string StreetName { get; set; } = null!;
        [StringLength(50)]
        
        public string StreetNumber { get; set; } = null!;
        [StringLength(50)]
        
        public string PostCode { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [ForeignKey("CandidateId")]
        [InverseProperty("CandidatesAddress")]
        public virtual Candidate Candidate { get; set; } = null!;
        [ForeignKey("CountryId")]
        [InverseProperty("CandidatesAddresses")]
        public virtual Country Country { get; set; } = null!;
    }
}
