using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Models
{
    public class List : Note
    {
        public ICollection<Item> Items { get; set; }
    }
}
