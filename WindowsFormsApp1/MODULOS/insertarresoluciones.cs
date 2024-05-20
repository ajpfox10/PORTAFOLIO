using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class GestionResoluciones
    {
        private readonly ConexionMySQL conexionMySQL;

        public GestionResoluciones()
        {
            conexionMySQL = new ConexionMySQL();
        }

        public void InsertarResolucion(int dni, string numeroResolucion, string tipoResolucionValueMember, DateTime fechaResolucion, string combinacion)
        {
            try
            {
                conexionMySQL.Conectar();

                string query = "INSERT INTO Resoluciones (dni, resolucion, tipoderesolucion, FECHADERESOLUCION, COMBINACION) VALUES (@DNI, @Resolucion, @TipoDeResolucion, @FechaDeResolucion, @Combinacion)";

                using (MySqlCommand command = new MySqlCommand(query, conexionMySQL.GetConnection()))
                {
                    command.Parameters.AddWithValue("@DNI", dni);
                    command.Parameters.AddWithValue("@Resolucion", numeroResolucion);
                    command.Parameters.AddWithValue("@TipoDeResolucion", tipoResolucionValueMember);
                    command.Parameters.AddWithValue("@FechaDeResolucion", fechaResolucion.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@Combinacion", combinacion);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la resolución: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexionMySQL.GetConnection().State == System.Data.ConnectionState.Open)
                {
                    conexionMySQL.GetConnection().Close();
                }
            }
        }



    }
}
