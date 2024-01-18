using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRocket.Data.Entitys
{
    public class Rocket:BaseEntity
    {
        public string Name { get; set; }
        public HeadModule HeadModule { get; set; }
        public Engine Engine { get; set; } 
        public Tank Tank { get; set; }
        public DateTime LaunchDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
