using Word = Microsoft.Office.Interop.Word;
using System.Linq;
using System;
using System.Net;

namespace WindowsFormsApp1.MODULOS
{
    internal class generarCertificadodetrabajo
    {
        private readonly string Dnis_;

        public generarCertificadodetrabajo(string dnis)
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

                // Crea una instancia de Word
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;

                // Crea un nuevo documento
                Word.Document doc = wordApp.Documents.Add();

                // Agrega los datos al documento
                AgregarDatos(doc, datos);
            }
        }

        private void AgregarParrafoConFormato(Word.Document doc, string nombreAgente, string fechaBeca, string fechaNombramiento, string ocupacion, string cargaHoraria, string dni, string legajo,string LEY, string dependencia)
        {
            // Agrega el párrafo con formato específico
            Word.Paragraph paragraph = doc.Paragraphs.Add();

            // Replace placeholders in the text
            string textoParrago = $"El agente que se detalla a continuación se desempeña desde la fecha {fechaBeca} hasta el {fechaNombramiento} como becario y desde esa fecha hasta la actualidad como {ocupacion} con una carga horaria de {cargaHoraria} horas semanales.";

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
                                    $"LEY:{LEY}\n" +
                                    $"DEPENDENCIA: {dependencia}";

            // Aplica el formato al segundo párrafo
            paragraph2.Range.Font.Name = "Times New Roman";
            paragraph2.Range.Font.Size = 12;
            paragraph2.Format.SpaceAfter = 1; // Interlineado de 1
        }
        private void AgregarDatos(Word.Document doc, IQueryable<string> datos)
        {
            // Verifica si hay suficientes datos en la IQueryable
            if (datos.Count() >= 5)
            {
                // Los primeros cinco elementos son utilizados en el ejemplo; ajusta según sea necesario
                string nombreAgente = datos.ElementAt(0);
                string fechaBeca = datos.ElementAt(3);
                string fechaNombramiento = datos.ElementAt(4);
                string ocupacion = datos.ElementAt(2);
                string cargaHoraria = datos.ElementAt(5);
                string LEY= datos.ElementAt(6);
                string dni = datos.ElementAt(1);
                string Legajo= datos.ElementAt(7);
                string dependencia= datos.ElementAt(8);
                
                // Agrega los datos al documento
                AgregarParrafoConFormato(doc, nombreAgente, fechaBeca, fechaNombramiento, ocupacion, cargaHoraria, dni, Legajo, LEY, dependencia);
            }
            else
            {
                // Manejo de error: No hay suficientes datos en la IQueryable
                Console.WriteLine("Error: No hay suficientes datos para generar el certificado.");
            }
        }
    }
}