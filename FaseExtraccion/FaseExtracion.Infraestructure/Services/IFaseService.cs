using FaseExtracion.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtracion.Infraestructure.Services
{
    public interface IFaseService
    {
        Task<bool> UpdateFase(FaseModel UpdateFaseModel);
        Task<bool> AddFase(FaseModel AddFaseModel);
        Task<FaseModel> GetFase(long Id);
        Task<bool> RemoveFase(long Id);
      
    }
}
