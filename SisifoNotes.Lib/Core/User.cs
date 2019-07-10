using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Core
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
