namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    public class FSEntriesConfig : IEntityTypeConfiguration<FSEntry>
    {
        public void Configure(EntityTypeBuilder<FSEntry> entity)
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


        }
    }
}