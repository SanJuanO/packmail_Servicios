using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPackMail.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPackMail.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<UserEntity>>> Get()
        {

            var listUser = await GetList();
            if (listUser.Count() < 0)
            {

                return NotFound();

            }
            return listUser;
          //  return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        private async Task<List<UserEntity>> GetList()
        {
            var listuser = new List<UserEntity>() {

                new UserEntity()
                {
                    Id=1,Name="dfdaf",Password="Sdfd",Username="sdfds"
            },
 new UserEntity()
                 {
                    Id=1,Name="dfdaf",Password="Sdfd",Username="sdfds"
                }, new UserEntity() {
                    Id=1,Name="dfdaf",Password="Sdfd",Username="sdfds"
                },

            };
            return listuser;

        }


        [HttpPost("[action]")]
        public ActionResult Login([FromBody] Usuarios usuariom)
        {

            int result = 0;
            string msj = "¡Error al obtener usuario intente más tarde!";

            try
            {
                Usuarios aux = new Usuarios();
                aux.password = usuariom.password;
                if (usuariom.obtenerUsuarioByUsuario())
                {
                    if (usuariom.password.Equals(aux.password))
                    {
                        result = 1;
                        msj = "¡Sesion iniciada!";
                    }
                    else
                    {
                        result = 0;
                        msj = "¡Contraseña incorrecta!";
                    }
                }
                else
                {
                    result = 0;
                    msj = "¡Usuario no existe!";
                }
            }
            catch
            {
                result = 0;
                msj = "¡Error al obtener usuario intente más tarde!";
            }

            return Ok(new
            {
                resultado = result,
                mensaje = msj,
                usuario = usuariom
            });
        }




    }
}
