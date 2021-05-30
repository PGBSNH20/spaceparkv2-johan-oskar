using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceParkTest.Tests
{
    internal class TestData
    {
        internal static DateTime DateTimeNow { get; } = DateTime.Now;

        internal static Spaceport GetSingleSpaceport()
        {
            return new Spaceport()
            {
                ID = 1,
                PlanetName = "Tatooine",
                Name = "Mos Eisley"
            };
        }

        internal static List<Spaceport> GetSingleSpaceportInList()
        {
            return new List<Spaceport>
            {
                new Spaceport()
                {
                    ID = 1,
                    PlanetName = "Tatooine",
                    Name = "Mos Eisley"
                }
            };
        }

        internal static List<Spaceport> GetListofTwoSpaceports()
        {
            return new List<Spaceport>
            {
                new Spaceport()
                {
                    ID = 1,
                    PlanetName = "Tatooine",
                    Name = "Mos Eisley"
                },
                new Spaceport()
                {
                    ID = 2,
                    PlanetName = "Not Tatooine",
                    Name = "Spaceport 9001"
                },
            };
        }

        internal static List<Parking> GetTwoParkingsInList()
        {
            return new List<Parking>
            {
                new Parking()
                {
                    ID = 1,
                    Traveller = "Anakin Skywalker",
                    StarShip = "Naboo fighter",
                    Spaceport = GetSingleSpaceport(),
                    StartTime = TestData.DateTimeNow.AddMinutes(-1)
                },
                new Parking()
                {
                    ID = 2,
                    Traveller = "Han Solo",
                    StarShip = "Millenium Falcon",
                    Spaceport = GetSingleSpaceport(),
                    StartTime = TestData.DateTimeNow.AddSeconds(-10)
                },
            };
        }
    }
}
