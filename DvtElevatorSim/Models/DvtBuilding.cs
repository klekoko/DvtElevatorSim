using DvtElevatorSim.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DvtElevatorSim.Models
{
    public class DvtBuilding
    {
        //Data Members
        public int TotalNoOfFloors { get; }
        public List<DvtElevator> lstDvtElevators { get; }

        IEnumerable<T> CreateItems<T> (int count) where T : new()
        {
            return CreateItems(count, () => new T());
        }
        IEnumerable<T> CreateItems<T>(int count, Func<T> creator)
        {
            for (int i = 0; i < count; i++)
            {
                yield return creator();
            }
        }

        static IEnumerable<int> GetElevators(int numberOfElevators)
        {
            yield return numberOfElevators;

        }
        //Constructor parameterized. Initializes the building with total number of floors and elevators
        public DvtBuilding(int totalFloors, int numberOfElevators)
        {
            TotalNoOfFloors = totalFloors;
            lstDvtElevators = new List<DvtElevator>(numberOfElevators);

            //foreach(var item in GetElevators(numberOfElevators))
            //{
            //    lstDvtElevators.Add(new DvtElevator(item + 1));
            //}

            for (int i = 0; i <= GetElevators(numberOfElevators).Count(); i++)
            {
                lstDvtElevators.Add(new DvtElevator(i + 1));
            }
        }

        /// <summary>
        /// Determines the closest idle elevator and assigns it to pick up and transport passengers. 
        /// </summary>
        /// <param name="reqFromFloor"></param>
        /// <param name="reqToDestinationFloor"></param>
        public void RequestClosestIdleElevator(int reqFromFloor, int reqToDestinationFloor)
        {
            var closestElevator = lstDvtElevators
                .Where(e => e.State == DvtElevatorStateEnum.DvtElevatorState.Idle ||
                e.State == DvtElevatorStateEnum.DvtElevatorState.Pending)
                .OrderBy(e => Math.Abs(e.CurrentFloor - reqFromFloor)).FirstOrDefault();

            if (closestElevator != null)
            {
                closestElevator.AddDestination(reqFromFloor);
                closestElevator.AddDestination(reqToDestinationFloor);
            }
            else
            {
                Console.WriteLine("No elevators available at the moment. Please wait.");
            }
        }

        /// <summary>
        /// Advances the state of all elevators by calling their PendingUpOrDownMove method.
        /// </summary>
        public void Step()
        {
            foreach (var elevator in lstDvtElevators)
            {
                elevator.PendingUpOrDownMove();
            }
        }

        /// <summary>
        /// Prints the status of all elevators.
        /// </summary>
        public void DisplayElevatorStatus()
        {
            foreach (var elevator in lstDvtElevators)
            {
                Console.WriteLine(elevator);
            }
        }
    }
}
