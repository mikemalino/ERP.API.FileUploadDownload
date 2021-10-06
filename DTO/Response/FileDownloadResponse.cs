using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.DTO.Response
{
	public class FileDownloadResponse
	{
		public int FSEntriesID { get; set; }
		public string FileName { get; set; }
		public string fsSubFolder { get; set; }
		public string PathCode { get; set; }
		public string Description { get; set; }
		public string createDate { get; set; }

	}
}
