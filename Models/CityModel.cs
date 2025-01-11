using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CoffeeShopAPI.Models
{
    public class CityModel
    {
        public int? CityID { get; set; }
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
        public int StateID { get; set; }
        public string? StateName { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public class CityDropDownModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
