using FaseExtraccion.DAL.DBManager;
using FaseExtraccion.DAL.Impl;
using FaseExtracion.Infraestructure.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly FaseExtraccionContext _context;
        IFaseRepository _fase;
        IPointRepository _point;
       

        public UnitOfWork(FaseExtraccionContext context)
        {
            _context = context;
        }
        
        public IFaseRepository Fase
        {
            get
            {
                if(_fase == null)
                {
                    _fase = new FaseRepository(_context);
                }
                return _fase;
            }
        }

        public IPointRepository Point
        {
            get
            {
                if (_point == null)
                {
                    _point = new PointRepository(_context);
                }
                return _point;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        ~UnitOfWork()
        {

            Dispose(disposing: false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();

                }
                _disposed = true;
                return;
            }
        }
    }
}
