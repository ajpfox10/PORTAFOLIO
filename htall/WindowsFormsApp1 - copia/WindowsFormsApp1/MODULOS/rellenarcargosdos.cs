using iText.Forms;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public class rellenrcargosdos

    {
        private string nombreCarpetaAdicional;
        public rellenrcargosdos(string nombreCarpeta)
        {
            nombreCarpetaAdicional = nombreCarpeta;
        }
        public void FillPdfForm(string _dnis)
        {
            PdfDocument pdfDoc = null;
            string rutaOrigen = "C:/FORMULARIOS/CARGOS.pdf";
            string rutaDestino = "C:/FORMULARIOS/CARGOS1.pdf";
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', ";
            consulta += "cargosdeinicio.FECHADEDESIGNACION AS 'DIA DE DESIGNACION', ";
            consulta += "cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO AS 'REGIMEN HORARIO', ";
            consulta += "cargosdeinicio.FECHADEBAJA AS 'DIA DE BAJA', ";
            consulta += "cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', ";
            consulta += "cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', ";
            consulta += "cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' ";
            consulta += "FROM cargosdeinicio ";
            consulta += "WHERE cargosdeinicio.DNIAGENTE = @DNIAGENTE";
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
                        pdfFormFields.GetField("RESOLUCION O DECRETORow1" + valor.ToString()).SetValue(r.Field<string>(9));
                        pdfFormFields.GetField("INGRESOROW1" + valor.ToString()).SetValue(r.Field<DateTime>(4).ToString());
                        pdfFormFields.GetField("EGRESOROW1" + valor.ToString()).SetValue(r.Field<DateTime>(7).ToString());
                        pdfFormFields.GetField("DESTINORow1" + valor.ToString()).SetValue(r.Field<String>(8).ToString());
                        pdfFormFields.GetField("FUNCIONRow" + valor.ToString()).SetValue(r.Field<String>(2).ToString());
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
                    string nombreArchivoOriginal = "CARGOS.pdf";
                    string nombreArchivoDestino = "CARGOS1.pdf";
                    string rutaDestinoCompleta = Path.Combine(direccionIP, nombreArchivoDestino);
                    File.Copy(Path.Combine("C:/FORMULARIOS/", nombreArchivoOriginal), rutaDestinoCompleta, true);
                    MessageBox.Show("Archivo copiado exitosamente a la carpeta: " + direccionIP);
                }
            }
        }
    }










}

