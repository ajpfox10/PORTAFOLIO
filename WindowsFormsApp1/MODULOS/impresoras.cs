using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace PrintFileExample
{
    class Printer
    {
        private PrintDocument pd = new PrintDocument();

        public Printer()
        {
            pd.PrintPage += new PrintPageEventHandler(PrintPageCallback);
        }

        public void PrintFile(string filePath)
        {
            try
            {
                // Asignar archivo a imprimir
                pd.DocumentName = filePath;

                // Mostrar el cuadro de diálogo de impresión
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Imprimir el archivo
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void PrintPageCallback(object sender, PrintPageEventArgs e)
        {
            // Obtener la ruta del archivo asignada al PrintDocument
            string filePath = ((PrintDocument)sender).DocumentName;

            // Verificar que el archivo exista
            if (File.Exists(filePath))
            {
                // Cargar el archivo y dibujar su contenido en la página
                // Aquí puedes utilizar alguna librería para leer el contenido del archivo y dibujarlo en la página
                e.Graphics.DrawImage(Image.FromFile(filePath), e.PageBounds);
            }
            else
            {
                Console.WriteLine("El archivo especificado no existe.");
            }
        }
    }
}