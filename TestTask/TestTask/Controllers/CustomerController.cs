using Microsoft.AspNetCore.Mvc;
using TestTask.API.Models.DTO;
using TestTask.API.Services.DBService;
using TestTask.Models;

namespace TestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private IDBService _dBService;

        public CustomerController(IDBService dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getCustomers()
        {
            
            return Ok(_dBService.GetCustomers());
        }
    }
}
