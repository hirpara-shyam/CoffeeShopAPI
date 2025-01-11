﻿using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        #region Get All City
        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _cityRepository.SelectAll();
            return Ok(cities);
        }
        #endregion

        #region Get City By ID
        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityRepository.SelectByPK(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        #endregion

        #region Delete City
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var isDeleted = _cityRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region Insert City
        [HttpPost]
        public IActionResult InsertCity([FromBody] CityModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }
            bool isInserted = _cityRepository.Insert(city);

            if (!isInserted)
            {
                return StatusCode(500, "An error occured while inserting the city.");
            }

            return Ok(new { Message = "City inserted successfully!" });
        }
        #endregion

        #region Update City
        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, [FromBody] CityModel city)
        {
            if(city == null || id != city.CityID)
            {
                return BadRequest();
            }

            var isUpdated = _cityRepository.Update(city);
            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion

        #region GetCountries
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var countries = _cityRepository.GetCountries();
            if (!countries.Any())
                return NotFound("No countries found.");

            return Ok(countries);
        }
        #endregion

        #region GetStatesByCountryID
        [HttpGet("states/{countryID}")]
        public IActionResult GetStatesByCountryID(int countryID)
        {
            if (countryID <= 0)
                return BadRequest("Invalid CountryID.");

            var states = _cityRepository.GetStatesByCountryID(countryID);
            if (!states.Any())
                return NotFound("No states found for the given CountryID.");

            return Ok(states);
        }
        #endregion
    }
}