using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRocket.Data.Entitys
{
    public class Engine:BaseEntity
    {
        public string Name { get; set; }
        public Fuel FuelType { get; set; }
        public double Thrust { get; set; }
        public double Weight { get; set; }
    }
}
