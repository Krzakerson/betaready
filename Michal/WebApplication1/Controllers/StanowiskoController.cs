using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StanowiskoController : Controller
    {
        private CosDbContext contex;

        public StanowiskoController(CosDbContext contex)
        {
            this.contex = contex;
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<Stanowisko>>Get()
        {
            return contex.Stanowiskos;
        }
        [HttpGet("{PersonId}")]   
        public ActionResult<Stanowisko> Get(int PersonId)
        {
            return contex.Stanowiskos.Find(PersonId);
        }
        [HttpDelete("{PersonId}")]
        public ActionResult<IEnumerable<Stanowisko>> Delete(int PersonId)
        {
            var cos = contex.Stanowiskos.Find(PersonId);
            contex.Stanowiskos.Remove(cos);
            contex.SaveChanges();
            return Ok(contex.Stanowiskos);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Stanowisko>> Post(Stanowisko stanowisko)
        {
            contex.Stanowiskos.Add(stanowisko);
            contex.SaveChanges();
            return Ok();
        }

        [HttpPut("{PersonId}")]

        public ActionResult<IEnumerable<Stanowisko>> Put(int PersonId,[FromBody] Stanowisko stanowisko)
        {
            Stanowisko stanowisko1 = contex.Stanowiskos.Find(PersonId);
            if (stanowisko1 != null)
            {
                stanowisko1.PersonId = stanowisko.PersonId;
                stanowisko1.Position = stanowisko.Position;
                stanowisko1.CreationTime = stanowisko.CreationTime;
                stanowisko1.UpdateTime = stanowisko.UpdateTime;

            }
            contex.Stanowiskos.Update(stanowisko1);
            contex.SaveChanges();
            return Ok("Update");

        }
    }
}
