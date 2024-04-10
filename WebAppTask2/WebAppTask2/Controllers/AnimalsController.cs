using Microsoft.AspNetCore.Mvc;
using WebAppTask2.Models;

namespace WebAppTask2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static List<Animal> animals = new List<Animal>();

        // GET: api/animals
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }

        // GET: api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound(); // Return 404 Not Found if animal not found
            return Ok(animal);
        }

        // POST: api/animals
        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            animal.Id = animals.Count + 1;
            animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }

        // PUT: api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            var existingAnimal = animals.FirstOrDefault(a => a.Id == id);
            if (existingAnimal == null)
                return NotFound(); 
            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Category = updatedAnimal.Category;
            existingAnimal.Weight = updatedAnimal.Weight;
            existingAnimal.FurColor = updatedAnimal.FurColor;
            return Ok(existingAnimal);
        }

        // DELETE: api/animals/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animalToRemove = animals.FirstOrDefault(a => a.Id == id);
            if (animalToRemove == null)
                return NotFound(); 
            animals.Remove(animalToRemove);
            return NoContent(); 
        }
    }
}
