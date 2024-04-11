using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppTask2.Models
{
    public class Visit
    {
        public int Id { get; private set; }
        public DateTime DateOfVisit { get; set; }
        public double Price { get; set; }

        // Foreign key property linking visits to animals
        [ForeignKey("Animal")]
        public int AnimalId { get; private set; }

        // Navigation property for accessing the related Animal entity
        public Animal Animal { get; set; } = null!;

        // Constructors if needed
        public Visit()
        {
            // Initialize properties if needed
        }

        public Visit(int id, DateTime dateOfVisit, double price, int animalId)
        {
            Id = id;
            DateOfVisit = dateOfVisit;
            Price = price;
            AnimalId = animalId;
        }
    }
}