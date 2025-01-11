using System.ComponentModel.DataAnnotations;

namespace CoffeeShopAPI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
    }

    public class ProductDropDownModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
