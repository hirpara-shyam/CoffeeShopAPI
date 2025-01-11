using CoffeeShopAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShopAPI.Data
{
	public class OrderRepository
	{
		private readonly string _connectionString;
		public OrderRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString");
		}

		#region Select All Order
		public IEnumerable<OrderModel> SelectAll()
		{
			List<OrderModel> orders = new List<OrderModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_SelectAll", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read())
				{
					orders.Add(new OrderModel()
					{
						OrderID = Convert.ToInt32(reader["OrderID"]),
						//OrderNumber = reader["OrderNumber"].ToString(),
						OrderDate = Convert.ToDateTime(reader["OrderDate"]),
						CustomerID = Convert.ToInt32(reader["CustomerID"]),
						CustomerName = reader["CustomerName"].ToString(),
						PaymentMode = reader["PaymentMode"].ToString(),
						TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
						ShippingAddress = reader["ShippingAddress"].ToString(),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					});
				}
			}
			return orders;
		}
		#endregion

		#region Select Order By ID
		public OrderModel SelectByPK(int OrderID)
		{
			OrderModel? order = null;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_SelectByID", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderID", OrderID);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					order = new OrderModel()
					{
						OrderID = Convert.ToInt32(reader["OrderID"]),
						//OrderNumber = reader["OrderNumber"].ToString(),
						OrderDate = Convert.ToDateTime(reader["OrderDate"]),
						CustomerID = Convert.ToInt32(reader["CustomerID"]),
						CustomerName = reader["CustomerName"].ToString(),
						PaymentMode = reader["PaymentMode"].ToString(),
						TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
						ShippingAddress = reader["ShippingAddress"].ToString(),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					};
				}
			}
			return order;
		}
		#endregion

		#region Insert Order
		public bool Insert(OrderModel orderModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_Insert", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderDate", orderModel.OrderDate);
				//command.Parameters.AddWithValue("OrderNumber", orderModel.OrderNumber);
				command.Parameters.AddWithValue("CustomerID", orderModel.CustomerID);
				command.Parameters.AddWithValue("TotalAmount", orderModel.TotalAmount);
				command.Parameters.AddWithValue("PaymentMode", orderModel.PaymentMode);
				command.Parameters.AddWithValue("ShippingAddress", orderModel.ShippingAddress);
				command.Parameters.AddWithValue("UserID", orderModel.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion

		#region Update Order
		public bool Update(OrderModel orderModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_Update", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderID", orderModel.OrderID);
				command.Parameters.AddWithValue("OrderDate", orderModel.OrderDate);
				//command.Parameters.AddWithValue("OrderNumber", orderModel.OrderNumber);
				command.Parameters.AddWithValue("CustomerID", orderModel.CustomerID);
				command.Parameters.AddWithValue("TotalAmount", orderModel.TotalAmount);
				command.Parameters.AddWithValue("PaymentMode", orderModel.PaymentMode);
				command.Parameters.AddWithValue("ShippingAddress", orderModel.ShippingAddress);
				command.Parameters.AddWithValue("UserID", orderModel.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion

		#region Delete Order
		public bool Delete(int OrderID)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_Delete", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderID", OrderID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion
	}
}
