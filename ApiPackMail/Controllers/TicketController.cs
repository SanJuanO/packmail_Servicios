using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPackMail.Models;
using ApiPackMail.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiPackMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly IOptions<AppSettings> _settings;


        public TicketController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        [HttpGet("[action]")]
        public ActionResult getByRastreo(string rastreo) {
            ResponseModel respuesta = new ResponseModel();
            respuesta.Resultado = 0;
            respuesta.Mensaje = "¡Error al obtener mensajero intente más tarde!";


            try
            {
                Ticket ticket = new Ticket(_settings);
                ticket.rastreo = rastreo;
                ticket.getByRastreo();
                respuesta.Resultado = 1;
                respuesta.Mensaje = "Ticket obtenido";
                respuesta.Datos=ticket;
            }
            catch
            {
                respuesta.Resultado = 0;
                respuesta.Mensaje = "¡Error al obtener usuario intente más tarde!";
            }

            return Ok(respuesta);
        }

    }
}