using System;
using System.Collections.Generic;

#nullable disable

namespace Premier.API.FileUploadDownload.Data.Entity
{
    public partial class NoteRef
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public short RefType { get; set; }
        public int RefEntityId { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public int CreateUserId { get; set; }
        public string ModifiedUser { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Note Note { get; set; }
    }
}
