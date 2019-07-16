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
        public async Task<ActionResult<Event>> GetEvent(Guid id)
        {
            return await Task.Run(() =>
            {
                var client = _clientsService.GetAll().FirstOrDefault(x => x.Id = id);
                if (client == null)
                {
                    return NotFound();
                }
                return new ActionResult<Client>(client);
            });
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(Guid id, Event event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(Guid id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return @event;
        }

        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
