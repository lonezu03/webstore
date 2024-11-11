using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Context;
using WebStore.Entity;
using WebStore.Models;
using WebStore.Reposiroty.Interface;


namespace WebStore.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        }
        public async Task<ApiResponse<string>> Authenticate(string username, string password)
        {
            // Retrieve the user based on username and password
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return new ApiResponse<string>(false, "Authentication failed. Invalid username or password.", null);
            }

            // If user exists, return success with an appropriate message (e.g., user ID or username as the token)
            return new ApiResponse<string>(true, "Authentication successful", user.Username);
        }

    }
}
