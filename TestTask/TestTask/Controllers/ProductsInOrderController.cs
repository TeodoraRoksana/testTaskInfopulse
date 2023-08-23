using Microsoft.AspNetCore.Mvc;
using TestTask.API.Services.DBService;
using TestTask.Models;

namespace TestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsInOrderController : Controller
    {
        private IDBService _dBService;

        public ProductsInOrderController(IDBService dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderProduct>>> getOrdersInProducts()
        {
            return Ok(_dBService.getProductsInOrderWithItems());
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderProduct>>> postProductInOrder(OrderProduct product)
        {
            _dBService.postProductInOrder(product);
            _dBService.saveChengesInDB();

            return Ok(_dBService.getProductsInOrderWithItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OrderProduct>>> deleteProductInOrderById(int id)
        {
            _dBService.deleteProductInOrderById(id);
            _dBService.saveChengesInDB();

            return Ok(_dBService.getProductsInOrderWithItems());
        }
    }
}
