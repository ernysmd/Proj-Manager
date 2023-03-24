using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopSmith2.VehicleManager;

namespace ShopSmith2
{
    public class Vehicle : Entity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LaborDetails { get; set; }
        public double LaborHours { get; set; }
        public LaborCategory? Category { get; set; }

        public Vehicle(int id, string make, string model, int year) : base(id)
        {
            Make = make;
            Model = model;
            Year = year;
        }
    }


}
