using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.Models;
using SisifoNotes.Lib.Services.Dtos;
using SisifoNotes.Lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SisifoNotes.Lib.Server.Services
{
    public class RegisterService : IRegisterService
    {
        public ILoginService LoginService { get; set; }

        public IRepository<Client> ClientsRepository { get; set; }
        public RegisterService (IRepository<Client> clientsRepository, ILoginService loginService)
        {
            ClientsRepository = clientsRepository;
            LoginService = loginService;
        }

        public virtual RegisterResponse Register(RegisterRequest registerRequest)
        {
            var output = new RegisterResponse();
            if (string.IsNullOrEmpty(registerRequest.Email))
            {
                output.Status = RegisterResponseStatus.MissingEmail;
            }
            else if (!registerRequest.Email.Contains("@"))
            {
                output.Status = RegisterResponseStatus.WrongEmail;
            }
            else if (string.IsNullOrEmpty(registerRequest.Password))
            {
                output.Status = RegisterResponseStatus.MissingPassword;
            }
            else if (registerRequest.Password.Length < 4)
            {
                output.Status = RegisterResponseStatus.PasswordInsecure;
            }

            var client = ClientsRepository.GetAll().FirstOrDefault(x => x.Email == registerRequest.Email);
            if (client != null)
            {
                output.Status = RegisterResponseStatus.UserWithEmailAlreadyExists;
            }
            else
            {
                client = new Client
                {
                    Email = registerRequest.Email,
                    Password = registerRequest.Password
                };

                ClientsRepository.Add(client);
                output.Status = RegisterResponseStatus.Ok;

                var loginRequest = new LoginRequest()
                {
                    Email = registerRequest.Email,
                    Password = registerRequest.Password
                };
                output.Client = LoginService.Authenticate(loginRequest) as Client;
            }
            return output;
        }
    }
}
