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
using System.IO;

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
		public async Task<IActionResult> GetFiles(int fsEntriesID)
		{
			try
			{
				if (fsEntriesID == 0)
				{
					var result = await _fileDownloadService.GetFiles(fsEntriesID);
					if (result == null)
					{
						throw new ApiException($"No Files retrieved.",Status200OK);
					}
					else
					{
						return Ok(result);
					}

				}
				else
				{
					Stream fileData = await _fileDownloadService.GetFile(fsEntriesID);

					if (fileData == null)
					{
						throw new ApiException($"No Files retrieved.", Status200OK);
					}
					else
					{
						return new FileStreamResult(fileData, "application/octet-stream");
					}
				}
			}
			catch (Exception e)
			{
				throw new ApiException(e, Status422UnprocessableEntity);
			}
		}

	}
}
