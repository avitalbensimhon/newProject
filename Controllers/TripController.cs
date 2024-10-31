using Microsoft.AspNetCore.Mvc;
using projectAvital.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        private static List<Trip> trips = new List<Trip> { new Trip { code = "123", location = "netivot", date = DateTime.Today, numRegisteres = 12, idGuide = "1" } };
        // GET: api/<TripController>
        public TripController()
        {
            
        }
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return trips;
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        public Trip Get(string code)
        {

            var index = trips.FindIndex(e => e.code.Equals(code));
            if (index != -1)
                return trips[index];
            return null;
        }

        // POST api/<TripController>
        [HttpPost]
        public Trip Post([FromBody] Trip newTrip)
        {
            trips.Add(newTrip);
            return newTrip;
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Trip newTrip)
        {
            var index = trips.FindIndex(e => e.code.Equals(id));
            trips[index].code= newTrip.code;
            trips[index].location = newTrip.location;
            trips[index].date = newTrip.date;
            trips[index].numRegisteres = newTrip.numRegisteres;
            trips[index].idGuide = newTrip.idGuide;
        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var index = trips.FindIndex(e => e.code.Equals(id));
            if (index != -1)
            {
                trips.RemoveAt(index);
            }
        }
    }
}
