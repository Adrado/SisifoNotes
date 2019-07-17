using SisifoNotes.Lib.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Models
{
    public class Note : Entity
    {
        public string Title { get; set; }
        public Guid ClientId { get; set; }
    }
}
