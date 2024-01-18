
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRocket.Data.Entitys
{
    public class Tank : BaseEntity
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double Weight { get; set; }
    }
}
