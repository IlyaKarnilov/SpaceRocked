using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models
{
    public class TankViewModel
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double Weight { get; set; }
        public List<Tank>? Tanks { get; set; }
    }
}
