﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class MESADEENTRADA : Form
    {
        private PersonaLEVENTOS personaLEVENTOS;
        public static readonly String DEST = "C:\\FORMULARIOS\\TICKETS.pdf";
        public static readonly String SRC = "C:\\FORMULARIOS\\TICKETS 1.pdf";
        private ListViewManager pedidosManager;
        private ListViewManager resolucionesManager;
        private ListViewManager consultasViejasManager;
        private ListViewManager expedientesManager;
        private ListViewManager RecargarCitacione;
        private ListViewManager RecargarPedidos;
        private ListViewManager citacionesmanager;
        public Int64 Dnis_;
        private string _Agentedeatencions;
        private ConexionMySQL conexion = new ConexionMySQL();
        private ListViewManager listViewManager;
        private DateTime ultimoClick = DateTime.Now;
        private int intervaloDobleClick = 1000; // Intervalo en milisegundos para considerar un doble clic
        public MESADEENTRADA(Int64 DNI, string Agentedeatencions_)
        {
            InitializeComponent();
            Dnis_ = DNI;
            _Agentedeatencions = Agentedeatencions_;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.dni, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
            Load += MESADEENTRADA_Load;       
            cargars.Click += Carga_Click_1;
            citaciones.MouseDown += ListView_MouseDown;
            PEDIDOS.MouseDown += ListView_MouseDown;
            CONSULTASVIEJAS.MouseDown += ListView_MouseDown;
            RESOLUCIONES.MouseDown += ListView_MouseDown;
            EXPEDIENTES.MouseDown += ListView_MouseDown;
            pedidosManager = new ListViewManager(PEDIDOS, DATOSANALIZAR, Dnis_, Agentedeatencions_, webBrowser);
            resolucionesManager = new ListViewManager(RESOLUCIONES, DATOSANALIZAR, Dnis_, Agentedeatencions_, webBrowser);
            consultasViejasManager = new ListViewManager(CONSULTASVIEJAS, DATOSANALIZAR, Dnis_, Agentedeatencions_, webBrowser);
            expedientesManager = new ListViewManager(EXPEDIENTES, DATOSANALIZAR, Dnis_, Agentedeatencions_, webBrowser);
            RecargarPedidos = new ListViewManager(PEDIDOS, DATOSANALIZAR, Dnis_, _Agentedeatencions, webBrowser);
            citacionesmanager = new ListViewManager(citaciones, DATOSANALIZAR, Dnis_, _Agentedeatencions, webBrowser);
            listViewManager = new ListViewManager(PEDIDOS, DATOSANALIZAR, Dnis_, _Agentedeatencions, webBrowser);
            listViewManager.RecargarPedidos(); 
        }
        public void MESADEENTRADA_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(citaciones, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT ID, DNI, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "id:75", "DNI:0", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
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
            dni.Text = DNI1.Text;
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }   
        private void Carga_Click_1(object sender, EventArgs e)
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
        private void ActualizarDatosConNuevoDnis()
        {
            Dnis_ = Convert.ToInt64(DNI1.Text);
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
        // Método para manejar el clic derecho en un ListViewItem
        private void ListView_MouseDown(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                TimeSpan diferencia = DateTime.Now - ultimoClick;
                if (diferencia.TotalMilliseconds < intervaloDobleClick)
                {
                    // Es un doble clic derecho
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    if (item != null)
                    {
                        // Seleccionar el ítem sobre el que se hizo clic derecho
                        listView.SelectedItems.Clear();
                        item.Selected = true;
                        // Obtener la columna en la que se hizo clic derecho
                        int columnIndex = -1;
                        for (int i = 0; i < listView.Columns.Count; i++)
                        {
                            if (listView.Columns[i].Width > e.X)
                            {
                                columnIndex = i;
                                break;
                            }
                        }
                        // Obtener el dato de la columna y fila seleccionada
                        if (columnIndex != -1)
                        {
                            string datoSeleccionado = item.SubItems[columnIndex].Text;
                            Clipboard.SetText(datoSeleccionado);
                            MessageBox.Show($"Dato '{datoSeleccionado}' copiado al portapapeles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                ultimoClick = DateTime.Now;
            }
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
                
             listViewManager.RecargarPedidos();
            // Limpiar los CheckBox
            foreach (Control control in GroupBox1.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
        // Método para copiar un dato específico de una columna seleccionada de un ListView dado
        private void dni_TextChanged(object sender, EventArgs e)
        {
           DNI1.Text = dni.Text;
        }
        private void MESADEENTRADA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Realiza la limpieza de datos sensibles
            Dnis_ = 0;
            _Agentedeatencions = string.Empty;



            // Si es necesario, puedes limpiar más controles o recursos
        }

        private void DNI1_DoubleClick(object sender, EventArgs e)
        {
            ActualizarDatosConNuevoDnis();
        }
    }
}