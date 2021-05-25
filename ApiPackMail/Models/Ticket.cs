using ApiPackMail.Models.Helpers;
using ConnectDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackMail.Models
{
    public class Ticket
    {
        public long id { get; set; }
        public string rastreo { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public long persona_entrega { get; set; }
        public long persona_recibe { get; set; }
        public string precio_venta { get; set; }
        public DateTime fecha_recoleccion { get; set; }
        public DateTime fecha_recibido { get; set; }
        public DateTime fechar { get; set; }
        public DateTime fecham { get; set; }
        public long id_user { get; set; }
        public bool borrado { get; set; }
        public int id_estado { get; set; }
        public string tipo_paquete { get; set; }
        public string peso_paquete { get; set; }
        public string valor_paquete { get; set; }
        public string descripcion_paquete { get; set; }
        public string nombre_alterno_recibe { get; set; }
        public string telefono_alterno_recibe { get; set; }
        public string recolectar { get; set; }
        public string tipoentrega { get; set; }
        public string direccionrecolecion { get; set; }
        public string personarecolecion { get; set; }
        public Persona persona_entrega_obj { get; set; }
        public Persona persona_recibe_obj { get; set; }

        private database db;
        private IOptions<AppSettings> _settings;
        public string ERROR { get; set; }
        public string _tableName = "ticket";
        public Ticket(IOptions<AppSettings> settings)
        {
            db = new database(settings);
            _settings = settings;
        }


        public bool getByRastreo()
        {

            try
            {
                string sql = $"SELECT * FROM {_tableName} WHERE rastreo=@rastreo";
                db.PreparedSQL(sql);
                db.command.Parameters.AddWithValue("@rastreo", rastreo);
                ResultSet res = db.getTable();
                if (res.Next())
                {
                    id = res.GetLong("id");
                    rastreo = res.Get("rastreo");
                    direccion = res.Get("direccion");
                    telefono = res.Get("telefono");
                    persona_entrega= res.GetLong("persona_entrega");
                    persona_recibe= res.GetLong("persona_recibe");
                    precio_venta = res.Get("precio_venta");
                    fecha_recoleccion = res.GetDateTime("fecha_recoleccion");
                    fecha_recibido = res.GetDateTime("fecha_recibido");
                    fechar = res.GetDateTime("fechar");
                    fecham = res.GetDateTime("fecham");
                    id_user = res.GetInt("id_user");
                    borrado = res.GetBool("borrado");
                    id_estado = res.GetInt("id_estado");
                    tipo_paquete = res.Get("tipo_paquete");
                    peso_paquete = res.Get("peso_paquete");
                    valor_paquete = res.Get("valor_paquete");
                    descripcion_paquete = res.Get("descripcion_paquete");
                    nombre_alterno_recibe = res.Get("nombre_alterno_recibe");
                    telefono_alterno_recibe = res.Get("telefono_alterno_recibe");
                    recolectar = res.Get("recolectar");
                    tipoentrega = res.Get("tipoentrega");
                    direccionrecolecion= res.Get("direccionrecolecion");
                    personarecolecion= res.Get("personarecolecion");
                    Persona per = new Persona(_settings);
                    Persona peen = new Persona(_settings);
                    per.id = persona_recibe;
                    per.getByUsuario();
                    peen.id = persona_entrega;
                    peen.getByUsuario();
                    persona_entrega_obj = peen;
                    persona_recibe_obj = per;
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
