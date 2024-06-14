using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CUMPLEAÑOSSSS : Form
    {
        public CUMPLEAÑOSSSS()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.CUMPLESS_Load); // Conecta el evento Load correctamente
        }
        private void CUMPLESS_Load(object sender, EventArgs e) // Asegúrate de que el nombre del método sea correcto
        {
            try
            {
                // Código de inicialización
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Load: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CARGA_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionMySQL conexion = new ConexionMySQL();
                DateTime fechaAnalizarValue = FECHAANALIZAR.Value;
                string consulta = "SELECT `APELLDO Y NOMBRE` AS 'APELLIDO Y NOMBRE', DATE_FORMAT(FECHAREALDENACIMIENTO, '%d/%m/%Y') AS 'FECHA DE NACIMIENTO' FROM PERSONAL WHERE ACTIVO = -1 AND MONTH(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Month + " AND DAY(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Day;
                conexion.CargarResultadosConsulta(consulta, CUMPLES);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CARGA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CARGARS_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionMySQL conexion = new ConexionMySQL();
                // Consulta SQL para obtener los registros que cumplen con los criterios de antigüedad
                string consulta = "SELECT `APELLDO Y NOMBRE`, `FECHA DE INGRESO`, " +
                                  "YEAR(CURDATE()) - YEAR(STR_TO_DATE(`FECHA DE INGRESO`, '%d/%m/%Y')) - " +
                                  "IF(DATE_FORMAT(CURDATE(), '%m%d') < DATE_FORMAT(STR_TO_DATE(`FECHA DE INGRESO`, '%d/%m/%Y'), '%m%d'), 1, 0) AS Antiguedad, " +
                                  "YEAR(CURDATE()) - YEAR(STR_TO_DATE(`FECHA DE INGRESO`, '%d/%m/%Y')) - " +
                                  "IF(DATE_FORMAT(CONCAT(YEAR(CURDATE()) - 1, '-12-31'), '%m%d') < DATE_FORMAT(STR_TO_DATE(`FECHA DE INGRESO`, '%d/%m/%Y'), '%m%d'), 1, 0) AS AntiguedadAnterior " +
                                  "FROM PERSONAL " +
                                  "WHERE ACTIVO = -1 " +
                                  "ORDER BY Antiguedad DESC"; // Ordenar por Antigüedad de forma descendente

                // Para depuración: muestra la consulta en un MessageBox
                MessageBox.Show(consulta, "Consulta SQL Generada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ejecutar la consulta y obtener los resultados
                DataTable resultado = conexion.EjecutarConsulta(consulta);

                // Llenar el ListView con los resultados
                LlenarListView(resultado);

                // Verificar si se han obtenido resultados
                if (ANTIGUEDAD.Items.Count > 0)
                {
                    MessageBox.Show("Datos cargados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron datos que coincidan con los criterios.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CARGARS_Click: {ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarListView(DataTable tabla)
        {
            // Limpiar el ListView antes de llenarlo
            ANTIGUEDAD.Items.Clear();
            ANTIGUEDAD.Columns.Add("Apellido y Nombre", 150);
            ANTIGUEDAD.Columns.Add("Fecha de Ingreso", 100);
            ANTIGUEDAD.Columns.Add("Antigüedad", 80);
            ANTIGUEDAD.Columns.Add("Antigüedad al 31/12/AñoAnterior", 120); // Nueva columna

            // Agregar cada fila de la tabla al ListView
            foreach (DataRow fila in tabla.Rows)
            {
                ListViewItem item = new ListViewItem(fila["APELLDO Y NOMBRE"].ToString());
                item.SubItems.Add(fila["FECHA DE INGRESO"].ToString());
                item.SubItems.Add(fila["Antiguedad"].ToString());
                item.SubItems.Add(fila["AntiguedadAnterior"].ToString()); // Agregar la nueva columna
                ANTIGUEDAD.Items.Add(item);
            }
        }









    }
}
