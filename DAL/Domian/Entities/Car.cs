using System.Collections.Generic;
namespace DAL.Domian.Entities
{
    public class  Car
    {
        public int ID { get; set; }
        public string Name { get => Model?.Name + " " + Model?.Brand?.Name; } 
        public decimal Price { get; set; }
        public List<Photo> Photos { get; set; }
        public Model Model { get; set; }
        public int EngineCapacity { get; set; }
        public Color Color { get; set; }
        public decimal Mileage { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string  About { get; set; }
        public int Year { get; set; }
    }
}
