using SisifoNotes.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore.ModelsDbSets
{
    public class NotesDbSet : SisifoNotesDbSet<Note>
    {
        public NotesDbSet(SisifoNotesContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Notes;
        }
    }
}
