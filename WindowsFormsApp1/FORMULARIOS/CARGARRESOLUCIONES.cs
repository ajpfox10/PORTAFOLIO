using System;
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
            apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();
            apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();
        }
        private void resolucionesd_Click(object sender, EventArgs e)
        {
            string datoSeleccionado = comparador.ObtenerDatoSeleccionado();
            if (datoSeleccionado != null)
            {
                MessageBox.Show("Has elegido el dato: " + datoSeleccionado, "Dato Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí estás creando una nueva variable local llamada resolucion
                string resolucion = datoSeleccionado + ".pdf";
                // Debes asignar el valor a la variable de la clase CARGARRESOLUCIONES
                this.resolucion = resolucion;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún dato.", "Dato Nulo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DNI_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
                {
                    Dnis_ = nuevoDnisValor;
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
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);
                if (todosCompletos)
                {
                    GestionResoluciones gestionResoluciones = new GestionResoluciones();
                    int dni = (int)Dnis_;
                    string tipoResolucionValueMember = TIPORESOLUCION.SelectedValue.ToString();
                    DateTime fechaResolucion = FECHADERESOLUCION.Value.Date;
                    gestionResoluciones.InsertarResolucion(dni, resolucion, tipoResolucionValueMember, fechaResolucion, resolucion);
                }
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
    }
}
