using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();//fixture deki kulllanıcıalrı expected response a tanımlıyoz, bunu da alttaki methoda veriyoz
            
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);//bu methodda mock messagehandlerda alıp bakıyor ve bize bir  handlermock dönüyor
            var //bu handlermock u aşağıda http client a verelim - usersercie ye uygun parçasını alsın
                httpClient = new HttpClient(handlerMock.Object);
            var sut= new UsersService(httpClient);

            //Act
            await sut.GetAllUsers();


            //Assert
            //verify HTTP request is made-http get isteiğnini yapıldığını testet

            handlerMock.Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),//send async 1 kere çağrıldığından emin ol
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    //yukardakinde : get request olduğundan emin olmak için expression is
                    ItExpr.IsAny<CancellationToken>()

                   );
             


        }
            

    }
}
