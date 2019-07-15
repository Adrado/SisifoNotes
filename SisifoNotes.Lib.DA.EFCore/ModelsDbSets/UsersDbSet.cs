using SisifoNotes.Lib.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.DA.EFCore.ModelsDbSets
{
    public class UsersDbSet : SisifoNotesDbSet<User>
    {
        public UsersDbSet(SisifoNotesContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Users;
        }
    }
}
