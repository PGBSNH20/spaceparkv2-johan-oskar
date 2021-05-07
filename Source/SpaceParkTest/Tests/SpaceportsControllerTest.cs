using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.APIModels;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repositories;
using SpaceParkTest.Helpers;
using SpaceParkTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpaceParkTest.Tests
{
    public class SpaceportsControllerTest
    {
        [Fact]
        public void On_GetMethod_Expect_AllSpaceports()
        {
            // Arrange
            var spaceports = TestData.GetListofTwoSpaceports();
            List<Spaceport> expectedSpaceports = CloneTestData.CloneCollection(spaceports);

            ISpaceportsRepository testRepo = new TestSpaceportsRepository(spaceports);
            var spaceportsController = new SpaceportsController(null, testRepo);

            // Act
            var actualSpaceports = spaceportsController.GetSpaceports().Result.Value;

            // Assert
            Assert.True(Helpers.Compare.Equivalent(expectedSpaceports, actualSpaceports));
        }

        [Fact]
        public void On_GetMethod_With_IdParameter_Expect_SingleSpaceport()
        {
            // Arrange
            var indexToTest = 1;
            var spaceports = TestData.GetListofTwoSpaceports();
            List<Spaceport> expectedSpaceports = CloneTestData.CloneCollection(spaceports);

            ISpaceportsRepository testRepo = new TestSpaceportsRepository(spaceports);
            var spaceportsController = new SpaceportsController(null, testRepo);

            // Act
            var actualSpaceport = spaceportsController.GetSpaceport(spaceports[indexToTest].ID).Result.Value;

            // Assert
            Assert.True(Helpers.Compare.Equivalent(expectedSpaceports[indexToTest], actualSpaceport));
        }

        [Fact]
        public void On_PostMethod_With_SpaceportName_Expect_NewSpaceport()
        {
            // Arrange
            var indexToTest = 1;
            var spaceports = TestData.GetListofTwoSpaceports();

            PostSpaceport postSpaceport = new()
            {
                Name = "Death Star I",
            };

            ISpaceportsRepository testRepo = new TestSpaceportsRepository(spaceports);
            var spaceportsController = new SpaceportsController(null, testRepo);

            // Act
            var actualSpaceport = ((CreatedAtActionResult)spaceportsController.PostSpaceport(postSpaceport).Result.Result).Value;

            // Assert
            Assert.IsType<Spaceport>(actualSpaceport);
            Assert.Equal(postSpaceport.Name, ((Spaceport)actualSpaceport).Name);
        }
    }
}
