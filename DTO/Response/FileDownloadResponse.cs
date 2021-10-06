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
		public string fsSubFolder { get; set; }
		public string createDate { get; set; }
		public string fsRoot { get; set; }

	}
}
