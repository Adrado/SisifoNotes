using SisifoNotes.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore.ModelsDbSets
{
    public class ClientsDbSet : SisifoNotesDbSet<Client>
    {
        public ClientsDbSet(SisifoNotesContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Clients;
        }
    }
}
