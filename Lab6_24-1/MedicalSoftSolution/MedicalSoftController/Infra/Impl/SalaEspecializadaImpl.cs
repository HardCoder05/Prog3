using MedicalSoftController.Infra.DAO;
using MedicalSoftDBManager;
using MedicalSoftModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSoftController.Infra.Impl
{
    public class SalaEspecializadaImpl : SalaEspecializadaDAO
    {
        private MySqlConnection con;
        private MySqlCommand cmd;
        private MySqlDataReader lector;

        public int eliminar(int idSala)
        {
            MySqlParameter[] parametros = new MySqlParameter[1];
            parametros[0] = new MySqlParameter("_id_sala_especializada", idSala);
            DBManager.getInstance().EjecutarProcedimiento("ELIMINAR_SALA_ESPECIALIZADA", parametros);
            return idSala;
        }

        public int insertar(SalaEspecializada sala)
        {
            MySqlParameter[] parametros = new MySqlParameter[7];

            parametros[0] = new MySqlParameter("_id_sala_especializada", MySqlDbType.Int32);
            parametros[0].Direction = ParameterDirection.Output;
            parametros[1] = new MySqlParameter("_espacio_en_m2", sala.EspacioMetrosCuadrados);
            parametros[2] = new MySqlParameter("_torre", sala.Torre);
            parametros[3] = new MySqlParameter("_piso", sala.Piso);
            parametros[4] = new MySqlParameter("_nombre", sala.Nombre);
            parametros[5] = new MySqlParameter("_tipo_sala", sala.TipoSala.ToString());
            parametros[6] = new MySqlParameter("_posee_equipamiento_imagenologia", sala.PoseeEquipamientoImagenologia);

            DBManager.getInstance().EjecutarProcedimiento("INSERTAR_SALA_ESPECIALIZADA", parametros);
            sala.IdAmbienteClinico = Int32.Parse(parametros[0].Value.ToString());
            
            return sala.IdAmbienteClinico;
        }

        public BindingList<SalaEspecializada> listarTodos()
        {
            BindingList<SalaEspecializada> listaSalas = new BindingList<SalaEspecializada>();

            con = new MySqlConnection(DBManager.getInstance().Url);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "LISTAR_SALAS_ESPECIALIZADAS_TODAS";
            cmd.CommandType = CommandType.StoredProcedure;
            lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                SalaEspecializada sala = new SalaEspecializada();
                sala.IdAmbienteClinico = Int32.Parse(lector["id_sala_especializada"].ToString());
                sala.EspacioMetrosCuadrados = Double.Parse(lector["espacio_en_m2"].ToString());
                sala.Torre = char.Parse(lector["torre"].ToString());
                sala.Piso = Int32.Parse(lector["piso"].ToString());
                sala.Nombre = lector["nombre"].ToString();
                sala.TipoSala = (TipoSala)Enum.Parse(typeof(TipoSala), lector["tipo_sala"].ToString());
                sala.PoseeEquipamientoImagenologia = Convert.ToBoolean(lector["posee_equipamiento_imagenologia"]);
                sala.Activo = true;

                listaSalas.Add(sala);
            }

            return listaSalas;
        }

        public int modificar(SalaEspecializada sala)
        {
            MySqlParameter[] parametros = new MySqlParameter[7];
            parametros[0] = new MySqlParameter("_id_sala_especializada", sala.IdAmbienteClinico);
            parametros[1] = new MySqlParameter("_espacio_en_m2", sala.EspacioMetrosCuadrados);
            parametros[2] = new MySqlParameter("_torre", sala.Torre);
            parametros[3] = new MySqlParameter("_piso", sala.Piso);
            parametros[4] = new MySqlParameter("_nombre", sala.Nombre);
            parametros[5] = new MySqlParameter("_tipo_sala", sala.TipoSala.ToString());
            parametros[6] = new MySqlParameter("_posee_equipamiento_imagenologia", sala.PoseeEquipamientoImagenologia);
            DBManager.getInstance().EjecutarProcedimiento("MODIFICAR_SALA_ESPECIALIZADA", parametros);
            return sala.IdAmbienteClinico;
        }

        public SalaEspecializada obtenerPorId(int id)
        {
            MySqlParameter[] parametros = new MySqlParameter[1];
            parametros[0] = new MySqlParameter("_id_sala_especializada", id);

            con = new MySqlConnection(DBManager.getInstance().Url);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "OBTENER_SALA_ESPECIALIZADA_X_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parametros);
            lector = cmd.ExecuteReader();

            SalaEspecializada sala = new SalaEspecializada();
            
            if (lector.Read())
            {
                sala.IdAmbienteClinico = Int32.Parse(lector["id_sala_especializada"].ToString());
                sala.EspacioMetrosCuadrados = Double.Parse(lector["espacio_en_m2"].ToString());
                sala.Torre = char.Parse(lector["torre"].ToString());
                sala.Piso = Int32.Parse(lector["piso"].ToString());
                sala.Nombre = lector["nombre"].ToString();
                sala.TipoSala = (TipoSala)Enum.Parse(typeof(TipoSala), lector["tipo_sala"].ToString());
                sala.PoseeEquipamientoImagenologia = Convert.ToBoolean(lector["posee_equipamiento_imagenologia"]);
            }

            return sala;
        }
    }
}
