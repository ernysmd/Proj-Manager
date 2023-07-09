using System.Text.Json.Serialization;

namespace ShopSmithAPI.Models
{
    public class Employee : User
    {
        public Guid Id { get; set; }
        public string Role { get; set; } = string.Empty;
       
    }
}
