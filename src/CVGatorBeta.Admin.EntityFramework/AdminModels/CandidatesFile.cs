using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("CandidateFileId", Name = "Index_CandidatesFiles_1", IsUnique = true)]
    public partial class CandidatesFile : IEntityBase
    {
        [Key]
        public Guid CandidateFileId { get; set; }

        public Guid FileId { get; set; }

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
        [InverseProperty("CandidatesFiles")]
        public virtual Candidate Candidate { get; set; } = null!;
        
        [ForeignKey("FileId")]
        [InverseProperty("CandidatesFiles")]
        public virtual File File { get; set; } = null!;
    }
}
