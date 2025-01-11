using CoffeeShopAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CoffeeShopAPI.Data
{
	public class CustomerRepository
	{
		private readonly string _connectionString;
		public CustomerRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString");
		}

		#region Select All Customer
		public IEnumerable<CustomerModel> GetAllCustomer()
		{
			List<CustomerModel> customers = new List<CustomerModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_SelectAll", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					customers.Add(new CustomerModel
					{
						CustomerID = Convert.ToInt32(reader["CustomerID"]),
						CustomerName = reader["CustomerName"].ToString(),
						HomeAddress = reader["HomeAddress"].ToString(),
						Email = reader["Email"].ToString(),
						MobileNo = reader["MobileNO"].ToString(),
						GSTNo = reader["GST_NO"].ToString(),
						CityName = reader["CityName"].ToString(),
						PinCode = reader["PinCode"].ToString(),
						NetAmount = Convert.ToInt32(reader["NetAmount"]),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					});
				}
			}
			return customers;
		}
		#endregion

		#region Select Customer By ID
		public CustomerModel GetCustomerByPK(int CustomerID)
		{
			CustomerModel? customer = null;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_SelectByID", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("CustomerID", CustomerID);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if (reader.Read())
				{
					customer = new CustomerModel
					{
						CustomerID = Convert.ToInt32(reader["CustomerID"]),
						CustomerName = reader["CustomerName"].ToString(),
						HomeAddress = reader["HomeAddress"].ToString(),
						Email = reader["Email"].ToString(),
						MobileNo = reader["MobileNO"].ToString(),
						GSTNo = reader["GST_NO"].ToString(),
						CityName = reader["CityName"].ToString(),
						PinCode = reader["PinCode"].ToString(),
						NetAmount = Convert.ToInt32(reader["NetAmount"]),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					};
				}
			}
			return customer;
		}
		#endregion

		#region Insert Customer
		public bool Insert(CustomerModel customer)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_Insert", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("CustomerName", customer.CustomerName);
				command.Parameters.AddWithValue("HomeAddress", customer.HomeAddress);
				command.Parameters.AddWithValue("Email", customer.Email);
				command.Parameters.AddWithValue("MobileNo", customer.MobileNo);
				command.Parameters.AddWithValue("GST_NO", customer.GSTNo);
				command.Parameters.AddWithValue("CityName", customer.CityName);
				command.Parameters.AddWithValue("PinCode", customer.PinCode);
				command.Parameters.AddWithValue("NetAmount", customer.NetAmount);
				command.Parameters.AddWithValue("UserID", customer.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion

		#region Update Customer
		public bool Update(CustomerModel customer)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_Update", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("CustomerID", customer.CustomerID);
				command.Parameters.AddWithValue("CustomerName", customer.CustomerName);
				command.Parameters.AddWithValue("HomeAddress", customer.HomeAddress);
				command.Parameters.AddWithValue("Email", customer.Email);
				command.Parameters.AddWithValue("MobileNo", customer.MobileNo);
				command.Parameters.AddWithValue("GST_NO", customer.GSTNo);
				command.Parameters.AddWithValue("CityName", customer.CityName);
				command.Parameters.AddWithValue("PinCode", customer.PinCode);
				command.Parameters.AddWithValue("NetAmount", customer.NetAmount);
				command.Parameters.AddWithValue("UserID", customer.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion

		#region Delete Customer
		public bool Delete(int CustomerID)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_Delete", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("CustomerID", CustomerID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return affectedRow > 0;
			}
		}
		#endregion
	}
}
