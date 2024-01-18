using SpaceRocket.Data.Entitys;

namespace SpaceRocket.Models.EditViewModels
{
    public class EditEngineViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FuelType { get; set; }
        public double Thrust { get; set; }
        public double Weight { get; set; }
        public List<Fuel>? Fuels { get; set; }
    }
}
