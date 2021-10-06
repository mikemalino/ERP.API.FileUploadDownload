namespace Premier.API.FileUploadDownload.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Premier.API.FileUploadDownload.Data.Entity;

    public class vImportConfig : IEntityTypeConfiguration<vImportType>
    {
        public void Configure(EntityTypeBuilder<vImportType> entity)
        {
            entity.HasNoKey();

            entity.ToView("vImportType");

            entity.Property(e => e.BaseImportType)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.CustomImportYn)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("CustomImportYN");

            entity.Property(e => e.DltTranTableOvrId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DltTranTableOvrID");

            entity.Property(e => e.DtlObmaction)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DtlOBMAction");

            entity.Property(e => e.DtlObmname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DtlOBMName");

            entity.Property(e => e.DtlOvrLinkField)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.DtlTranTable)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.DtlTranTableId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("DtlTranTableID");

            entity.Property(e => e.DtlTranTableOvr)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.DtlTranTableOvrObm)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DtlTranTableOvrOBM");

            entity.Property(e => e.DtlTranTableOvrObmaction)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("DtlTranTableOvrOBMAction");

            entity.Property(e => e.HdrDtlLinkField)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.HdrObmaction)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("HdrOBMAction");

            entity.Property(e => e.HdrObmname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HdrOBMName");

            entity.Property(e => e.HdrOvrField)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.HdrTranTable)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.Property(e => e.HdrTranTableId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("HdrTranTableID");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.ImportFileFormat).HasColumnType("numeric(1, 0)");

            entity.Property(e => e.ImportType)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.ImportTypeDesc)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PathCode)
                .HasMaxLength(2)
                .IsUnicode(false);

            entity.Property(e => e.TransFormObmaction)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("TransFormOBMAction");

            entity.Property(e => e.TransFormObmname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TransFormOBMName");

            entity.Property(e => e.TransFormOnlyYn)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("TransFormOnlyYN");

            entity.Property(e => e.XdltTranTableId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("XDltTranTableID");

            entity.Property(e => e.XdtlDftEditView)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("XDtlDftEditView");

            entity.Property(e => e.XdtlLinkField)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("XDtlLinkField");

            entity.Property(e => e.XdtlObmaction)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("XDtlOBMAction");

            entity.Property(e => e.XdtlObmname)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("XDtlOBMName");

            entity.Property(e => e.XdtlTranTable)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("XDtlTranTable");

        }
    }
}