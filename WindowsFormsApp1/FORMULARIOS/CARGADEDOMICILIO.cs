using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;

namespace WindowsFormsApp1
{
    public partial class CARGADEDOMICILIO : Form
    {
        public Int64 Dnis_;
        private readonly string Agentedeatencions_;
 
        public CARGADEDOMICILIO(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            CargarComboBoxes cargador = new CargarComboBoxes(PCIA, LOCALIDAD); this.Load += CARGADEDOMICILIO_Load;
            /////NUEVA CLASE ADAPTAR ACA 
        }
        private void CARGADEDOMICILIO_Load(object sender, EventArgs e)
        {
            CARDADEDOMICILIO.MouseDoubleClick += CARDADEDOMICILIO_MouseDoubleClick;
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = " SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, localidades1.provincia_id AS PCIA, form3.PARTIDO, form3.LOCALIDAD, form3.TELEMERGEN AS TEL, form3.EMAILOFICIAL AS EMAIL, form3.TELCELCONTA AS CONTACTO, form3.OTRAS, form3.DNIAGENTE AS DNI FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id) WHERE form3.DNIAGENTE = '" + Dnis_ + "'";
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
            string filePath = "c:/domicilio1.pdf"; // Ruta al archivo PDF
            webBrowser1.Navigate(filePath);
            if (CARDADEDOMICILIO.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0];
                CargarValoresComboBox1(selectedItem);
            }
            CargarComboBoxes cargador = new CargarComboBoxes(PCIA, LOCALIDAD);            // Para cargar las provincias en un ComboBox
            cargador.CargarProvinciasEnComboBox(PCIA);
            // Para manejar el evento de cambio de provincia y cargar los municipios correspondientes en otro ComboBox
            PCIA.SelectedIndexChanged += (senderPCIA, args) =>
            {
                cargador.ManejarCambioProvincia(senderPCIA, args, PARTIDO);
            };
            // Para manejar el evento de cambio de partido y cargar las localidades correspondientes en otro ComboBox
            PARTIDO.SelectedIndexChanged += (senderPARTIDO, args) =>
            {
                cargador.ManejarCambioPartido(senderPARTIDO, args, LOCALIDAD);
            };
        }
        private void CargarValoresComboBox1(ListViewItem selectedItem)
        {
            // Obtener los valores de las columnas necesarias
            string provinciaId = selectedItem.SubItems[8].Text;
            string partidoId = selectedItem.SubItems[9].Text;
            string localidadId = selectedItem.SubItems[10].Text;
            // Establecer los valores en los ComboBox correspondientes
            PCIA.SelectedValue = provinciaId;
            PARTIDO.SelectedValue = partidoId;
            LOCALIDAD.SelectedValue = localidadId;
        }
        private void CARGADATOS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (VERIFICARCONTR.VerificarControles(this.Controls))
            {
                string calle1 = calle.Text;
                string numero1 = numero.Text;
                string piso1 = piso.Text;
                string depto1 = depto.Text;
                string partido = PARTIDO.SelectedValue.ToString();
                string localidad = LOCALIDAD.SelectedValue.ToString();
                string telefono = TELCONTACTO.Text;
                string email = EMAIL.Text;
                string dni = Dnis_.ToString();
                string tele = TELEMERGENCIA.Text;
                string otrosss = OTRASCARACTERISTICAS.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.InsertarDatos(calle1, numero1, piso1, depto1, partido, localidad, telefono, email, dni, tele, otrosss);
                string consulta = " SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, form3.PARTIDO, form3.LOCALIDAD, form3.TELEMERGEN AS TEL, form3.EMAILOFICIAL AS EMAIL, form3.TELCELCONTA AS CONTACTO, form3.OTRAS FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id)";
                ControlHelper.LimpiarControles(this);
                conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
            }
            else
            {
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }
        private void CARDADEDOMICILIO_DoubleClick(object sender, EventArgs e)
        {
            if (CARDADEDOMICILIO.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0];
                string columna0 = selectedItem.SubItems[0].Text;
                string columna1 = selectedItem.SubItems[1].Text;
                string columna2 = selectedItem.SubItems[2].Text;
                string columna3 = selectedItem.SubItems[3].Text;
                string columna4 = selectedItem.SubItems[4].Text;
                string columna5 = selectedItem.SubItems[5].Text;
                string columna6 = selectedItem.SubItems[6].Text;
                string columna7 = selectedItem.SubItems[7].Text;
                string columna8 = selectedItem.SubItems[8].Text;
                string columna9 = selectedItem.SubItems[9].Text;
                string columna10 = selectedItem.SubItems[10].Text;
                string columna11 = selectedItem.SubItems[11].Text;
                string columna12 = selectedItem.SubItems[12].Text;
                string columna13 = selectedItem.SubItems[13].Text;
                string columna14 = selectedItem.SubItems[14].Text;
                ID.Text = columna0;
                calle.Text = columna1;
                numero.Text = columna2;
                piso.Text = columna3;
                depto.Text = columna4;
                TELCONTACTO.Text = columna11;
                EMAIL.Text = columna12;
                TELEMERGENCIA.Text = columna13;
                OTRASCARACTERISTICAS.Text = columna14;
                if (CARDADEDOMICILIO.SelectedItems.Count > 0)
                {
                    CargarValoresComboBox1(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una dirección");
            }
        }
        private void EDITARDATOS_Click(object sender, EventArgs e)
        {
            string IDXX1 = ID.Text;
            string numero2 = numero.Text;
            string calle2 = calle.Text;
            string piso3 = piso.Text;
            string depto4 = depto.Text;
            string partido1 = PARTIDO.SelectedValue.ToString();
            string localidad1 = LOCALIDAD.SelectedValue.ToString();
            string telefono1 = TELCONTACTO.Text;
            string email1 = EMAIL.Text;
            string tele = TELEMERGENCIA.Text;
            string otross = OTRASCARACTERISTICAS.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.ActualizarDatos(calle2, numero2, piso3, depto4, partido1, localidad1, telefono1, email1, IDXX1, tele, otross);
            string consulta = " SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, form3.PARTIDO, form3.LOCALIDAD, form3.TELEMERGEN AS TEL, form3.EMAILOFICIAL AS EMAIL, form3.TELCELCONTA AS CONTACTO, form3.OTRAS FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id)";
            conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
        }
        private void CARGARPDF_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = Dnis_.ToString();
            PdfFormFiller formFiller = new PdfFormFiller(nombreCarpeta);
            formFiller.FillPdfForm(Dnis_.ToString());
        }
        private void CARDADEDOMICILIO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (CARDADEDOMICILIO.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0];
                    string idtValue = selectedItem.SubItems[0].Text;
                    DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        CARDADEDOMICILIO.Items.Remove(selectedItem);
                        ConexionMySQL conexion = new ConexionMySQL();
                        {
                            conexion.Conectar();
                            string query = "DELETE FROM form3 WHERE Id = @idt";
                            using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                            {
                                command.Parameters.AddWithValue("@idt", idtValue);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
