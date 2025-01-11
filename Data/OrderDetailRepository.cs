using CoffeeShopAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShopAPI.Data
{
	public class OrderDetailRepository
	{
		private readonly string _connectionString;

		public OrderDetailRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString");
		}

		#region Select All OrderDetails
		public IEnumerable<OrderDetailModel> SelectAll()
		{
			var orderDetails = new List<OrderDetailModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_OrderDetail_SelectAll", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					orderDetails.Add(new OrderDetailModel
					{
						OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
						OrderID = Convert.ToInt32(reader["OrderID"]),
						ProductID = Convert.ToInt32(reader["ProductID"]),
						ProductName = reader["ProductName"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						Amount = Convert.ToDecimal(reader["Amount"]),
						TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					});
				}
			}
			return orderDetails;
		}
		#endregion

		#region Select OrderDetail By ID
		public OrderDetailModel SelectByPK(int orderDetailID)
		{
			OrderDetailModel? orderDetail = null;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_OrderDetail_SelectByID", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderDetailID", orderDetailID);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					orderDetail = new OrderDetailModel
					{
						OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
						OrderID = Convert.ToInt32(reader["OrderID"]),
						ProductID = Convert.ToInt32(reader["ProductID"]),
						ProductName = reader["ProductName"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						Amount = Convert.ToDecimal(reader["Amount"]),
						TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					};
				}
			}
			return orderDetail;
		}
		#endregion

		#region Insert OrderDetail
		public bool Insert(OrderDetailModel orderDetailModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_OrderDetail_Insert", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderID", orderDetailModel.OrderID);
				command.Parameters.AddWithValue("ProductID", orderDetailModel.ProductID);
				command.Parameters.AddWithValue("Quantity", orderDetailModel.Quantity);
				command.Parameters.AddWithValue("Amount", orderDetailModel.Amount);
				command.Parameters.AddWithValue("TotalAmount", orderDetailModel.TotalAmount);
				command.Parameters.AddWithValue("UserID", orderDetailModel.UserID);
				connection.Open();
				int affectedRows = command.ExecuteNonQuery();
				return affectedRows > 0;
			}
		}
		#endregion

		#region Update OrderDetail
		public bool Update(OrderDetailModel orderDetailModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_OrderDetail_Update", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderDetailID", orderDetailModel.OrderDetailID);
				command.Parameters.AddWithValue("OrderID", orderDetailModel.OrderID);
				command.Parameters.AddWithValue("ProductID", orderDetailModel.ProductID);
				command.Parameters.AddWithValue("Quantity", orderDetailModel.Quantity);
				command.Parameters.AddWithValue("Amount", orderDetailModel.Amount);
				command.Parameters.AddWithValue("TotalAmount", orderDetailModel.TotalAmount);
				command.Parameters.AddWithValue("UserID", orderDetailModel.UserID);
				connection.Open();
				int affectedRows = command.ExecuteNonQuery();
				return affectedRows > 0;
			}
		}
		#endregion

		#region Delete OrderDetail
		public bool Delete(int orderDetailID)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_OrderDetail_Delete", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("OrderDetailID", orderDetailID);
				connection.Open();
				int affectedRows = command.ExecuteNonQuery();
				return affectedRows > 0;
			}
		}
		#endregion
	}
}
