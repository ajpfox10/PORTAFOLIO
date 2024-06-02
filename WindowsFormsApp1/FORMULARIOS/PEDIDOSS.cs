using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class PEDIDOSS : Form
    {
        private readonly string Agentedeatencions_;
        public Int64 Dnis_;
        private Process wordProcess;
        public PEDIDOSS(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
        }
        private void PEDIDOSS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaPedidos = "SELECT pedidos.ID, personal.DNI, personal.`apelldo y nombre` AS 'APELLIDO Y NOMBRE', pedidos.PEDIDO, pedidos.agente FROM pedidos INNER JOIN personal ON pedidos.dni = personal.dni WHERE activa IS NULL  ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "ID:0", "DNI:0", "APELLIDO Y NOMBRE:250", "PEDIDO:500", "AGENTE:175" };
            loader.CargarDatosYAcciones(PEDIDOSSS, consultaPedidos, columnasPedidos);
            PEDIDOSSS.MultiSelect = true;
        }
        private void CargarDatosEnTextBox(string dni, string pedido)
        {
            textBoxDNI.Text = dni;
            richpedidos.Text = pedido;
        }
        private void CBTRA_Click(object sender, EventArgs e)
        {
            string dniValue = Dnis_.ToString();
            // Create an instance of GenerarCertificadodetrabajo
            GenerarCertificadodetrabajo generador = new GenerarCertificadodetrabajo(dniValue);
            generador.GenerateCertificate();
        }






        private void BIOMA_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordProcess != null && !wordProcess.HasExited)
                {
                    MessageBox.Show("Debe cerrar el documento de Word anterior antes de abrir uno nuevo.");
                    return;
                }

                // Ruta del documento en la red
                string rutaDocumento = "\\\\192.168.0.21\\g\\LALA\\1.docx";
                string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
                IOMA documentProcessor = new IOMA();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (FileStream fileStream = new FileStream(rutaDocumento, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(memoryStream);
                    }

                    using (ConexionMySQL conexionMySQL = new ConexionMySQL())
                    {
                        string consultaSQL = "SELECT personal.`apelldo y nombre` AS 'APELLIDOYNOMBRE', personal.dni, personal.dependencia, personal.Decreto, personal.legajo, personal.`Fecha de Ingreso` AS 'FECHAP' FROM personal WHERE dni = '" + Dnis_ + "'";
                        var dataTable = conexionMySQL.EjecutarConsulta(consultaSQL);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string cadenaReemplazo = row["APELLIDOYNOMBRE"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "APELLDOYNOMBRE", cadenaReemplazo);
                            cadenaReemplazo = row["dni"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "DNIP", cadenaReemplazo);
                            cadenaReemplazo = row["dependencia"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", cadenaReemplazo);
                            cadenaReemplazo = row["Decreto"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "DECRETOS", cadenaReemplazo);
                            cadenaReemplazo = row["FECHAP"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "FECHASS", cadenaReemplazo);
                            cadenaReemplazo = row["legajo"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "LEGAJOS", cadenaReemplazo);
                            string cadenaReemplazoFecha = DateTime.Now.ToString("dd/MM/yyyy");
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "FFFFFFFFFFFFFFFFF", cadenaReemplazoFecha);
                        }
                    }

                    using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.Position = 0;
                        memoryStream.CopyTo(fileStream);
                    }
                }

                wordProcess = Process.Start("WINWORD.EXE", tempFilePath);
                if (wordProcess != null)
                {
                    wordProcess.EnableRaisingEvents = true;
                    wordProcess.Exited += (s, ev) => File.Delete(tempFilePath); // Eliminar archivo temporal cuando se cierra Word
                }

                MessageBox.Show("Reemplazo completado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }



        private void PEDIDOSSS_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (PEDIDOSSS.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(PEDIDOSSS.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)Dnis_;
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondient                    
                    conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                }
                DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
                string consultaPedidos = "SELECT pedidos.ID, personal.DNI, personal.`apelldo y nombre` AS 'APELLIDO Y NOMBRE', pedidos.PEDIDO, pedidos.agente FROM pedidos INNER JOIN personal ON pedidos.dni = personal.dni WHERE activa IS NULL  ORDER BY id DESC";
                string[] columnasPedidos = new string[] { "ID:0", "DNI:0", "APELLIDO Y NOMBRE:250", "PEDIDO:500", "AGENTE:175" };
                loader.CargarDatosYAcciones(PEDIDOSSS, consultaPedidos, columnasPedidos);
            }
        }
        private void PEDIDOSSS_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = PEDIDOSSS.SelectedItems[0];
            string dni = selectedItem.SubItems[1].Text;
            string pedido = selectedItem.SubItems[3].Text;
            string textoDnis = selectedItem.SubItems[1].Text;
            long.TryParse(textoDnis, out Dnis_);
            // Llama a tu método para cargar datos en TextBox
            CargarDatosEnTextBox(dni, pedido);
        }
    }
}
