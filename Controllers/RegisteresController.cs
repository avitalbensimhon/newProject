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
        Datacontext _context = new Datacontext();
        // GET: api/<RegisteresController>
        public RegisteresController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Registeres> Get()
        {
            return _context.registeres;
        }

        // GET api/<RegisteresController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var index = _context.registeres.FindIndex(e => e.id.Equals(id));
            if (index != -1) 
                return Ok(_context.registeres[index]);
            return NotFound(null);
        }

        // POST api/<RegisteresController>
        [HttpPost]
        public Registeres Post([FromBody] Registeres newRegisteres)
        {
            _context.registeres.Add(newRegisteres);
            return newRegisteres;
        }

        // PUT api/<RegisteresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Registeres newRegisteres)
        {
            var index = _context.registeres.FindIndex(e => e.id.Equals(id));
            if (index != -1)
            {
                _context.registeres[index].id = newRegisteres.id;
                _context.registeres[index].name = newRegisteres.name;
                _context.registeres[index].age = newRegisteres.age;
                _context.registeres[index].codeTrip = newRegisteres.codeTrip;
                return Ok(_context.registeres[index]);
            }
            return NotFound(null);
        }

        // DELETE api/<RegisteresController>/5
        [HttpDelete("{id}")]
        public ActionResult ChangeStatus(string id)
        {
            var index = _context.registeres.FindIndex(e => e.id.Equals(id));
            if (index != -1)
            {
                _context.registeres[index].status = false;
                return Ok(_context.registeres[index]);
            }
            return NotFound(null);
        }
    }
}
