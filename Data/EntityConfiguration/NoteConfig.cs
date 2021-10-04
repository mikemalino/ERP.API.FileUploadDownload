namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    public class FSEntryConfig : IEntityTypeConfiguration<FSEntry>
    {
        public void Configure(EntityTypeBuilder<FSEntry> entity)
        {
            entity.ToTable("FSEntry");

            entity.Property(e => e.Id)
                .HasColumnName("ID");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.Property(e => e.CreateUser)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreateUser).HasColumnName("CreateUser");

            entity.Property(e => e.LastUsedDate).HasColumnType("datetime");

            entity.Property(e => e.LastUsedUser)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.LastUsedUser).HasColumnName("LastUsedUser");


        }
    }
}