using DvtElevatorSim.Enums;
using DvtElevatorSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DvtElevatorSim.UnitTests
{
    public class DvtElevatorTest
    {
        [Fact]
        public void Test_AddDestinationWithDistinctFloor()
        {
            var elevator = new DvtElevator(1);
            elevator.AddDestination(6);
            elevator.AddDestination(6);
            Assert.Single(elevator.DvtElevatorDestinations);
        }

        [Fact]
        public void Test_MovesToNextFloor()
        {
            var elevator = new DvtElevator(1, 0);
            elevator.AddDestination(2);
            elevator.PendingUpOrDownMove();
            Assert.Equal(1, elevator.CurrentFloor);
            Assert.Equal(DvtElevatorStateEnum.DvtElevatorState.MovingUp, elevator.State);
        }

        [Fact]
        public void Test_ReachesDestination()
        {
            var elevator = new DvtElevator(1, 0);
            elevator.AddDestination(0);
            elevator.PendingUpOrDownMove();
            Assert.Equal(0, elevator.CurrentFloor);
            Assert.Equal(DvtElevatorStateEnum.DvtElevatorState.Pending, elevator.State);
        }
    }
}
