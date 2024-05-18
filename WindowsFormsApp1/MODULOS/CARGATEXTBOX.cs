using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ConsultaMySQL : IDisposable
    {
        private readonly ConexionMySQL conexion;
        private readonly string consulta;
        private readonly List<Control> controles;
        private readonly List<string> nombresColumnas;
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
                        List<string> nombresColumnas = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            nombresColumnas.Add(reader.GetName(i));
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine("Nombre de columna: " + nombresColumnas[i]);
                            Console.WriteLine("Valor: " + reader.GetValue(i).ToString());
                            Console.WriteLine("Tipo de dato de 'foto': " + reader.GetValue(i).GetType().ToString());
                            if (reader.IsDBNull(i) || (reader.GetValue(i) is int && Convert.ToInt32(reader.GetValue(i)) == 0))
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
                            else if (controles[i] is CheckBox box)
                            {
                                bool valor = reader.GetBoolean(i);
                                box.Checked = valor;
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
