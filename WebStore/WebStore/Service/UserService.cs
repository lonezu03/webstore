using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebStore.Reposiroty.Interface;
using WebStore.Service.IService;


namespace WebStore.Service
{ 

    
        public class UserService : IUserService
        {
            private readonly IUserRepository _userRepository;
            private readonly IConfiguration _configuration;

            public UserService(IUserRepository userRepository, IConfiguration configuration)
            {
                _userRepository = userRepository;
                _configuration = configuration;
            }

            public async Task<string> Authenticate(string username, string password)
            {
                var user = await _userRepository.GetUserByUsernameAndPassword(username, password);
                if (user == null) return null;

                // Tạo token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
}
    