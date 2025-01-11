using CoffeeShopAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class DropDownController : ControllerBase
	{
		private readonly DropDownRepository _dropDownRepository;
		public DropDownController(DropDownRepository dropDownRepository)
		{
			_dropDownRepository = dropDownRepository;
		}

		#region User Drop Down
		[HttpGet]
		public IActionResult GetUserDropDown()
		{
			var users = _dropDownRepository.UserDropDown();
			return Ok(users);
		}
		#endregion

		#region Order Drop Down
		[HttpGet]
		public IActionResult GetOrderDropDown()
		{
			var orders = _dropDownRepository.OrderDropDown();
			return Ok(orders);
		}
		#endregion

		#region Customer Drop Down
		[HttpGet]
		public IActionResult GetCustomerDropDown()
		{
			var customers = _dropDownRepository.CustomerDropDown();
			return Ok(customers);
		}
		#endregion

		#region Product Drop Down
		[HttpGet]
		public IActionResult GetProductDropDown()
		{
			var products = _dropDownRepository.ProductDropDown();
			return Ok(products);
		}
        #endregion

        #region City Drop Down
        [HttpGet]
        public IActionResult GetCityDropDown()
        {
            var cities = _dropDownRepository.CityDropDown();
            return Ok(cities);
        }
        #endregion

        #region State Drop Down
        [HttpGet]
        public IActionResult GetStateDropDown()
        {
            var states = _dropDownRepository.StateDropDown();
            return Ok(states);
        }
        #endregion

        #region Country Drop Down
        [HttpGet]
        public IActionResult GetCountryDropDown()
        {
            var countries = _dropDownRepository.CountryDropDown();
            return Ok(countries);
        }
        #endregion
    }
}
