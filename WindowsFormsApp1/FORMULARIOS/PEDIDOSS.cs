using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            PEDIDOSSS.HideSelection = false;
            // Configurar OwnerDraw en true
      
            PEDIDOSSS.Font = new Font("Arial", 10, FontStyle.Regular); // Ejemplo de fuente y tamaño

        }
        private void PEDIDOSS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaPedidos = "SELECT pedidos.ID, personal.DNI, personal.`apelldo y nombre` AS 'APELLIDO Y NOMBRE', pedidos.PEDIDO, pedidos.agente, pedidos.fechadepedido AS 'FECHA DE PEDIDO' FROM pedidos INNER JOIN personal ON pedidos.dni = personal.dni WHERE activa IS NULL  ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "ID:0", "DNI:0", "APELLIDO Y NOMBRE:250", "PEDIDO:500", "AGENTE:175", "FECHA DE PEDIDO:250" };
            loader.CargarDatosYAcciones(PEDIDOSSS, consultaPedidos, columnasPedidos);
            // Llamar al método para pintar los pedidos antiguos al cargar los datos
            PintarPedidosAntiguos();
            MostrarMensajeAtraso();
        }
        private void CargarDatosEnTextBox(string dni, string pedido)
        {
            textBoxDNI.Text = dni;
            richpedidos.Text = pedido;
            MostrarMensajeAtraso();
        }
        private void CBTRA_Click(object sender, EventArgs e)
        {
            string dniValue = Dnis_.ToString();
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
                int id = Convert.ToInt32(PEDIDOSSS.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)Dnis_;
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
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
            CargarDatosEnTextBox(dni, pedido);
        }
        private void PintarPedidosAntiguos()
        {
            int indiceColumnaFecha = 5; // Índice de la columna "FECHA DE PEDIDO" en tu ListView

            for (int indiceFila = 0; indiceFila < PEDIDOSSS.Items.Count; indiceFila++)
            {
                ListViewItem item = PEDIDOSSS.Items[indiceFila];
                string fechaPedidoString = item.SubItems[indiceColumnaFecha].Text;
                DateTime fechaPedido;

                if (DateTime.TryParse(fechaPedidoString, out fechaPedido))
                {
                    TimeSpan diferencia = DateTime.Now - fechaPedido;
                    if (diferencia.Days == 1)
                    {
                        item.BackColor = Color.Yellow; // Pintar de amarillo los pedidos con un día de atraso
                        item.ForeColor = Color.Black; // Color de texto por defecto
                    }
                    else if (diferencia.Days > 1)
                    {
                        item.BackColor = Color.Red; // Pintar de rojo los pedidos con más de un día de atraso
                        item.ForeColor = Color.White; // Color de texto blanco para mejor visibilidad
                    }
                    else
                    {
                        // Asegúrate de restaurar los colores por defecto si no se cumple la condición
                        item.BackColor = Color.White; // Color de fondo por defecto
                        item.ForeColor = Color.Black; // Color de texto por defecto
                    }
                }
            }
        }


        private void MostrarMensajeAtraso()
        {
            int tareasUnDiaAtraso = 0;
            int tareasDosDiasAtraso = 0;

            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Iterar sobre los elementos del ListView
            foreach (ListViewItem item in PEDIDOSSS.Items)
            {
                // Obtener el texto de la tercera columna (índice 2)
                string fechaPedidoString = item.SubItems[5].Text; // Columna "FECHA DE PEDIDO"
                string nombreColumna = PEDIDOSSS.Columns[5].Text; // Nombre de la columna

                // Depurar información sobre la columna actual
                Console.WriteLine($"Analizando columna: {nombreColumna}");

                DateTime fechaPedido;

                // Intentar convertir la fecha de pedido a DateTime
                if (DateTime.TryParse(fechaPedidoString, out fechaPedido))
                {
                    // Calcular los días de atraso
                    int diasAtraso = (fechaActual - fechaPedido).Days;
                    Console.WriteLine($"Días de atraso para el elemento: {diasAtraso}");
                    // Contar tareas con 1 día de atraso
                    if (diasAtraso == 1)
                    {
                        tareasUnDiaAtraso++;
                    }
                    // Contar tareas con 2 días de atraso
                    else if (diasAtraso >= 2)
                    {
                        tareasDosDiasAtraso++;
                        Console.WriteLine($"Días de atraso para el elemento: {tareasDosDiasAtraso}");
                    }
                }
                else
                {
                    // Manejar caso donde no se puede convertir la fecha de pedido
                    Debug.WriteLine($"No se pudo convertir la fecha de pedido ({fechaPedidoString}) de la columna {nombreColumna}");
                }
            }
         
            // Construir el mensaje solo si hay tareas con atraso
            if (tareasUnDiaAtraso > 0 || tareasDosDiasAtraso > 0)
            {
                string mensaje = $"USTED TIENE {tareasUnDiaAtraso} TAREAS CON UN DÍA DE ATRASO Y {tareasDosDiasAtraso} TAREAS CON DOS DÍAS DE ATRASO AL LLEGAR A LOS 3 DIAS SE REPRTARA A SU CORDINADOR.";

                // Mostrar el mensaje en un MessageBox
                MessageBox.Show(mensaje, "Información Importante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }






    }
}







