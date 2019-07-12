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
    public class ClientsController : ControllerBase
    {
        private readonly ICrudService<Client> _clientsService;

        public ClientsController(ICrudService<Client> clientsService)
        {
            _clientsService = clientsService;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _clientsService.GetAll().ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            return await Task.Run(() =>
            {
                var client = _clientsService.GetAll().FirstOrDefault(x => x.Id == id);
                if (client == null)
                {
                    return NotFound();
                }
                return new ActionResult<Client>(client);
            });
        }

        // PUT: api/Clients/5
        [HttpPut]
        public async Task<ActionResult<Client>> PutClient(Client client)
        {
            return await Task.Run(() =>
            {
                var output = _clientsService.Update(client);
                return new ActionResult<Client>(output);
            });
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            return await Task.Run(() =>
            {
                var output = _clientsService.Add(client);
                return new ActionResult<Client>(output);
            });
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteClient(Guid id)
        {
            return await Task.Run(() =>
            {
                return _clientsService.Delete(id);
            });
        }

    }
}
