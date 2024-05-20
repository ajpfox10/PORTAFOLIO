using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1.FORMULARIOS
{
    public partial class CARGARRESOLUCIONES : Form
    {
        private ComparadorArchivos comparador;
        public string resolucion;
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly ConexionMySQL conexionMySQL = new ConexionMySQL();
        string carpetaArchivos = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\";
        private MODULOS.PersonaLEVENTOS personaLEVENTOS;

        public CARGARRESOLUCIONES(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
            apellido1.Enter += Apellido1_Enter;
            resolucionesd.ItemSelectionChanged += resolucionesd_ItemSelectionChanged;
        }

        private void Apellido1_Enter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.ComboBox)sender).SelectAll();
        }

        private void resolucionesd_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                e.Item.BackColor = System.Drawing.Color.White; // o el color predeterminado de fondo
            }
        }

        private void resolucionesd_DoubleClick(object sender, EventArgs e)
        {
            // Verifica si hay elementos seleccionados en el ListView
            if (resolucionesd.SelectedItems.Count > 0)
            {
                // Obtén el nombre del archivo seleccionado
                string nombreArchivo = resolucionesd.SelectedItems[0].SubItems[1].Text;

                // Construir la ruta completa del archivo
                string rutaCompleta = Path.Combine(carpetaArchivos, nombreArchivo);

                try
                {
                    // Verificar si el archivo existe
                    if (File.Exists(rutaCompleta))
                    {
                        // Abrir el archivo en el WebBrowser
                        VISORRESO.Url = new Uri(rutaCompleta);
                    }
                    else
                    {
                        MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DNI_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
                {
                    Dnis_ = nuevoDnisValor;
                    DNI.BackColor = System.Drawing.Color.Yellow; // Cambia el color de fondo a amarillo
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es válido. Debe ser un número de DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CARGARESO_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los controles estén llenos y pintar el fondo de amarillo si es necesario
                if (string.IsNullOrEmpty(DNI.Text))
                {
                    DNI.BackColor = Color.Yellow; // Pintar de amarillo si el campo está vacío
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    DNI.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                if (FECHADERESOLUCION.Value == DateTime.MinValue)
                {
                    FECHADERESOLUCION.BackColor = Color.Yellow; // Pintar de amarillo si la fecha no está seleccionada
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    FECHADERESOLUCION.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                if (string.IsNullOrEmpty(RESOTRABAJAR.Text))
                {
                    RESOTRABAJAR.BackColor = Color.Yellow; // Pintar de amarillo si el campo está vacío
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    RESOTRABAJAR.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                // Si todos los controles están llenos, ejecutar el procedimiento
                GestionResoluciones gestionResoluciones = new GestionResoluciones();
                int dni = int.Parse(DNI.Text);
                string tipoResolucionValueMember = TIPORESOLUCION.SelectedValue.ToString();
                DateTime fechaResolucion = FECHADERESOLUCION.Value.Date;
                string resolucion = RESOTRABAJAR.Text;
                gestionResoluciones.InsertarResolucion(dni, resolucion, tipoResolucionValueMember, fechaResolucion, resolucion);

                // Vaciar los TextBox después de ejecutar el procedimiento
                DNI.Clear();
                FECHADERESOLUCION.Value = DateTime.Today; // Establecer la fecha actual
                RESOTRABAJAR.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CARGARRESOLUCIONES_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("CARGARRESOLUCIONES_Load iniciado.");
                comparador = new ComparadorArchivos(carpetaArchivos, resolucionesd, CANTIDADS);
                comparador.ListarArchivosYComparar();
                Console.WriteLine("Comparación completada correctamente.");
                string consultaTIPORESO = @"SELECT tipoderesolucion.resolucion, tipoderesolucion.id FROM tipoderesolucion";
                conexionMySQL.LlenarComboBox(consultaTIPORESO, TIPORESOLUCION, "resolucion", "id");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la carga del formulario: " + ex.Message);
                MessageBox.Show("Error durante la carga del formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resolucionesd_MouseClick(object sender, MouseEventArgs e)
        {
            // Verificar si se hizo clic con el botón derecho del ratón
            if (e.Button == MouseButtons.Right)
            {
                string datoSeleccionado = comparador.ObtenerDatoSeleccionado();
                if (datoSeleccionado != null)
                {
                    this.resolucion = datoSeleccionado;
                    resolucion = RESOTRABAJAR.Text;
                    // Obtener el ListView del comparador
                    ListView listView = comparador.GetListView();

                    // Buscar el ítem seleccionado en el ListView y seleccionarlo
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.SubItems[1].Text == datoSeleccionado)
                        {
                            listView.SelectedItems.Clear();
                            item.Selected = true;
                            item.Focused = true;
                            item.EnsureVisible();
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún dato.", "Dato Nulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}

