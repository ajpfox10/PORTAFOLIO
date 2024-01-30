using iText.StyledXmlParser.Jsoup.Select;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;
using System.Globalization;


namespace WindowsFormsApp1
{
    public partial class BONIFICACIONES : Form
    {       
        public Int64 _dnis;
   
        public BONIFICACIONES(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            MessageBox.Show(_dnis.ToString());           
        }
        private void CARGARDATOS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (verificador.VerificarControles(this.Controls))
            {
                // Todos los controles están completos, por lo que se puede insertar los datos en la base de datos
                DateTime A2 = FECHAALTA.Value;
                DateTime A3 = FECHABAJA.Value;
                DateTime A4 = DateTime.Now;
                string A5 = DECRETO.Text;
                string A6 = MOTIVO.Text;
                string A8 = observaciones.Text;
                int A9 = DateTime.Now.Year;
                string A11 = observaciones.Text;
                string A12 = _dnis.ToString();
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.INSERTARDATOSBONIFICACIONES(A2, A3, A4, A5, A6, A8, A9, A11, A12);
                string consulta = "SELECT bonificaciones.ID, DATE_FORMAT(bonificaciones.FECHAALTA, '%Y-%m-%d') AS 'FECHA DE ALTA', DATE_FORMAT(bonificaciones.FECHABAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', bonificaciones.FECHA, bonificaciones.DECRETO, bonificaciones.MOTIVO, bonificaciones.EXPEDIENTE, bonificaciones.AÑO, bonificaciones.OBSERVACIONES, bonificaciones.DNIAGENTE FROM bonificaciones WHERE bonificaciones.DNIAGENTE = '" + _dnis + "'";
                conexion.CargarResultadosConsulta(consulta, boni);
            }
            else
            {
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }
        private void EDITARDATOS_Click(object sender, EventArgs e)
        {
            DateTime A2 = FECHAALTA.Value;
            DateTime A3 = FECHABAJA.Value;
            DateTime A4 = DateTime.Now;
            string A5 = DECRETO.Text;
            string A6 = MOTIVO.Text;
            string A7 = EXPEDIENTE.Text;
            int A8 = DateTime.Now.Year;
            string A9 = observaciones.Text;            
            string A10 = ID.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.ActualizarDatosbonificacioness(A2, A3, A4, A5, A6, A7, A8, A9, A10);
            string consulta = "SELECT bonificaciones.ID, DATE_FORMAT(bonificaciones.FECHAALTA, '%Y-%m-%d') AS 'FECHA DE ALTA', DATE_FORMAT(bonificaciones.FECHABAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', bonificaciones.FECHA, bonificaciones.DECRETO, bonificaciones.MOTIVO, bonificaciones.EXPEDIENTE, bonificaciones.AÑO, bonificaciones.OBSERVACIONES, bonificaciones.DNIAGENTE FROM bonificaciones WHERE bonificaciones.DNIAGENTE = '" + _dnis + "'";
            ListView miListView = new ListView();
            ControlHelper.LimpiarControles(this);            
            conexion.CargarResultadosConsulta(consulta, boni);
        }
        private void boni_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = boni.SelectedItems[0];
            // Obtener los subelementos de la fila seleccionada
            string columna0 = selectedItem.SubItems[0].Text;
            string fechaTexto1 = selectedItem.SubItems[1].Text;
            string formatoFecha = "yyyy-MM-dd";
            DateTime columna1;
            if (DateTime.TryParseExact(fechaTexto1, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna1))
            {
                string fechaFormateada = columna1.ToString("dd/MM/yyyy");
                FECHAALTA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string fechaTexto2 = selectedItem.SubItems[2].Text;
            DateTime columna2;
            if (DateTime.TryParseExact(fechaTexto2, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna2))
            {
                string fechaFormateada = columna2.ToString("dd/MM/yyyy");
                FECHABAJA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string fechaTexto3 = selectedItem.SubItems[3].Text;
             DateTime columna3;
            if (DateTime.TryParseExact(fechaTexto3, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna3))
            {
                string fechaFormateada = columna3.ToString("dd/MM/yyyy");
                FECHAALTA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna4 = selectedItem.SubItems[4].Text;
            string columna5 = selectedItem.SubItems[5].Text;
            string columna6 = selectedItem.SubItems[6].Text;
            string columna7 = selectedItem.SubItems[7].Text;
            string columna8 = selectedItem.SubItems[8].Text;
            string columna9 = selectedItem.SubItems[9].Text;         
            ID.Text = columna0;
            DECRETO.Text = columna4;
            MOTIVO.Text = columna5;
            EXPEDIENTE.Text = columna6;            
            observaciones.Text = columna9;            
        }
        private void boni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem selectedItem = boni.SelectedItems[0]; // Obtén el elemento seleccionado
                // Obtén el valor del campo "idt" del elemento seleccionado
                string idtValue = selectedItem.SubItems[0].Text;
                // Muestra un cuadro de diálogo para confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Elimina el elemento del ListView
                    boni.Items.Remove(selectedItem);
                    ConexionMySQL conexion = new ConexionMySQL();
                    {
                        conexion.Conectar();
                        // Consulta SQL para eliminar el registro
                        string query = "DELETE FROM bonificaciones WHERE ID = @idt";
                        using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@idt", idtValue);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            
             }
          }
        private void BONIFICACIONES_Load(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "SELECT bonificaciones.ID, DATE_FORMAT(bonificaciones.FECHAALTA, '%Y-%m-%d') AS 'FECHA DE ALTA', DATE_FORMAT(bonificaciones.FECHABAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', bonificaciones.FECHA, bonificaciones.DECRETO, bonificaciones.MOTIVO, bonificaciones.EXPEDIENTE, bonificaciones.AÑO, bonificaciones.OBSERVACIONES, bonificaciones.DNIAGENTE FROM bonificaciones WHERE bonificaciones.DNIAGENTE = '" + _dnis + "'";
            conexion.CargarResultadosConsulta(consulta, boni);
        }

    }
}
