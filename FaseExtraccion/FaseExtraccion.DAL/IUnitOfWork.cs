using FaseExtracion.Infraestructure.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IFaseRepository Fase { get; }
        IPointRepository Point { get; }

    }
}
