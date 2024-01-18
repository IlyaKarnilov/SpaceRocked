using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models
{
    public class EngineViewModel
    {
        public string Name { get; set; }
        public string FuelType { get; set; }
        public double Thrust { get; set; }
        public double Weight { get; set; }
        public List<Fuel>? Fuels { get; set; } = new List<Fuel>();
        public List<Engine>? Engines { get; set; }

    }
}
