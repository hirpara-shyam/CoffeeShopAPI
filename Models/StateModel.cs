namespace CoffeeShopAPI.Models
{
    public class StateModel
    {
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public string? CountryName { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public int CityCount { get; set; } // New field
    }

    public class StateDropDownModel
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

    }
}
