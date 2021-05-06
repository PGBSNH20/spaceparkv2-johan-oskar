using SpaceParkAPI.Controllers;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace SpaceParkTest
{
    public class ParkingsControllerTest
    {
        [Fact]
        public void On_ParkingEndpointGetMethod_Expect_AllParkings()
        {
            // Arrange
            Spaceport testSpaceport = new Spaceport()
            {
                ID = 1,
                PlanetName = "Tatooine",
                Name = "Mos Eisley"
            };

            List<Parking> testParkings = new List<Parking>
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    Spaceport = testSpaceport,
                    StartTime = DateTime.Now.AddSeconds(-10)
                },
                new Parking()
                {
                    ID = 2,
                    Traveller = "Han Solo",
                    StarShip = "Millenium Falcon",
                    Spaceport = testSpaceport,
                    StartTime = DateTime.Now.AddSeconds(-10)
                },

            };

            IParkingsRepository testRepo = new TestParkingsRepository(testParkings);
            var parkingsController = new ParkingsController(null, testRepo);

            // Act
            var actualParkings = parkingsController.GetParkings().Result.Value;

            // Assert
            Assert.Equal(testParkings, actualParkings);
        }

        [Fact]
        public void On_ParkingEndpointGetMethodWithId_Expect_SingleParking()
        {
            // Arrange
            Spaceport testSpaceport = new Spaceport()
            {
                ID = 1,
                PlanetName = "Tatooine",
                Name = "Mos Eisley"
            };

            List<Parking> testParkings = new List<Parking>
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    Spaceport = testSpaceport,
                    StartTime = DateTime.Now.AddSeconds(-10)
                },
                new Parking()
                {
                    ID = 2,
                    Traveller = "Han Solo",
                    StarShip = "Millenium Falcon",
                    Spaceport = testSpaceport,
                    StartTime = DateTime.Now.AddSeconds(-10)
                },
            };

            IParkingsRepository testRepo = new TestParkingsRepository(testParkings);
            var parkingsController = new ParkingsController(null, testRepo);

            // Act
            var actualParkings = parkingsController.GetParking(2).Result.Value;

            // Assert
            Assert.Equal(testParkings[1], actualParkings);
        }
    }
}
