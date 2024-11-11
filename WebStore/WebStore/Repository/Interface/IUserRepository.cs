using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entity;
using WebStore.Models;

namespace WebStore.Reposiroty.Interface
{
    public interface IUserRepository
    {
        Task<ApiResponse<string>> Authenticate(string username, string password);
        Task<User> GetUserByUsernameAndPassword(string username, string password);
    }
}
