using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracownicyController : Controller
    {
        private CosDbContext context;
      
        public PracownicyController(CosDbContext contex)
        {
            this.context = contex;
        }
       



        /*[HttpGet]
        public IActionResult Hello()
        {
            return Ok("Pracownicy");
        }
        */

        [HttpGet]
        public ActionResult<IEnumerable<Pracownik>> Get()
        {
            return context.Pracowniks;
        }

        [HttpGet("{Id}")]

        public ActionResult<Pracownik> Get(int Id)
        {
           
            return context.Pracowniks.Find(Id);
        }


        [HttpDelete("{Id}")]
        public ActionResult<IEnumerable<Pracownik>> Delete(int Id)
        {
           var cos = context.Pracowniks.Find(Id);
           context.Pracowniks.Remove(cos);
            context.SaveChanges();
           return Ok(context.Pracowniks);

        }

        [HttpPost]
        public IActionResult Post(Pracownik pracownik)
        {
            //_repocs.AddPracownik(pracownik);
           
            context.Pracowniks.Add(pracownik);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult<IEnumerable<Pracownik>> Put(int Id ,[FromBody] Pracownik pracownik)
        {
            Pracownik pracownik1 = context.Pracowniks.Find(Id);
            if( pracownik1 != null )
            {
                pracownik1.Name = pracownik.Name;
                pracownik1.LastName = pracownik.LastName;
                pracownik1.CreationTime = pracownik.CreationTime;
                pracownik1.UpdateTime = pracownik.UpdateTime;
                pracownik1.PositionId = pracownik.PositionId;
                
            }

           context.Pracowniks.Update(pracownik1);
           context.SaveChanges();
           return Ok("Update");
        }
    }
}
