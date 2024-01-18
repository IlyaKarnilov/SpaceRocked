using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models.EditViewModels
{
    public class EditRocketViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HeadModuleName { get; set; }
        public string EngineName { get; set; }
        public string TankName { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<HeadModule>? HeadModules { get; set; } = new List<HeadModule>();
        public List<Engine>? Engines { get; set; } = new List<Engine>();
        public List<Tank>? Tanks { get; set; } = new List<Tank>();
       
    }
}
