using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SisifoNotes.Lib.Services.Interfaces
{
    public interface ILoginService : IGenericService
    {
        User Authenticate(LoginRequest loginRequest);
    }
}
