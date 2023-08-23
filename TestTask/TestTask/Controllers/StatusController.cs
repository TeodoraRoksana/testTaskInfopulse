using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.API.Models.DTO;
using TestTask.API.Models.Mapper;
using TestTask.API.Services.DBService;
using TestTask.Models;

namespace TestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private IDBService _dBService;

        public StatusController(IDBService dBService)
        {
            _dBService = dBService;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetStatuses()
        {
            return Ok(_dBService.getStatuses());
        }
    }
}
