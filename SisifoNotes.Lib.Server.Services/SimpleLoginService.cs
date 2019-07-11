using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.Services.Dtos;
using SisifoNotes.Lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Server.Services
{
    public class SimpleLoginService : ILoginService
    {
        IRepository<User> UsersRepository { get; set; }
        
        public SimpleLoginService(IRepository<User> usersRepository)
        {
            UsersRepository = usersRepository;
        }

        public virtual User Authenticate(LoginRequest loginRequest)
        {
            var user = UsersRepository.GetAll().FirstOrDefault(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            return user;
        }
    }
}
