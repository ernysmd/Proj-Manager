using System.Text.Json.Serialization;

namespace ShopSmithAPI.Models
{
    public class Customer : User
    {
        public Guid Id { get; set; }
        public string Phone { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
