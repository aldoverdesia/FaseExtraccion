using FaseExtraccion.Comunication.Request;
using FaseExtraccion.Comunication.Response;
using FaseExtracion.Infraestructure.Entities;
using FaseExtracion.Infraestructure.Models;
using FaseExtracion.Infraestructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FaseExtraccion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaseController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly IFaseService _fase;

        public FaseController(IFaseService faseService)
        {
            _fase= faseService;
        }

        [HttpPost]
        [Route("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddFase([FromBody] AddFaseRequest addFaseRequest)
        {
          if(!ModelState.IsValid) { throw new Exception("Modelo Invalido"); }

            try
            {
                var point = new Point{
                    IdEmplazamiento= addFaseRequest.IdEmplazamiento,
                    X=addFaseRequest.X_Centro,
                    Y=addFaseRequest.Y_Centro,
                    Ubicacion=true
                };

                var perimetro = new List<Point>();
                foreach (var puntos in addFaseRequest.perimetro)
                {
                    perimetro.Add(new Point
                    {
                        IdEmplazamiento = addFaseRequest.IdEmplazamiento,
                        Ubicacion = false,
                        X = puntos.Item1,
                        Y = puntos.Item2,
                    });
                }

                var result = _fase.AddFase(new FaseModel
                {
                    Estado = addFaseRequest.Estado,
                    IdEmplazamiento = addFaseRequest.IdEmplazamiento,
                    Nombre = addFaseRequest.Nombre,
                    Ubicacion = point,
                    Perimetro=perimetro
                }) ;
                return Ok(new BoolResponse { succes = result.Result });
            }
            catch(Exception ex)
            {
                return Ok(new BoolResponse { succes = false });
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateFase([FromBody] AddFaseRequest addFaseRequest)
        {
           
           var update = _fase.UpdateFase(new FaseModel
           {
               Estado = addFaseRequest.Estado,
               IdEmplazamiento = addFaseRequest.IdEmplazamiento,
               Nombre = addFaseRequest.Nombre,
               //Ubicacion= Ubi
           });
            return Ok(new BoolResponse { succes= update.Result });
        }


        [HttpDelete]
        [Route("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteFase([FromBody] DeleteFaseRequest deleteFaseRequest)
        {
            var delete = _fase.RemoveFase(deleteFaseRequest.IdFase);
            return Ok(new BoolResponse { succes=delete.Result });
        }

        [HttpPost]
        [Route("[action]")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult? GetFase([FromBody]GetFaseRequest getFaseRequest)
        {
            var Fase = _fase.GetFase(getFaseRequest.FaseId);
            if (Fase == null) { return null; }
            return Ok(new GetFaseResponse
            {
                Estado = Fase.Result.Estado,
                IdEmplazamiento = Fase.Result.IdEmplazamiento,
                Nombre = Fase.Result.Nombre,
                Ubicacion = Fase.Result.Ubicacion,
                Perimetro=Fase.Result.Perimetro
                
            });
        }

     
    }
}
