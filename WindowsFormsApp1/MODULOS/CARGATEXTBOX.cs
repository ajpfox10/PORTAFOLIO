using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ConsultaMySQL : IDisposable
    {
        private ConexionMySQL conexion;
        private string consulta;
        private List<Control> controles;
        private List<string> nombresColumnas;

        public ConsultaMySQL(string consulta, List<Control> controles, List<string> nombresColumnas)
        {
            this.conexion = new ConexionMySQL();
            this.consulta = consulta;
            this.controles = controles;
            this.nombresColumnas = nombresColumnas;
        }

        public void EjecutarConsulta()
        {
            using (MySqlCommand comando = new MySqlCommand(consulta, conexion.GetConnection()))
            {
                conexion.Conectar();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < controles.Count; i++)
                        {
                            if (reader.IsDBNull(i))
                            {
                                string nombreColumna = nombresColumnas[i];
                                if (controles[i] is CheckBox)
                                {
                                    MessageBox.Show("FALTA HACER (" + nombreColumna + ")");
                                }
                                else
                                {
                                    controles[i].Text = "FALTA HACER (" + nombreColumna + ")";
                                }
                            }
                            else if (controles[i] is CheckBox)
                            {
                                bool valor = reader.GetBoolean(i);
                                ((CheckBox)controles[i]).Checked = valor;
                            }
                            else if (controles[i] is TextBox)
                            {
                                controles[i].Text = reader.GetString(i);
                            }
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            conexion.Dispose();
        }
    }
}
