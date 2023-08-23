using Microsoft.AspNetCore.Mvc;
using TestTask.API.Services.DBService;
using TestTask.Models;

namespace TestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IDBService _dBService;

        public ProductsController(IDBService dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> getProducts()
        {
            return Ok(_dBService.getProductsWithItems());
        }
    }
}
