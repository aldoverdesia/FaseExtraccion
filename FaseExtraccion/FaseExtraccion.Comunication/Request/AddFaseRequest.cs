using FaseExtracion.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.Comunication.Request
{
     public class AddFaseRequest
    {
       public string Nombre { get; set; }
        public int Estado { get; set; }
        public int X_Centro { get; set; }
        public int Y_Centro { get; set; }
        public int IdEmplazamiento { get; set; }

        public List<Tuple<int,int>> perimetro { get; set; }
    }
}
