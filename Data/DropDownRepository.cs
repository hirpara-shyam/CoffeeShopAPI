using CoffeeShopAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShopAPI.Data
{
	public class DropDownRepository
	{
		public readonly string _connectionString;
		public DropDownRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString");
		}

		#region User Drop Down
		public IEnumerable<UserDropDownModel> UserDropDown()
		{
			var users = new List<UserDropDownModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_User_DropDown", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					users.Add(new UserDropDownModel
					{
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					});
				}
			}
			return users;
		}
		#endregion

		#region Order Drop Down
		public IEnumerable<OrderDropDownModel> OrderDropDown()
		{
			var orders = new List<OrderDropDownModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Order_DropDown", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					orders.Add(new OrderDropDownModel
					{
						OrderID = Convert.ToInt32(reader["OrderID"]),
						//OrderNumber = reader["OrderNumber"].ToString()
					});
				}
			}
			return orders;
		}
		#endregion

		#region Product Drop Down
		public IEnumerable<ProductDropDownModel> ProductDropDown()
		{
			var products = new List<ProductDropDownModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_DropDown", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					products.Add(new ProductDropDownModel
					{
						ProductID = Convert.ToInt32(reader["ProductID"]),
						ProductName = reader["ProductName"].ToString()
					});
				}
			}
			return products;
		}
		#endregion

		#region Customer Drop Down
		public IEnumerable<CustomerDropDownModel> CustomerDropDown()
		{
			var customers = new List<CustomerDropDownModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Customer_DropDown", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					customers.Add(new CustomerDropDownModel
					{
						CustomerID = Convert.ToInt32(reader["CustomerID"]),
						CustomerName = reader["CustomerName"].ToString()
					});
				}
			}
			return customers;
		}
        #endregion

        #region State Drop Down
        public IEnumerable<StateDropDownModel> StateDropDown()
        {
            var states = new List<StateDropDownModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("PR_LOC_State_SelectComboBoxByCountryID", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new StateDropDownModel
                    {
                        StateID = Convert.ToInt32(reader["StateID"]),
                        StateName = reader["StateName"].ToString()
                    });
                }
            }
            return states;
        }
        #endregion

        #region Country Drop Down
        public IEnumerable<CountryDropDownModel> CountryDropDown()
        {
            var countries = new List<CountryDropDownModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("PR_LOC_Country_SelectComboBox", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new CountryDropDownModel
                    {
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        CountryName = reader["CountryName"].ToString()
                    });
                }
            }
            return countries;
        }
        #endregion

        #region City Drop Down
        public IEnumerable<CityDropDownModel> CityDropDown()
        {
            var cities = new List<CityDropDownModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("PR_City_DropDown", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cities.Add(new CityDropDownModel
                    {
                        CityID = Convert.ToInt32(reader["CityID"]),
                        CityName = reader["CityName"].ToString()
                    });
                }
            }
            return cities;
        }
        #endregion
    }
}
