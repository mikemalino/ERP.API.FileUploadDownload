using Microsoft.AspNetCore.Http;

namespace Premier.API.FileUploadDownload.DTO.Request
{
    public class FileUploadRequest
    {
		public string ImportType { get; set; }
		public string SourceFile_UPL { get; set; }
		public string Message { get; set; }
		public string ImportTypeDesc { get; set; }
		public string LoadAndVerifyNoImportYN { get; set; }
		public IFormFile UploadedFile { get; set; }
	}
}