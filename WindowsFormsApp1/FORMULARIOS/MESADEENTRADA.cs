using System;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Collections.Generic;
using System.Net;
using WindowsFormsApp1.MODULOS;
using DocumentFormat.OpenXml.Bibliography;

namespace WindowsFormsApp1
{
    public partial class MESADEENTRADA : Form
    {
        private PersonaLEVENTOS personaLEVENTOS;
        public static readonly String DEST = "C:\\FORMULARIOS\\TICKETS.pdf";
        public static readonly String SRC = "C:\\FORMULARIOS\\TICKETS 1.pdf";
        public Int64 Dnis_;
        private string _Agentedeatencions;
        private ToolTip tooltip;
        private ConexionMySQL conexion = new ConexionMySQL();
        public MESADEENTRADA(Int64 DNI, string Agentedeatencions_)
        {
            InitializeComponent();
            Dnis_ = DNI;
            _Agentedeatencions = Agentedeatencions_;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.dni, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_); // Corregido aquí
            CONSULTASVIEJAS.MouseUp += CONSULTASVIEJAS_MouseUp;
        }
        public void MESADEENTRADA_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(citaciones, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:250" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.dni, resoluciones.resolucion, tiporesolucion.resolucion as TIPO_RESOLUCION, resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', resoluciones.COMBINACION FROM resoluciones INNER JOIN tipoderesolucion AS tiporesolucion ON resoluciones.tipoderesolucion = tiporesolucion.id WHERE dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:75", "DNI:0", "RESOLUCION:135", "TIPO_RESOLUCION:300", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "COMBINACION:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + Dnis_ + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(CONSULTASVIEJAS, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, dni, legajohecho, REALIZODOMICILIO, JURADASALRIO, foto };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALARIO", "foto" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO, personal.foto FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }
        private void PEDIDOS_MouseClick(object sender, MouseEventArgs e)
        {
            if (PEDIDOS.SelectedItems.Count > 0)
            {
                string campo3Value = PEDIDOS.SelectedItems[0].SubItems[2].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void EXPEDIENTES_MouseClick(object sender, MouseEventArgs e)
        {
            if (EXPEDIENTES.SelectedItems.Count > 0)
            {
                string campo3Value = EXPEDIENTES.SelectedItems[0].SubItems[3].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void CONSULTASVIEJAS_MouseClick(object sender, MouseEventArgs e)
        {
            if (CONSULTASVIEJAS.SelectedItems.Count > 0)
            {
                string campo3Value = CONSULTASVIEJAS.SelectedItems[0].SubItems[3].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void CONSULTASVIEJAS_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && CONSULTASVIEJAS.SelectedItems.Count > 0)
            {
                string campo3Value = CONSULTASVIEJAS.SelectedItems[0].SubItems[3].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void PEDIDOS_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (tooltip == null)
                {
                    // Crear una instancia de la clase ToolTip
                    tooltip = new ToolTip();
                    // Establecer el texto del tooltip
                    tooltip.SetToolTip(citaciones, "PEDIDOS");
                    // Establecer la duración del tooltip
                    tooltip.AutoPopDelay = 9000;
                    // Establecer la posición del tooltip
                    tooltip.Show("PEDIDOS", this, citaciones.Location.X - 200, citaciones.Location.Y - 50);
                    // Mostrar el tooltip
                    tooltip.Active = true;
                }
                else
                {
                    // Reiniciar el temporizador del tooltip
                    tooltip.Active = false;
                    tooltip.Active = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void EXPEDIENTES_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (tooltip == null)
                {
                    // Crear una instancia de la clase ToolTip
                    tooltip = new ToolTip();
                    // Establecer el texto del tooltip
                    tooltip.SetToolTip(citaciones, "EXPEDIENTES");
                    // Establecer la duración del tooltip
                    tooltip.AutoPopDelay = 9000;
                    // Establecer la posición del tooltip
                    tooltip.Show("EXPEDIENTES", this, citaciones.Location.X - 200, citaciones.Location.Y - 50);
                    // Mostrar el tooltip
                    tooltip.Active = true;
                }
                else
                {
                    // Reiniciar el temporizador del tooltip
                    tooltip.Active = false;
                    tooltip.Active = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void RESOLUCIONES_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (tooltip == null)
                {
                    // Crear una instancia de la clase ToolTip
                    tooltip = new ToolTip();
                    // Establecer el texto del tooltip
                    tooltip.SetToolTip(citaciones, "RESOLUCIONES");
                    // Establecer la duración del tooltip
                    tooltip.AutoPopDelay = 9000;
                    // Establecer la posición del tooltip
                    tooltip.Show("RESOLUCIONES", this, citaciones.Location.X - 200, citaciones.Location.Y - 50);
                    // Mostrar el tooltip
                    tooltip.Active = true;
                }
                else
                {
                    // Reiniciar el temporizador del tooltip
                    tooltip.Active = false;
                    tooltip.Active = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CONSULTASVIEJAS_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (tooltip == null)
                {
                    // Crear una instancia de la clase ToolTip
                    tooltip = new ToolTip();
                    // Establecer el texto del tooltip
                    tooltip.SetToolTip(citaciones, "CONSULTAS VIEJAS");
                    // Establecer la duración del tooltip
                    tooltip.AutoPopDelay = 9000;
                    // Establecer la posición del tooltip
                    tooltip.Show("CONSULTAS VIEJAS", this, citaciones.Location.X - 200, citaciones.Location.Y - 50);
                    // Mostrar el tooltip
                    tooltip.Active = true;
                }
                else
                {
                    // Reiniciar el temporizador del tooltip
                    tooltip.Active = false;
                    tooltip.Active = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CONSULTASVIEJAS_MouseLeave(object sender, EventArgs e)
        {
            tooltip.InitialDelay = 7000;
        }
        private void RESOLUCIONES_MouseLeave(object sender, EventArgs e)
        {
            tooltip.InitialDelay = 7000;
        }
        private void EXPEDIENTES_MouseLeave(object sender, EventArgs e)
        {
            tooltip.InitialDelay = 7000;
        }
        private void PEDIDOS_MouseLeave(object sender, EventArgs e)
        {
            tooltip.InitialDelay = 7000;
        }
        private void CARGARPEDIDO_Click(object sender, EventArgs e)
        {

            string nombresSeleccionados = "";
            foreach (Control control in GroupBox1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    nombresSeleccionados += checkBox.Text + ", ";
                }
            }
            nombresSeleccionados = nombresSeleccionados.TrimEnd(',', ' ');
            string pedido = textoadjuntars.Text;
            string dni = Dnis_.ToString();
            string agente = _Agentedeatencions.ToString();
            DateTime fechaPedido = DateTime.Now;
            string pedidoCompleto = nombresSeleccionados + " " + pedido;
            MessageBox.Show("Valor en pedidoCompleto: " + pedidoCompleto);
            CARGARMESADEENTRADA formularioPrincipal = new CARGARMESADEENTRADA();
            formularioPrincipal.AgregarPedido("pedidos", "pedido, dni, agente, fechadepedido", GroupBox1, pedidoCompleto, dni, agente, fechaPedido);
            CrearTicket miCrearTicket = new CrearTicket();
            // Establecer los valores de las propiedades
            miCrearTicket.Agentedeatencion = _Agentedeatencions.ToString();
            miCrearTicket.Horadeatencion = DateTime.Now.ToString();
            miCrearTicket.Motivodeconsulta = pedidoCompleto;
            miCrearTicket.Explicaciondada = "RECORDA QUE IOMA SE RETIRA EN 48 HORAS SI LO SOLICITASTE EL RESTO SE AVISA POR EL TEL";
            miCrearTicket.Agente = Dnis_.ToString();
            // Calcular el ancho máximo en píxeles
            int anchoMaximoCm = 8; // Especificar el ancho máximo en centímetros
            int anchoMaximoPixels = (int)(anchoMaximoCm * 300 / 2.54); // Utilizar una aproximación de 300 DPI
            miCrearTicket.Imprimir();
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            // Limpiar los CheckBox
            foreach (Control control in GroupBox1.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            ConexionMySQL conexionMySQL = new ConexionMySQL();
            CrearTicket miCrearTicket = new CrearTicket();
            // Establecer los valores de las propiedades
            miCrearTicket.Agentedeatencion = _Agentedeatencions.ToString();
            miCrearTicket.Horadeatencion = DateTime.Now.ToString();
            miCrearTicket.Motivodeconsulta = MOTIVODECONSULTA.Text;
            miCrearTicket.Explicaciondada = EXPLICACIONDADA.Text;
            miCrearTicket.Agente = Dnis_.ToString();
            // Calcular el ancho máximo en píxeles
            int anchoMaximoCm = 8; // Especificar el ancho máximo en centímetros
            int anchoMaximoPixels = (int)(anchoMaximoCm * 300 / 2.54); // Utilizar una aproximación de 300 DPI
            // Llamar al método imprimir
            miCrearTicket.Imprimir();
            string motivo = MOTIVODECONSULTA.Text;
            string explicacion = EXPLICACIONDADA.Text;
            string dni = Dnis_.ToString();
            string atendidoPor = _Agentedeatencions.ToString();
            conexionMySQL.AgregarConsulta(motivo, explicacion, dni, atendidoPor);
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + Dnis_ + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(CONSULTASVIEJAS, consultaViejas, columnasViejas);
        }
        private void PEDIDOS_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (citaciones.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(citaciones.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)Dnis_;
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondient                    
                    conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                }
                CrearTicket miCrearTicket = new CrearTicket();
                // Establecer los valores de las propiedades
                miCrearTicket.Agentedeatencion = _Agentedeatencions.ToString();
                miCrearTicket.Horadeatencion = DateTime.Now.ToString();
                miCrearTicket.Motivodeconsulta = "ENTREGA DEL " + id;
                miCrearTicket.Explicaciondada = "ENTREGADO";
                miCrearTicket.Agente = Dnis_.ToString();
                // Calcular el ancho máximo en píxeles
                int anchoMaximoCm = 8; // Especificar el ancho máximo en centímetros
                int anchoMaximoPixels = (int)(anchoMaximoCm * 300 / 2.54); // Utilizar una aproximación de 300 DPI                                                                          // Llamar al método imprimir
                miCrearTicket.Imprimir();
                DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
                string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
                string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
                loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);

            }
        }
        private void RESOLUCIONES_DoubleClick(object sender, EventArgs e)
        {
            // Verifica si hay elementos seleccionados en el ListView
            if (RESOLUCIONES.SelectedItems.Count > 0)
            {
                // Busca el índice de la columna que contiene el nombre del archivo
                int columnIndex = -1;
                foreach (ColumnHeader column in RESOLUCIONES.Columns)
                {
                    if (column.Text == "COMBINACION") // Reemplaza "NombreDeLaColumna" con el nombre real de la columna
                    {
                        columnIndex = column.Index;
                        break;
                    }
                }
                // Verifica si se encontró el índice de la columna
                if (columnIndex >= 0)
                {
                    // Obtén el valor de la columna deseada del elemento seleccionado
                    string nombreArchivo = RESOLUCIONES.SelectedItems[0].SubItems[columnIndex].Text.Trim();
                    string rutaCompleta = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\" + nombreArchivo;
                    string url = "file:///" + rutaCompleta.Replace("\\", "/");
                    MessageBox.Show("Se abrirá la siguiente ruta:\n\n" + rutaCompleta);
                    webBrowser1.Navigate(url);
                }
                else
                {
                    // No se encontró la columna con el nombre especificado
                    MessageBox.Show("No se encontró la columna especificada.");
                }
            }

        }
        private void dni_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dni.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(dni.Text, out Int64 nuevoDnisValor))
                {
                    // Actualiza el valor de Dnis_.
                    Dnis_ = nuevoDnisValor;

                    // Realiza la actualización de los datos en tu formulario con el nuevo valor de Dnis_.
                    ActualizarDatosConNuevoDnis();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es válido. Debe ser un número de DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ActualizarDatosConNuevoDnis()
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(citaciones, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:250" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.dni, resoluciones.resolucion, tiporesolucion.resolucion as TIPO_RESOLUCION, resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', resoluciones.COMBINACION FROM resoluciones INNER JOIN tipoderesolucion AS tiporesolucion ON resoluciones.tipoderesolucion = tiporesolucion.id WHERE dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:75", "DNI:0", "RESOLUCION:135", "TIPO_RESOLUCION:300", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "COMBINACION:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + Dnis_ + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(CONSULTASVIEJAS, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, dni, legajohecho, REALIZODOMICILIO, JURADASALRIO, foto };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALARIO", "foto" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO, personal.foto FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }

        private void DNI1_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dni.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(DNI1.Text, out Int64 nuevoDnisValor))
                {
                    // Actualiza el valor de Dnis_.
                    Dnis_ = nuevoDnisValor;

                    // Realiza la actualización de los datos en tu formulario con el nuevo valor de Dnis_.
                    ActualizarDatosConNuevoDnis();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es válido. Debe ser un número de DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}