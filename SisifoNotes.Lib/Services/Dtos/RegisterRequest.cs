using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Services.Dtos
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
