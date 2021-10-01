using System;
using System.Linq;
using System.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Premier.API.Core.Contracts;
using Premier.API.FileUploadDownload.Data.Contexts;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;


namespace Premier.API.FileUploadDownload.Services
{
    public interface IBaseService { }




    public abstract class BaseService_Data<TEntity> : IBaseService
        where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext _ApplicationDbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        

        public BaseService_Data(ApplicationDbContext ApplicationDbContext, IMapper mapper, ILogger logger)
        {
            _ApplicationDbContext = ApplicationDbContext;
            _mapper = mapper;
            _logger = logger;
        }
    }

    public abstract class BaseService<TEntity> : IBaseService
         where TEntity : class, IEntity
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public BaseService(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

    }
}
