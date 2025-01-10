using System.Collections.Generic;
using DvtElevatorSim.Enums;


namespace DvtElevatorSim.Models
{
    public class DvtElevator
    {
        //Data Members
        public int Id { get; }
        public int CurrentFloor { get; set; }
        public DvtElevatorStateEnum.DvtElevatorState State { get; set; } = DvtElevatorStateEnum.DvtElevatorState.Idle;
        //Used to queue floors the elevator is schedules to visit.
        public Queue<int> DvtElevatorDestinations { get; } = new Queue<int>();

        //Constructor parameterized
        public DvtElevator(int id, int startingFloor = 0)
        {
            Id = id;
            CurrentFloor = startingFloor;
        }

        /// <summary>
        /// Add a floor to the destionation queue and avoid duplicates
        /// </summary>
        /// <param name="floor"></param>
        public void AddDestination(int floor)
        {
            if (!DvtElevatorDestinations.Contains(floor))
            {
                DvtElevatorDestinations.Enqueue(floor);
            }
        }

        /// <summary>
        /// Moves elevator one step closer to the destination.
        /// Updates the state as well - Idle, MovingUp etc.
        /// </summary>
        public void PendingUpOrDownMove()
        {
            if (DvtElevatorDestinations.Count == 0)
            {
                State = DvtElevatorStateEnum.DvtElevatorState.Idle;
                return;
            }

            int targetFloor = DvtElevatorDestinations.Peek();

            if (CurrentFloor < targetFloor)
            {
                State = DvtElevatorStateEnum.DvtElevatorState.MovingUp;
                CurrentFloor++;
            }
            else if (CurrentFloor > targetFloor)
            {
                State = DvtElevatorStateEnum.DvtElevatorState.MovingDown;
                CurrentFloor--;
            }
            else
            {
                State = DvtElevatorStateEnum.DvtElevatorState.Pending;
                DvtElevatorDestinations.Dequeue();
            }
        }

        /// <summary>
        /// Display elevator status and system's state.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Elevator {Id} - Floor: {CurrentFloor}, State: {State}, Destinations: [{string.Join(", ", DvtElevatorDestinations)}]";
        }

    }
}
