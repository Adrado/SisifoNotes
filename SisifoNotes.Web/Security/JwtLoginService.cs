using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SisifoNotes.Lib.Core;
using SisifoNotes.Lib.Core.Interfaces;
using SisifoNotes.Lib.Server.Services;
using SisifoNotes.Lib.Services.Dtos;
using SisifoNotes.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SisifoNotes.Web.Security
{
    public class JwtLoginService : SimpleLoginService
    {
        private readonly AppSettings _appSettings;

        public JwtLoginService(IRepository<User> usersRepository, IOptions<AppSettings> appSettings)
            : base (usersRepository)
        {
            _appSettings = appSettings.Value;
        }

        public override User Authenticate(LoginRequest loginRequest)
        {
            var user = base.Authenticate(loginRequest);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.GetType().Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
