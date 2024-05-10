using iText.StyledXmlParser.Jsoup.Select;
using System;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class FORMULARIODESIGNACION : Form
    {
        private CargarComboBoxes cargadorComboBoxes = new CargarComboBoxes();
        public Int64 _dnis;   
        public FORMULARIODESIGNACION(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            MessageBox.Show(_dnis.ToString());
        }
        private void FORMULARIODESIGNACION_Load(object sender, EventArgs e)
        {
            cargadorComboBoxes.nomenclador(CARGOS);
            cargadorComboBoxes.regimenhorario(REGIMENHORARIO);
            cargadorComboBoxes.ministerios(MINISTERIOS);
            cargadorComboBoxes.CATEGORIA(CATEGORIA);
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + _dnis + "'";
            DataTable dataTable = new DataTable();
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);      
        }
        private void CARGARDATOS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (verificador.VerificarControles(this.Controls))
            {
                // Todos los controles están completos, por lo que se puede insertar los datos en la base de datos
                string A2 = CARGOS.ValueMember;
                string A3 = MINISTERIOS.ValueMember;
                DateTime A4 = INGRESO.Value;
                int A5 = Convert.ToInt32(CATEGORIA.SelectedValue);
                int A6 = Convert.ToInt32(REGIMENHORARIO.SelectedValue);
                string A8 = DEPENDENCIA.Text;
                string A9 = RESOLUCION.Text;
                string A11 = _dnis.ToString();
                string A12 = textBox1.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.INSERTARDATOSIFGRA(A2, A3, A4, A5, A6, A8, A9, A11, A12);
                string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + _dnis + "'";
                conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);
            }
            else
            {
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }
        private void DESIGNACIONESSS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string A2 = CARGOS.ValueMember;
            string A3 = MINISTERIOS.ValueMember;
            DateTime A4 = INGRESO.Value;
            int A5 = Convert.ToInt32(CATEGORIA.SelectedValue);
            int A6 = Convert.ToInt32(REGIMENHORARIO.SelectedValue);
            DateTime A7=BAJA.Value;
            string A8 = DEPENDENCIA.Text;
            string A9 = RESOLUCION.Text;
            string A10 = MOTIVODEBAJA.Text;
            string A12 = textBox1.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.ActualizarDatosdesignaciones(A2, A3, A4, A5, A6, A7, A8, A9, A10, A12);
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + _dnis + "'";
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);
        }
        private void DESIGNACIONESSS_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = DESIGNACIONESSS.SelectedItems[0];
            // Obtener los subelementos de la fila seleccionada
            string columna0 = selectedItem.SubItems[0].Text;
            string columna1 = selectedItem.SubItems[1].Text;
            string columna2 = selectedItem.SubItems[2].Text;
            string fechaTexto1 = selectedItem.SubItems[3].Text;
            string formatoFecha = "yyyy-MM-dd";
            DateTime columna3;
            if (DateTime.TryParseExact(fechaTexto1, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna3))
            {
                string fechaFormateada = columna3.ToString("dd/MM/yyyy");
                INGRESO.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna4 = selectedItem.SubItems[4].Text;
            string columna5 = selectedItem.SubItems[5].Text;
            string fechaTexto2 = selectedItem.SubItems[6].Text;     // Corregido el índice a 6 para la columna de fecha 2
            DateTime columna6;
            if (DateTime.TryParseExact(fechaTexto2, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna6))
            {
                string fechaFormateada = columna6.ToString("dd/MM/yyyy");
                BAJA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna7 = selectedItem.SubItems[7].Text;
            string columna8 = selectedItem.SubItems[8].Text;
            string columna9 = selectedItem.SubItems[9].Text;
            string columna10 = selectedItem.SubItems[10].Text;
            ID.Text = columna0;
            CARGOS.Text = columna1;
            MINISTERIOS.Text = columna2;
            CATEGORIA.SelectedItem = columna4;
            REGIMENHORARIO.SelectedItem = columna5;
            DEPENDENCIA.Text = columna7;
            RESOLUCION.Text = columna8;
            MOTIVODEBAJA.Text = columna9;
            textBox1.Text = columna10;
        }
        private void DESIGNACIONESSS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem selectedItem = DESIGNACIONESSS.SelectedItems[0]; // Obtén el elemento seleccionado
                // Obtén el valor del campo "idt" del elemento seleccionado
                string idtValue = selectedItem.SubItems[0].Text;
                // Muestra un cuadro de diálogo para confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Elimina el elemento del ListView
                    DESIGNACIONESSS.Items.Remove(selectedItem);
                    ConexionMySQL conexion = new ConexionMySQL();
                    {
                        conexion.Conectar();
                        // Consulta SQL para eliminar el registro
                        string query = "DELETE FROM cargosdeinicio WHERE ID = @idt";
                        using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@idt", idtValue);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void CARGARPDF_Click(object sender, EventArgs e)
        
            {
                int trackBarValue = trackBar2.Value;

                if (trackBarValue >= 0 && trackBarValue < 25)
                {
                    string nombreCarpeta = _dnis.ToString(); // Obtener el nombre de la carpeta adicional desde otra fuente (por ejemplo, otro formulario)
                    rellenACARGODEINICIO formFiller = new rellenACARGODEINICIO(nombreCarpeta);
                    formFiller.FillPdfForm(_dnis.ToString()); ;
                }
                else if (trackBarValue >= 50 && trackBarValue < 100)
                {
                string nombreCarpeta = _dnis.ToString(); // Obtener el nombre de la carpeta adicional desde otra fuente (por ejemplo, otro formulario)
                rellenrcargosdos formFiller = new rellenrcargosdos(nombreCarpeta);
                formFiller.FillPdfForm(_dnis.ToString());
            }
              
        }

    }
}
