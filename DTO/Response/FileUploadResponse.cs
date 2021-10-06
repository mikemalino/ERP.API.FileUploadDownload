using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.DTO.Response
{
	public class FileUploadResponse
	{
		public int FSEntriesID { get; set; }
		public string ImportType { get; set; }
		public string SourceFile_UPL { get; set; }
		public string Message { get; set; }
		public string LoadAndVerifyNoImportYN { get; set; }
		public IFormFile UploadedFile { get; set; }
	}
}
