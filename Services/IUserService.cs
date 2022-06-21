using Machinego_Demo.DataAccesLayer;
using Machinego_Demo.Models;
using System;
using System.Linq;
using Machinego_Demo.DataAccesLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Machinego_Demo.Helpers;

namespace Machinego_Demo.Services
{
    public interface IUserService
    {
        public string LoginUser(LoginViewModel loginModel);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            this.userRepository = userRepository;
            _appSettings = appSettings.Value;
        }
        public string LoginUser(LoginViewModel loginModel)
        {
            var user = userRepository.List(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();
            if (user != null) {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddMinutes(180),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string generatedToken = tokenHandler.WriteToken(token);
                return generatedToken;
            }
            else
                return "Kullanıcı bulunamadı.";
           

        }
    }
}
