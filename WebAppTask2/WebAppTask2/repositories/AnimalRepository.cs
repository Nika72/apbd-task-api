using WebAppTask2.Interfaces;
using WebAppTask2.Models;

namespace WebAppTask2.repositories;

public class AnimalRepository : IAnimalRepository
{
    private List<Animal> _animals = new List<Animal>();

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public bool Delete(Animal animal)
    {
        return _animals.Remove(animal);
    }

    public void Edit(Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == animal.Id);
        if (existingAnimal != null)
        {
            existingAnimal.Name = animal.Name;
            existingAnimal.Category = animal.Category;
            existingAnimal.Weight = animal.Weight;
            existingAnimal.FurColor = animal.FurColor;
        }
    }

    public Animal Get(int id)
    {
        return _animals.FirstOrDefault(a => a.Id == id);
    }

    public Task<IEnumerable<Animal>> GetAll()
    {
        return Task.FromResult(_animals.AsEnumerable());
    }
}