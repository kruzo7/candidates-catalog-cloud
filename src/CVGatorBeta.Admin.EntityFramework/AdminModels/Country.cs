using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CountryId", Name = "Index_Countries_1", IsUnique = true)]
    public partial class Country : IEntityBase
    {
        public Country()
        {
            CandidatesAddresses = new HashSet<CandidatesAddress>();
        }

        [Key]
        public Guid CountryId { get; set; }
        [StringLength(500)]
        
        public string CountryName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        [StringLength(250)]
        
        public string AudCreateBy { get; set; } = null!;
        [StringLength(250)]
        
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("Country")]
        public virtual ICollection<CandidatesAddress> CandidatesAddresses { get; set; }
    }
}
