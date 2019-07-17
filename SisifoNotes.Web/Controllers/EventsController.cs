using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.DA.EFCore;
using SisifoNotes.Lib.Models;
using Task = System.Threading.Tasks.Task;

namespace SisifoNotes.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ICrudService<Event> _eventsService;

        public EventsController(ICrudService<Event> eventsService)
        {
            _eventsService = eventsService;
        }


        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _eventsService.GetAll().ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvent(Guid id)
        {
            return await _eventsService.GetAll().Where(x => x.ClientId == id).ToListAsync();
        }

        [HttpPut]
        public async Task<ActionResult<Event>> PutEvent(Event @event)
        {
            return await Task.Run(() =>
            {
                var output = _eventsService.Update(@event);
                return new ActionResult<Event>(output);
            });
        }

        [HttpPost]
        public async Task<ActionResult<Event>> PostClient(Event @event)
        {
            return await Task.Run(() =>
            {
                var output = _eventsService.Add(@event);
                return new ActionResult<Event>(output);
            });
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteClient(Guid id)
        {
            return await Task.Run(() =>
            {
                return _eventsService.Delete(id);
            });
        }
    }
}
