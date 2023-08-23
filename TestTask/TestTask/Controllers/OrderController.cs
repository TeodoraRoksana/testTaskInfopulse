using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.API.Models.DTO;
using TestTask.API.Models.Mapper;
using TestTask.API.Services.DBService;
using TestTask.Models;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IDBService _dBService;

        public OrderController(IDBService dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> getOrder()
        {
            return Ok(_dBService.getOrdersWithItems());
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderDTO>>> putOrder(OrderDTO order) 
        {
            _dBService.postOrder(order);
            _dBService.saveChengesInDB();
            
            return Ok(_dBService.getOrdersWithItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OrderDTO>>> deleteOrderById(int id)
        {
            _dBService.deleteOrderById(id);
            _dBService.saveChengesInDB();

            return Ok(_dBService.getOrdersWithItems());
        }
    }
}
