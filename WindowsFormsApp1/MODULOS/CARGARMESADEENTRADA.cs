using iText.Kernel.Pdf.Canvas.Wmf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class CARGARMESADEENTRADA
    {
        public void CargarDatos(ListView listView, string consulta, string[] columnas)
        {
            using (ConexionMySQL conexionMySQL = new ConexionMySQL())
            {
                conexionMySQL.Conectar();

                try
                {
                    MySqlConnection conexion = conexionMySQL.conexion;

                    DataTable tabla = new DataTable();

                    using (MySqlCommand sqlCommand = new MySqlCommand(consulta, conexion))
                    {
                        tabla.Load(sqlCommand.ExecuteReader());
                    }

                    listView.View = View.Details;
                    listView.GridLines = true;

                    foreach (string columna in columnas)
                    {
                        listView.Columns.Add(columna.Split(':')[0], int.Parse(columna.Split(':')[1]));
                    }

                    string[] row;
                    listView.Items.AddRange(tabla.AsEnumerable().Select(fila =>
                    {
                        row = columnas.Select(columna => fila[columna.Split(':')[0]].ToString()).ToArray();
                        return new ListViewItem(row);
                    }).ToArray());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error de MySQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error de formato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Error de índice: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error desconocido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // conexionMySQL.Desconectar();
                }
            }
        }
        public void AgregarPedido(string nombreTabla, string nombreColumna, GroupBox groupBox, string pedido, string dni, string agente, DateTime fechaPedido)
        {
            using (ConexionMySQL conexionMySQL = new ConexionMySQL())
            {
                conexionMySQL.Conectar();

                try
                {
                    MySqlConnection conexion = conexionMySQL.conexion;

                    bool hayCheckBoxSeleccionados = false;

                    string nombresCheckBox = "";

                    foreach (Control control in groupBox.Controls)
                    {
                        if (control is CheckBox checkBox && checkBox.Checked)
                        {
                            nombresCheckBox += checkBox.Text + ", ";
                            hayCheckBoxSeleccionados = true;
                        }
                    }

                    string nombresTextBox = "";

                    foreach (Control control in groupBox.Controls)
                    {
                        if (control is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            nombresTextBox += textBox.Text + ", ";
                        }
                    }

                    string nombresSeleccionados = nombresCheckBox + nombresTextBox;

                    if (hayCheckBoxSeleccionados)
                    {
                        nombresSeleccionados = nombresSeleccionados.TrimEnd(',', ' ');
                        string consulta = $"INSERT INTO {nombreTabla} ({nombreColumna}) VALUES ('{pedido}', '{dni}', '{agente}', '{fechaPedido:yyyy-MM-dd}')";



                        using (MySqlCommand sqlCommand = new MySqlCommand(consulta, conexion))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pedido agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar al menos un producto para agregar el pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error de MySQL: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error de formato: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error desconocido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conexionMySQL.Dispose();
                }
            }
        }
    }

}

