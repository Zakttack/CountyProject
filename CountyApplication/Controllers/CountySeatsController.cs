using CountyLibrary.Models;
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
        public IActionResult CountySeatChange(SelectedCountySeatView selectedValue)
        {
            TestEntry entry = Service.TestEntries[selectedValue.IndexLocation];
            entry.SelectedCountySeat = selectedValue.CountySeatName;
            return Ok();
        }
    }
}