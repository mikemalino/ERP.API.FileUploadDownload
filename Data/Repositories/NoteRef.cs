using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Premier.CommonData.Core;

using Premier.API.Core.Data.Repositories;
using Premier.API.FileUploadDownload.Data.Contexts;
using Premier.API.FileUploadDownload.Data.Entity;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.API.FileUploadDownload.DTO.Request;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.Data.Repositories
{
    public class NoteRefRepository : GenericRepository<NoteRef>
    {
        //protected readonly IERPNACommonDataLookup _erpNACommonDataLookup;

        //public NoteRefRepository(ApplicationDbContext context, IMapper mapper, IERPNACommonDataLookup erpNACommonDataLookup) : base(context, mapper)
        //{
        //    _erpNACommonDataLookup = erpNACommonDataLookup;
        //}
    }
}
