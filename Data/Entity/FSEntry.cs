using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class FSEntry
    {
        public int Id { get; set; }
        public string PathCode { get; set; }
        public string FileName { get; set; }
        public string FileDesc { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUsedDate { get; set; }
        public string LastUsedUser { get; set; }
        public DateTime? LastDownloadDate { get; set; }
        public string LastDownloadUser { get; set; }
        public decimal GwdownloadStatus { get; set; }
        public decimal FileReadyYn { get; set; }
        public string Org { get; set; }
        public int? PrinterId { get; set; }
    }
}
