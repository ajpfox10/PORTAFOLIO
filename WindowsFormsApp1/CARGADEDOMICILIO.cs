using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;
namespace WindowsFormsApp1
{
    public partial class CARGADEDOMICILIO : Form
    {
        private readonly CargarComboBoxes cargadorComboBoxes = new CargarComboBoxes();
        private readonly CargarComboBoxes provincias = new CargarComboBoxes();
        public Int64 _dnis;
        private string _agentedeatencions;
        public CARGADEDOMICILIO(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            _agentedeatencions = agenteDeAtencion;
            provincias.PCIA(PCIA);
        }
        private void CARGADEDOMICILIO_Load(object sender, EventArgs e)
        {
            CARDADEDOMICILIO.MouseDoubleClick += CARDADEDOMICILIO_MouseDoubleClick;
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = " SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, localidades1.provincia_id AS PCIA, form3.PARTIDO, form3.LOCALIDAD, form3.TELEMERGEN AS TEL, form3.EMAILOFICIAL AS EMAIL, form3.TELCELCONTA AS CONTACTO, form3.OTRAS, form3.DNIAGENTE AS DNI FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id) WHERE form3.DNIAGENTE = '" + _dnis + "'";
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
            string filePath = "c:/domicilio1.pdf"; // Ruta al archivo PDF
            webBrowser1.Navigate(filePath);
            if (CARDADEDOMICILIO.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0];
                CargarValoresComboBox1(selectedItem);
            }
        }
        private void CARDADEDOMICILIO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0]; // Obtén el elemento seleccionado
                // Obtén el valor del campo "idt" del elemento seleccionado
                string idtValue = selectedItem.SubItems[0].Text;
                // Muestra un cuadro de diálogo para confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Elimina el elemento del ListView
                    CARDADEDOMICILIO.Items.Remove(selectedItem);
                    ConexionMySQL conexion = new ConexionMySQL();
                    {
                        conexion.Conectar();
                        // Consulta SQL para eliminar el registro
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
        private void PCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un valor seleccionado en el ComboBox "PCIA"
            if (PCIA.SelectedValue != null && PCIA.SelectedValue is string provincia_id)
            {
                // Cargar los municipios correspondientes a esa provincia en el ComboBox "PARTIDO"
                cargadorComboBoxes.CargarPartidos(PARTIDO, provincia_id);
            }
            else
            {
                // Si no hay un valor seleccionado, muestra un mensaje de error o realiza otra acción necesaria
                MessageBox.Show("Seleccione una provincia válidasssssss");
            }
        }
        private void PARTIDO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PARTIDO.SelectedValue != null && PARTIDO.SelectedValue is string partido_id)
            {
                if (int.TryParse(partido_id, out int partido_id_int))
                {
                    // Cargar las localidades correspondientes al partido seleccionado
                    cargadorComboBoxes.CargarLocalidades(LOCALIDAD, partido_id_int);
                }
                else
                {
                    // Si el valor seleccionado no se puede convertir a int, muestra un mensaje de error
                    MessageBox.Show("Seleccione un partido válido");
                }
            }
            else
            {
                // Si el valor seleccionado es nulo, muestra un mensaje de error
                MessageBox.Show("Seleccione un partido válido");
            }
        }
        private void CargarValoresComboBox1(ListViewItem selectedItem)
        {
            // Obtener los valores de las columnas necesarias
            string provinciaId = selectedItem.SubItems[8].Text;
            string partidoId = selectedItem.SubItems[9].Text;
            string localidadId = selectedItem.SubItems[10].Text;

            // Establecer los valores en los ComboBox correspondientes
            PCIA.SelectedValue = provinciaId;
            cargadorComboBoxes.CargarPartidos(PARTIDO, provinciaId);
            PARTIDO.SelectedValue = partidoId;
            cargadorComboBoxes.CargarLocalidades(LOCALIDAD, Convert.ToInt32(partidoId));
            LOCALIDAD.SelectedValue = localidadId;
        }
        private void CARGADATOS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (verificador.VerificarControles(this.Controls))
            {
                // Todos los controles están completos, por lo que se puede insertar los datos en la base de datos
                string IDXX1 = ID.Text;
                string calle1 = calle.Text;
                string numero1 = numero.Text;
                string piso1 = piso.Text;
                string depto1 = depto.Text;
                string partido = PARTIDO.SelectedValue.ToString();
                string localidad = LOCALIDAD.SelectedValue.ToString();
                string telefono = TELCONTACTO.Text;
                string email = EMAIL.Text;
                string dni = _dnis.ToString();
                string tele = TELEMERGENCIA.Text;
                string otrosss = OTRASCARACTERISTICAS.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.InsertarDatos(calle1, numero1, piso1, depto1, partido, localidad, telefono, email, dni, tele, otrosss);

                string consulta = " SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, form3.PARTIDO, form3.LOCALIDAD, form3.TELEMERGEN AS TEL, form3.EMAILOFICIAL AS EMAIL, form3.TELCELCONTA AS CONTACTO, form3.OTRAS FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id)";
                ListView miListView = new ListView();
                ControlHelper.LimpiarControles(this);
                provincias.PCIA(PCIA);
                conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
            }
            else
            {
                // Algunos controles están incompletos, se debe pedir al usuario que complete los controles requeridos.
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }
        private void CARDADEDOMICILIO_DoubleClick(object sender, EventArgs e)
        {
            if (CARDADEDOMICILIO.SelectedItems.Count > 0) // Verificar si hay algún elemento seleccionado
            {
                PCIA.SelectedIndexChanged -= PCIA_SelectedIndexChanged;
                PARTIDO.SelectedIndexChanged -= PARTIDO_SelectedIndexChanged;
                // Obtener el elemento seleccionado
                // Asignar los valores de los subelementos a los controles correspondientes en el formulario
                ListViewItem selectedItem = CARDADEDOMICILIO.SelectedItems[0];
                // Obtener los subelementos de la fila seleccionada
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
                // Asignar los valores de los subelementos a los controles correspondientes en el formulario
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
                    // Cargar los valores en los ComboBox
                    CargarValoresComboBox1(selectedItem);
                }
                PCIA.SelectedIndexChanged += PCIA_SelectedIndexChanged;
                PARTIDO.SelectedIndexChanged += PARTIDO_SelectedIndexChanged;
            }
            else
            {
                // Si no hay ningún elemento seleccionado, mostrar un mensaje de error o realizar alguna otra acción
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
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, CARDADEDOMICILIO);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = _dnis.ToString(); // Obtener el nombre de la carpeta adicional desde otra fuente (por ejemplo, otro formulario)
            PdfFormFiller formFiller = new PdfFormFiller(nombreCarpeta);
            formFiller.FillPdfForm(_dnis.ToString());
        }
    }
}

