using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace ShopSmithAPI.Models
{
    public class Customer : User
    {
       public List<Vehicle>? Vehicles { get; set; }

    }
}
