using System.Threading.Tasks;
using WebAppTask2.Models;

namespace WebAppTask2.Interfaces
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetAllForAnimal(int animalId);
        void Add(Visit visit);
        void Update(Visit visit);
        void Delete(int id);
        Task<Visit> GetById(int id);
    }
}