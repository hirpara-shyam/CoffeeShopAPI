using CoffeeShopAPI.Data;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class OrderDetailController : ControllerBase
	{
		private readonly OrderDetailRepository _orderDetailRepository;

		public OrderDetailController(OrderDetailRepository orderDetailRepository)
		{
			_orderDetailRepository = orderDetailRepository;
		}

		#region Get All OrderDetails
		[HttpGet]
		public IActionResult GetAllOrderDetails()
		{
			var orderDetails = _orderDetailRepository.SelectAll();
			return Ok(orderDetails);
		}
		#endregion

		#region Get OrderDetail By ID
		[HttpGet("{id}")]
		public IActionResult GetOrderDetailByID(int id)
		{
			var orderDetail = _orderDetailRepository.SelectByPK(id);
			if (orderDetail == null)
			{
				return NotFound();
			}
			return Ok(orderDetail);
		}
		#endregion

		#region Insert OrderDetail
		[HttpPost]
		public IActionResult InsertOrderDetail([FromBody] OrderDetailModel orderDetailModel)
		{
			if (orderDetailModel == null) return BadRequest();
			bool isInserted = _orderDetailRepository.Insert(orderDetailModel);
			if (isInserted) return Ok(new { Message = "Order Detail Inserted Successfully" });
			return StatusCode(500, "Error occurred while inserting order detail.");
		}
		#endregion

		#region Update OrderDetail
		[HttpPut("{id}")]
		public IActionResult UpdateOrderDetail(int id, [FromBody] OrderDetailModel orderDetailModel)
		{
			if (orderDetailModel == null || id != orderDetailModel.OrderDetailID) return BadRequest();
			bool isUpdated = _orderDetailRepository.Update(orderDetailModel);
			if (isUpdated) return Ok(new { Message = "Order Detail Updated Successfully" });
			return NoContent();
		}
		#endregion

		#region Delete OrderDetail
		[HttpDelete("{id}")]
		public IActionResult DeleteOrderDetail(int id)
		{
			var isDeleted = _orderDetailRepository.Delete(id);
			if (!isDeleted)
			{
				return NotFound();
			}
			return NoContent();
		}
		#endregion
	}
}
