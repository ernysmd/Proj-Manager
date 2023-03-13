using ProjManagementApp;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.IO;

namespace ProjManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ShopSmith!");
            
            Console.WriteLine("Please choose one of the following options:");
            
            Console.WriteLine("Enter '1' for Manager");
            
            Console.WriteLine("Enter '2' for Employee");
            
            Console.WriteLine("Enter '3' for Customer");

            List<Vehicle> vehicles = new List<Vehicle>();

            int userInput;

            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                switch (userInput)
                {
                    case 1:
                        // Perform manager actions
                        
                        Console.WriteLine("You have chosen Manager role. What task would you like to complete?");

                        //Entering 1 must allow to add vehicle and to what customer vehicle belongs to. 
                        Console.WriteLine("Enter 1 to add a vehicle to the shop.");
                        
                        //Entering 2 must allow Manager to remove a vehicle from the shop.
                        Console.WriteLine("Enter 2 to remove a vehcle from the shop.");

                        //Entering 3 must allow Manager to view all details of a project. 
                        Console.WriteLine("Enter 3 to view details of a project.");

                        int managerInput = int.Parse(Console.ReadLine());

                        switch (managerInput)
                        {
                            case 1:
                                //Add vehicle to the shop
                                Console.WriteLine("Enter vehicle details:");
                                
                                Console.Write("Vin number: ");
                                string vinNumber = Console.ReadLine();
                                
                                Console.Write("Year: ");
                                int year = int.Parse(Console.ReadLine());

                                Console.Write("Make: ");
                                string make = Console.ReadLine();

                                Console.Write("Model: ");
                                string model = Console.ReadLine();

                                Console.Write("Estimated time to complete (Hours): ");
                                double timeToComplete = int.Parse(Console.ReadLine());

                                // Create a new Vehicle object with the input values
                                Vehicle newVehicle = new Vehicle
                                {
                                    VinNumber = vinNumber,
                                    Year = year,
                                    Make = make,
                                    Model = model,
                                    TimeToComplete = timeToComplete
                                };

                                // Add the new vehicle to the list
                                vehicles.Add(newVehicle);

                                // Open the text file for writing
                                using (StreamWriter writer = new StreamWriter("C:\\Users\\ernys\\Desktop\\program_projects\\ShopSmith\\ConsoleApp1\\vehicle_list.txt", true))
                                {
                                    writer.WriteLine($"{newVehicle.VinNumber}, {newVehicle.Year}, {newVehicle.Make}, {newVehicle.Model}, {newVehicle.TimeToComplete}");
                                    writer.Flush();
                                    writer.Close();
                                }

                                break;

                            case 2:
                                //Remove vehicle from the shop
                                Console.WriteLine("Enter vehicle details:");
                                //..
                                break;

                            case 3:
                                // View details of a project
                                Console.WriteLine("Enter the project ID:");
                                // ...
                                break;
                        }
                        break;
                   
                    case 2:
                        // Perform employee actions
                        
                        Console.WriteLine("You have chosen the Employee role. What task would you like to complete?");

                        //Entering 1 must allow to add hours and catagory.
                        Console.WriteLine("Enter 1 to add hours worked on a vehicle.");
                        
                        //Entering 2 must allow Employee to add a description to the hours. 
                        Console.WriteLine("Enter 2 to add a description of work done to a vehicle.");
                        break;
                   
                    case 3:
                        // Perform customer actions
                        
                        Console.WriteLine("You have chosen the Customer role. What task would you like to perform?");

                        //Entering 1 must allow Customer to view total labor hours and catagory of labor.
                        Console.WriteLine("Enter 1 to view details on your vehicle.");

                        //Entering 2 must allow Customer to view how long the waitlist is.
                        Console.WriteLine("Enter 2 to view waitlist.");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please choose a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

    