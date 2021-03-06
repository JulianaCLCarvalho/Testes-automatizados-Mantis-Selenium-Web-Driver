using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.DataBaseSteps;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.CustomProperties;

namespace DesafioSeleniumMantis.Helpers
{
    public class DataBaseHelpers
    {
        private static MySqlConnection DbConnection()
        {
            string connectionString = "Data Source=" + BuilderJson.ReturnParameterAppSettings("DB_URL") + "," + BuilderJson.ReturnParameterAppSettings("DB_PORT") + ";" +
                                      "Initial Catalog=" + BuilderJson.ReturnParameterAppSettings("DB_NAME") + ";" +
                                      "User ID=" + BuilderJson.ReturnParameterAppSettings("DB_USER") + "; " +
                                      "Password=" + BuilderJson.ReturnParameterAppSettings("DB_PASSWORD") + ";";

            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static void ExecuteQuery(string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(BuilderJson.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static List<string> RetornaDadosQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();
            using (MySqlCommand cmd = new MySqlCommand(query, DbConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(BuilderJson.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }
            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                string result = string.Empty;
                Assume.That(!result.Equals(string.Empty), "A consulta do banco de dados não retornou nenhum registro");
            }


            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return lista;

        }
        /*
        public static void PrepararMassaDeTestes()
        {
            CargaTestesDBSteps.deletaMassaTestesDB();
            CargaTestesDBSteps.InsereMassaTestesDB();
        }
        */
    }
}
