using Microsoft.Build.Framework;

namespace ShopSmithAPI.Models
{
    public class Labor
    {
        public Guid Id { get; set; }
        
        public decimal LaborTime { get; set; }
       
        public DateTime DateTime { get; set; }
        
        public Guid EmployeeId { get; set; }
        
        public string Description { get; set; } = string.Empty;
       
        public Guid VehicleId { get; set; } 

    }
}
