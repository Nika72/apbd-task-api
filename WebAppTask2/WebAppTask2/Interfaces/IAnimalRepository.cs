// using WebAppTask2.Models;
//
// namespace WebAppTask2.Interfaces;
//
// public interface IAnimalRepository
// {
//     Task<IEnumerable<Animal>> GetAll();
//     Animal Get(int id);
//     void Add(Animal animal);
//     void Edit(Animal animal);
//     bool Delete(Animal animal);
// }

using System.Collections.Generic;
using System.Threading.Tasks;
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
