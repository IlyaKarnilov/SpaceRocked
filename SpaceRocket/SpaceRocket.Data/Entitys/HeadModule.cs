using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRocket.Data.Entitys
{
    public class HeadModule : BaseEntity
    {
        public string Name { get; set; }
        public int CrewCount { get; set; }
        public double Weight { get; set; }
    }
}
