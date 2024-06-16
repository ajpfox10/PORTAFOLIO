using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using DataTable = System.Data.DataTable;

namespace WindowsFormsApp1
{
    public partial class CUMPLEAÑOSSSS : Form
    {
        private DataTable datosFiltrados = null;
        public CUMPLEAÑOSSSS()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.CUMPLESS_Load);
            ContextMenuStrip menuContextual = new ContextMenuStrip();
            this.ANTIGUEDAD.ContextMenuStrip = menuContextual;
            ConfigurarMenuContextual(ANTIGUEDAD);
        }
        private void CUMPLESS_Load(object sender, EventArgs e)
        {
            try
            {
                // Llenar el ComboBox con los nombres de las columnas
                cmbColumnas.Items.Add("APELLIDO Y NOMBRE");
                cmbColumnas.Items.Add("dni");
                cmbColumnas.Items.Add("FECHA DE INGRESO");
                cmbColumnas.Items.Add("Antiguedad");
                cmbColumnas.Items.Add("Antiguedad al año anterior");
                cmbColumnas.Items.Add("Ley");
                // Selecciona la primera columna por defecto
                cmbColumnas.SelectedIndex = 0;
                cmbColumnasSecundario.Items.Add("APELLIDO Y NOMBRE");
                cmbColumnas.Items.Add("dni");
                cmbColumnasSecundario.Items.Add("FECHA DE INGRESO");
                cmbColumnasSecundario.Items.Add("Antiguedad");
                cmbColumnasSecundario.Items.Add("Antiguedad al año anterior");
                cmbColumnasSecundario.Items.Add("Ley");
                // Selecciona la primera columna por defecto
                cmbColumnasSecundario.SelectedIndex = 0;
                // Código de inicialización
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Load: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CARGA_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        // Declarar una variable para almacenar los datos originales cargados
        private DataTable datosOriginales = null;
        // Método para cargar los datos iniciales
        private void CargarDatos()
        {
            try
            {
                using (ConexionMySQL conexion = new ConexionMySQL())
                {
                    string consulta =
                    "SELECT PERSONAL.`APELLDO Y NOMBRE` AS `APELLIDO Y NOMBRE`, PERSONAL.dni, PERSONAL.`FECHA DE INGRESO`, ley.Ley, " +
                    "YEAR(CURDATE()) - YEAR(STR_TO_DATE(PERSONAL.`FECHA DE INGRESO`, '%d/%m/%Y')) - " +
                    "IF(DATE_FORMAT(CURDATE(), '%m%d') < DATE_FORMAT(STR_TO_DATE(PERSONAL.`FECHA DE INGRESO`, '%d/%m/%Y'), '%m%d'), 1, 0) AS Antiguedad, " +
                    "YEAR(CURDATE()) - 1 - YEAR(STR_TO_DATE(PERSONAL.`FECHA DE INGRESO`, '%d/%m/%Y')) - " +
                    "IF(DATE_FORMAT(CONCAT(YEAR(CURDATE()) - 1, '-12-31'), '%m%d') < DATE_FORMAT(STR_TO_DATE(PERSONAL.`FECHA DE INGRESO`, '%d/%m/%Y'), '%m%d'), 1, 0) AS `Antiguedad al año anterior` " +
                    "FROM ley " +
                    "INNER JOIN PERSONAL ON ley.IDLEY = PERSONAL.Ley " +
                    "WHERE PERSONAL.ACTIVO = -1 " +
                    "ORDER BY PERSONAL.`APELLDO Y NOMBRE`, `Antiguedad al año anterior` DESC;";


                    datosOriginales = conexion.EjecutarConsulta(consulta);

                    LlenarListView(datosOriginales);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CargarDatos: {ex.Message}\n{ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para aplicar el segundo nivel de filtrado sobre los datos ya filtrados
        private void AplicarFiltroSecundario()
        {
            if (datosFiltrados == null)
                return;

            string columnaSeleccionada = cmbColumnasSecundario.SelectedItem.ToString();
            string valorBuscado = txtBuscarSecundario.Text.ToLower(); // Convertir a minúsculas para comparación

            DataView dv = new DataView(datosFiltrados);

            // Aplicar el filtro utilizando Convert en la columna y el valor buscado
            dv.RowFilter = $"CONVERT([{columnaSeleccionada}], 'System.String') LIKE '%{Convert.ToString(valorBuscado)}%'";

            // Limpiar el ListView y volver a llenarlo con los datos filtrados
            ANTIGUEDAD.Items.Clear();
            foreach (DataRowView drv in dv)
            {
                ListViewItem item = new ListViewItem(drv["APELLIDO Y NOMBRE"].ToString());
                item.SubItems.Add(drv["dni"].ToString());
                item.SubItems.Add(drv["FECHA DE INGRESO"].ToString());
                item.SubItems.Add(drv["Antiguedad"].ToString());
                item.SubItems.Add(drv["Antiguedad al año anterior"].ToString());
                item.SubItems.Add(drv["Ley"].ToString());
                ANTIGUEDAD.Items.Add(item);
            }
        }
        // Método para filtrar los datos inicialmente
        private void FiltrarDatos()
        {
            if (datosOriginales == null)
                return;

            string columnaSeleccionada = cmbColumnas.SelectedItem.ToString();
            string valorBuscado = txtBuscar.Text.ToLower(); // Convertir a minúsculas para comparación

            DataView dv = new DataView(datosOriginales);

            // Aplicar el filtro utilizando Convert en la columna y el valor buscado
            dv.RowFilter = $"CONVERT([{columnaSeleccionada}], 'System.String') LIKE '%{Convert.ToString(valorBuscado)}%'";

            // Guardar los datos filtrados para el segundo nivel de filtrado
            datosFiltrados = dv.ToTable();

            // Limpiar el ListView y volver a llenarlo con los datos filtrados
            ANTIGUEDAD.Items.Clear();
            foreach (DataRowView drv in dv)
            {
                ListViewItem item = new ListViewItem(drv["APELLIDO Y NOMBRE"].ToString());
                item.SubItems.Add(drv["dni"].ToString());
                item.SubItems.Add(drv["FECHA DE INGRESO"].ToString());
                item.SubItems.Add(drv["Antiguedad"].ToString());
                item.SubItems.Add(drv["Antiguedad al año anterior"].ToString());
                item.SubItems.Add(drv["Ley"].ToString());
                ANTIGUEDAD.Items.Add(item);
            }
        }
        // Evento para manejar el cambio en el primer ComboBox y aplicar el primer nivel de filtrado
        private void cmbColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarDatos();
        }
        // Evento para manejar el cambio en el TextBox del primer filtro y aplicar el primer nivel de filtrado
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FiltrarDatos();
                e.Handled = true; // Evitar el sonido de "ding" al presionar Enter
            }
        }
        // Evento para manejar el cambio en el segundo ComboBox y aplicar el segundo nivel de filtrado
        private void cmbColumnasSecundario_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltroSecundario();
        }
        // Evento para manejar el cambio en el TextBox del segundo filtro y aplicar el segundo nivel de filtrado
        private void txtBuscarSecundario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AplicarFiltroSecundario();
                e.Handled = true; // Evitar el sonido de "ding" al presionar Enter
            }
        }
        // Método para llenar el ListView
        private void LlenarListView(DataTable dataTable)
        {
            ANTIGUEDAD.Items.Clear();

            ANTIGUEDAD.Columns.Add("APELLIDO Y NOMBRE", 250);
            ANTIGUEDAD.Columns.Add("dni", 100);
            ANTIGUEDAD.Columns.Add("FECHA DE INGRESO", 150);
            ANTIGUEDAD.Columns.Add("Antiguedad", 100);
            ANTIGUEDAD.Columns.Add("Antiguedad al año anterior", 175);
            ANTIGUEDAD.Columns.Add("Ley", 100);

           // ANTIGUEDAD.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["APELLIDO Y NOMBRE"].ToString());
                item.SubItems.Add(row["dni"].ToString());
                item.SubItems.Add(row["FECHA DE INGRESO"].ToString());
                item.SubItems.Add(row["Antiguedad"].ToString());
                item.SubItems.Add(row["Antiguedad al año anterior"].ToString());
                item.SubItems.Add(row["Ley"].ToString());
                ANTIGUEDAD.Items.Add(item);
            }
        }
        private void ConfigurarMenuContextual(ListView listView)
        {
            ContextMenuStrip menuContextual = new ContextMenuStrip();
            menuContextual.Opening += (sender, e) =>
            {
                e.Cancel = (listView.SelectedItems.Count == 0);
            };

            ToolStripMenuItem copiarTodosMenuItem = new ToolStripMenuItem("Copiar Todos los Datos");
            copiarTodosMenuItem.Click += (sender, e) =>
            {
                CopiarTodosLosDatos(listView);
            };
            menuContextual.Items.Add(copiarTodosMenuItem);

            ToolStripMenuItem exportarExcelMenuItem = new ToolStripMenuItem("Exportar a Excel");
            exportarExcelMenuItem.Click += (sender, e) =>
            {
                ExportarAExcel(listView);
            };
            menuContextual.Items.Add(exportarExcelMenuItem);

            listView.ContextMenuStrip = menuContextual;
        }
        private void CopiarTodosLosDatos(ListView listView)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ListViewItem item in listView.Items)
            {
                stringBuilder.AppendLine(string.Join("\t", item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subItem => subItem.Text)));
            }
            Clipboard.SetText(stringBuilder.ToString());
        }
        private void ExportarAExcel(ListView listView)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate { ExportarAExcel(listView); });
                    return;
                }

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                Workbook workbook = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                for (int col = 0; col < listView.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1] = listView.Columns[col].Text;
                }

                for (int row = 0; row < listView.Items.Count; row++)
                {
                    for (int col = 0; col < listView.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1] = listView.Items[row].SubItems[col].Text;
                    }
                }

                worksheet.Columns.AutoFit();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos de Excel|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Datos exportados a Excel correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CARGA_Click_1(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            DateTime fechaAnalizarValue = FECHAANALIZAR.Value;
            string consulta = "SELECT `APELLDO Y NOMBRE` AS 'APELLIDO Y NOMBRE', DATE_FORMAT(FECHAREALDENACIMIENTO, '%d/%m/%Y') AS 'FECHA DE NACIMIENTO' FROM PERSONAL WHERE ACTIVO = -1 AND MONTH(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Month + " AND DAY(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Day;
            conexion.CargarResultadosConsulta(consulta, CUMPLES);
        }
    }
}