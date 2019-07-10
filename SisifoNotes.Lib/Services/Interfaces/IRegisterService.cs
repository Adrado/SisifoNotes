using SisifoNotes.Lib.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Services.Interfaces
{
    public interface IRegisterService
    {
        RegisterResponse Register(RegisterRequest registerRequest);
    }
}
