using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;

        public CountryController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        #region Get all Country
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _countryRepository.SelectAll();
            return Ok(countries);
        }
        #endregion

        #region Get Country by ID
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.SelectByPK(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        #endregion

        #region Delete Country
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var isDeleted = _countryRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Insert Country
        [HttpPost]
        public IActionResult InsertCountry([FromBody] CountryModel country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            bool isInserted = _countryRepository.Insert(country);

            if (!isInserted)
            {
                return StatusCode(500, "An error occured while inserting the country.");
                
            }

            return Ok(new { Message = "Country inserted successfully!" });
        }
        #endregion

        #region Update Country
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, [FromBody] CountryModel country)
        {
            if (country == null || id != country.CountryID)
            {
                return BadRequest();
            }

            var isUpdated = _countryRepository.Update(country);
            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion

        #region Get Country for DropDown
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();
            if (!countries.Any())
                return NotFound("No countries found.");

            return Ok(countries);
        }
        #endregion

    }
}
