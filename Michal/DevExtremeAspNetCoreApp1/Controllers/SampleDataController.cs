using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;

namespace DevExtremeAspNetCoreApp1.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public List<Pracownike> GetPracownicy()
        {
            var _client = new RestClient("http://localhost:5100/api/Pracownik");

            var request = new RestRequest("");
            var response = _client.Execute(request);

            List<Pracownike> people = JsonConvert.DeserializeObject<List<Pracownike>>(response.Content);
            return people;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {

            


            return DataSourceLoader.Load(GetPracownicy(), loadOptions);
        }

        [HttpPost]

        public IActionResult Post(string values)
        {
            var _client = new RestClient();
            var request = new RestRequest("http://localhost:5100/api/Pracownik/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", values, ParameterType.RequestBody);
            _client.Execute(request);

            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(int key)
        {
            var _client = new RestClient();
            var request = new RestRequest($"http://localhost:5100/api/Pracownik/{key}", Method.Delete);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", values, ParameterType.RequestBody);
            _client.Execute(request);

            return Ok();
        }


        [HttpPut]

        public IActionResult Update(int key , string values)
        {

            var _client = new RestClient();
            var request = new RestRequest($"http://localhost:5100/api/Pracownik/{key}", Method.Put);
            var temp = GetPracownicy().Find(a => a.Id == key);
            JsonConvert.PopulateObject(values, temp);
            request.AddParameter("application/json", temp, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            var response = _client.Execute(request);
            return Ok();
        }
    }



}


