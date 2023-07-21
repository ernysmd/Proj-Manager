using System.Text.Json.Serialization;

namespace ShopSmithAPI.Models
{
    public class Employee : User
    {  
        public string Role { get; set; } 

    }
}
