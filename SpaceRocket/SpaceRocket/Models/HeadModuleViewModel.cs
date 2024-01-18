using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models
{
    public class HeadModuleViewModel
    {
        public string Name { get; set; }
        public int CrewCount { get; set; }
        public double Weight { get; set; }
        public List<HeadModule>? headModules { get; set; }
    }
}
