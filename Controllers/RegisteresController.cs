using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectAvital.model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteresController : ControllerBase
    {
        private static List<Registeres> registeres = new List<Registeres> { new Registeres { id = "1", name = "avital", age = 12 , codeTrip="1",status=true} };
        // GET: api/<RegisteresController>
        public RegisteresController()
        {
            
        }
        [HttpGet]
        public IEnumerable<Registeres> Get()
        {
            return registeres;
        }

        // GET api/<RegisteresController>/5
        [HttpGet("{id}")]
        public Registeres Get(int id)
        {
            var index = registeres.FindIndex(e => e.id.Equals(id));
            if (index != -1)
                return registeres[index];
            return null;
        }

        // POST api/<RegisteresController>
        [HttpPost]
        public Registeres Post([FromBody] Registeres newRegisteres)
        {
            registeres.Add(newRegisteres);
            return newRegisteres;
        }

        // PUT api/<RegisteresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Registeres newRegisteres)
        {
            var index = registeres.FindIndex(e => e.id.Equals(id));
            registeres[index].id = newRegisteres.id;
            registeres[index].name = newRegisteres.name;
            registeres[index].age = newRegisteres.age;
            registeres[index].codeTrip = newRegisteres.codeTrip;
        }

        // DELETE api/<RegisteresController>/5
        [HttpDelete("{id}")]
        public void ChangeStatus(int id)
        {
            var index = registeres.FindIndex(e => e.id.Equals(id));
            registeres[index].status = false;
        }
    }
}
