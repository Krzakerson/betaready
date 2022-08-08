using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api1;
using WebApplication1.Models;
using RestSharp;
using Newtonsoft.Json;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
            var request = new RestRequest("http://localhost:5100/api/Pracownik/", Method.Put);
            //JsonConvert.PopulateObject(values, temp);
            request.AddParameter("application/json",  ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            var response = _client.Execute(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.StatusCode);
           
        }

        [TestMethod]

        public void TestMethodPost()
        {
            
        }


        [TestMethod]

        public void TestMethodDelete()
        {

        }


        [TestMethod]

        public void TestMethodPut()
        {

        }
    }
}