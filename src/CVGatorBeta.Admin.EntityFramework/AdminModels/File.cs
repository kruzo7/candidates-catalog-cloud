using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CVGatorBeta.Admin.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Index("FileId", Name = "Index_Files_1", IsUnique = true)]
    public partial class File : IEntityBase
    {
        public File()
        {
            CandidatesFiles = new HashSet<CandidatesFile>();
        }

        [Key]
        public Guid FileId { get; set; }
        
        public Guid CandidateId { get; set; }

        [StringLength(1000)]
        public string FileName { get; set; } = null!;

        [StringLength(1000)]
        public string CautionUserFileName { get; set; } = null!;
                
        public int? FileResource { get; set; }
                
        public int? FileType { get; set; }

        [StringLength(1000)]
        public string? MimeContentType { get; set; } = null!;
                
        public int? UploadFileStatus { get; set; }

        [StringLength(4000)]
        public string? Message { get; set; } = null!;

        [StringLength(2000)]
        public string? Url { get; set; } = null!;

        [StringLength(2000)]
        public string? BlobUrl { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime AudCreateOn { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime AudModifyOn { get; set; }
        
        [StringLength(250)]
        public string AudCreateBy { get; set; } = null!;
        
        [StringLength(250)]
        public string AudModifyBy { get; set; } = null!;

        [InverseProperty("File")]
        public virtual ICollection<CandidatesFile> CandidatesFiles { get; set; }
    }
}
