using Newtonsoft.Json;
using SisifoNotes.Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Models
{
    public class Client : User
    {
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }
        public List<Guid> NotesIds
        {
            get
            {
                return Notes == null ? new List<Guid>() : Notes.Select(x => x.Id).ToList();
            }
        }
    }
}
