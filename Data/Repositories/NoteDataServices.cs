using AutoMapper;

using Premier.API.FileUploadDownload.Data.Contexts;
using Premier.API.Core.Data.DataServices;
using System.Linq;
using Premier.API.FileUploadDownload.DTO.Response;

namespace Premier.API.FileUploadDownload.Data.Repositories
{
    public class NoteDataServices : DataServices
    {
        public NoteDataServices(ApplicationDbContext context, IMapper mapper) : base(context)
        {
        }
    }
}
