using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Premier.CommonData.ERPCommonData;

using Premier.API.Core.Data.Repositories;
using Premier.API.FileUploadDownload.Data.Contexts;
using Premier.API.FileUploadDownload.Data.Entity;
using Premier.API.FileUploadDownload.DTO.Response;
using Premier.API.FileUploadDownload.DTO.Request;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Premier.API.FileUploadDownload.Data.Repositories
{
    public class NoteRepository : GenericRepository<Note>
    {
        public NoteRefRepository _noteRefRepo { get; }

        protected readonly IERPCommonData _erpCommonDataLookup;

        public NoteRepository(ApplicationDbContext context, IMapper mapper, NoteRefRepository noteRefRepo, IERPCommonData erpCommonDataLookup) : base(context, mapper)
        {
            _noteRefRepo = noteRefRepo;
            _erpCommonDataLookup = erpCommonDataLookup;
        }

        #region FSEntries CRUD Operations

        public EntityEntry InsertFSEntries(FileUploadRequest fileUploadRequest)
        {
            FileUpload item = _mapper.Map<FileUpload>(fileUploadRequest);
            //item.NoteDate = DateTime.UtcNow;
            //item.NoteRefs.Add(new NoteRef() { RefEntityId = noteInsertRequest.EntityID, RefType = noteInsertRequest.EntityType });
            //return this.Insert(item);
        }

        public void UpdateNoteText(NoteUpdateRequest noteUpdateRequest)
        {
            Note note = this.GetByPK(noteUpdateRequest.NoteID);
            note.NoteText = noteUpdateRequest.NoteText;

            var fields = new Expression<Func<Note, object>>[]
            {
                i => i.NoteText
            };

            this.UpdateFields(note, fields);
        }

        public void DeleteNoteText(int notesID)
        {            
            try
            {
                this._noteRefRepo.RemoveRange(this._noteRefRepo.Where(n => n.NoteId == notesID));
                this.Remove(notesID);
            }
            catch (Exception e)
            {                
                throw e;
            }            
        }

        public IEnumerable<TResult> GetSavedEntities<TResult>()
        {
            var entitiesSaved = this._GetSavedEntities();
            return _mapper.Map<List<TResult>>(entitiesSaved);
        }

        #endregion

        #region IQueryable notes

        public IQueryable<NoteRecordResponse> qNoteRecordResponse(int entityID, int entityType)
        {
            var query = _noteRefRepo.Where(i => i.RefEntityId == entityID && i.RefType == entityType)
                .Join(_dbSet,
                    nref => nref.NoteId,
                    note => note.Id,
                    (nref, note) => new NoteRecordResponse(note)
               );

            return query;
        }

        #endregion

        /*
        public EntityEntry InsertNotespingCart(NotespingCart cart)
        {
            var entityResult = this.Insert(cart);
            return entityResult;
        }

        public async Task<EntityEntry> UpdateNotespingCart(NotespingCartUpdateRequest request)
        {
            var entityResult = await this.UpdateAsync(_mapper.Map<NotespingCart>(request));
            return entityResult;
        }

        public IEnumerable<TResult> GetSavedEntities<TResult>()
        {
            var entitiesSaved = this._GetSavedEntities();
            return _mapper.Map<List<TResult>>(entitiesSaved);
        }

        public void DeleteCart(int cartID)
        {
            this._scLineRepo.RemoveRange(this._scLineRepo.Where(i => i.NotespingCartId == cartID));
            this.Remove(cartID);
        }
        */
    }
}
