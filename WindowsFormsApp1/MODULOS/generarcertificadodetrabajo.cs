using Word = Microsoft.Office.Interop.Word;
using System.Linq;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
namespace WindowsFormsApp1.MODULOS
{// controlada
    internal class GenerarCertificadodetrabajo
    {
        private readonly string Dnis_;

        public GenerarCertificadodetrabajo(string dnis)
        {
            Dnis_ = dnis;
        }

        public void GenerateCertificate()
        {
            // Crea una instancia de tu clase de conexión MySQL
            using (ConexionMySQL conexionMySQL = new ConexionMySQL())
            {
                // Obtén los datos de la base de datos
                var datos = conexionMySQL.Certificadodetrabajo(Convert.ToInt64(Dnis_));

                // Mecanismo de reintento
                int maxRetries = 5;
                int delay = 1000; // en milisegundos

                for (int i = 0; i < maxRetries; i++)
                {
                    try
                    {
                        // Crea una instancia de Word
                        Word.Application wordApp = new Word.Application();
                        wordApp.Visible = true;

                        // Crea un nuevo documento
                        Word.Document doc = wordApp.Documents.Add();

                        // Agrega los datos al documento
                        AgregarDatos(doc, datos);

                        MessageBox.Show("Certificado generado con éxito.");
                        break; // Salir del bucle si la operación es exitosa
                    }
                    catch (COMException ex) when (ex.HResult == unchecked((int)0x80010001))
                    {
                        if (i == maxRetries - 1)
                        {
                            MessageBox.Show("Error: No se pudo abrir Microsoft Word. Inténtelo de nuevo más tarde.");
                            throw;
                        }
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        private void AgregarParrafoConFormato(Word.Document doc, string nombreAgente, string ocupacion, string fechaBeca, string fechaNombramiento, string cargaHoraria, string LEY, string dni, string legajo,  string dependencia)
        {                                                       //doc, nombreAgente, ocupacion, fechaBeca, fechaNombramiento, cargaHoraria, LEY, dni, legajo, dependencia                   
            // Convertir la fecha de nombramiento a DateTime
            DateTime fechaNombramientoDT = DateTime.Parse(fechaNombramiento);

            // Restar un día a la fecha de nombramiento
            DateTime fechaNombramientoMenosUnDia = fechaNombramientoDT.AddDays(-1);

            // Convertir la fecha modificada de nuevo a cadena
            string fechaNombramientoMenosUnDiaStr = fechaNombramientoMenosUnDia.ToString("dd/MM/yyyy");

            // Agrega el párrafo con formato específico
            Word.Paragraph paragraph = doc.Paragraphs.Add();

            // Replace placeholders in the text
            string textoParrago = $"El agente que se detalla a continuación se desempeña desde la fecha {fechaBeca} hasta el {fechaNombramiento} como becario y desde {fechaNombramientoMenosUnDiaStr} como agente de la {LEY} desempeñandose como {ocupacion} con una carga horaria de {cargaHoraria} horas semanales.";

            // Append the completed paragraph to the document
            paragraph.Range.Text = textoParrago;

            // Aplica el formato al párrafo
            paragraph.Range.Font.Name = "Times New Roman";
            paragraph.Range.Font.Size = 12;
            paragraph.Format.SpaceAfter = 1; // Interlineado de 1

            // Inserta un salto de párrafo después del primer párrafo
            paragraph.Range.InsertParagraphAfter();

            // Agrega el segundo párrafo con información adicional
            Word.Paragraph paragraph2 = doc.Paragraphs.Add();
            paragraph2.Range.Text = $"AGENTE\n" +
                                    $"APELLIDO Y NOMBRE: {nombreAgente}\n" +
                                    $"DNI: {dni}\n" +
                                    $"LEGAJO: {legajo}\n" +
                                    $"SERVICIO:\n" +
                                    $"LEY: {LEY}\n" +
                                    $"DEPENDENCIA: {dependencia}";

            // Aplica el formato al segundo párrafo
            paragraph2.Range.Font.Name = "Times New Roman";
            paragraph2.Range.Font.Size = 12;
            paragraph2.Format.SpaceAfter = 1; // Interlineado de 1
        }
        private void AgregarDatos(Word.Document doc, IQueryable<string> datos)
        {
            // Verifica si hay suficientes datos en la IQueryable
            if (datos.Count() >= 9) // Asegúrate de que el IQueryable contenga al menos 9 elementos
            {
                // Extrae los datos necesarios
                string nombreAgente = datos.ElementAt(0);
                string dni = datos.ElementAt(1);
                string ocupacion = datos.ElementAt(2);
                string fechaBeca = datos.ElementAt(3);
                string fechaNombramiento = datos.ElementAt(4);                
                string cargaHoraria = datos.ElementAt(5);
                string LEY = datos.ElementAt(6);
                string legajo = datos.ElementAt(7);                
                string dependencia = datos.ElementAt(8);
                // Agrega los datos al documento
                AgregarParrafoConFormato(doc, nombreAgente, ocupacion, fechaBeca, fechaNombramiento, cargaHoraria, LEY, dni, legajo, dependencia);
            }
            else
            {
                // Manejo de error: No hay suficientes datos en la IQueryable
                Console.WriteLine("Error: No hay suficientes datos para generar el certificado.");
            }
        }
    }
}
