using Microsoft.AspNetCore.Mvc;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Models;
using SisifoNotes.Lib.Services.Dtos;
using SisifoNotes.Lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace SisifoNotes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IRegisterService _registerService { get; set; }

        public RegisterController (IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<RegisterResponse> Post([FromBody] RegisterRequest registerRequest)
        {
            return await Task.Run(() =>
            {
                return _registerService.Register(registerRequest);
            });
        }
    }
}
