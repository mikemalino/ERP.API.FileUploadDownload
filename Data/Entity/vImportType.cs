using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class vImportType
    {
        public int Id { get; set; }
        public string ImportType { get; set; }
        public string ImportTypeDesc { get; set; }
        public string PathCode { get; set; }
        public string HdrObmname { get; set; }
        public string HdrObmaction { get; set; }
        public string HdrTranTable { get; set; }
        public string HdrTranTableId { get; set; }
        public string DtlObmname { get; set; }
        public string DtlObmaction { get; set; }
        public string DtlTranTable { get; set; }
        public string DtlTranTableId { get; set; }
        public string HdrDtlLinkField { get; set; }
        public string TransFormObmname { get; set; }
        public string TransFormObmaction { get; set; }
        public decimal TransFormOnlyYn { get; set; }
        public decimal CustomImportYn { get; set; }
        public int MaxErrorThreshold { get; set; }
        public decimal ImportFileFormat { get; set; }
        public string BaseImportType { get; set; }
        public string XdtlObmname { get; set; }
        public string XdtlObmaction { get; set; }
        public string XdtlTranTable { get; set; }
        public string XdltTranTableId { get; set; }
        public string XdtlLinkField { get; set; }
        public string XdtlDftEditView { get; set; }
        public string DtlTranTableOvr { get; set; }
        public string DtlTranTableOvrObm { get; set; }
        public string DtlTranTableOvrObmaction { get; set; }
        public string DtlOvrLinkField { get; set; }
        public string HdrOvrField { get; set; }
        public string DltTranTableOvrId { get; set; }
    }
}
