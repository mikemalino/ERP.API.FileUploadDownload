using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class ImportContext : DbContext
    {
        public ImportContext()
        {
        }

        public ImportContext(DbContextOptions<ImportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Import> Imports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=C3DIPBDB02;Initial Catalog=EM_Dev_Master;Integrated Security=SSPI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Import>(entity =>
            {
                entity.ToTable("Import");

                entity.HasIndex(e => e.CreateDate, "IX_Import_CreateDate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AsyncJobId).HasColumnName("AsyncJobID");

                entity.Property(e => e.AsyncJobName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AsyncJobStatus).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FsentriesId).HasColumnName("FSEntriesID");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImportIdentifier)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImportSource)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ImportStatus)
                    .HasColumnType("numeric(1, 0)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.ImportType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastUsedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUsedUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoadAndVerifyNoImportYn)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("LoadAndVerifyNoImportYN");

                entity.Property(e => e.MapName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MissingAttachmentFullPath)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParmFields)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Process997Yn)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("Process997YN");

                entity.Property(e => e.SourceFile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
