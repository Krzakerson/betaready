using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeAspNetCoreApp1.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeAspNetCoreApp1.Controllers
{
   
    public class WorkerController: Controller
    {
        

       public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult PositionIndex()
        {
            return View();
        }

      
        public IActionResult TreeList()
        {
            return View();
        }

    }

}