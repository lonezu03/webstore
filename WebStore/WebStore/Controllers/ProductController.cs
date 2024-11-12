using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Context;
using WebStore.Entity;
using WebStore.Service.IService;


namespace ApiWebQuanAo.Web.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.Material)
                .Include(p => p.Gender)
                .ToListAsync();

            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            return Ok();
        }
        //cach khac
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    // Truy vấn danh sách sản phẩm bằng SQL query
        //    var products = await _context.Products.FromSqlRaw("SELECT TOP (1000) [Id], [Name], [Material_Id], [Gender_Id] FROM [dbo].[Product]").ToListAsync();

        //    if (products == null || !products.Any())
        //    {
        //        return NotFound("No products found.");
        //    }

        //    return Ok(products);
        //}

    }

}

