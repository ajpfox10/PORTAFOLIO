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

        public ComparadorArchivos(string carpetaArchivos, ListView listView, TextBox textBoxCantidadArchivos)
        {
            this.carpetaArchivos = carpetaArchivos;
            this.listView = listView;
            this.textBoxCantidadArchivos = textBoxCantidadArchivos;
        }

        public void ListarArchivosYComparar()
        {
            try
            {
                // Obtener archivos PDF en la carpeta
                var archivosPdf = Directory.GetFiles(carpetaArchivos, "*.pdf").Select(Path.GetFileNameWithoutExtension).ToList();
                Console.WriteLine("Archivos PDF encontrados: " + archivosPdf.Count);

                // Consultar los nombres en la base de datos
                var dataTable = ObtenerNombresDesdeBaseDeDatos();

                // Obtener lista de resoluciones desde la base de datos
                var resolucionesBD = dataTable.AsEnumerable().Select(row => row.Field<string>("resolucion")).ToList();
                Console.WriteLine("Resoluciones en la base de datos: " + resolucionesBD.Count);

                // Limpiar el ListView
                listView.Items.Clear();

                // Contador de archivos no asociados
                int noAsociados = 0;

                // Comparar y llenar el ListView
                for (int i = 0; i < archivosPdf.Count; i++)
                {
                    bool encontrado = resolucionesBD.Contains(archivosPdf[i]);
                    if (!encontrado)
                    {
                        var item = new ListViewItem((i + 1).ToString()); // Agregar el número de ítem como primer columna
                        item.SubItems.Add(archivosPdf[i]);
                        item.SubItems.Add("NO ASOCIADO");
                        listView.Items.Add(item);
                        noAsociados++;
                    }
                }

                Console.WriteLine("Comparación de archivos completada.");

                // Mostrar la cantidad de archivos no asociados en el TextBox
                textBoxCantidadArchivos.Text = noAsociados.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la comparación de archivos: " + ex.Message);
            }
        }


        private DataTable ObtenerNombresDesdeBaseDeDatos()
        {
            // Aquí iría la lógica para obtener los nombres desde la base de datos
            // Se puede usar la clase ConexionMySQL o cualquier otra clase que maneje la conexión y consultas a la base de datos
            // Por simplicidad, aquí se retorna un DataTable vacío
            return new DataTable();
        }
    }
}
