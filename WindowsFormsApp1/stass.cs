using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
namespace WindowsFormsApp1
    

{
    public partial class stass : Form
    {
        private ConexionMySQL conexionMySQL = new ConexionMySQL();
        private MySqlConnection conexion;
        public stass()
        {
            InitializeComponent();
            conexion = conexionMySQL.GetConnection();
      
        }
        private void StatsForm_Load(object sender, EventArgs e)
        {
            // Cargar años y meses al inicio del formulario
            CargarAnios();
            CargarMeses();
            CargarAgentes();
        }
        private void CargarAnios()
        {
            comboBoxAnio.Items.Clear();
            DataTable dataTableAnios = conexionMySQL.EjecutarConsulta("SELECT DISTINCT YEAR(HORADEATENCION) AS Anio FROM consultas ORDER BY Anio DESC");
            foreach (DataRow row in dataTableAnios.Rows)
            {
                comboBoxAnio.Items.Add(row["Anio"]);
            }
        }

        private void CargarMeses()
        {
        comboBoxMes.Items.Clear();
        DataTable dataTableMeses = conexionMySQL.EjecutarConsulta("SELECT DISTINCT MONTH(HORADEATENCION) AS MesNumero FROM consultas ORDER BY MONTH(HORADEATENCION)");

        CultureInfo culturaEspañola = new CultureInfo("es-ES");
        string[] nombresMeses = culturaEspañola.DateTimeFormat.MonthNames;

        foreach (DataRow row in dataTableMeses.Rows)
        {
            int mesNumero = Convert.ToInt32(row["MesNumero"]);
            if (mesNumero >= 1 && mesNumero <= 12)
            {
                comboBoxMes.Items.Add(nombresMeses[mesNumero - 1]);
            }
         }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (comboBoxAnio.SelectedItem == null && comboBoxMes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione al menos un año o un mes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroAnio = comboBoxAnio.SelectedItem?.ToString();
            string filtroMes = comboBoxMes.SelectedItem?.ToString();

            string consulta = "SELECT COUNT(*) AS `Total de Consultas` FROM consultas WHERE ";

            if (!string.IsNullOrEmpty(filtroAnio))
            {
                consulta += $"YEAR(HORADEATENCION) = {filtroAnio} ";
                if (!string.IsNullOrEmpty(filtroMes))
                {
                    consulta += $"AND MONTHNAME(HORADEATENCION) = '{filtroMes}'";
                }
            }
            else if (!string.IsNullOrEmpty(filtroMes))
            {
                consulta += $"MONTHNAME(HORADEATENCION) = '{filtroMes}'";
            }

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticas(dataTable);
        }

        private void btnEstadisticasDiarias_Click(object sender, EventArgs e)
        {
            if (comboBoxAnio.SelectedItem == null && comboBoxMes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione al menos un año o un mes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroAnio = comboBoxAnio.SelectedItem?.ToString();
            string filtroMes = comboBoxMes.SelectedItem?.ToString();

            string consulta = "SELECT DATE(HORADEATENCION) AS Dia, COUNT(*) AS `Total de Consultas`  " +
                              "FROM consultas " +
                              "WHERE ";

            if (!string.IsNullOrEmpty(filtroAnio))
            {
                consulta += $"YEAR(HORADEATENCION) = {filtroAnio} ";
                if (!string.IsNullOrEmpty(filtroMes))
                {
                    consulta += $"AND MONTHNAME(HORADEATENCION) = '{filtroMes}' ";
                }
            }
            else if (!string.IsNullOrEmpty(filtroMes))
            {
                consulta += $"MONTHNAME(HORADEATENCION) = '{filtroMes}' ";
            }

            consulta += "GROUP BY Dia ORDER BY Dia";

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticasDiarias(dataTable);
        }

        private void btnEstadisticasPorAgente_Click(object sender, EventArgs e)
        {
            if (comboBoxAnio.SelectedItem == null && comboBoxMes.SelectedItem == null && comboBoxAgente.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione al menos un año, un mes o un agente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filtroAnio = comboBoxAnio.SelectedItem?.ToString();
            string filtroMes = comboBoxMes.SelectedItem?.ToString();
            string filtroAgente = comboBoxAgente.SelectedItem?.ToString();

            string consulta = "SELECT ATENDIDOPOR AS Agente, DATE(HORADEATENCION) AS Dia, COUNT(*) AS `Total de Consultas` " +
                              "FROM consultas " +
                              "WHERE ";

            if (!string.IsNullOrEmpty(filtroAnio))
            {
                consulta += $"YEAR(HORADEATENCION) = {filtroAnio} ";
                if (!string.IsNullOrEmpty(filtroMes))
                {
                    consulta += $"AND MONTHNAME(HORADEATENCION) = '{filtroMes}' ";
                    if (!string.IsNullOrEmpty(filtroAgente))
                    {
                        consulta += $"AND ATENDIDOPOR = '{filtroAgente}' ";
                    }
                }
                else if (!string.IsNullOrEmpty(filtroAgente))
                {
                    consulta += $"AND ATENDIDOPOR = '{filtroAgente}' ";
                }
            }
            else if (!string.IsNullOrEmpty(filtroMes))
            {
                consulta += $"MONTHNAME(HORADEATENCION) = '{filtroMes}' ";
                if (!string.IsNullOrEmpty(filtroAgente))
                {
                    consulta += $"AND ATENDIDOPOR = '{filtroAgente}' ";
                }
            }
            else if (!string.IsNullOrEmpty(filtroAgente))
            {
                consulta += $"ATENDIDOPOR = '{filtroAgente}' ";
            }

            consulta += "GROUP BY Agente, Dia ORDER BY Agente, Dia";

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticasPorAgente(dataTable);
        }




        private void MostrarEstadisticas(DataTable dataTable)
        {
            // Mostrar el total de consultas en el TextBox
            if (dataTable.Rows.Count > 0)
            {
                textBoxTotalConsultas.Text = dataTable.Rows[0]["Total de Consultas"].ToString();
            }
            else
            {
                textBoxTotalConsultas.Text = "0";
            }

            // Mostrar detalles en el DataGridView
            dataGridViewStats.DataSource = dataTable;
        }
      
        private void MostrarEstadisticasDiarias(DataTable dataTable)
        {
            // Mostrar detalles en el DataGridView
            dataGridViewStats.DataSource = dataTable;
            // Limpiar el TextBox
            textBoxTotalConsultas.Text = string.Empty;
        }
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewAExcel(dataGridViewStats);
        }
        private void ExportarDataGridViewAExcel(DataGridView dataGridView)
        {
            try
            {
                // Crear una aplicación de Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;

                // Crear un nuevo libro de Excel
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];

                // Agregar encabezados
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }

                // Agregar datos
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value;
                    }
                }

                // Autoajustar columnas
                worksheet.Columns.AutoFit();

                // Guardar el libro de Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "ExportedData.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportación exitosa", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cerrar y liberar recursos de Excel
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarAgentes()
        {
            comboBoxAgente.Items.Clear();
            DataTable dataTableAgentes = conexionMySQL.EjecutarConsulta("SELECT DISTINCT ATENDIDOPOR AS Agente FROM consultas ORDER BY Agente");
            foreach (DataRow row in dataTableAgentes.Rows)
            {
                comboBoxAgente.Items.Add(row["Agente"]);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            conexionMySQL.Dispose();
        }


        private void MostrarEstadisticasPorAnioMes(DataTable dataTable)
        {
            dataGridViewStats.DataSource = dataTable;

            // Calcular y mostrar el total de consultas
            int totalConsultas = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 1; i < dataTable.Columns.Count; i++) // Ignorar la columna Año
                {
                    totalConsultas += Convert.ToInt32(row[i]);
                }
            }
            textBoxTotalConsultas.Text = totalConsultas.ToString();
        }






        private void MostrarEstadisticasPorAgente(DataTable dataTable)
        {
            dataGridViewStats.DataSource = dataTable;

            // Calcular y mostrar el total de consultas
            int totalConsultas = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                totalConsultas += Convert.ToInt32(row["Total de Consultas"]);
            }
            textBoxTotalConsultas.Text = totalConsultas.ToString();
        }

 


        private void btnEstadisticasPorAnioMes_Click(object sender, EventArgs e)
        {
            string consulta = @"SELECT
        YEAR(HORADEATENCION) AS Año,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 1 THEN 1 ELSE 0 END) AS Enero,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 2 THEN 1 ELSE 0 END) AS Febrero,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 3 THEN 1 ELSE 0 END) AS Marzo,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 4 THEN 1 ELSE 0 END) AS Abril,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 5 THEN 1 ELSE 0 END) AS Mayo,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 6 THEN 1 ELSE 0 END) AS Junio,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 7 THEN 1 ELSE 0 END) AS Julio,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 8 THEN 1 ELSE 0 END) AS Agosto,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 9 THEN 1 ELSE 0 END) AS Septiembre,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 10 THEN 1 ELSE 0 END) AS Octubre,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 11 THEN 1 ELSE 0 END) AS Noviembre,
        SUM(CASE WHEN MONTH(HORADEATENCION) = 12 THEN 1 ELSE 0 END) AS Diciembre
        FROM consultas
        GROUP BY Año
        ORDER BY Año";

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticasPorAnioMes(dataTable);
        }

        private void PORAÑOPORMESPORAGENTE_Click(object sender, EventArgs e)
        {
            string consulta = @"SELECT
         YEAR(HORADEATENCION) AS Año,
         MONTHNAME(HORADEATENCION) AS Mes,
         ATENDIDOPOR AS Agente,
         COUNT(*) AS `Total de Consultas`
         FROM consultas
         GROUP BY Año, Mes, Agente
         ORDER BY Año, Mes, Agente";

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticasPorAnioMesAgente(dataTable);
        }




        private void btnEstadisticasPorAnioMesAgente_Click(object sender, EventArgs e)
        {
            string consulta = @"SELECT
                            YEAR(HORADEATENCION) AS Año,
                            MONTHNAME(HORADEATENCION) AS Mes,
                            ATENDIDOPOR AS Agente,
                            COUNT(*) AS `Total de Consultas`
                        FROM consultas
                        GROUP BY Año, Mes, Agente
                        ORDER BY Año, MONTH(HORADEATENCION), Agente";

            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            MostrarEstadisticasPorAnioMesAgente(dataTable);
        }

        private void MostrarEstadisticasPorAnioMesAgente(DataTable dataTable)
        {
            dataGridViewStats.DataSource = dataTable;

            // Calcular y mostrar el total de consultas
            int totalConsultas = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                totalConsultas += Convert.ToInt32(row["Total de Consultas"]);
            }
            textBoxTotalConsultas.Text = totalConsultas.ToString();
        }







    }
}
