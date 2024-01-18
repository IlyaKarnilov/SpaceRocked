using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models
{
    public class FuelViewModel
    {
        public string Name { get; set; } 
        public double WeightPerCubicMeter { get; set; }
        public List<Fuel>? Fuels { get; set; }
    }
}
