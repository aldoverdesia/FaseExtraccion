using FaseExtraccion.DAL;
using FaseExtracion.Infraestructure.Entities;
using FaseExtracion.Infraestructure.Models;
using FaseExtracion.Infraestructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.BLL.Service
{
    public class FaseService : IFaseService
    {
        private readonly IUnitOfWork _unitOfWork;

      //  private readonly ILogger<FaseService> _logger;
       

        public FaseService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

          
        }
        public Task<bool> AddFase(FaseModel AddFaseModel)
        {
            try
            {
                var fase = new Fase();
                fase.Nombre = AddFaseModel.Nombre;
                fase.IdEmplazamiento = AddFaseModel.IdEmplazamiento;
                fase.Estado = AddFaseModel.Estado;
                _unitOfWork.Fase.AddAsync(fase);
                _unitOfWork.Point.AddAsync(AddFaseModel.Ubicacion);
                foreach (var item in AddFaseModel.Perimetro)
                {
                    _unitOfWork.Point.AddAsync(item);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }

        }

        public Task<FaseModel> GetFase(long Id)
        {
            try
            {
                var fase = _unitOfWork.Fase.GetAllByPredicate(f=>f.IdEmplazamiento== Id).FirstOrDefault();
                var puntos = _unitOfWork.Point.GetAllByPredicate(p=>p.IdEmplazamiento== Id);
               
                if (fase == null)
                {
                    return null;
                }
                return Task.FromResult(new FaseModel
                {
                    Estado = fase.Estado,
                    Nombre = fase.Nombre,
                    IdEmplazamiento = fase.IdEmplazamiento,
                    Ubicacion = puntos.Where(p=>p.Ubicacion).FirstOrDefault(),
                    Perimetro = puntos.Where(p=>!p.Ubicacion).ToList()
                });
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public Task<bool> RemoveFase(long Id)
        {
            var fase = _unitOfWork.Fase.GetAllByPredicate(f => f.IdEmplazamiento == Id).FirstOrDefault();
            if (fase == null)
            {
                throw new Exception("El registro a eliminar no se encuentra en el sistema");
            }
            //var puntos = _unitOfWork.Point.GetAllByPredicate(puntos => puntos.IdEmplazamiento == Id);
            //foreach (var item in puntos)
            //{
            //}
            _unitOfWork.Point.DeleteByPredicateAsync(p=>p.IdEmplazamiento==Id);
            _unitOfWork.Fase.DeleteAsync(fase);
            return Task.FromResult(true);   
            

        }

        public Task<bool> UpdateFase(FaseModel UpdateFaseModel)
        {
            try
            {
                var fase = _unitOfWork.Fase.GetAllByPredicate(f => f.IdEmplazamiento == UpdateFaseModel.IdEmplazamiento).FirstOrDefault();
                if (fase == null)
                {
                    throw new Exception("El registro a actualizar no se encuentra en el sistema");

                }
               
                fase.Nombre = UpdateFaseModel.Nombre == null ? fase.Nombre: UpdateFaseModel.Nombre;
               // fase.Ubicacion = UpdateFaseModel.Ubicacion == null ? fase.Ubicacion : UpdateFaseModel.Ubicacion;
  
                fase.Estado = UpdateFaseModel.Estado == 0 ? fase.Estado :UpdateFaseModel.Estado;
                _unitOfWork.Fase.UpdateAsync(fase);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
