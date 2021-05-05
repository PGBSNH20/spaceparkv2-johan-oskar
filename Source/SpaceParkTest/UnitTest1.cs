using SpaceParkAPI.Controllers;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace SpaceParkTest
{
    public class UnitTest1
    {
        //    public static List<Parking> ParkingsData = new List<Parking>
        //    {
        //        new Parking()
        //        {
        //            ID = 1,
        //            Traveller = "Anakin Skywalker",
        //            StarShip = "Naboo fighter",
        //            StartTime = DateTime.Now.AddSeconds(-10)
        //        },
        //        new Parking()
        //        {
        //            ID = 2,
        //            Traveller = "Anakin Skywalker",
        //            StarShip = "Naboo fighter",
        //            StartTime = DateTime.Now.AddSeconds(-10)
        //        },

        //}

        //DataForTest_When_TempatureIs36OrMore_Expect_Heatwave
        //public static IEnumerable<Parking> ParkingsData()
        //{
        //    yield return new Parking
        //    {
        //        //ID = 1,
        //        //StartTime = 
        //        //EndTime =
        //    };
        //    yield return new Parking()
        //    {
        //        Traveller = "Anakin Skywalker",
        //        StarShip = "Naboo fighter",
        //        StartTime = DateTime.Now.AddSeconds(-10)
        //    };
        //}

        [Fact]
        //[Theory]
        //[InlineData(3698897)]
        //[ClassData(typeof(Parkingsdata))]
        //public void When_ParkingGetMethod_Expect_Parkings(IEnumerable<Parking> parkings)
        public void On_ParkingGet_Expect_Parkings()
        {
            // Arrange
            List<Parking> parkingsData = new List<Parking>
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    StartTime = DateTime.Now.AddSeconds(-10)
                },
                new Parking()
                {
                    ID = 2,
                    Traveller = "Han Solo",
                    StarShip = "Millenium Falcon",
                    StartTime = DateTime.Now.AddSeconds(-10)
                },

            };

            IParkingsRepository repo = new ParkingsRepositoryStub(parkingsData);
            var parkingsController = new ParkingsController(null, repo);

            // Act
            parkingsData[0].ID = 3;
            var parkings = parkingsController.GetParkings().Result.Value;

            // Assert
            Assert.Equal(parkingsData, parkings);
        }

        //public void When_Inserting_ParkingData_In_Database_Expect_AnakinSkywalker_ParkingPrice_10sec()
        //{
        //    var parking = new Parking()
        //    {
        //        Traveller = "Anakin Skywalker",
        //        StarShip = "Naboo fighter",
        //        StartTime = DateTime.Now.AddSeconds(-10)
        //    };
        //    var person = Fetch.People("Anakin");

        //    using (var db = new MyContext())
        //    {
        //        db.Parkings.Add(parking);
        //        db.SaveChanges();
        //    }

        //    DatabaseQueries.EndParking(person.Result.SingleOrDefault());

        //    using (var db = new MyContext())
        //    {
        //        var result = db.Parkings.Where(x => x.Traveller == parking.Traveller).OrderBy(x => x.EndTime).LastOrDefault();

        //        Assert.Equal(0.34m, Math.Round(
        //            result.TotalSum.Value, 2));

        //        db.Remove(result);
        //        db.SaveChanges();
        //    }
    }
}
