using SisifoNotes.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore.ModelsDbSets
{
    public class EventsDbSet : SisifoNotesDbSet<Event>
    {
        public EventsDbSet(SisifoNotesContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Events;
        }
    }
}
