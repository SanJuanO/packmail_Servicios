﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPackMail.Models;
using BenchmarkDotNet.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPackMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajerosController : ControllerBase
    {

        ///<Summary>
        ///Solo nececita usuario,password
        ///</Summary>
        ///<param name="usuario">nombre de usuario</param>
        ///<param name="password">password del usuario</param>
        [HttpPost("[action]")]
        public ActionResult Login([FromBody] Mensajeros usuariom)
        {
            ResponseModel respuesta = new ResponseModel();
            respuesta.Resultado = 0;
            respuesta.Mensaje = "¡Error al obtener mensajero intente más tarde!";

            try
            {
                Mensajeros aux = new Mensajeros();
                aux.password = usuariom.password;
                if (usuariom.getByUsuario())
                {
                    if (usuariom.password.Equals(aux.password))
                    {
                        respuesta.Resultado = 1;
                        respuesta.Mensaje = "¡Sesion iniciada!";
                        respuesta.Datos = usuariom;
                    }
                    else
                    {
                        respuesta.Resultado = 0;
                        respuesta.Mensaje = "¡Contraseña incorrecta!";
                    }
                }
                else
                {
                    respuesta.Resultado = 0;
                    respuesta.Mensaje = "¡Usuario no existe!";
                }
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