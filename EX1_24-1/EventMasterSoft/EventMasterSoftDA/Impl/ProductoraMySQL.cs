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
    public class ProductoraMySQL : ProductoraDAO
    {
        MySqlDataReader lector;
        public BindingList<Productora> listarTodas()
        {
            BindingList<Productora> lista = new BindingList<Productora>();

            try
            {
                lector = DBManager.Instance.EjecutarProcedimientoLectura("LISTAR_PRODUCTORAS_TODAS", null);

                while (lector.Read())
                {
                    Productora p = new Productora
                    {
                        IdProductora = Int32.Parse(lector["id_productora"].ToString()),
                        Nombre = lector["nombre"].ToString(),
                        Activa = Convert.ToBoolean(lector["activa"])
                    };

                    lista.Add(p);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productoras: " + ex.Message);
            }
            finally
            {
                DBManager.Instance.CerrarConexion();
            }

            return lista;
        }

    }
}
