using CVGatorBeta.Admin.EntityFramework.AdminModels;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.ContextData
{
    public partial class CVGatorBetaAdminContext : DbContext
    {
        public CVGatorBetaAdminContext()
        {
        }

        public CVGatorBetaAdminContext(DbContextOptions<CVGatorBetaAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;
        public virtual DbSet<CandidatesAddress> CandidatesAddresses { get; set; } = null!;
        public virtual DbSet<CandidatesCategory> CandidatesCategories { get; set; } = null!;
        public virtual DbSet<CandidatesCertificate> CandidatesCertificates { get; set; } = null!;
        public virtual DbSet<CandidatesCourse> CandidatesCourses { get; set; } = null!;
        public virtual DbSet<CandidatesEmployer> CandidatesEmployers { get; set; } = null!;
        public virtual DbSet<CandidatesSchool> CandidatesSchools { get; set; } = null!;
        public virtual DbSet<CandidatesFile> CandidatesFiles { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CvGatorBetaMaintanance> CvGatorBetaMaintanances { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<CVGatorBeta.Admin.EntityFramework.AdminModels.File> Files { get; set; } = null!;
        public virtual DbSet<SearchCandidate> SearchCandidates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatesAddress>(entity =>
            {
                entity.HasKey(e => e.CandidateAddressId)
                    .HasName("PK__Candidat__CAD87B487B9786B9");


                entity.HasOne(d => d.Candidate)
                    .WithOne(p => p.CandidatesAddress)
                    .HasForeignKey<CandidatesAddress>(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesAddresses_Candidates");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CandidatesAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesAddresses_Countries");
            });

            modelBuilder.Entity<CandidatesCategory>(entity =>
            {
                entity.HasKey(e => e.CandidateCategoryId)
                    .HasName("PK__Candidat__C67764CCF6045066");



                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesCategories)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCategories_Candidates");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CandidatesCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCategories_Categories");
            });

            modelBuilder.Entity<CandidatesCertificate>(entity =>
            {
                entity.HasKey(e => e.CandidateCertificateId)
                    .HasName("PK__Candidat__308D4A8E8A759111");



                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesCertificates)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCertificates_Candidates");

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.CandidatesCertificates)
                    .HasForeignKey(d => d.CertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCertificates_Certificates");
            });

            modelBuilder.Entity<CandidatesCourse>(entity =>
            {
                entity.HasKey(e => e.CandidateCourseId)
                    .HasName("PK__Candidat__2882F6B8C50BD7CD");



                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesCourses)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCourses_Candidates");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CandidatesCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesCourses_Courses");
            });

            modelBuilder.Entity<CandidatesEmployer>(entity =>
            {
                entity.HasKey(e => e.CandidatesEmployersId)
                    .HasName("PK__Candidat__5FDF641BFB7F8FF9");



                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesEmployers)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesEmployers_Candidates");

                entity.HasOne(d => d.Employer)
                    .WithMany(p => p.CandidatesEmployers)
                    .HasForeignKey(d => d.EmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesEmployers_Employers");
            });

            modelBuilder.Entity<CandidatesSchool>(entity =>
            {
                entity.HasKey(e => e.CandidateSchoolId)
                    .HasName("PK__Candidat__CA36C7BF4FDF6E5C");



                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesSchools)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesSchools_Candidates");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.CandidatesSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesSchools_Schools");
            });

            modelBuilder.Entity<CandidatesFile>(entity =>
            {
                entity.HasKey(e => e.CandidateFileId)
                    .HasName("PK__Candidat__3C32F6F1FCCC2BE3");

                entity.HasOne(d => d.Candidate)
                    .WithMany(p => p.CandidatesFiles)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesFiles_Candidates");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.CandidatesFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatesFiles_Files");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
