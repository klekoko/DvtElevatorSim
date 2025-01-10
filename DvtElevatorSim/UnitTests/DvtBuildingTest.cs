using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvtElevatorSim.Models;
using DvtElevatorSim.Enums;
using Xunit;

namespace DvtElevatorSim.UnitTests
{
    public class DvtBuildingTest
    {
        /// <summary>
        /// Unit test the closest idle elevator
        /// </summary>
        [Fact]
        public void Test_RequestElevatorAndChooseClosestIdleElevator()
        {
            var building = new DvtBuilding(10, 2);
            building.lstDvtElevators[0].CurrentFloor = 0;
            building.lstDvtElevators[1].CurrentFloor = 5;
            building.RequestClosestIdleElevator(3, 7);

            Assert.Contains(3, building.lstDvtElevators[0].DvtElevatorDestinations);
            Assert.DoesNotContain(3, building.lstDvtElevators[1].DvtElevatorDestinations);
        }

        /// <summary>
        /// Unit test the elevator requests and handles Unavailable ones
        /// </summary>

        [Fact]
        public void Test_RequestElevatorAndHandlesUnavailableElevators()
        {
            var building = new DvtBuilding(10, 1);
            building.lstDvtElevators[0].State = DvtElevatorStateEnum.DvtElevatorState.MovingUp;
            building.RequestClosestIdleElevator(3, 7);

            Assert.Empty(building.lstDvtElevators[0].DvtElevatorDestinations);
        }
    }
}
