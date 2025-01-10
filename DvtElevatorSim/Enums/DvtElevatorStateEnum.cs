using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvtElevatorSim.Enums
{
    public class DvtElevatorStateEnum
    {
        /// <summary>
        /// Defines possible states of an elevator
        /// Idle: elevator is not moving
        /// MovingUp: elevator is moving in an upward direction
        /// MovingDown: elevator is moving in a downward direction
        /// Pending: Elevator is still busy loading/unloading passengers at a floor.
        /// </summary>
        public enum DvtElevatorState
        {
            Idle,
            MovingUp,
            MovingDown,
            Pending
        }
    }
}
