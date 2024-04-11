using WebAppTask2.Models;

namespace WebAppTask2.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAll();
        Task<Animal> Get(int id);
        Task Add(Animal animal);
        Task Edit(Animal animal);
        Task<bool> Delete(Animal animal);
    }
}
