using Bogus.Demo.Data;
using Bogus.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bogus.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("fake")]
        public IActionResult GetFakeProduct()
        {
            return Ok(Product.Fake().Generate(1).FirstOrDefault());
        }
    }
}
