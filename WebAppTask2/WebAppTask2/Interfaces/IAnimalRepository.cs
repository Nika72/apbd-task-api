using WebAppTask2.Models;

namespace WebAppTask2.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAll();
    Animal Get(int id);
    void Add(Animal animal);
    void Edit(Animal animal);
    bool Delete(Animal animal);
}