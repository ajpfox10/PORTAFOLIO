using iText.Forms;
using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace WindowsFormsApp1
{    public class rellenACARGODEINICIO

    {
        private string nombreCarpetaAdicional;
        public rellenACARGODEINICIO(string nombreCarpeta)
        {
            nombreCarpetaAdicional = nombreCarpeta;
        }
        public void FillPdfForm(string _dnis)
        {
            PdfDocument pdfDoc = null;
            string rutaOrigen = "C:/FORMULARIOS/CARGOS.pdf";
            string rutaDestino = "C:/FORMULARIOS/CARGOS1.pdf";            
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', ";
            consulta += "DAY(cargosdeinicio.FECHADEDESIGNACION) AS 'DIA DE DESIGNACION', ";
            consulta += "MONTH(cargosdeinicio.FECHADEDESIGNACION) AS 'MES DE DESIGNACION', ";
            consulta += "YEAR(cargosdeinicio.FECHADEDESIGNACION) AS 'AÑO DE DESIGNACION', ";
            consulta += "cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO AS 'REGIMEN HORARIO', ";
            consulta += "DAY(cargosdeinicio.FECHADEBAJA) AS 'DIA DE BAJA', ";
            consulta += "MONTH(cargosdeinicio.FECHADEBAJA) AS 'MES DE BAJA', ";
            consulta += "YEAR(cargosdeinicio.FECHADEBAJA) AS 'AÑO DE BAJA', ";
            consulta += "cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', ";
            consulta += "cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', ";
            consulta += "cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' ";
            consulta += "FROM cargosdeinicio ";
            consulta += "WHERE cargosdeinicio.DNIAGENTE = @DNIAGENTE";
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

