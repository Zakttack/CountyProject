using CountyLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountyApplication.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        [HttpGet("api/states")]
        public IEnumerable<string> GetStates()
        {
            ICollection<string> stateNames = new HashSet<string>();
            foreach (State state in Service.CountyService.States)
            {
                stateNames.Add(state.StateName);
            }
            return stateNames;
        }
        [HttpPost("api/selectedstate")]
        public IActionResult SetSelectedState([FromBody] string stateName)
        {
            Service.SelectedState = new State(stateName);
            return Ok();
        }
    }
}