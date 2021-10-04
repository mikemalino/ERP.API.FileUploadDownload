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
    public class FSEntriesRepository : GenericRepository<FSEntry>
    {
        
        protected readonly IERPCommonData _erpCommonDataLookup;

        public FSEntriesRepository(ApplicationDbContext context, IMapper mapper, IERPCommonData erpCommonDataLookup) : base(context, mapper)
        {
            _erpCommonDataLookup = erpCommonDataLookup;
        }

        #region FSEntries CRUD Operations




        public IEnumerable<TResult> GetSavedEntities<TResult>()
        {
            var entitiesSaved = this._GetSavedEntities();
            return _mapper.Map<List<TResult>>(entitiesSaved);
        }

        #endregion

        #region IQueryable notes

        //public IQueryable<NoteRecordResponse> qNoteRecordResponse(int entityID, int entityType)
        //{
        //    var query = _noteRefRepo.Where(i => i.RefEntityId == entityID && i.RefType == entityType)
        //        //.Join(_dbSet,
        //        //    nref => nref.NoteId,
        //        //    note => note.Id,
        //        //    (nref, note) => new NoteRecordResponse(note)
        //       );

        //    return query;
        //}

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
