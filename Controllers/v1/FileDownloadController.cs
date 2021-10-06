using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Premier.API.Core.Infrastructure.Controllers;
using Premier.API.Core.Infrastructure.Filters;
using Premier.API.Core.Infrastructure.Extensions;

using Premier.API.FileUploadDownload.DTO.Request;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.API.FileUploadDownload.DTO.QueryParams;
using Premier.API.FileUploadDownload.Services;


using AutoWrapper.Wrappers;

using static Microsoft.AspNetCore.Http.StatusCodes;

using Serilog;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Premier.API.FileUploadDownload.Data.Entity;

namespace Premier.API.FileUploadDownload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileDownloadController : PremierAPIControllerBase
    {
        private readonly FileDownloadService _fileDownloadService;

        public FileDownloadController(FileDownloadService fileDownloadService)
        {
            _fileDownloadService = fileDownloadService;
        }


		[HttpGet]
		[ValidateModel]
		[Authorize]
		[ProducesResponseType(typeof(FileDownloadResponse), Status200OK)]
		public async Task<ApiResponse> GetFiles(int fsEntriesID)
		{
			try
			{
				var result = await _fileDownloadService.GetFiles(fsEntriesID);
				if (result != null)
				{
					return new ApiResponse(result);
				}
				else
				{
					return new ApiResponse($"No Files retrieved.");
				}
			}
			catch (Exception e)
			{
				throw new ApiException(e, Status422UnprocessableEntity);
			}
		}

		//[HttpPost("upload")]
		//[ProducesResponseType(typeof(ApiResponse), Status201Created)]
		//[ProducesResponseType(typeof(ApiResponse), Status422UnprocessableEntity)]
		//[ProducesResponseType(typeof(ApiResponse), Status400BadRequest)]
		//public async Task<ApiResponse> UploadFile([FromForm] FileUploadRequest createFileUploadRequest)
		//{
		//    try
		//    {
		//        var fileUpload = _mapper.Map<FileUpload>(createFileUploadRequest);
		//        var returnval = await _fileUploadService.UploadAsync(fileUpload);

		//        //return Ok(new { files.Count, size = FileService.SizeConverter(files.Sum(files => files.length))});
		//        return await Task.FromResult(new ApiResponse("Record Successfully Created", null, Status201Created));
		//    }
		//    catch (Exception ex)
		//    {
		//        throw new ApiException($"File Upload Failed {ex.Message}",Status400BadRequest);

		//    }
		//}

		//[HttpPost]
		//[ValidateModel]
		//[Authorize]
		//[ProducesResponseType(typeof(NoteRecordResponse), Status200OK)]
		//[Route("updatenotetext")]
		//public async Task<ApiResponse> UpdateNoteText([FromBody] NoteUpdateRequest noteUpdateRequest)
		//{
		//    try
		//    {
		//        return new ApiResponse($"Note text updated.", await _notesAPIService.UpdateNoteText(noteUpdateRequest));
		//    }
		//    catch (Exception e)
		//    {
		//        throw new ApiException(e, Status422UnprocessableEntity);
		//    }
		//}

		//[HttpDelete]
		//[Authorize]
		//[ProducesResponseType(typeof(int), Status200OK)]
		//[Route("deletenotetext/{notesID}")]
		//public async Task<ApiResponse> DeleteNoteText(int notesID)
		//{
		//    try
		//    {
		//        int result = await _notesAPIService.DeleteNoteText(notesID);

		//        if (result > 0)
		//            return new ApiResponse($"Note text ID ({notesID}) deleted.", result, 200);
		//        else
		//            return new ApiResponse($"Note ID ({notesID}) not found.", result, 200);
		//    }
		//    catch (Exception e)
		//    {
		//        throw new ApiException(e, Status422UnprocessableEntity);
		//    }
		//}

		//[HttpGet]
		//[Authorize]
		//[ProducesResponseType(typeof(List<NoteRecordResponse>), Status200OK)]
		//[Route("GetByEntityID/{entityID}/type/{entityType}")]
		//public async Task<ApiResponse> GetNotesByEntityID(int entityID, int entityType)
		//{
		//    return new ApiResponse(await _notesAPIService.GetNotesByEntityID(entityID, entityType));
		//}
	}
}
