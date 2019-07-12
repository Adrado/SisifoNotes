using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Models
{
    public class Task : Note
    {
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High,
        Urgent
    }
}
