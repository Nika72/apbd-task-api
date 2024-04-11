using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTask2.Interfaces;
using WebAppTask2.Models;

namespace WebAppTask2.repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly List<Animal> _animals = new List<Animal>();

        public async Task Add(Animal animal)
        {
            _animals.Add(animal);
            await Task.CompletedTask;
        }

        public async Task<bool> Delete(Animal animal)
        {
            var result = _animals.Remove(animal);
            await Task.CompletedTask;
            return result;
        }

        public async Task Edit(Animal animal)
        {
            var existingAnimal = _animals.FirstOrDefault(a => a.Id == animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Category = animal.Category;
                existingAnimal.Weight = animal.Weight;
                existingAnimal.FurColor = animal.FurColor;
            }
            await Task.CompletedTask;
        }

        public async Task<Animal> Get(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            await Task.CompletedTask;
            return animal;
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            await Task.CompletedTask;
            return _animals.AsEnumerable();
        }
    }
}