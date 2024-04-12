using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;
public class PdfFormFiller
{
    private string nombreCarpetaAdicional;
    public PdfFormFiller(string nombreCarpeta)
    {
        nombreCarpetaAdicional = nombreCarpeta;
    }
    public void FillPdfForm(string Dnis_)
    {
        PdfDocument pdfDoc = null;
        string rutaOrigen = "c:/FORMULARIOS/domicilio.pdf";
        string rutaDestino = "c:/FORMULARIOS/domicilio1.pdf";
        PdfReader pdfReader = new PdfReader(rutaOrigen);
        PdfAcroForm pdfFormFields;
        string[] primerafila = new string[10];
        using (var conexion = new ConexionMySQL())
        {
            conexion.Conectar();
            using (var da = new MySqlDataAdapter("SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, localidades1.provincia_id AS PCIA, form3.PARTIDO, form3.LOCALIDAD, form3.DNIAGENTE AS DNI, form3.fechadecarga FROM form3 INNER JOIN localidades1 ON (form3.LOCALIDAD = localidades1.idlocalidad) AND (form3.PARTIDO = localidades1.municipio_id) WHERE form3.DNIAGENTE = @DNIAGENTE LIMIT 20", conexion.GetConnection()))           //" SELECT form3.Id, form3.CALLE, form3.NUMERO, form3.PISO, form3.DEPTO, localidades1.Provincia AS PROVINCIA, localidades1.municipio AS MUNICIPIO, localidades1.nombre AS NOMBRE, localidades1.provincia_id AS PCIA, form3.PARTIDO, form3.LOCALIDAD form3.DNIAGENTE AS DNI FROM form3 INNER JOIN localidades1 ON(form3.LOCALIDAD = localidades1.idlocalidad) AND(form3.PARTIDO = localidades1.municipio_id) WHERE form3.DNIAGENTE = '" + Dnis_ + "'";
            {
                da.SelectCommand.Parameters.AddWithValue("@DNIAGENTE", Dnis_);

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
                    pdfFormFields.GetField("NUMERORow" + valor.ToString()).SetValue(r.Field<string>(1) + " " + r.Field<string>(2) + " " + "PISO: " + r.Field<string>(3) + " " + "DEPTO:"+ r.Field<string>(4));
                    pdfFormFields.GetField("LOCALIDADRow" + valor.ToString()).SetValue(r.Field<string>(6) + " " + r.Field<string>(7));
                    DateTime fecha = r.Field<DateTime>(12);
                    string fechaString = fecha.ToString("dd/MM/yyyy"); // Cambia el formato de fecha según tus necesidades
                    pdfFormFields.GetField("FECHARow" + valor.ToString()).SetValue(fechaString);
                    valor++;
                }
                valor = 1;
                pdfFormFields.FlattenFields();
                pdfDoc.Close();
                pdfReader.Close();
                string direccionIP = Path.Combine(@"C:", nombreCarpetaAdicional);

           //     string direccionIP = Path.Combine(@"\\192.168.0.21\g\DOCU\", nombreCarpetaAdicional);
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