using Microsoft.EntityFrameworkCore;
using SpaceRocket.Data.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaseRocket.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { 

        }

        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Tank> Tank { get; set; }
        public DbSet<HeadModule> HeadModule { get; set; }
        public DbSet<Rocket> Rocket { get; set; }
    }
}
