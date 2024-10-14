using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services.Abstractions;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange - This is the section where we set up our system under test
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers
            );
            
            var sut = new UserController(mockUserService.Object);

            //Act - In Act section we call our methods that we want to test. Actual testing goes here basically.
            var result = (OkObjectResult) await sut.Get();

            //Assert - This is the section that we can make our assertions based on the outcome of our test scenerio.
            /*
             Like below, we did our assertions by telling StatusCode returned by the Get method 
            should be 200 as the test method name suggests!
             */
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserService()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers
            );

            var sut = new UserController(mockUserService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers
            );

            var sut = new UserController(mockUserService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult) result;
            objectResult.Value.Should().BeOfType<List<User>>();

        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>()
            );
            
            var sut = new UserController (mockUserService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
            var obJectresult = (NotFoundResult) result;
            obJectresult.StatusCode.Should().Be(404);

        }

    }
}
