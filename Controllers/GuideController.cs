using Microsoft.AspNetCore.Mvc;
using projectAvital.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private static List<Guide> guides = new List<Guide> { new Guide { id = "1", name = "avital",status=true } };
        // GET: api/<GuideController>
        public GuideController()
        {
            
        }
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return guides;
        }

        // GET api/<GuideController>/5
        [HttpGet("{id}")]
        public Guide Get(int id)
        {
            var index = guides.FindIndex(e => e.id.Equals(id));
            if(index != -1)
                return guides[index];
            return null;
        }

        // POST api/<GuideController>
        [HttpPost]
        public Guide Post([FromBody] Guide newGuide)
        {
            guides.Add(newGuide);
            return newGuide;
        }

        // PUT api/<GuideController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Guide guide)
        {
            var index = guides.FindIndex(e => e.id.Equals(id));
            guides[index].id=guide.id;
            guides[index].name=guide.name;
        }

        // DELETE api/<GuideController>/5
        [HttpDelete("{id}")]
        public void ChangeStatus(int id)
        {
            var index = guides.FindIndex(e => e.id.Equals(id));
            guides[index].status = false;
        }
    }
}
