using FaseExtraccion.DAL.DBManager;
using FaseExtracion.Infraestructure.AbstractRepository;
using FaseExtracion.Infraestructure.Entities;
using FaseExtracion.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL.Impl
{
   public class FaseRepository : Repository<Fase>,IFaseRepository
    {
        public FaseRepository(FaseExtraccionContext _context) : base(_context)
        {
        }
    }
}
