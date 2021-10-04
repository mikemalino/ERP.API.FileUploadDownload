using AutoMapper;
using Premier.API.Core.Data.Repositories;
using Premier.API.FileUploadDownload.Data.Contexts;
using Premier.API.FileUploadDownload.Data.Entity;
using Premier.API.FileUploadDownload.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.Data.UnitsOfWork
{

    public class NoteUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public FSEntriesRepository _noteRepository { get; }

        public NoteUnitOfWork(
            ApplicationDbContext context,
            FSEntriesRepository noteRepository
        ) : base(context)
        {
            _context = context;
            _noteRepository = noteRepository;
        }
    }
}
