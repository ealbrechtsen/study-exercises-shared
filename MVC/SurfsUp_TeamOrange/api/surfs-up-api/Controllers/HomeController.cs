using Microsoft.AspNetCore.Mvc;
using surfs_up_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace surfs_up_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        // Dependency injection af AppDbContext
        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: api/home
        [HttpGet]
        public IActionResult GetProducts()
        {
            // Henter listen af produkter fra databasen
            var products = _appDbContext.Products.ToList();

            if (products == null || !products.Any())
            {
                return NotFound(new { message = "No products found" });
            }

            // Returnerer produkterne som JSON
            return Ok(products);
        }
    }
}
