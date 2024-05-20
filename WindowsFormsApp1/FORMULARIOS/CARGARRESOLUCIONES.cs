using System;
using System.Windows.Forms;
using System.Collections.Generic;
using WindowsFormsApp1.MODULOS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace WindowsFormsApp1.FORMULARIOS
{
    public partial class CARGARRESOLUCIONES : Form
    {
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly List<System.Windows.Forms.TextBox> textBoxes;
        private readonly ConexionMySQL conexionMySQL = new ConexionMySQL();
        private PersonaLEVENTOS personaLEVENTOS;
        public CARGARRESOLUCIONES(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_); apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();
            apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();

        }
        private void CARGARRESOLUCIONES_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("CARGARRESOLUCIONES_Load iniciado.");
                // Configurar columnas del ListView
                resolucionesd.View = View.Details;
                resolucionesd.Columns.Add("ID", 75);
                resolucionesd.Columns.Add("Resolución", 193);
                resolucionesd.Columns.Add("Estado", 100);
                // Ruta de la carpeta
                string carpetaArchivos = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\";
                ComparadorArchivos comparador = new ComparadorArchivos(carpetaArchivos, resolucionesd, CANTIDADS);
                comparador.ListarArchivosYComparar();
                Console.WriteLine("Comparación completada correctamente.");
                string consultaTIPORESO = @"SELECT tipoderesolucion.resolucion, tipoderesolucion.id FROM tipoderesolucion";
                // Llenar el ComboBox con los resultados de la consulta
                conexionMySQL.LlenarComboBox(consultaTIPORESO, TIPORESOLUCION, "resolucion", "id");
                Gestionrr.ComboBoxItem itemDecreto = new Gestionrr.ComboBoxItem { DisplayMember = "DECRETO", ValueMember = 0 };
                Gestionrr.ComboBoxItem itemResolucion = new Gestionrr.ComboBoxItem { DisplayMember = "RESOLUCION", ValueMember = 11112 };
                Gestionrr.ComboBoxItem iteexpediediente = new Gestionrr.ComboBoxItem { DisplayMember = "EXPEDIENTE", ValueMember = 2910 };
                Gestionrr.ComboBoxItem iteDISPOSCION = new Gestionrr.ComboBoxItem { DisplayMember = "DISPOSICION", ValueMember = 2 };
                Gestionrr.ComboBoxItem iteDISPOSCIONGDEBA = new Gestionrr.ComboBoxItem { DisplayMember = "DISPOSICION GDEBA", ValueMember = 3 };
                Gestionrr.ComboBoxItem RESOGDEBANGDEBA = new Gestionrr.ComboBoxItem { DisplayMember = "RESOLUCION GDEBA SALUD", ValueMember = 4 };
                Gestionrr.ComboBoxItem RESOGDEBANGDEBAS = new Gestionrr.ComboBoxItem { DisplayMember = "RESOLUCION GDEBA GOBIERNO", ValueMember = 5 };
                Gestionrr.ComboBoxItem RESOLGDEBANGDEBAS = new Gestionrr.ComboBoxItem { DisplayMember = "RESOL", ValueMember = 6 };
                Gestionrr.ComboBoxItem RESOLNU = new Gestionrr.ComboBoxItem { DisplayMember = "RS", ValueMember = 7 };

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la carga del formulario: " + ex.Message);
            }
        }
    }
}
