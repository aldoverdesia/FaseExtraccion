using FaseExtracion.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaseExtraccion.Comunication.Response
{
    public class GetFaseResponse
    {
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public Point Ubicacion { get; set; }
        public int IdEmplazamiento { get; set; }
        
        public List<Point> Perimetro { get;set; }
    }
}
