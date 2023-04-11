using CountyLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountyApplication.Controllers
{
    public class StateController : Controller
    {
        [HttpGet]
        [Route("api/State/GetStateNames")]
        public IEnumerable<State> GetStateNames()
        {
            return Service.CountyService.States;
        }
        [HttpPost]
        [Route("api/State/SetSelectedState")]
        public IActionResult SetSelectedState(State selectedState)
        {
            Service.SelectedState = selectedState;
            return Ok();
        }
    }
}