using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Models
{
    public class Event : Note
    {
        public DateTime DateInit { get; set; }
        public DateTime DateFinish { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        
    }
}
