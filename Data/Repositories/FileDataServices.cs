using AutoMapper;

using Premier.API.FileUploadDownload.Data.Contexts;
using Premier.API.Core.Data.DataServices;
using System.Linq;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.API.FileUploadDownload.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Premier.API.FileUploadDownload.Data.Repositories
{
    public class FileDataServices : DataServices
    {
        public FileDataServices(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            
        }

        public async Task<vImportType> GetImportType(string ImportType)
		{
            return await _context.Set<vImportType>().Where(x => x.ImportType == ImportType).FirstOrDefaultAsync();
		}

        public async Task<string> GetImportTypeV2(string ImportType)
		{
            var param = new { ImportTypeValue = ImportType };
            var pathCode = await this.SQLQuerySingleAsync<string>("Select pathcode from vImportType where ImportType = @ImportTypeValue", param, System.Data.CommandType.Text);
            return pathCode;
		}
		public async Task<List<FileDownloadResponse>> GetFSEntryList(int FSEntriesID)
		{
            var param = new { fsEntriesID = FSEntriesID };
            return (List<FileDownloadResponse>)await SQLQueryAsync<FileDownloadResponse>("mcsp_API_FSEntries_Get", param, System.Data.CommandType.StoredProcedure);

			//return await _context.Set<FileDownloadResponse>().Where(x => x.FSEntriesID == FSEntriesID).FirstOrDefault();
		}
	}
}
