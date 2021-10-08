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
    //[Authorize]
    public class FileUploadController : PremierAPIControllerBase
    {
        private readonly FileUploadService _fileUploadService;

        public FileUploadController(FileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }


        [HttpPost]
        [ValidateModel]
        //[Authorize]
        [ProducesResponseType(typeof(FileUploadResponse), Status200OK)]
        public async Task<ApiResponse> UploadFile([FromForm] FileUploadRequest uploadFileRequest)
        {
            try
            {
                var result = await _fileUploadService.UploadAsync(uploadFileRequest);
                if (result != null)
                {
                    return new ApiResponse($"File Uploaded.", result);
				}
				else
				{
                    return new ApiResponse($"File not uploaded");
				}
            }
            catch (Exception e)
            {
                throw new ApiException(e, Status422UnprocessableEntity);
            }
        }

    }
}
