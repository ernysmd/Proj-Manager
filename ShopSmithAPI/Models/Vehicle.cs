using System.Reflection.Emit;
using System.Text.Json.Serialization;
using ShopSmithAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Build.Framework;

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
        [Required]
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public List<Labor> Labors { get; set; }

    }


}
