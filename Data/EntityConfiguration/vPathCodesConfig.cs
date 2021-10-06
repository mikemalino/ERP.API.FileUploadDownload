namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    public class vPathCodesConfig : IEntityTypeConfiguration<vPathCodes>
    {
        public void Configure(EntityTypeBuilder<vPathCodes> entity)
        {
            entity.HasNoKey();

            entity.ToView("vPathCodes");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.FssubFolder)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FSSubFolder");

            entity.Property(e => e.GatewayEnabledYn)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("GatewayEnabledYN");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.Property(e => e.PathCode)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

        }
    }
}