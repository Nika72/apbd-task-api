using WebAppTask2.Models;

namespace WebAppTask2.Models;

// Animal.cs
public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } 
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public List<Visit> Visits { get; set; } = new List<Visit>();
    
}