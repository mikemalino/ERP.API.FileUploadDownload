using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class vPathCodes
    {
        public int Id { get; set; }
        public string PathCode { get; set; }
        public string Description { get; set; }
        public string FssubFolder { get; set; }
        public decimal GatewayEnabledYn { get; set; }
    }
}
