using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StateRepository _stateRepository;

        public StateController(StateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        #region Get all State
        [HttpGet]
        public IActionResult GetAllStates()
        {
            var states = _stateRepository.SelectAll();
            return Ok(states);
        }
        #endregion

        #region Get State by ID
        [HttpGet("{id}")]
        public IActionResult GetStateById(int id)
        {
            var state = _stateRepository.SelectByPK(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
        #endregion

        #region Delete State
        [HttpDelete("{id}")]
        public IActionResult DeleteState(int id)
        {
            var isDeleted = _stateRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Insert State
        [HttpPost]
        public IActionResult InsertState([FromBody] StateModel state)
        {
            if (state == null)
            {
                return BadRequest();
            }
            bool isInserted = _stateRepository.Insert(state);

            if (!isInserted)
            {
                return StatusCode(500, "An error occured while inserting the state.");
            }

            return Ok(new { Message = "State inserted successfully!" });
        }
        #endregion

        #region Update State
        [HttpPut("{id}")]
        public IActionResult UpdateState(int id, [FromBody] StateModel state)
        {
            if (state == null)
            {
                return BadRequest();
            }

            var isUpdated = _stateRepository.Update(state);
            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion

        #region Get states by Country ID
        [HttpGet("states/{countryID}")]
        public IActionResult GetStatesByCountryID(int countryID)
        {
            if (countryID <= 0)
                return BadRequest("Invalid CountryID.");

            var states = _stateRepository.GetStatesByCountryID(countryID);
            if (!states.Any())
                return NotFound("No states found for the given CountryID.");

            return Ok(states);
        }
        #endregion
    }
}
