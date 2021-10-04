using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class Import
    {
        public int Id { get; set; }
        public string ImportType { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportSource { get; set; }
        public decimal ImportStatus { get; set; }
        public string SourceFile { get; set; }
        public string Message { get; set; }
        public int FsentriesId { get; set; }
        public decimal AsyncJobStatus { get; set; }
        public string AsyncJobName { get; set; }
        public int AsyncJobId { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUsedDate { get; set; }
        public string LastUsedUser { get; set; }
        public byte[] TimeStamp { get; set; }
        public decimal LoadAndVerifyNoImportYn { get; set; }
        public int ImportCount { get; set; }
        public int ProcessedCount { get; set; }
        public string MapName { get; set; }
        public string ImportIdentifier { get; set; }
        public string ParmFields { get; set; }
        public decimal Process997Yn { get; set; }
        public string MissingAttachmentFullPath { get; set; }
    }
}
