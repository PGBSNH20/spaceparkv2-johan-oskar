using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.APIModels;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using SpaceParkTest.Helpers;
using SpaceParkTest.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace SpaceParkTest.Tests
{
    public class ParkingsControllerTest
    {
        [Fact]
        public void On_ParkingEndpointGetMethod_Expect_AllParkings()
        {
            // Arrange
            Spaceport testSpaceport = new()
            {
                ID = 1,
                PlanetName = "Tatooine",
                Name = "Mos Eisley"
            };

            List<Parking> testParkings = new()
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
            var parkingsController = new ParkingsController(null, testRepo, null);

            // Act
            var actualParkings = parkingsController.GetParkings().Result.Value;

            // Assert
            Assert.Equal(testParkings, actualParkings);
        }

        [Fact]
        public void On_GetMethod_And_EndedAction_And_TravellerName_Expect_AllParkings()
        {
            // Arrange
            // Set `EndTime` and `TotalSum` on the first object.
            // This is the object we expect from `parkingsController.GetEndedForTraveller()`
            List<Parking> testParkings = TestData.GetTwoParkingsInList();
            testParkings[0].EndTime = TestData.DateTimeNow;
            testParkings[0].TotalSum = 2m;

            // Clone the list of parkings and remove the 2nd parking objects since this shouldn't be returned if `parkingsController.GetEndedForTraveller()` functions as expected.
            var expectedParkings = CloneTestData.CloneCollection<Parking>(testParkings);
            expectedParkings.RemoveAt(1);

            // Init our tests repository and add our "entities" / test data.
            IParkingsRepository testRepo = new TestParkingsRepository(testParkings);
            var parkingsController = new ParkingsController(null, testRepo, null);

            // Act
            var actualParkings = parkingsController.GetEndedForTraveller(testParkings[0].Traveller).Result.Value;

            // Assert
            Assert.True(Compare.Equivalent(expectedParkings, actualParkings));
        }

        [Fact]
        public void On_ParkingEndpointGetMethodWithId_Expect_SingleParking()
        {
            // Arrange
            Spaceport testSpaceport = new()
            {
                ID = 1,
                PlanetName = "Tatooine",
                Name = "Mos Eisley"
            };

            List<Parking> testParkings = new()
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
            var parkingsController = new ParkingsController(null, testRepo, null);

            // Act
            var actualParkings = parkingsController.GetParking(2).Result.Value;

            // Assert
            Assert.Equal(testParkings[1], actualParkings);
        }

        [Fact]
        public void On_ParkingEndpointPostNewParking_Expect_SingleParking()
        {
            // Arrange
            List<Spaceport> spacePorts = new()
            {
                new Spaceport()
                {
                    ID = 1,
                    PlanetName = "Tatooine",
                    Name = "Mos Eisley"
                }
            };

            PostParking postParking = new()
            {
                Traveller = "Anakin Skywalker",
                StarShip = "Naboo fighter",
                SpaceportId = spacePorts[0].ID
            };

            TestParkingsRepository testParkingsrepo = new(null);
            ISpaceportsRepository testSpaceportsRepo = new TestSpaceportsRepository(spacePorts);
            var parkingsController = new ParkingsController(null, testParkingsrepo, testSpaceportsRepo);

            // Act
            //var newParkings = parkingsController.PostParking(postParking).Result.Value;
            var newParking = ((CreatedAtActionResult)parkingsController.PostParking(postParking).Result.Result).Value;

            // Assert
            Assert.IsType<Parking>(newParking);
            Assert.Equal(postParking.Traveller, ((Parking)newParking).Traveller);
            Assert.Equal(postParking.StarShip, ((Parking)newParking).StarShip);
            Assert.Equal(postParking.SpaceportId, ((Parking)newParking).Spaceport.ID);

        }

        [Fact]
        public void On_PostNewParking_When_ActiveParkingExists_Expect_BadRequest()
        {
            // Arrange
            List<Spaceport> spacePorts = new()
            {
                new Spaceport()
                {
                    ID = 1,
                    PlanetName = "Tatooine",
                    Name = "Mos Eisley"
                }
            };

            List<Parking> testParkings = new()
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    Spaceport = spacePorts[0],
                },
            };

            PostParking postParking = new()
            {
                Traveller = "Anakin Skywalker",
                StarShip = "Naboo fighter",
                SpaceportId = spacePorts[0].ID
            };

            TestParkingsRepository testParkingsrepo = new(testParkings);
            ISpaceportsRepository testSpaceportsRepo = new TestSpaceportsRepository(spacePorts);
            var parkingsController = new ParkingsController(null, testParkingsrepo, testSpaceportsRepo);

            // Act
            //var newParkings = parkingsController.PostParking(postParking).Result.Value;
            var badRequest = parkingsController.PostParking(postParking).Result.Result;

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequest);
        }

        [Fact]
        public void On_ParkingEndpointPatchWithTravellerQuery_Expect_EndparkingSuccess()
        {
            // Arrange
            List<Spaceport> spacePorts = new()
            {
                new Spaceport() { ID = 1, PlanetName = "Tatooine", Name = "Mos Eisley" }
            };

            List<Parking> testParkings = new()
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    Spaceport = spacePorts[0],
                    StartTime = DateTime.Now.AddSeconds(-10)
                },
                new Parking()
                {
                    ID = 2,
                    Traveller = "Han Solo",
                    StarShip = "Millenium Falcon",
                    Spaceport = spacePorts[0],
                    StartTime = TestData.DateTimeNow.AddSeconds(-60)
                },
            };

            TestParkingsRepository testParkingsrepo = new(testParkings);
            ISpaceportsRepository testSpaceportsRepo = new TestSpaceportsRepository(spacePorts);
            var parkingsController = new ParkingsController(null, testParkingsrepo, testSpaceportsRepo);

            // Act
            //var newParkings = parkingsController.PostParking(postParking).Result.Value;
            var finishedParking = parkingsController.EndParking("Han Solo").Result.Value;

            // Assert
            Assert.NotNull(finishedParking.EndTime);
            Assert.NotNull(finishedParking.TotalSum);
        }
    }
}
