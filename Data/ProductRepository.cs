using CoffeeShopAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;
namespace CoffeeShopAPI.Data
{
	public class ProductRepository
	{
		private readonly string _connectionString;
		public ProductRepository(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("ConnectionString");
		}

		#region Select All Product
		public IEnumerable<ProductModel> SelectAll()
		{
			var products = new List<ProductModel>();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_SelectAll", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					products.Add(new ProductModel
					{
						ProductID = Convert.ToInt32(reader["ProductID"]),
						ProductName = reader["ProductName"].ToString(),
						ProductCode = reader["ProductCode"].ToString(),
						ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
						Description = reader["Description"].ToString(),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					});
				}
			}
			return products;
		}
		#endregion

		#region Select Product By ID
		public ProductModel SelectBYPK(int id)
		{
			ProductModel? product = null;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_SelectByID", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("ProductID",id);
				connection.Open();
				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					product = new ProductModel
					{
						ProductID = Convert.ToInt32(reader["ProductID"]),
						ProductName = reader["ProductName"].ToString(),
						ProductCode = reader["ProductCode"].ToString(),
						ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
						Description = reader["Description"].ToString(),
						UserID = Convert.ToInt32(reader["UserID"]),
						UserName = reader["UserName"].ToString()
					};
				}
			}
			return product;
		}
		#endregion

		#region Insert Product
		public bool Insert(ProductModel productModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_Insert", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("ProductName", productModel.ProductName);
				command.Parameters.AddWithValue("ProductPrice", productModel.ProductPrice);
				command.Parameters.AddWithValue("ProductCode", productModel.ProductCode);
				command.Parameters.AddWithValue("Description", productModel.Description);
				command.Parameters.AddWithValue("UserID", productModel.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return (affectedRow > 0);
			}
		}
		#endregion

		#region Update Product
		public bool Update(ProductModel productModel)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_Update", connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("ProductID", productModel.ProductID);
				command.Parameters.AddWithValue("ProductName", productModel.ProductName);
				command.Parameters.AddWithValue("ProductPrice", productModel.ProductPrice);
				command.Parameters.AddWithValue("ProductCode", productModel.ProductCode);
				command.Parameters.AddWithValue("Description", productModel.Description);
				command.Parameters.AddWithValue("UserID", productModel.UserID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return (affectedRow > 0);
			}
		}
		#endregion

		#region Delete Product
		public bool Delete(int ProductID)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				SqlCommand command = new SqlCommand("PR_Product_Delete",connection)
				{
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.AddWithValue("ProductID", ProductID);
				connection.Open();
				int affectedRow = command.ExecuteNonQuery();
				return (affectedRow > 0);
			}
		}
		#endregion
	}
}
