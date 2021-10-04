namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    //public class NoteRefConfig : IEntityTypeConfiguration<NoteRef>
    //{
    //    public void Configure(EntityTypeBuilder<NoteRef> entity)
    //    {
    //        entity.ToTable("NoteRefs");

    //        entity.Property(e => e.Id)
    //            .HasColumnName("ID");

    //        entity.Property(e => e.CreateDate).HasColumnType("datetime");

    //        entity.Property(e => e.CreateUser)
    //            .IsRequired()
    //            .HasMaxLength(20)
    //            .IsUnicode(false);

    //        entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

    //        entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

    //        entity.Property(e => e.ModifiedUser)
    //            .HasMaxLength(20)
    //            .IsUnicode(false);

    //        entity.Property(e => e.ModifiedUserId).HasColumnName("ModifiedUserID");

    //        entity.Property(e => e.NoteId).HasColumnName("NoteID");

    //        entity.Property(e => e.RefEntityId).HasColumnName("RefEntityID");

    //        entity.HasOne(d => d.Note)
    //            .WithMany(p => p.NoteRefs)
    //            .HasForeignKey(d => d.NoteId)
    //            .OnDelete(DeleteBehavior.ClientSetNull);
    //    }
    //}
}