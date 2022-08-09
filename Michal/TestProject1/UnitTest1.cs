using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api1;
using WebApplication1.Models;
using RestSharp;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using ikvm.runtime;
using System.Net;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static WebApplicationFactory<Startup> _factory;

        /*[Fact]

      public async Task GetPracownicy()
      {
          await using var application = new WebApplicationFactory<Api.Startup>();
          using var client = application.CreateClient();
          var response = await client.GetAsync("http://localhost:5100/api/Pracownik/");
          response.StatusCode.Should().Be(HttpStatusCode.OK);

      }
      
        [TestMethod]

        public async Task ShouldReturnSucces()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/values");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var json = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("[\"value1\",\"value2\"]", json);
        }
        */
        [TestMethod]
        public void TestMethodPost()
        {
            Pracownik pracownik = new Pracownik()


            {
                Id = 10,
                Name = "test",
                LastName = "TEST",
                CreationTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                PositionId = "szef"
            }; 
            
           
            List<Pracownik> pracowniks = new List<Pracownik>();
            var _client = new RestClient();
            var request = new RestRequest("http://localhost:5100/api/Pracownik/", Method.Post);
            //JsonConvert.PopulateObject(values, temp);
            request.AddParameter("application/json",  ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            var response = _client.Execute(request);
            Assert.IsNotNull(response);
           //Assert.AreEqual(200, response.StatusCode);  
            //Assert.AreEqual(System.Net.HttpStatusCode.OK,response.Content);
           
        }
 

       


        [TestMethod]

        public void TestMethodDelete(int key)
        {
            var _client = new RestClient();
            var request = new RestRequest($"http://localhost:5100/api/Pracownik/{key}", Method.Delete);
            request.AddParameter("application/json", ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            var response =  _client.Execute(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.Content);
        }


        [TestMethod]

        public void TestMethodPut()
        {

        }
    }
}