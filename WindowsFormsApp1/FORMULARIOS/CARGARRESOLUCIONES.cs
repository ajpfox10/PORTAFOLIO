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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la carga del formulario: " + ex.Message);
            }
        }
    }
}
