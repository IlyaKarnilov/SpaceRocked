using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceRocket.Data.Entitys
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }= DateTime.UtcNow;
        public DateTime? DateUpdatet { get; set; }
        public Guid? UserCreated { get; set; }
        public Guid? UserUpdated { get; set; }
        
    }
}
