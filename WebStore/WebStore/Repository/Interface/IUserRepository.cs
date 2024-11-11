using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Entity;

namespace WebStore.Reposiroty.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAndPassword(string username, string password);
    }
}
