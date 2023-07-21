namespace ShopSmithAPI.Dto
{
    public class LaborDto
    {
        public Guid Id { get; set; }

        public decimal LaborTime { get; set; }

        public DateTime DateTime { get; set; }

        public Guid employeeId { get; set; }
    }
}
