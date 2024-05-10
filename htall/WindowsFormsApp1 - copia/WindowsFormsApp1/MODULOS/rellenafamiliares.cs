using iText.Forms;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Select;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public class rellenafamiliares

    {
        private string nombreCarpetaAdicional;
        public rellenafamiliares(string nombreCarpeta)
        {
            nombreCarpetaAdicional = nombreCarpeta;
        }
        public void FillPdfForm(string _dnis)
        {
            PdfDocument pdfDoc = null;
            string rutaOrigen = "C:/FORMULARIOS/FAMILIA.pdf";
            string rutaDestino = "C:/FORMULARIOS/FAMILIA1.pdf";
         //   string rutaOrigen = "e:/FORMULARIOS/domicilio.pdf";
        //    string rutaDestino = "e:/FORMULARIOS/domicilio1.pdf";
            if (File.Exists(rutaOrigen))
            {
                MessageBox.Show("existe");
            }
            else
            {
                MessageBox.Show("no");
            }
            PdfReader pdfReader = new PdfReader(rutaOrigen);
            PdfAcroForm pdfFormFields;
            string[] primerafila = new string[10];
            using (var conexion = new ConexionMySQL())
            {
                conexion.Conectar();
                using (var da = new MySqlDataAdapter("SELECT form1.DNIAGENTE, form1.PARENTESCO, form1.NOMBREYAPELLIDO, form1.SEXO, form1.VIVE, form1.FECHA, form1.CAJAJUBILACION, form1.PROFESION, DAY(form1.FECHA) AS DayOfMonth, MONTH(form1.FECHA) AS MonthOfYear, YEAR(form1.FECHA) AS YearValue, form1.JUB FROM form1 HAVING form1.DNIAGENTE = @DNIAGENTE LIMIT 20", conexion.GetConnection()))
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
                        pdfFormFields.GetField("PARENTESCORow" + valor.ToString()).SetValue(r.Field<string>(1));
                        pdfFormFields.GetField("NOMBRERow" + valor.ToString()).SetValue(r.Field<string>(2));
                        pdfFormFields.GetField("SEXORow" + valor.ToString()).SetValue(r.Field<string>(3));
                        pdfFormFields.GetField("VIVERow" + valor.ToString()).SetValue(r.Field<string>(4));
                        pdfFormFields.GetField("DIARow" + valor.ToString()).SetValue(r.Field<Int64>(8).ToString());
                        pdfFormFields.GetField("MESRow" + valor.ToString()).SetValue(r.Field<Int64>(9).ToString());
                        pdfFormFields.GetField("AÑORow" + valor.ToString()).SetValue(r.Field<Int64>(10).ToString());
                        //   pdfFormFields.GetField("PENSIONADORow" + valor.ToString()).SetValue(DateTime.Now.ToString("dd/MM/yyyy"));
                        string jubilado = r.Field<string>(11);
                        if (jubilado == "SI")
                        {
                            string fraseJubilado = "Si jubilado y caja: " + r.Field<string>(6);
                            pdfFormFields.GetField("PENSIONADORow" + valor.ToString()).SetValue(fraseJubilado);
                        }
                        else  
                        {
                            string profesion = r.Field<string>(7);
                            pdfFormFields.GetField("PENSIONADORow" + valor.ToString()).SetValue(profesion);
                        }


                        valor++;
                    }
                    valor = 1;
                    pdfFormFields.FlattenFields();
                    pdfDoc.Close();
                    pdfReader.Close();
                    string direccionIP = Path.Combine(@"C:", nombreCarpetaAdicional);
                  //  string direccionIP = Path.Combine(@"\\192.168.0.21\g\DOCU\", nombreCarpetaAdicional);
                    if (!Directory.Exists(direccionIP))
                    {
                        Directory.CreateDirectory(direccionIP);
                    }
                    string nombreArchivoOriginal = "FAMILIA.pdf";
                    string nombreArchivoDestino = "FAMILIALEG.pdf";
                    string rutaDestinoCompleta = Path.Combine(direccionIP, nombreArchivoDestino);
                    File.Copy(Path.Combine("C:/FORMULARIOS/", nombreArchivoOriginal), rutaDestinoCompleta, true);
                    MessageBox.Show("Archivo copiado exitosamente a la carpeta: " + direccionIP);
                }
            }
        }
    }










}

