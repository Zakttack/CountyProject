using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CountyApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountySeatsController : ControllerBase
    {
        private readonly ILogger<CountySeatsController> _logger;

        public CountySeatsController(ILogger<CountySeatsController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("CountySeatChange")]
        public IActionResult CountySeatChange(string selectedValue)
        {
            Service.CurrentEntry.SelectedCountySeat = selectedValue;
            return Ok();
        }
    }
}