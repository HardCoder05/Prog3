using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MedicalSoftDBManager
{
    public class DBManager
    {
        private static DBManager dbManager;
        private string url;
        private string hostname = "database-lab06.ct8ec2g04pnq.us-east-1.rds.amazonaws.com";
        private string usuario = "administrador";
        private string password = "contraparalabs2025";
        private string database = "lab6";
        private string puerto = "3306";
        //private string nombreArchivo = "properties.txt";
        private MySqlConnection con;
        private MySqlCommand com;
        private DBManager()
        {
            this.url = "server=" + hostname + ";"
                + "user=" + usuario + ";"
                + "password=" + password + ";"
                + "database=" + database + ";"
                + "port=" + puerto + ";";
            con = new MySqlConnection(url);
        }

        public static DBManager getInstance()
        {
            if (dbManager == null)
                dbManager = new DBManager();
            return dbManager;
        }

        public string Url
        {
            get => url;
        }

        public MySqlConnection Connection
        {
            get
            {
                AbrirConexion();
                return con;
            }
        }

        private void AbrirConexion()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
        }

        public void CerrarConexion()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        //Métodos para llamadas a Procedimientos Almacenados
        public int EjecutarProcedimiento(string nombreProcedimiento,
            MySqlParameter[] parametros)
        {
            int resultado = 0;
            try
            {
                AbrirConexion();
                com = con.CreateCommand();
                com.CommandText = nombreProcedimiento;
                com.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                    com.Parameters.AddRange(parametros);
                resultado = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
            return resultado;
        }
    }
}
