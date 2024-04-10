using Microsoft.AspNetCore.Mvc;
using WebAppTask2.Models; 

namespace WebAppTask2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitsController : ControllerBase
    {
        private static List<Visit> visits = new List<Visit>();

        // GET: api/visits/{animalId}
        [HttpGet("{animalId}")]
        public IActionResult GetVisitsByAnimalId(int animalId)
        {
            // Assuming Visit model has an AnimalId property
            var animalVisits = visits.Where(v => v.AnimalId == animalId).ToList();
            return Ok(animalVisits);
        }

        // POST: api/visits
        [HttpPost]
        public IActionResult AddVisit([FromBody] Visit visit)
        {
            visit.Id = visits.Count + 1;
            visits.Add(visit);
            return CreatedAtAction(nameof(GetVisitsByAnimalId), new { animalId = visit.AnimalId }, visit);
        }
    }
}