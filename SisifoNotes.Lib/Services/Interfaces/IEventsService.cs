using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Services.Interfaces
{
    public interface IEventsService
    {
        IQueryable<Event> EventsFromClient(Guid guid);
    }
}
