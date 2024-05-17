using iText.StyledXmlParser.Jsoup.Select;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class Tareas : Form
    {
        private readonly string Agentedeatencions_;
        public Tareas(string agenteDeAtencion)
        {
            InitializeComponent();
            Agentedeatencions_ = agenteDeAtencion;
        }
        private void Tareas_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            CargarDatosYAcciones(TAREASASIGNADAS);
            TAREASASIGNADAS.MultiSelect = true;
        }
        private void CargarDatosYAcciones(ListView listView)
        {
            TAREASASIGNADAS.Items.Clear();
            TAREASASIGNADAS.Columns.Clear();
            CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
            string consultaTAREAS = "SELECT tareas.id AS 'ID', tareas.tarea AS 'TAREA', tareas.fechadealtadetarea AS 'FECHA DE ASIGNACION DE LA TAREA', tareas.asifgnadoa AS 'ASIGNADO A AGENTE' FROM tareas WHERE(((tareas.fechadebajadetarea)Is Null));\r\n";
            string[] columnasTAREAS = new string[] { "ID:75", "TAREA:75", "FECHA DE ASIGNACION DE LA TAREA:250", "ASIGNADO A AGENTE:75" };
            cargador.CargarDatos(TAREASASIGNADAS, consultaTAREAS, columnasTAREAS);
        }
        private void TAREASASIGNADAS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (TAREASASIGNADAS.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(TAREASASIGNADAS.SelectedItems[0].SubItems[0].Text);
                String ACT = COMENTARIOS.Text;
                // Verificar si el campo de comentarios está lleno
                if (string.IsNullOrWhiteSpace(ACT))
                {
                    MessageBox.Show("Por favor, ingrese un comentario antes de actualizar la tarea.", "Comentario Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la baja de la tarea con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredetarea" de la citación correspondient                    
                    conexion.ActualizarCierreDetarea(id, ACT);
                }
                TAREASASIGNADAS.Items.Clear();
                TAREASASIGNADAS.Columns.Clear();
                CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
                string consultaTAREAS = "SELECT tareas.id AS 'ID', tareas.tarea AS 'TAREA', tareas.fechadealtadetarea AS 'FECHA DE ASIGNACION DE LA TAREA', tareas.asifgnadoa AS 'ASIGNADO A AGENTE' FROM tareas WHERE(((tareas.fechadebajadetarea)Is Null));";
                string[] columnasTAREAS = new string[] { "ID:75", "TAREA:75", "FECHA DE ASIGNACION DE LA TAREA:250", "ASIGNADO A AGENTE:75" };
                cargador.CargarDatos(TAREASASIGNADAS, consultaTAREAS, columnasTAREAS);
            }
        }
        private void TAREASASIGNADAS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (TAREASASIGNADAS.SelectedItems.Count > 0) // Verificar si hay elementos seleccionados
                    {
                        int selectedIndex = TAREASASIGNADAS.SelectedItems[0].Index;
                        string columnaDos = TAREASASIGNADAS.Items[selectedIndex].SubItems[1].Text;
                        TAREASAREALIZAR.Text = columnaDos;
                    }
                }
            }
        }
    }
}