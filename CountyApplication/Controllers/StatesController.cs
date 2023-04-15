using CountyLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountyApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("StateChange")]
        public IActionResult StateChange(State selectedValue)
        {
            Service.SelectedState = selectedValue;
            return Ok();
        }
        [HttpPost]
        [Route("StateNotFound")]
        public IActionResult StateNotFound()
        {
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}
