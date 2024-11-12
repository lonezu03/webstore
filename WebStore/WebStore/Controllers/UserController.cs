using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Context;
using WebStore.Entity;
using WebStore.Service.IService;


namespace ApiWebQuanAo.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
            
        private readonly IUserService _userService;

        private readonly ApplicationDbContext _context;

        // Constructor nhận DbContext từ DI container
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    // Truy vấn danh sách sản phẩm bằng SQL query
        //    var products = await _context.Products.FromSqlRaw("SELECT TOP (1000) [Id], [Name], [MaterialId], [GenderId] FROM [dbo].[Products]").ToListAsync();

        //    if (products == null || !products.Any())
        //    {
        //        return NotFound("No products found.");
        //    }

        //    return Ok(products);
        //}
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // Truy vấn danh sách người dùng theo SQL query
            var users = await _context.Users.FromSqlRaw("SELECT TOP (1000) [id], [username], [email], [password] FROM [dbo].[Users]").ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }
    }

}

