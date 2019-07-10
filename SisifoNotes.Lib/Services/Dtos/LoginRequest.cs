using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Services.Dtos
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
