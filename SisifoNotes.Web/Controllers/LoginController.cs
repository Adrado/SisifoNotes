using Microsoft.AspNetCore.Mvc;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Services.Dtos;
using SisifoNotes.Lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisifoNotes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService { get; set; }

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<User> Post([FromBody] LoginRequest loginRequest)
        {
            return await Task.Run(() =>
            {
                return _loginService.Authenticate(loginRequest);
            });
        }
    }
}
