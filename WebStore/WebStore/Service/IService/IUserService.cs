using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Service.IService
{
    public interface IUserService
    {
        Task<ApiResponse<string>> Authenticate(string username, string password);

    }
}
