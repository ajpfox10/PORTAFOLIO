using iText.StyledXmlParser.Jsoup.Select;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class ASIGNARTAREAS : Form
    {
        public ASIGNARTAREAS()
        {
            InitializeComponent();
        }
        private void ASIGNARTAREAS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            var conexion = new ConexionMySQL();
            AGENTE.Items.AddRange(conexion.ObtenerUsuarios().ToArray());
            this.BackColor = Color.MediumPurple;
            CargarDatosYAcciones(TAREASACCINAR);
            TAREASACCINAR.MultiSelect = true;
            TAREASACCINAR.MouseClick += TAREASACCINAR_MouseClick;
        }
        private void CargarDatosYAcciones(ListView listView)
        {
            TAREASACCINAR.Items.Clear();
            TAREASACCINAR.Columns.Clear();
            CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
            string consultaTAREAS = "SELECT tareas.id AS 'ID', tareas.tarea AS 'TAREA', tareas.fechadebajadetarea AS 'FECHA DE BAJA DE TAREA', tareas.fechadealtadetarea AS 'FECHA DE ALTA DE TAREA', tareas.comentariosagenterealizo AS 'COMENTARIO DEL AGENTE QUE REALIZO LA TAREA', tareas.asifgnadoa 'ASIGNADO A' FROM tareas;";                  
            string[] columnasTAREAS = new string[] { "ID:75", "TAREA:75", "FECHA DE BAJA DE TAREA:250", "FECHA DE ALTA DE TAREA:250", "COMENTARIO DEL AGENTE QUE REALIZO LA TAREA:250", "ASIGNADO A:100 " };
            cargador.CargarDatos(TAREASACCINAR, consultaTAREAS, columnasTAREAS);
        }

        private void ASIGNATAREA_Click(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            // Obtener la fecha y hora actual
            DateTime fechaActual = DateTime.Now;
            // Obtener el valor seleccionado del ComboBox de agentes
            string agenteSeleccionado = AGENTE.SelectedItem.ToString();
            String TAREASSS = TAREASASIGNARS.Text;          
            // Llamar al método AgregarTAREAS con los valores obtenidos
            conexion.AgregarTAREAS(TAREASSS, fechaActual, agenteSeleccionado);
            TAREASACCINAR.Items.Clear();
            TAREASACCINAR.Columns.Clear();
            CARGARMESADEENTRADA cargador = new CARGARMESADEENTRADA();
            string consultaTAREAS = "SELECT tareas.id AS 'ID', tareas.tarea AS 'TAREA', tareas.fechadebajadetarea AS 'FECHA DE BAJA DE TAREA', tareas.fechadealtadetarea AS 'FECHA DE ALTA DE TAREA', tareas.comentariosagenterealizo AS 'COMENTARIO DEL AGENTE QUE REALIZO LA TAREA', tareas.asifgnadoa 'ASIGNADO A' FROM tareas;";
            string[] columnasTAREAS = new string[] { "ID:75", "TAREA:75", "FECHA DE BAJA DE TAREA:250", "FECHA DE ALTA DE TAREA:250", "COMENTARIO DEL AGENTE QUE REALIZO LA TAREA:275", "ASIGNADO A:100 " };
            cargador.CargarDatos(TAREASACCINAR, consultaTAREAS, columnasTAREAS);

        }
        private void TAREASACCINAR_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Limpiar el contenido existente en el RichTextBox
                ESTUDIODEDATOS.Clear();

                // Obtener el índice de la fila seleccionada
                int selectedIndex = TAREASACCINAR.SelectedIndices[0];

                // Iterar sobre todas las subítems de la fila seleccionada
                foreach (ListViewItem.ListViewSubItem subItem in TAREASACCINAR.Items[selectedIndex].SubItems)
                {
                    // Agregar el texto de la subítem al RichTextBox
                    ESTUDIODEDATOS.AppendText(subItem.Text + Environment.NewLine);
                }
            }
        }
    }
}
