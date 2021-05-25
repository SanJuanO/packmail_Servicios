using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackMail.Models
{
    public class ResponseModel
    {
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }
    }
}
