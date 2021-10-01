using Microsoft.AspNetCore.Http;

namespace Premier.API.FileUploadDownload.Data.Entity
{
	public class FileUpload
	{
		public string CustomerID { get; set; }
		public string UserID { get; set; }
		public string ImportType { get; set; }
		public string SourceFile_UPL { get; set; }
		public string Message { get; set; }
		public string LoadAndVerifyNoImportYN { get; set; }
		public IFormFile UploadedFile { get; set; }
	}
}
