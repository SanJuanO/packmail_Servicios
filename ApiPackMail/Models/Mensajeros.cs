using ConnectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackMail.Models
{
    public class Mensajeros
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public long id_rol { get; set; }
        public string foto { get; set; }
        public int activo { get; set; }
        public DateTime fechar { get; set; }
        public DateTime fecham { get; set; }
        public int borrado { get; set; }
        public long iduser { get; set; }

        private database db;
        public string ERROR { get; set; }

        public Mensajeros()
        {
            db = new database();
        }

        public bool getByUsuario()
        {

            try
            {
                string sql = "SELECT * FROM mensajeros WHERE usuario=@usuario";
                db.PreparedSQL(sql);
                db.command.Parameters.AddWithValue("@usuario", usuario);
                ResultSet res = db.getTable();
                if (res.Next())
                {
                    id = res.GetLong("id");
                    nombre = res.Get("nombre");
                    email = res.Get("email");
                    telefono = res.Get("telefono");
                    usuario = res.Get("usuario");
                    password = res.Get("password");
                    id_rol = res.GetLong("id_rol");
                    foto = res.Get("foto");
                    activo = res.GetInt("activo");
                    fechar = res.GetDateTime("fechar");
                    fecham = res.GetDateTime("fecham");
                    borrado = res.GetInt("borrodado");
                    iduser = res.GetInt("iduser");

                    return true;
                }
            }
            catch (Exception e) {
                ERROR = e.Message;
            }

            return false;
        }
    }
}
