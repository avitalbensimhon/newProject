using projectAvital.model;

namespace projectAvital
{
    public class Datacontext
    {
        public List<Guide> guides { get; set; }
        public List<Registeres> registeres { get; set; }
        public List<Trip> trips { get; set; }
        public Datacontext()
        {
            guides = new List<Guide> { new Guide { id = "1", name = "avital", status = true } };
            registeres = new List<Registeres> { new Registeres { id = "1", name = "avital", age = 12, codeTrip = "1", status = true } };
            trips= new List<Trip> { new Trip { code = "123", location = "netivot", date = DateTime.Today, numRegisteres = 12, idGuide = "1" } };
        }
    }
}
