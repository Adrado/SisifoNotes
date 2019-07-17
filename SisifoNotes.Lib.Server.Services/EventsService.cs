using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Models;
using SisifoNotes.Lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Server.Services
{
    public class EventsService : IEventsService
    {
        public IRepository<Client> ClientsRepository { get; set; }
        public IRepository<Event> EventsRepository { get; set; }

        public EventsService (IRepository<Client> clientsRepository, IRepository<Event> eventsRespository)
        {
            ClientsRepository = clientsRepository;
            EventsRepository = eventsRespository;
        }
        public IQueryable<Event> EventsFromClient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
