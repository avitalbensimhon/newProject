using Microsoft.AspNetCore.Mvc;
using projectAvital.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        Datacontext _context=new Datacontext();
        // GET: api/<TripController>
        public TripController(Datacontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _context.trips;
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string code)
        {

            var index = _context.trips.FindIndex(e => e.code.Equals(code));
            if (index != -1)
                return Ok(_context.trips[index]);
            return NotFound( null);
        }

        // POST api/<TripController>
        [HttpPost]
        public Trip Post([FromBody] Trip newTrip)
        {
            _context.trips.Add(newTrip);
            return newTrip;
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Trip newTrip)
        {
            var index = _context.trips.FindIndex(e => e.code.Equals(id));
            if (index != -1)
            {
                _context.trips[index].code = newTrip.code;
                _context.trips[index].location = newTrip.location;
                _context.trips[index].date = newTrip.date;
                _context.trips[index].numRegisteres = newTrip.numRegisteres;
                _context.trips[index].idGuide = newTrip.idGuide;
                return Ok(_context.trips[index]);
            }
            return NotFound();
        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        public  ActionResult Delete(string id)
        {
            var index = _context.trips.FindIndex(e => e.code.Equals(id));
            if (index != -1)
            {
                _context.trips.RemoveAt(index);
                return Ok(_context.trips[index]);
            }
            return NotFound();
        }
    }
}
