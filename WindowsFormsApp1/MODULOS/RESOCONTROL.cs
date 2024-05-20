using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.FORMULARIOS
{
    public class ComparadorArchivos
    {
        private readonly string carpetaArchivos;
        private readonly ListView listView;
        private readonly TextBox textBoxCantidadArchivos;
        private readonly ContextMenuStrip contextMenuStrip;
        private string datoSeleccionado;  // Variable para almacenar el dato seleccionado
        public string DatoSeleccionado; // Propiedad pública para acceder al dato seleccionado
        public ComparadorArchivos(string carpetaArchivos, ListView listView, TextBox textBoxCantidadArchivos)
        {
            this.carpetaArchivos = carpetaArchivos;
            this.listView = listView;
            this.textBoxCantidadArchivos = textBoxCantidadArchivos;
            ConfigurarListView();
            contextMenuStrip = new ContextMenuStrip();
            var copiarMenuItem = new ToolStripMenuItem("Copiar resolución");
            copiarMenuItem.Click += CopiarResolucionMenuItem_Click;
            contextMenuStrip.Items.Add(copiarMenuItem);
            listView.ContextMenuStrip = contextMenuStrip;
            listView.MouseUp += ListView_MouseUp;
        }
        private void ConfigurarListView()
        {
            // Limpiar cualquier configuración previa de columnas
            listView.Columns.Clear();
            listView.View = View.Details;
            listView.Columns.Add("Ítem", 50);
            listView.Columns.Add("Nombre Archivo", 150);
            listView.Columns.Add("Estado", 100);
        }
        private void ListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = listView.HitTest(e.Location);
                if (hitTest.Item != null)
                {
                    listView.SelectedItems.Clear();
                    hitTest.Item.Selected = true;
                    contextMenuStrip.Show(listView, e.Location);
                }
            }
        }
        private void CopiarResolucionMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                var item = listView.SelectedItems[0];
                var resolucion = item.SubItems[1].Text; // Asumiendo que la resolución está en la segunda columna
                Clipboard.SetText(resolucion);
                MessageBox.Show("Resolución copiada al portapapeles: " + resolucion, "Copiar Resolución", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataTable ObtenerNombresDesdeBaseDeDatos()
        {
            // Consulta SQL para obtener las resoluciones desde la base de datos
            string consulta = "SELECT resolucion FROM resoluciones";

            // Crear una instancia de la clase ConexionMySQL
            using (ConexionMySQL conexionMySQL = new ConexionMySQL())
            {
                // Ejecutar la consulta y obtener los resultados
                return conexionMySQL.EjecutarConsulta(consulta);
            }
        }
        public void ListarArchivosYComparar()
        {
            try
            {
                // Obtener archivos en la carpeta
                var archivos = Directory.GetFiles(carpetaArchivos)
                                        .Select(Path.GetFileName)
                                        .ToList();
                Console.WriteLine("Archivos encontrados: " + archivos.Count);

                // Consultar los nombres en la base de datos
                var dataTable = ObtenerNombresDesdeBaseDeDatos();

                // Obtener lista de resoluciones desde la base de datos
                var resolucionesBD = dataTable.AsEnumerable()
                                              .Select(row => row.Field<string>("resolucion"))
                                              .ToList();

                Console.WriteLine("Resoluciones en la base de datos: " + resolucionesBD.Count);

                // Limpiar el ListView
                listView.Items.Clear();

                // Contador de archivos no asociados
                int noAsociados = 0;

                // Comparar y llenar el ListView
                foreach (var archivo in archivos)
                {
                    var archivoCleaned = CleanString(Path.GetFileNameWithoutExtension(archivo).ToLower());
                    var extension = Path.GetExtension(archivo); // Obtener la extensión del archivo

                    // Verificar si el nombre del archivo coincide con alguna resolución de la base de datos
                    bool encontrado = resolucionesBD.Any(resolucion => CleanString(resolucion.ToLower()) == archivoCleaned);

                    if (!encontrado)
                    {
                        var item = new ListViewItem((noAsociados + 1).ToString());
                        item.SubItems.Add(archivo);
                        item.SubItems.Add("NO ASOCIADO");
                        listView.Items.Add(item);
                        noAsociados++;
                    }
                }

                Console.WriteLine("Comparación de archivos completada.");
                textBoxCantidadArchivos.Text = noAsociados.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la comparación de archivos: " + ex.Message);
                MessageBox.Show("Se produjo un error durante la comparación de archivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CleanString(string input)
        {
            // Eliminar caracteres no deseados como espacios en blanco y caracteres especiales
            return new string(input.Where(char.IsLetterOrDigit).ToArray());
        }
        public string ObtenerDatoSeleccionado()
        {
            if (listView.SelectedItems.Count > 0)
            {
                var item = listView.SelectedItems[0];
                if (item.SubItems.Count > 1)
                {
                    return item.SubItems[1].Text; // Obtener el dato de la segunda columna
                }
                else
                {
                    MessageBox.Show("Error: El dato seleccionado no está en la segunda columna.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún ítem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public ListView GetListView()
        {
            return listView;
        }
    }
}
