using System;
using ConnectDB;

namespace ApiPackMail.Models
{
    public class Usuarios
    {

        public string id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string BORRADO { get; set; }
        public string activo { get; set; }
      

        private database db;

        public Usuarios()
        {
            db = new database();
        }

        public bool obtenerUsuarioByUsuario()
        {

            try
            {
                string sql = "SELECT * FROM mensajeros WHERE usuario=@usuario";
                db.PreparedSQL(sql);
                db.command.Parameters.AddWithValue("@usuario", usuario);
                ResultSet res = db.getTable();
                if (res.Next())
                {
                    id = res.Get("id");
                    nombre = res.Get("nombre");
                    email = res.Get("email");
                    usuario = res.Get("usuario");
                    telefono = res.Get("telefono");
                    password = res.Get("password");
                    BORRADO = res.Get("borrodado");
                    activo = res.Get("FECHA_C");
            
                    return true;
                }
            }
            catch (Exception e) { }

            return false;
        }

    }
}
