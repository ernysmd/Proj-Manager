using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSmith2
{
    public class VehicleManager
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public VehicleManager()
        {
            LoadVehiclesFromFile();
        }
        public void ManageVehicles()
        {
            while (true)
            {
                Console.WriteLine("1. Add vehicle");
                Console.WriteLine("2. Remove vehicle");
                Console.WriteLine("3. List vehicles");
                Console.WriteLine("4. Filter vehicles by year");
                Console.WriteLine("5. Exit");

                int managerInput = int.Parse(Console.ReadLine());

                if (managerInput == 1)
                {
                    AddVehicle();
                }
                else if (managerInput == 2)
                {
                    RemoveVehicle();
                }
                else if (managerInput == 3)
                {
                    ListVehicles();
                }
                else if (managerInput == 4)
                {
                    Console.Write("Enter the minimum year: ");
                    int minYear = int.Parse(Console.ReadLine());
                    FilterVehiclesByYear(minYear);
                }
                else if (managerInput == 5)
                {
                    break;
                }
            }
        }


        public void FilterVehiclesByYear(int minYear)
        {
            var filteredVehicles = vehicles.Where(v => v.Year >= minYear).ToList();

            Console.WriteLine($"Vehicles from {minYear} and newer:");
            foreach (var vehicle in filteredVehicles)
            {
                Console.WriteLine($"{vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }
        }


        public void AddVehicle()
        {
            Console.Write("Enter the vehicle make: ");
            string make = Console.ReadLine();

            Console.Write("Enter the vehicle model: ");
            string model = Console.ReadLine();

            Console.Write("Enter the vehicle year: ");
            int year = int.Parse(Console.ReadLine());

            int id = vehicles.Count + 1;
            vehicles.Add(new Vehicle(id, make, model, year));

            SaveVehiclesToFile(); 

            Console.WriteLine("Vehicle added.");
        }


        public void RemoveVehicle()
        {
            ListVehicles();

            Console.Write("Enter the index of the vehicle to remove: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < vehicles.Count)
            {
                vehicles.RemoveAt(index);
                SaveVehiclesToFile();
                Console.WriteLine("Vehicle removed.");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }




        public void ListVehicles()
        {
            string filePath = "vehicles.txt"; // For the same directory as the executable
                                             

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("No vehicles found.");
                    return;
                }

                foreach (string line in lines)
                {
                    string[] vehicleData = line.Split(',');

                    int id = int.Parse(vehicleData[0]);
                    string make = vehicleData[1];
                    string model = vehicleData[2];
                    int year = int.Parse(vehicleData[3]);

                    Console.WriteLine($"ID: {id} | {year} {make} {model}");
                }

            }
            else
            {
                Console.WriteLine("No vehicles found.");
            }
        }

        public enum LaborCategory
        {
            Fabrication,
            AssemblyDisassembly,
            Electrical
        }

        public void AddLaborDetails()
        {
            ListVehicles();

            Console.Write("Enter the index of the vehicle to add labor details: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < vehicles.Count)
            {
                Console.Write("Enter labor details: ");
                string laborDetails = Console.ReadLine();

                Console.Write("Enter labor hours: ");
                double laborHours = double.Parse(Console.ReadLine());

                Console.WriteLine("Select a labor category:");
                Console.WriteLine("1. Fabrication");
                Console.WriteLine("2. Assembly/Disassembly");
                Console.WriteLine("3. Electrical");
                int categoryChoice = int.Parse(Console.ReadLine());

                LaborCategory category = LaborCategory.Fabrication; // Default value
                switch (categoryChoice)
                {
                    case 1:
                        category = LaborCategory.Fabrication;
                        break;
                    case 2:
                        category = LaborCategory.AssemblyDisassembly;
                        break;
                    case 3:
                        category = LaborCategory.Electrical;
                        break;
                    default:
                        Console.WriteLine("Invalid category choice, using default category (Fabrication).");
                        break;
                }

                Vehicle vehicle = vehicles[index];
                vehicle.LaborDetails = laborDetails;
                vehicle.LaborHours = laborHours;
                vehicle.Category = category;

                SaveVehiclesToFile();
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }



        public void CustomerSelection()
        {
            ListVehicles();

            Console.Write("Enter the index of the vehicle to view details: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < vehicles.Count)
            {
                Vehicle vehicle = vehicles[index];
                Console.WriteLine($"Make: {vehicle.Make}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Year: {vehicle.Year}");
                Console.WriteLine($"Labor details: {vehicle.LaborDetails ?? "N/A"}");
                Console.WriteLine($"Labor hours: {vehicle.LaborHours}");
                Console.WriteLine($"Labor category: {vehicle.Category}");
            }
            else
            {
                Console.WriteLine("Invalid index.");
            }
        }

        public void SaveVehiclesToFile()
        {
            // Update vehicle IDs
            for (int i = 0; i < vehicles.Count; i++)
            {
                vehicles[i].ID = i + 1;
            }

            string filePath = "vehicles.txt"; // For the same directory as the executable
                                              

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    writer.WriteLine($"{vehicle.ID},{vehicle.Make},{vehicle.Model},{vehicle.Year},{vehicle.LaborDetails ?? "N/A"},{vehicle.LaborHours},{vehicle.Category}");
                }
            }
        }



        public void LoadVehiclesFromFile()
        {
            string filePath = "vehicles.txt"; // For the same directory as the executable
                                              

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] vehicleData = line.Split(',');

                    int id = int.Parse(vehicleData[0]);
                    string make = vehicleData[1];
                    string model = vehicleData[2];
                    int year = int.Parse(vehicleData[3]);
                    string laborDetails = vehicleData[4] != "N/A" ? vehicleData[4] : null;
                    double laborHours = double.Parse(vehicleData[5]);

                    LaborCategory category = LaborCategory.Fabrication; // Default value
                    if (vehicleData.Length > 6)
                    {
                        if (Enum.TryParse<LaborCategory>(vehicleData[6], out LaborCategory parsedCategory))
                        {
                            category = parsedCategory;
                        }
                        else
                        {
                            // Handle the case when the value couldn't be parsed. 
                            Console.WriteLine($"Unable to parse LaborCategory for Vehicle ID: {id}. Using default value.");
                        }
                    }

                    Vehicle vehicle = new Vehicle(id, make, model, year);
                    vehicle.LaborDetails = laborDetails;
                    vehicle.LaborHours = laborHours;
                    vehicle.Category = category;
                    vehicles.Add(vehicle);
                }
            }
        }




    }
}
