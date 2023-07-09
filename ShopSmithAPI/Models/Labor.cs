namespace ShopSmithAPI.Models
{
    public class Labor
    {
        public Guid Id { get; set; }
        public decimal LaborHours { get; set; }
        public decimal LaborMinutes { get; set; }
        public int EmployeeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual Vehicle Vehicle { get; set; }

    }
}
