using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorSim.Models;

namespace DvtElevatorSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************Welcome to DVT Elevator Simulation************************");
            Console.Write("a) Enter the number of floors in the building: ");
            int totalNoOfFloors = int.Parse(Console.ReadLine());

            Console.Write("b) Enter the number of elevators: ");
            int totalNoOfElevators = int.Parse(Console.ReadLine());
            Console.WriteLine("c) Exit");

            var dvtBuilding = new DvtBuilding(totalNoOfFloors, totalNoOfElevators);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============Current Elevator Status=============");
                dvtBuilding.DisplayElevatorStatus();

                Console.WriteLine("**********/nMenu**********");
                Console.WriteLine("1. Request for an Elevator");
                Console.WriteLine("2. Advance Simulation");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter your initial floor");
                        int reqFromFloor = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter destination floor");
                        int destFloor = int.Parse(Console.ReadLine());

                        if(reqFromFloor < 0 || reqFromFloor >= totalNoOfFloors
                                || destFloor < 0 || destFloor > totalNoOfFloors)
                        {
                            Console.WriteLine("Invalid entry, please try again.");
                            Console.ReadKey();
                        }
                        else
                        {
                            dvtBuilding.RequestClosestIdleElevator(reqFromFloor, destFloor);
                        }
                        break;
                    case 2:
                        dvtBuilding.Step();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please press enter to try again.");
                        Console.ReadKey(); 
                        break;
                }
            }
        }
    }
}
