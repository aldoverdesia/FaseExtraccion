using FaseExtracion.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL.DBManager
{
    public class FaseExtraccionContext:DbContext
    {
        public FaseExtraccionContext(DbContextOptions<FaseExtraccionContext> options) : base(options) { }

        public DbSet<Fase> Fase { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FaseExtraccionContext).Assembly);
            //modelBuilder.ApplyConfiguration(new FaseConfiguration());
            //modelBuilder.ApplyConfiguration(new PointConfiguration());
          

        }
    }
}
