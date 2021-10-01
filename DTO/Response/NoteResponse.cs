using Premier.API.FileUploadDownload.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Premier.API.FileUploadDownload.DTO.Response
{
    public partial class NoteRecordResponse
    {
        public NoteRecordResponse() { }

        public NoteRecordResponse(Note note)
        {
            this.Id = note.Id;
            this.NoteType = note.NoteType;
            this.NoteDate = note.NoteDate;
            this.NoteText = note.NoteText;
            this.CreateDate = note.CreateDate;
            this.CreateUser = note.CreateUser;
            this.CreateUserId = note.CreateUserId;
            this.TimeStamp = note.TimeStamp;
        }

        public int Id { get; set; }
        public short NoteType { get; set; }
        public DateTime NoteDate { get; set; }
        public string NoteText { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public int CreateUserId { get; set; }
        public string ModifiedUser { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
