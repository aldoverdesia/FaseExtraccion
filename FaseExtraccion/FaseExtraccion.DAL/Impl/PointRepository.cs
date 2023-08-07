using FaseExtraccion.DAL.DBManager;
using FaseExtracion.Infraestructure.AbstractRepository;
using FaseExtracion.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL.Impl
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        public PointRepository(FaseExtraccionContext _context) : base(_context)
        {
        }
    }
}
