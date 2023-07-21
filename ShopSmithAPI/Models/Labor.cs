using Microsoft.Build.Framework;

namespace ShopSmithAPI.Models
{
    public class Labor
    {
        public Guid Id { get; set; }
      
        public decimal LaborTime { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public Guid employeeId { get; set; }
        
        public string Description { get; set; } = string.Empty;
       
        public Guid vehicleId { get; set; } 

    }
}
