using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.FORMULARIOS
{
    public partial class CARGARRESOLUCIONES : Form
    {
        public CARGARRESOLUCIONES()
        {
            InitializeComponent();
        }

        private void CARGARRESOLUCIONES_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("CARGARRESOLUCIONES_Load iniciado.");

                // Configurar columnas del ListView
                listView1.View = View.Details;
                listView1.Columns.Add("Resolución", 150);
                listView1.Columns.Add("Estado", 100);

                // Ruta de la carpeta
                string carpetaArchivos = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\";

                // Crear instancia de ComparadorArchivos y realizar la comparación
                ComparadorArchivos comparador = new ComparadorArchivos(carpetaArchivos, listView1);
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
