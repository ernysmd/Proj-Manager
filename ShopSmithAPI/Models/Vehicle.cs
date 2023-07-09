using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace ShopSmithAPI.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string VinNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int CustomerId { get; set; }

    }
}
