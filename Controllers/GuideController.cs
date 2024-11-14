using Microsoft.AspNetCore.Mvc;
using projectAvital.model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        Datacontext _context = new Datacontext();
        // GET: api/<GuideController>
        public GuideController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return _context.guides;
        }

        // GET api/<GuideController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var index = _context.guides.FindIndex(e => e.id.Equals(id));
            if (index != -1)
            {
                return Ok(_context.guides[index]);
            }

            return NotFound(null);
        }

        // POST api/<GuideController>
        [HttpPost]
        public Guide Post([FromBody] Guide newGuide)
        {
            _context.guides.Add(newGuide);
            return newGuide;
        }

        // PUT api/<GuideController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Guide guide) 
        {
            var index = _context.guides.FindIndex(e => e.id.Equals(id));
            if (index != -1)
            { 
                _context.guides[index].name=guide.name;
                _context.guides[index].id = guide.id;
                return Ok(guide);
            }

            return NotFound();
        }

        // DELETE api/<GuideController>/5
        [HttpDelete("{id}")]
        public ActionResult ChangeStatus(string id)
        {
            var index = _context.guides.FindIndex(e => e.id.Equals(id));
            if (index != -1)
            {
                _context.guides[index].status = false;
                return Ok(id);
            }

            return NotFound();
            
        }
    }
}
