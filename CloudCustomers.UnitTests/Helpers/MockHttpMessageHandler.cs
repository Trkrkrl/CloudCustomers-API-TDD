using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Helpers
{
    public class MockHttpMessageHandler<T>
    {
        public static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)//generic bir tip-mockun dönmesini beklendiğimz şey
        {//burada tatamıyle setup edilmiş bir http response hazırlıyor bu emthod
            // expected bize geliyor-


            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)//gelen expectedi  içerideki method ile jsondan çeviriyoruz
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))//jsondan çevirdğimzii bir string içeriki olarak içeriğe atıyoruz
            };//artık bu içeriği mockResponse a tanımlamış olduk

            //sonra mock response içeriğinin başık  türünü= application/jsondaki tipten alıyoruz alıyoruz
            mockResponse.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");    
            
            //
            var handlerMock=new Mock<HttpMessageHandler>();//sahte mesaj halledici-handler oluştur
            //bu handleri protected yap
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(//http response message türünde dönecek-
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),//it expr: protected eleman oluştururken bir değişkenin değeri yerin , onun için eşleşen koşulun gösterilmesine izin verir
                    //buradaki koşul IsAny yani hiç varmı= httprequestmessage hiç varmı
                    ItExpr.IsAny<CancellationToken>())//buradada iptal tokeni hiç varmı diye soruyor
                                                      //buna göre de mockresponse dönüyor-ki türü:HttpResponseMessage
                .ReturnsAsync(mockResponse);//yani içeride request varmı bakıyor request var ise response veriyor-istek varsa cevap veriyor yani

            //sendasync  yapabilmesi içn içerdeki o tipler gerekli
            //bu zahmete testdd yaptığımızdan girdik
            //normalde apiye istek atıp deniyorduk o süreçleri  mekanize ediyor bu

            return handlerMock;


                
                



        }
    }
}
