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
				var result = (dynamic)null;
				if (fsEntriesID == 0)
				{
					result = await _fileDownloadService.GetFiles(fsEntriesID);
				}
				else
				{
					result = await _fileDownloadService.GetFile(fsEntriesID);
				}
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

	}
}
