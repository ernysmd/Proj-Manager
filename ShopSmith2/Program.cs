using System.IO;
using System;
using System.Collections.Generic;


namespace ShopSmith2;
  class Program
    {
    static void Main(string[] args)
    {
        VehicleManager vehicleManager = new VehicleManager();

        while (true)
        {
            Console.WriteLine("Hello, please make a selection:");
            Console.WriteLine("1.Manager");
            Console.WriteLine("2.Employee");
            Console.WriteLine("3.Customer");
            Console.WriteLine("4.Exit");

            int userinput = int.Parse(Console.ReadLine());

            switch (userinput)
            {
                case 1:
                    {
                        vehicleManager.ManageVehicles();
                        break;
                    }
                case 2:
                    {
                        vehicleManager.AddLaborDetails();
                        break;
                    }
                case 3:
                    {
                        vehicleManager.CustomerSelection();
                        break;
                    }
                case 4:
                    {
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                    }
            }
        }
    }
}



