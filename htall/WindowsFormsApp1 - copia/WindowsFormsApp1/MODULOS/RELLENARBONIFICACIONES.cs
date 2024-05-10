using iText.Forms;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public class rellenaBONIFICACIONES

    {
        private string nombreCarpetaAdicional;
        public rellenaBONIFICACIONES(string nombreCarpeta)
        {
            nombreCarpetaAdicional = nombreCarpeta;
        }
        public void FillPdfForm(string _dnis)
        {
            PdfDocument pdfDoc = null;
            string rutaOrigen = "C:/FORMULARIOS/BONIFICACIONES.pdf";
            string rutaDestino = "C:/FORMULARIOS/BONIFICACIONES1.pdf";
            string consulta = "SELECT bonificaciones.ID, ";
            consulta += "DAY(bonificaciones.FECHAALTA) , ";
            consulta += "MONTH(bonificaciones.FECHAALTA) , ";
            consulta += "YEAR(bonificaciones.FECHAALTA) , ";
            consulta += "DAY(bonificaciones.FECHABAJA) , ";
            consulta += "MONTH(bonificaciones.FECHABAJA) , ";
            consulta += "YEAR(bonificaciones.FECHABAJA) , ";
            consulta += "bonificaciones.FECHA, ";
            consulta += "bonificaciones.decreto, ";
            consulta += "bonificaciones.MOTIVO, ";
            consulta += "bonificaciones.EXPEDIENTE, ";
            consulta += "bonificaciones.AÑO, ";
            consulta += "bonificaciones.OBSERVACIONES, ";
            consulta += "bonificaciones.DNIAGENTE";
            consulta += "FROM bonificaciones ";
            consulta += "WHERE bonificaciones.DNIAGENTE = @DNIAGENTE";
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
                using (var da = new MySqlDataAdapter(consulta, conexion.GetConnection()))
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
                        pdfFormFields.GetField("RESOLUCIÓN" + valor.ToString()).SetValue(r.Field<string>(1));
                        pdfFormFields.GetField("DIAB" + valor.ToString()).SetValue(r.Field<string>(2));
                        pdfFormFields.GetField("MESB1" + valor.ToString()).SetValue(r.Field<Int64>(3).ToString());
                        pdfFormFields.GetField("AÑOB" + valor.ToString()).SetValue(r.Field<Int64>(4).ToString());
                        pdfFormFields.GetField("MINISTERIORow1" + valor.ToString()).SetValue(r.Field<Int64>(8).ToString());
                        pdfFormFields.GetField("DEPENDENCIARow1" + valor.ToString()).SetValue(r.Field<Int64>(9).ToString());
                        pdfFormFields.GetField("CARGORow" + valor.ToString()).SetValue(r.Field<Int64>(10).ToString());
                        pdfFormFields.GetField("CAT" + valor.ToString()).SetValue(r.Field<Int64>(8).ToString());
                        pdfFormFields.GetField("REGIMEN HORARIORow1" + valor.ToString()).SetValue(r.Field<Int64>(9).ToString());
                        pdfFormFields.GetField("DIARow" + valor.ToString()).SetValue(r.Field<Int64>(10).ToString());
                        pdfFormFields.GetField("MESR" + valor.ToString()).SetValue(r.Field<Int64>(9).ToString());
                        pdfFormFields.GetField("AÑO" + valor.ToString()).SetValue(r.Field<Int64>(10).ToString());
                        pdfFormFields.GetField("MOTIVORow1" + valor.ToString()).SetValue(r.Field<Int64>(10).ToString());
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
                    string nombreArchivoOriginal = "BONIFICACIONES.pdf";
                    string nombreArchivoDestino = "BONIFICACIONES1.pdf";
                    string rutaDestinoCompleta = Path.Combine(direccionIP, nombreArchivoDestino);
                    File.Copy(Path.Combine("C:/FORMULARIOS/", nombreArchivoOriginal), rutaDestinoCompleta, true);
                    MessageBox.Show("Archivo copiado exitosamente a la carpeta: " + direccionIP);
                }
            }
        }
    }


