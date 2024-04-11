using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppTask2.Models;

namespace WebAppTask2.Interfaces
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllForAnimal(int animalId);
        void Add(Visit visit); // Change the return type to void
        void Update(Visit visit);
        void Delete(int id);
        Task<Visit> GetById(int id);
    }
}