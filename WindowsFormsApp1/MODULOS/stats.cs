using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1.MODULOS
{
    class Stats
    {
        private readonly ConexionMySQL conexionMySQL;

        public Stats()
        {
            conexionMySQL = new ConexionMySQL();
        }

        public DataTable ObtenerDatos(string year = null, string agent = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                conexionMySQL.Conectar();
                string query = "SELECT AÑO1, MES1, ATENDIDOPOR, COUNT(*) AS Count FROM conteo WHERE 1=1";

                if (!string.IsNullOrEmpty(year))
                {
                    query += " AND AÑO1 = @year";
                }

                if (!string.IsNullOrEmpty(agent))
                {
                    query += " AND ATENDIDOPOR = @agent";
                }

                query += " GROUP BY AÑO1, MES1, ATENDIDOPOR";

                MySqlCommand cmd = new MySqlCommand(query, conexionMySQL.GetConnection());

                if (!string.IsNullOrEmpty(year))
                {
                    cmd.Parameters.AddWithValue("@year", year);
                }

                if (!string.IsNullOrEmpty(agent))
                {
                    cmd.Parameters.AddWithValue("@agent", agent);
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionMySQL.Dispose();
            }

            return dataTable;
        }

        public DataTable ObtenerAnios()
        {
            DataTable dataTable = new DataTable();

            try
            {
                conexionMySQL.Conectar();
                string query = "SELECT DISTINCT AÑO1 FROM conteo ORDER BY AÑO1";
                MySqlCommand cmd = new MySqlCommand(query, conexionMySQL.GetConnection());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener años: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionMySQL.Dispose();
            }

            return dataTable;
        }

        public DataTable ObtenerAgentes()
        {
            DataTable dataTable = new DataTable();

            try
            {
                conexionMySQL.Conectar();
                string query = "SELECT DISTINCT ATENDIDOPOR FROM conteo ORDER BY ATENDIDOPOR";
                MySqlCommand cmd = new MySqlCommand(query, conexionMySQL.GetConnection());

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener agentes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionMySQL.Dispose();
            }

            return dataTable;
        }
    }
}
