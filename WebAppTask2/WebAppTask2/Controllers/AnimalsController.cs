using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppTask2.Interfaces;
using WebAppTask2.Models;

namespace WebAppTask2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        // GET: api/animals
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await _animalRepository.GetAll();
            return Ok(animals);
        }

        // GET: api/animals/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await _animalRepository.Get(id);
            if (animal == null)
                return NotFound(); // Return 404 Not Found if animal not found
            return Ok(animal);
        }

        // POST: api/animals
        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody] Animal animal)
        {
            await _animalRepository.Add(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }

        // PUT: api/animals/{id}
        // PUT: api/animals
        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] Animal updatedAnimal)
        {
            var id = updatedAnimal.Id; 
            var existingAnimal = await _animalRepository.Get(id);
            if (existingAnimal == null)
                return NotFound(); 

            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Category = updatedAnimal.Category;
            existingAnimal.Weight = updatedAnimal.Weight;
            existingAnimal.FurColor = updatedAnimal.FurColor;

            await _animalRepository.Edit(existingAnimal);
            return Ok(existingAnimal);
        }

        // DELETE: api/animals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animalToRemove = await _animalRepository.Get(id);
            if (animalToRemove == null)
                return NotFound(); // Return 404 Not Found if animal not found

            var deletionResult = await _animalRepository.Delete(animalToRemove);
            if (!deletionResult)
                return StatusCode(500); // Return 500 Internal Server Error if deletion fails

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
