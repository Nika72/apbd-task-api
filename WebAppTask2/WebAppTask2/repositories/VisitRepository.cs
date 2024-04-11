using WebAppTask2.Interfaces;
using WebAppTask2.Models;

namespace WebAppTask2.repositories
{
    public class VisitRepository : IVisitRepository
    {
        private List<Visit> _visits = new List<Visit>();

        public void Add(Visit visit)
        {
            _visits.Add(visit);
        }

        public void Update(Visit visit)
        {
            var existingVisit = _visits.FirstOrDefault(v => v.Id == visit.Id);
            if (existingVisit != null)
            {
                existingVisit.DateOfVisit = visit.DateOfVisit;
                existingVisit.Price = visit.Price;
                // Update other properties as needed
            }
        }

        public void Delete(int id)
        {
            var visitToRemove = _visits.FirstOrDefault(v => v.Id == id);
            if (visitToRemove != null)
            {
                _visits.Remove(visitToRemove);
            }
        }

        public Task<IEnumerable<Visit>> GetAllForAnimal(int animalId)
        {
            var animalVisits = _visits.Where(v => v.AnimalId == animalId).ToList();
            return Task.FromResult(animalVisits.AsEnumerable());
        }

        public Task<Visit?> GetById(int id)
        {
            var visit = _visits.FirstOrDefault(v => v.Id == id);
            return Task.FromResult<Visit?>(visit);
        }
    }
}