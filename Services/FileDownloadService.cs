using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Dapper;

using AutoMapper;
using AutoWrapper.Wrappers;

using static Microsoft.AspNetCore.Http.StatusCodes;

using Premier.API.FileUploadDownload.DTO.Request;
using Premier.API.FileUploadDownload.Data.Repositories;

using Newtonsoft.Json;

using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Linq;
using Premier.API.FileUploadDownload.Data.UnitsOfWork;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.CommonData.Core;
using Premier.API.Core.Util;
using Premier.API.FileUploadDownload.Data.Entity;
using Premier.API.Core.Data.Entity;
using System.Collections.Generic;
using Premier.API.FileUploadDownload.Services;
using Microsoft.EntityFrameworkCore;
using Premier.API.Core.Authentication.Helpers;
using System.IO;
using Premier.API.Core.Services;

namespace Premier.API.FileUploadDownload.Services
{
	public class FileDownloadService : IBaseService
	{
		private readonly IMapper _mapper;
		private readonly ILogger<FileDownloadService> _logger;

		private readonly FSEntriesUnitOfWork _fsEntriesUnitOfWork;
		private readonly FSEntriesRepository _fsEntriesRepository;

		private readonly iHTTPContextHelper _HTTPContextHelper;
		private readonly FileDataServices _fileDataServices;

		public FileDownloadService(
					IMapper mapper,
					iHTTPContextHelper HTTPContextHelper,
					FSEntriesUnitOfWork fsEntriesUnitOfWork,
					FSEntriesRepository fsEntriesRepository,
					ILogger<FileDownloadService> logger,
					FileDataServices fileDataServices
				)
		{
			_mapper = mapper;
			_logger = logger;

			_fsEntriesUnitOfWork = fsEntriesUnitOfWork;
			_fsEntriesRepository = fsEntriesRepository;

			_HTTPContextHelper = HTTPContextHelper;
			_fileDataServices = fileDataServices;

			_logger.LogInformation("Service Created");
		}

		//public async Task<NoteRecordResponse> InsertAsync(FileUploadRequest fileUploadRequest)
		//{
		//    _noteUnitOfWork.CreateTransaction();

		//    try
		//    {
		//        _noteRepository.InsertNote(noteInsertRequest);
		//        int recordsAdds = await _noteUnitOfWork.CompleteAsync();
		//        _noteUnitOfWork.Commit();

		//        return _noteRepository.GetSavedEntities<NoteRecordResponse>().FirstOrDefault();
		//    }
		//    catch (Exception e)
		//    {
		//        _noteUnitOfWork.Rollback();
		//        throw e;
		//    }
		//}

		public async Task<IEnumerable<FileDownloadResponse>> GetFiles(int fsEntriesID)
		{
			var result = await _fileDataServices.GetFSEntryList(fsEntriesID);
			return result;
		}


		//public async Task<List<NoteRecordResponse>> GetNotesByEntityID(int entityID, int entityType)
		//{
		//    var result = await _noteRepository.qNoteRecordResponse(entityID, entityType).ToListAsync();
		//    return result;
		//}
	}
}