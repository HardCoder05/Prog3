using EventMasterSoftDA.DAO;
using EventMasterSoftDBManager;
using EventMasterSoftModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMasterSoftDA.Impl
{
    public class EventoMySQL : EventoDAO
    {
        public int insertar(Evento evento)
        {
            MySqlParameter[] parametros = new MySqlParameter[11];

            parametros[0] = new MySqlParameter("_id_evento", MySqlDbType.Int32);
            parametros[0].Direction = ParameterDirection.Output;
            parametros[1] = new MySqlParameter("_fid_productora", evento.Productora.IdProductora);
            parametros[2] = new MySqlParameter("_fid_clasificacion", evento.Clasificacion);
            parametros[3] = new MySqlParameter("_nombre", evento.Nombre);
            parametros[4] = new MySqlParameter("_costo_realizacion", evento.CostoRealizacion);
            parametros[5] = new MySqlParameter("_tipo_evento", evento.TipoEvento.ToString());
            parametros[6] = new MySqlParameter("_fecha_realizacion", evento.FechaRealizacion);
            parametros[7] = new MySqlParameter("_descripcion", evento.Descripcion);
            parametros[8] = new MySqlParameter("_permite_reingreso", evento.PermiteReingreso);
            parametros[9] = new MySqlParameter("_permite_grabacion", evento.PermiteGrabacion);
            parametros[10] = new MySqlParameter("_banner_promocional", evento.BannerPromocional);

            DBManager.Instance.EjecutarProcedimiento("INSERTAR_EVENTO", parametros, "_id_evento");

            evento.IdEvento = Int32.Parse(parametros[0].Value.ToString());

            return evento.IdEvento;
        }
        public BindingList<Evento> listarPorNombre(string nombre)
        {
            BindingList<Evento> lista = new BindingList<Evento>();

            MySqlParameter[] parametros = new MySqlParameter[1];

            parametros[0] = new MySqlParameter("_nombre", nombre);

            MySqlDataReader lector = DBManager.Instance.EjecutarProcedimientoLectura("LISTAR_EVENTOS_X_NOMBRE", parametros);

            while (lector.Read())
            {
                Evento evento = new Evento
                {
                    IdEvento = Int32.Parse(lector["id_evento"].ToString()),
                    Nombre = lector["nombre_evento"].ToString(),
                    FechaRealizacion = DateTime.Parse(lector["fecha_realizacion"].ToString()),
                    Productora = new Productora
                    {
                        IdProductora = Int32.Parse(lector["id_productora"].ToString()),
                        Nombre = lector["nombre_productora"].ToString()
                    }
                };

                lista.Add(evento);
            }

            DBManager.Instance.CerrarConexion();

            return lista;
        }
        public Evento obtenerPorId(int id)
        {
            MySqlParameter[] parametros = new MySqlParameter[1];
            parametros[0] = new MySqlParameter("_id_evento", id);

            MySqlDataReader lector = DBManager.Instance.EjecutarProcedimientoLectura("OBTENER_EVENTO_X_ID", parametros);

            Evento evento = null;

            while (lector.Read())
            {
                evento = new Evento
                {
                    IdEvento = Int32.Parse(lector["id_evento"].ToString()),
                    Productora = new Productora
                    {
                        IdProductora = Int32.Parse(lector["id_productora"].ToString()),
                        Nombre = lector["nombre_productora"].ToString()
                    },
                    Clasificacion = Char.Parse(lector["id_clasificacion"].ToString()),
                    Nombre = lector["nombre_evento"].ToString(),
                    CostoRealizacion = Double.Parse(lector["costo_realizacion"].ToString()),
                    TipoEvento = (TipoEvento)Enum.Parse(typeof(TipoEvento), lector["tipo_evento"].ToString()),
                    FechaRealizacion = DateTime.Parse(lector["fecha_realizacion"].ToString()),
                    Descripcion = lector["descripcion"].ToString(),
                    PermiteReingreso = Convert.ToBoolean(lector["permite_reingreso"]),
                    PermiteGrabacion = Convert.ToBoolean(lector["permite_grabacion"]),
                    BannerPromocional = (byte[])lector["banner_promocional"],
                    Activo = Convert.ToBoolean(lector["activo"])
                };
            }

            DBManager.Instance.CerrarConexion();

            return evento;
        }
    }
}
