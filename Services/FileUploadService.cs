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

namespace Premier.API.FileUploadDownload.Services
{
    public class FileUploadService : IBaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FileUploadService> _logger;

        private readonly NoteUnitOfWork _noteUnitOfWork;
        private readonly NoteRepository _noteRepository;
        private readonly NoteDataServices _noteDataServices;

        private readonly iHTTPContextHelper _HTTPContextHelper;

        public FileUploadService(
                    IMapper mapper,
                    iHTTPContextHelper HTTPContextHelper,
                    NoteUnitOfWork noteUnitOfWork,
                    NoteRepository noteRepository,
                    NoteDataServices noteDataServices,
                    ILogger<FileUploadService> logger
                )
        {
            _mapper = mapper;
            _logger = logger;

            _noteUnitOfWork = noteUnitOfWork;
            _noteRepository = noteRepository;
            _noteDataServices = noteDataServices;

            _HTTPContextHelper = HTTPContextHelper;

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

        public async Task<bool> UploadAsync(FileUploadRequest fileUpload)
        {
            // TO DO:
            /* 1) Create Stored Procedure to insert records into Import and FSEntries Tables
			 * 2) Get resulting FSEntriesID and Filepath 
			 * 3) Call FileIO on Frameworks passing the above Filepath
			 * 4) Return Success/Failure
			 *    a) SP Failure
			 *    b) File Save Failure
			 * 
			 * 
			 * 
			 */
            try
            {
                #region variables
                string sqlProcedure = "mcsp_API_FSEntries_Add";
                string dbconnectionstring = _config.GetConnectionString("SQLDBConnectionString");
                DbFactory myFactory = new DbFactory(dbconnectionstring);
                DynamicParameters sqlParameters = new DynamicParameters();
                string[] fileParts = fileUpload.UploadedFile.FileName.Split('.');
                string fileUploadName = fileParts[0] + "_" + DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + "." + fileParts[1];

                #endregion

                #region Call SQL stored proc
                sqlParameters.Add("ImportType", fileUpload.ImportType);
                sqlParameters.Add("FileName", fileUploadName);
                sqlParameters.Add("CreateUser", fileUpload.UserID);
                sqlParameters.Add("Org", "200"); //Hardcoded for POC
                var returnData = await myFactory.DbQueryAsyncWithRetry<string>(fileUpload.CustomerID, sqlProcedure, sqlParameters, System.Data.CommandType.StoredProcedure);
                #endregion

                string fsSubRoot = "";
                foreach (var item in returnData)
                {
                    fsSubRoot = item.ToString();
                }

                MemoryStream myStream = new MemoryStream();
                fileUpload.UploadedFile.CopyTo(myStream);
                FileIO fileIO = new FileIO();
                return await fileIO.SaveFile(myStream, fileUploadName, myFactory.customerRecordInfo.FSRoot + fsSubRoot);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<NoteRecordResponse> UpdateNoteText(NoteUpdateRequest noteUpdateRequest)
        //{
        //    _noteUnitOfWork.CreateTransaction();

        //    try
        //    {  
        //        _noteRepository.UpdateNoteText(noteUpdateRequest);
        //        int recordsUpdated = await _noteUnitOfWork.CompleteAsync();
        //        _noteUnitOfWork.Commit();

        //        return _noteRepository.GetSavedEntities<NoteRecordResponse>().FirstOrDefault();
        //    }
        //    catch (Exception e)
        //    {
        //        _noteUnitOfWork.Rollback();
        //        throw e;
        //    }
        //}

        //public async Task<int> DeleteNoteText(int notesID)
        //{
        //    _noteUnitOfWork.CreateTransaction();
        //    int result = 0;
        //    try
        //    {
        //        _noteUnitOfWork._noteRepository.DeleteNoteText(notesID);
        //        result = await _noteUnitOfWork.CompleteAsync();
        //        _noteUnitOfWork.Commit();
        //    }
        //    catch (Exception e)
        //    {
        //        _noteUnitOfWork.Rollback();
        //        throw e;
        //    }
        //    return result;
        //}

        //public async Task<List<NoteRecordResponse>> GetNotesByEntityID(int entityID, int entityType)
        //{
        //    var result = await _noteRepository.qNoteRecordResponse(entityID, entityType).ToListAsync();
        //    return result;
        //}
    }
}