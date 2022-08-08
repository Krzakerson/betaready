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
    public class UseController : Controller
    {
        public List<Stanowisko> GetStanowisko()
        {
            var _client = new RestClient("http://localhost:5100/api/Stanowisko");

            var request = new RestRequest("");
            var response = _client.Execute(request);

            List<Stanowisko> stanowisko = JsonConvert.DeserializeObject<List<Stanowisko>>(response.Content);
            return stanowisko;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {



            return DataSourceLoader.Load(GetStanowisko(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            var _client = new RestClient();
            var request = new RestRequest("http://localhost:5100/api/Stanowisko/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", values, ParameterType.RequestBody);
            _client.Execute(request);

            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(int key)
        {
            var _client = new RestClient();
            var request = new RestRequest($"http://localhost:5100/api/Stanowisko/{key}", Method.Delete);
            //request.AddHeader("Content-Type", "application/json");
            // request.AddParameter("application/json", Id, ParameterType.RequestBody);
            _client.Execute(request);

            return Ok();
        }


        [HttpPut]

        public IActionResult Update(int key, string values)
        {
           
            var _client = new RestClient();
            var request = new RestRequest($"http://localhost:5100/api/Stanowisko/{key}", Method.Put);
            var temp = GetStanowisko().Find(a => a.PersonId == key);
            JsonConvert.PopulateObject(values, temp);
            request.AddParameter("application/json", temp, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json");
            var response = _client.Execute(request);
            return Ok();
        }

    }

}
