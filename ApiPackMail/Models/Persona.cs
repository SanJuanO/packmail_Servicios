using ApiPackMail.Models.Helpers;
using ConnectDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackMail.Models
{
    public class Persona
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string representante { get; set; }
        public string rfc { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string cp { get; set; }
        public string comentarios { get; set; }
        public long tipo_rda { get; set; }
        public long tipo_usuario { get; set; }
        public string estatus { get; set; }
        public DateTime fecha { get; set; }
        public long id_user { get; set; }
        public DateTime fechar { get; set; }
        public DateTime fecham { get; set; }
        public bool borrado { get; set; }

        private database db;
        public string ERROR { get; set; }
        public string _tableName = "persona";
        public Persona(IOptions<AppSettings> settings)
        {
            db = new database(settings);
        }


        public bool getByUsuario()
        {

            try
            {
                string sql = $"SELECT * FROM {_tableName} WHERE id=@id";
                db.PreparedSQL(sql);
                db.command.Parameters.AddWithValue("@id", id);
                ResultSet res = db.getTable();
                if (res.Next())
                {
                    id = res.GetLong("id");
                    nombre = res.Get("nombre");
                    representante = res.Get("representante");
                    rfc = res.Get("rfc");
                    telefono = res.Get("telefono");
                    email = res.Get("email");
                    calle = res.Get("calle");
                    colonia = res.Get("colonia");
                    municipio = res.Get("municipio");
                    estado = res.Get("estado");
                    pais = res.Get("pais");
                    cp = res.Get("cp");
                    comentarios = res.Get("comentarios");
                    tipo_rda= res.GetLong("tipo_rda");
                    tipo_usuario= res.GetLong("tipo_usuario");
                    estatus= res.Get("estatus");
                    fecha = res.GetDateTime("fecha");
                    id_user = res.GetLong("id_user");
                    fechar = res.GetDateTime("fechar");
                    if (!string.IsNullOrEmpty(res.Get("fecham")))
                    {
                        fecham = res.GetDateTime("fecham");
                    }
                    borrado = res.GetBool("borrado");

                    return true;
                }
            }
            catch (Exception e)
            {
                ERROR = e.Message;
            }

            return false;
        }
    }
}
