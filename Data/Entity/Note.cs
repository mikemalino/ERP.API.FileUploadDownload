using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class Note
    {
        public Note()
        {
            NoteRefs = new HashSet<NoteRef>();
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
        public virtual ICollection<NoteRef> NoteRefs { get; set; }
    }
}
