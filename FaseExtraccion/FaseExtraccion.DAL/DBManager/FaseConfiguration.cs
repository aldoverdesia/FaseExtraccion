using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaseExtracion.Infraestructure.Entities;

namespace FaseExtraccion.DAL.DBManager
{
    public class FaseConfiguration : IEntityTypeConfiguration<Fase>
    {
        public void Configure(EntityTypeBuilder<Fase> builder)
        {
            builder.ToTable("Fase");
            builder.HasKey(p => p.IdEmplazamiento);
            builder.Property(p => p.Nombre).HasMaxLength(50).IsRequired();
           
           // builder.Property(p => p.Ubicacion).IsRequired();
        }

    }
}
