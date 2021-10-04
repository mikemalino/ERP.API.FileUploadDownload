using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class FSEntryContext : DbContext
    {
        public FSEntryContext()
        {
        }

        public FSEntryContext(DbContextOptions<FSEntryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fsentry> Fsentries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=C3DIPBDB02;Initial Catalog=EM_Dev_Master;Integrated Security=SSPI;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Fsentry>(entity =>
            {
                entity.ToTable("FSEntries");

                entity.HasIndex(e => new { e.GwdownloadStatus, e.FileReadyYn }, "IX_FSEntries_GWDownloadStatus_FileReadyYN")
                    .HasFillFactor((byte)85);

                entity.HasIndex(e => new { e.PathCode, e.GwdownloadStatus, e.FileReadyYn, e.Org }, "IX_FSEntries_PathCode_GWDowloadStatus_FileReadyYN_Org");

                entity.HasIndex(e => new { e.PathCode, e.FileName }, "IX_PathCode_FileName")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.FileReadyYn)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("FileReadyYN");

                entity.Property(e => e.GwdownloadStatus)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("GWDownloadStatus");

                entity.Property(e => e.LastDownloadDate).HasColumnType("datetime");

                entity.Property(e => e.LastDownloadUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastUsedDate).HasColumnType("datetime");

                entity.Property(e => e.LastUsedUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Org)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PathCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrinterId).HasColumnName("PrinterID");

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
