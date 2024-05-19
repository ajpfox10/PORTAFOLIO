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
        private readonly ConexionMySQL conexion;

        public ComparadorArchivos(string carpetaArchivos, ListView listView)
        {
            this.carpetaArchivos = carpetaArchivos;
            this.listView = listView;
            this.conexion = new ConexionMySQL();
        }

        public void ListarArchivosYComparar()
        {
            try
            {
                // Obtener archivos PDF en la carpeta
                var archivosPdf = Directory.GetFiles(carpetaArchivos, "*.pdf").Select(Path.GetFileNameWithoutExtension).ToList();
                Console.WriteLine("Archivos PDF encontrados: " + archivosPdf.Count);

                // Consultar los nombres en la base de datos
                var dataTable = conexion.EjecutarConsulta("SELECT resolucion FROM resoluciones");

                // Obtener lista de resoluciones desde la base de datos
                var resolucionesBD = dataTable.AsEnumerable().Select(row => row.Field<string>("resolucion")).ToList();
                Console.WriteLine("Resoluciones en la base de datos: " + resolucionesBD.Count);

                // Limpiar el ListView
                listView.Items.Clear();

                // Comparar y llenar el ListView
                foreach (string archivo in archivosPdf)
                {
                    bool encontrado = resolucionesBD.Contains(archivo);
                    var item = new ListViewItem(archivo);
                    item.SubItems.Add(encontrado ? "Encontrado" : "NO ASOCIADO");
                    listView.Items.Add(item);
                }

                Console.WriteLine("Comparación de archivos completada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la comparación de archivos: " + ex.Message);
            }
        }
    }
}
