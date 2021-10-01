namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    public class NoteConfig : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> entity)
        {
            entity.ToTable("Notes");

            entity.Property(e => e.Id)
                .HasColumnName("ID");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");

            entity.Property(e => e.CreateUser)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.Property(e => e.ModifiedUser)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

            entity.Property(e => e.NoteText)
                .IsRequired()
                .HasColumnName("NoteText");

            entity.Property(e => e.NoteDate).HasColumnType("datetime");

            entity.Property(e => e.TimeStamp)
                .IsRequired()
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }
}