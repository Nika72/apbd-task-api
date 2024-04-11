using System.Collections.Generic;

namespace WebAppTask2.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = ""; 
        public double Weight { get; set; }
        public string FurColor { get; set; } = ""; 

        // Navigation property for related visits
        public List<Visit> Visits { get; set; } = new List<Visit>();
    }
}