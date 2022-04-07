using CloudCustomers.API.Controllers;
using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {// buradaki sut system under test in kisaltmasidir 
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {//arrange
            var mockUsersService = new Mock<IUsersService>();

            var sut = new UsersController(mockUsersService.Object);

            mockUsersService.Setup(service => service.GetAllUsers())
                 .ReturnsAsync(UsersFixture.GetTestUsers());
            //act
            var result = (OkObjectResult)await sut.Get();

            //assert
            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()
        {   //arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            //act
            var result = await sut.Get();

            //assert
            mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());


        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfUsers()
        {   //arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var sut = new UsersController(mockUsersService.Object);

            //act
            var result = await sut.Get();

            //assert

            result.Should().BeOfType<OkObjectResult>(); 
            var objectResult=(OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_Return404()
        {   //arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService.Setup(service => service.GetAllUsers()).ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            //act
            var result = await sut.Get();

            //assert

            result.Should().BeOfType<NotFoundResult>();
            var objectResult=(NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
           
        }
    }
}