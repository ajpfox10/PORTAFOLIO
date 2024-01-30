using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;
using iText.StyledXmlParser.Jsoup.Select;
using System.Net;
using static Syncfusion.Windows.Forms.Tools.TextBoxExt;

namespace WindowsFormsApp1
{
    internal class rellenahoja1
    {
        private string nombreCarpetaAdicional;
        public rellenahoja1(string nombreCarpeta)
        {
            nombreCarpetaAdicional = nombreCarpeta;
        }
        public void FillPdfForm(string _dnis)
        {
            PdfDocument pdfDoc = null;
            string rutaOrigen = "c:/FORMULARIOS/hoja1legajo.pdf";
            string rutaDestino = "c:/FORMULARIOS/hoja1legajo1.pdf";
            PdfReader pdfReader = new PdfReader(rutaOrigen);
            PdfAcroForm pdfFormFields;
            string[] primerafila = new string[10];
            using (var conexion = new ConexionMySQL())
            {
                conexion.Conectar();
                using (var da = new MySqlDataAdapter("SELECT  SUBSTRING_INDEX(personal.[Apelldo y Nombre], ',', 1) AS Apellido," +
                    "TRIM(SUBSTRING_INDEX(personal.[Apelldo y Nombre], ',', -1)) AS Nombre,\r\n" +
                    "form2.DNIDELAGENTE, " +
                    "form2.NACIOPAIS, " +
                    "form2.PROVINCIADENAC," +
                    "form2.PARTIDO," +
                    "form2.FCHANACI," +
                    "DAY(form2.FCHANACI)," +
                    "CONCAT(MONTHNAME(form2.FCHANACI), ' mes')," +
                    "YEAR(form2.FCHANACI)," +
                    "form2.ESTADOCIVIL," +
                    "form2.MAXIMONIVELESTUDIOS, " +
                    "form2.TITULOSECUNDARIO," +
                    "form2.TITULOUNIVERSITARIOOTORGADOPOR," +
                    "form2.PRESTOSERVICIOS," +
                    "form2.ARMA," +
                    "form2.ESPECIALIDADARMAMILITAR," +
                    "form2.causalexcepcion," +
                    "form2.ESTUDIOSENCURSO," +
                    "form2.TITULODELESTUDIOENCURSO," +
                    "form2.GRADO," +
                    "form2.DESTINO," +
                    "form2.TITULOTECNICO," +
                    "form2.MATRICULA," +
                    "form2.cartaciudadania," +
                    "form2.fechadeciudadania," +
                    "DAY(form2.fechadeciudadania)," +
                    "MONTH(form2.fechadeciudadania)," +
                    "YEAR(form2.fechadeciudadania)," +
                    "form2.fechadeciudadania," +
                    "form2.fechadeciudadania," +
                    "form2.OTORGADACIUDAD," +
                    "form2.JUEZQLAOTORGO" +
                    "FROM personal INNER JOIN form2 ON personal.dni = form2.DNIDELAGENTE WHERE form2.DNIDELAGENTE = @DNIAGENTE", conexion.GetConnection()))
                {
                    da.SelectCommand.Parameters.AddWithValue("@DNIAGENTE", _dnis);
                    var dt = new DataTable();
                    da.Fill(dt);
                    var ds = new DataSet("Dataset1");
                    ds.Tables.Add(dt);
                    int valor = 1;
                    pdfDoc = new PdfDocument(pdfReader, new PdfWriter(rutaDestino));
                    pdfFormFields = PdfAcroForm.GetAcroForm(pdfDoc, true);
                    foreach (DataRow r in dt.Rows)
                    {
                        r.Field<string>(1);
                        pdfFormFields.GetField("apellidoynombre" + valor.ToString()).SetValue(r.Field<string>(1));
                        pdfFormFields.GetField("nombre" + valor.ToString()).SetValue(r.Field<string>(2));
                        pdfFormFields.GetField("NACIOPAIS" + valor.ToString()).SetValue(r.Field<string>(3));
                        pdfFormFields.GetField("Provincia" + valor.ToString()).SetValue(r.Field<string>(4));
                        pdfFormFields.GetField("Partido" + valor.ToString()).SetValue(r.Field<string>(5));
                        pdfFormFields.GetField("fechanacimiento" + valor.ToString()).SetValue(r.Field<string>(6));
                        pdfFormFields.GetField("mesnacimiento" + valor.ToString()).SetValue(r.Field<string>(7));
                        pdfFormFields.GetField("añonacimiento" + valor.ToString()).SetValue(r.Field<string>(8));
                        pdfFormFields.GetField("soltero" + valor.ToString()).SetValue(r.Field<string>(9));
                        pdfFormFields.GetField("casado" + valor.ToString()).SetValue(r.Field<string>(10));
                        pdfFormFields.GetField("viudo" + valor.ToString()).SetValue(r.Field<string>(11));
                        pdfFormFields.GetField("separado" + valor.ToString()).SetValue(r.Field<string>(12));
                        pdfFormFields.GetField("DNI" + valor.ToString()).SetValue(r.Field<string>(13));
                        pdfFormFields.GetField("Clase" + valor.ToString()).SetValue(r.Field<string>(14));
                        pdfFormFields.GetField("DistMilitar" + valor.ToString()).SetValue(r.Field<string>(15));
                        pdfFormFields.GetField("CI" + valor.ToString()).SetValue(r.Field<string>(16));
                        pdfFormFields.GetField("Expedidapor" + valor.ToString()).SetValue(r.Field<string>(17));
                        pdfFormFields.GetField("CATRACIUDADANIA" + valor.ToString()).SetValue(r.Field<string>(18));
                        pdfFormFields.GetField("localidadcarta" + valor.ToString()).SetValue(r.Field<string>(19));
                        pdfFormFields.GetField("fechacarta" + valor.ToString()).SetValue(r.Field<string>(20));
                        pdfFormFields.GetField("mescarta" + valor.ToString()).SetValue(r.Field<string>(21));
                        pdfFormFields.GetField("añocarta" + valor.ToString()).SetValue(r.Field<string>(22));
                        pdfFormFields.GetField("JuezFEDERAL" + valor.ToString()).SetValue(r.Field<string>(23));
                        pdfFormFields.GetField("EstudioSCURSADOS" + valor.ToString()).SetValue(r.Field<string>(24));
                        pdfFormFields.GetField("TITULOSECUNDARIOOTECNICO" + valor.ToString()).SetValue(r.Field<string>(25));
                        pdfFormFields.GetField("OtorgadoPORSECUNDARIA" + valor.ToString()).SetValue(r.Field<string>(26));
                        pdfFormFields.GetField("TítuloUniversitario" + valor.ToString()).SetValue(r.Field<string>(27));
                        pdfFormFields.GetField("OtorgadoPORUNI" + valor.ToString()).SetValue(r.Field<string>(28));
                        pdfFormFields.GetField("APTITUDESPECIALUOFICIO" + valor.ToString()).SetValue(r.Field<string>(29));
                        pdfFormFields.GetField("HAPRESTADOSERVICIOSMILITARES" + valor.ToString()).SetValue(r.Field<string>(30));
                        pdfFormFields.GetField("Arma" + valor.ToString()).SetValue(r.Field<string>(31));
                        pdfFormFields.GetField("Especialidad" + valor.ToString()).SetValue(r.Field<string>(32));
                        pdfFormFields.GetField("Grado" + valor.ToString()).SetValue(r.Field<string>(33));
                        pdfFormFields.GetField("Destino" + valor.ToString()).SetValue(r.Field<string>(34));
                        pdfFormFields.GetField("motivodelaexcepcion" + valor.ToString()).SetValue(r.Field<string>(35));

                        valor++;
                    }
                    valor = 1;
                    pdfFormFields.FlattenFields();
                    pdfDoc.Close();
                    pdfReader.Close();
                    string direccionIP = Path.Combine(@"C:", nombreCarpetaAdicional);

                    if (!Directory.Exists(direccionIP))
                    {
                        Directory.CreateDirectory(direccionIP);
                    }
                    string nombreArchivoOriginal = "domicilio1.pdf";
                    string nombreArchivoDestino = "DOMICILIOLEG.pdf";
                    string rutaDestinoCompleta = Path.Combine(direccionIP, nombreArchivoDestino);
                    File.Copy(Path.Combine("e:/FORMULARIOS/", nombreArchivoOriginal), rutaDestinoCompleta, true);
                    MessageBox.Show("Archivo copiado exitosamente a la carpeta: " + direccionIP);
                }
            }
        }
    }
















}

