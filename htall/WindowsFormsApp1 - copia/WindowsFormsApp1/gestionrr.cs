using iText.StyledXmlParser.Jsoup.Select;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace WindowsFormsApp1
{
    public partial class gestionrr : Form
    {
        public Int64 _dnis;
        public string _agentedeatencions;
        private List<System.Windows.Forms.TextBox> textBoxes;
        private ConexionMySQL conexionMySQL = new ConexionMySQL();
        public gestionrr(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            _agentedeatencions = agenteDeAtencion;
         
        }
        private void gestionrr_Load(object sender, EventArgs e)
        {
           
            DNI1.DoubleClick += textBox1_DoubleClick;
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);

            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + _dnis + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);

            string CARGAACTOS22 = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + _dnis + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS222 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(GDEBANOTAS, CARGAACTOS22, CARGAACTOS222);
           
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + _dnis + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.dni, resoluciones.resolucion, tiporesolucion.resolucion as TIPO_RESOLUCION, resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', resoluciones.COMBINACION FROM resoluciones INNER JOIN tipoderesolucion AS tiporesolucion ON resoluciones.tipoderesolucion = tiporesolucion.id WHERE dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:75", "DNI:0", "RESOLUCION:135", "TIPO_RESOLUCION:300", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "COMBINACION:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + _dnis + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(consultasechas, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, dni, legajohecho, REALIZODOMICILIO };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio FROM personal WHERE personal.dni = '" + _dnis + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();

            var conexion = new ConexionMySQL();
            var usuarios = conexion.ObtenerUsuarios().ToList();
            try
            {
                string consulta1 = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> valoresApellido = conexion.EjecutarConsulta(consulta1, "APELLIDO");
                List<string> valoresDNI = conexion.EjecutarConsulta(consulta1, "DNI");
                // Limpiamos el ComboBox antes de agregar los valores
                apellido1.Items.Clear();
                // Crear un diccionario para asociar DNI con apellidos y nombres
                var diccionarioDNI = new Dictionary<string, string>();
                for (int i = 0; i < valoresApellido.Count; i++)
                {
                    diccionarioDNI[valoresDNI[i]] = valoresApellido[i];
                }
                // Agregamos los valores al ComboBox, mostrando solo los apellidos
                apellido1.Items.AddRange(valoresApellido.ToArray());
                // Asociamos el diccionario como un Tag al ComboBox
                apellido1.Tag = diccionarioDNI;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private void CITA_MouseClick(object sender, MouseEventArgs e)
        {
            {
                if (CITA.SelectedItems.Count > 0)
                {
                    string campo3Value = CITA.SelectedItems[0].SubItems[3].Text;
                    DATOSANALIZAR.Text = campo3Value;
                }
            }
        }
        private void CITA_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (CITA.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(CITA.SelectedItems[0].SubItems[0].Text);
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la citación con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondiente
                    conexion.ActualizarCierreDeCitacion(id);
                }
            }
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);

        }
        private void consultasechas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            {
                if (consultasechas.SelectedItems.Count > 0)
                {
                    string campo3Value = consultasechas.SelectedItems[0].SubItems[3].Text;
                    DATOSANALIZAR.Text = campo3Value;
                }
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
        private void EXPEDIENTES_MouseClick(object sender, MouseEventArgs e)
        {
            if (EXPEDIENTES.SelectedItems.Count > 0)
            {
                string campo3Value = EXPEDIENTES.SelectedItems[0].SubItems[3].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void PEDIDOS_MouseClick(object sender, MouseEventArgs e)
        {
            if (PEDIDOS.SelectedItems.Count > 0)
            {
                string campo3Value = PEDIDOS.SelectedItems[0].SubItems[2].Text;
                DATOSANALIZAR.Text = campo3Value;
            }
        }
        private void PEDIDOS_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (PEDIDOS.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(PEDIDOS.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)_dnis;
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondient                    
                    conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                }
                DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
                string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
                string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
                loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);

             }
         }
        private void CARGAREXPEDIENTES_Click(object sender, EventArgs e)
        {
            // Aquí obtén los valores necesarios y llama al método
  
            long dni = _dnis; // Reemplaza con el valor adecuado
            string atendidoPor = _agentedeatencions; // Reemplaza con el valor adecuado
            string notanumero = NUMEROS.Text; // Reemplaza con el valor adecuado
            string año = AÑOS.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string reparticion = REPARTICION.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string memo = MEMOS.Text; // Reemplaza con el valor adecuado
            string save = $"{tipos1.SelectedItem.ToString()}-{año}-{notanumero}-GDEBA-{reparticion}";  // Reemplaza con el valor adecuado
            if (string.IsNullOrEmpty(notanumero) || string.IsNullOrEmpty(año) || string.IsNullOrEmpty(reparticion))
            {
                MessageBox.Show("Asegúrate de completar todos los campos necesarios antes de ejecutar la consulta.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Verificar el valor de tipos1 y ejecutar la consulta adicional si cumple con la condición
                if (tipos1.SelectedItem.ToString() == "EX")
                {
                    conexionMySQL.Agregarexpedientes(dni, atendidoPor, notanumero, año, memo, save);
                }
                else
                {
                    // Llamar al método para agregar notas de expedientes solo si tipos1 no es "EX"
                    conexionMySQL.Agregarnotasexpedientes(dni, atendidoPor, notanumero, año, reparticion, memo, save);
                }
            }
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + _dnis + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXP2, consultaExpedientes, columnasExpedientes);
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + _dnis + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);

            string consultaExpedientes2 = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + _dnis + "' ORDER BY id DESC";
            string[] columnasExpedientes2 = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(ACTOS2, consultaExpedientes2, columnasExpedientes2);
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void cargacita_Click(object sender, EventArgs e)
        {
            {
                long dni = _dnis; // Reemplaza con el valor adecuado
                string CITADOPOR = _agentedeatencions; // Reemplaza con el valor adecuado
                string MOTIVACION = NUMEROS.Text; // Reemplaza con el valor adecuado
                string CITACIONACTIVA = AÑOS.SelectedItem.ToString(); // Reemplaza con el valor adecuado
                DateTime fechadecitacion = DateTime.Now; // Reemplaza con el valor adecuado
                string memo = MEMOS.Text; // Reemplaza con el valor adecuado    
                if (string.IsNullOrEmpty(CITADOPOR) || string.IsNullOrEmpty(MOTIVACION) || string.IsNullOrEmpty(CITACIONACTIVA) || fechadecitacion == DateTime.MinValue || string.IsNullOrEmpty(memo))
                {
                    MessageBox.Show("Asegúrate de completar todos los campos necesarios antes de ejecutar la consulta.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                        conexionMySQL.CARGADECITACION(dni, CITADOPOR, MOTIVACION, CITACIONACTIVA, fechadecitacion);
                }
             }
         }
        private void apellido1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();
                // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
                // Asigna el DNI al cuadro de texto "DNI"
                DNI1.Text = dni;
            }
        }
        private void apellido1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();
                // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
                // Asigna el DNI al cuadro de texto "DNI"
                DNI1.Text = dni;
            }
        }
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI1.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(DNI1.Text, out Int64 nuevoDnisValor))
                {
                    // Actualiza el valor de _dnis.
                    _dnis = nuevoDnisValor;

                    // Realiza la actualización de los datos en tu formulario con el nuevo valor de _dnis.
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
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + _dnis + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);
            string CARGAACTOS22 = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + _dnis + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS222 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(GDEBANOTAS, CARGAACTOS22, CARGAACTOS222);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + _dnis + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.dni, resoluciones.resolucion, tiporesolucion.resolucion as TIPO_RESOLUCION, resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', resoluciones.COMBINACION FROM resoluciones INNER JOIN tipoderesolucion AS tiporesolucion ON resoluciones.tipoderesolucion = tiporesolucion.id WHERE dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:75", "DNI:0", "RESOLUCION:135", "TIPO_RESOLUCION:300", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "COMBINACION:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + _dnis + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(consultasechas, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, dni, legajohecho, REALIZODOMICILIO };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio FROM personal WHERE personal.dni = '" + _dnis + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }
        private void DNI1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(DNI1.Text) && long.TryParse(DNI1.Text, out long dniNumber))
                {
                    _dnis = dniNumber;
                    // Obtener el diccionario del Tag del ComboBox
                    var diccionarioDNI = apellido1.Tag as Dictionary<string, string>;

                    if (diccionarioDNI != null)
                    {
                        string dniString = dniNumber.ToString();
                        if (diccionarioDNI.ContainsKey(dniString))
                        {
                            // Si se encuentra, obtener el "APELLIDO Y NOMBRE" correspondiente
                            string apellidoNombre = diccionarioDNI[dniString];
                            // Seleccionar el elemento en el ComboBox
                            apellido1.SelectedItem = apellidoNombre;
           
                            _dnis = Convert.ToInt64(DNI1.Text);
                        }
                        else
                        {
                            // Si no se encuentra coincidencia, puedes realizar alguna acción apropiada, como limpiar la selección.
                            apellido1.SelectedIndex = -1;
                            MessageBox.Show("No se encontró un APELLIDO Y NOMBRE correspondiente al DNI ingresado.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo DNI no es válido. Debe ingresar un número válido.");
                }
            }
        }
        private void apellido1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();
                // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
                // Asigna el DNI al cuadro de texto "DNI"
                DNI1.Text = dni;
                _dnis = Convert.ToInt64(DNI1.Text);
            }
        }
        private void apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string apellidoSeleccionado = apellido1.SelectedItem.ToString();
            // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
            string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
            var conexion = new ConexionMySQL();
            string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
            // Asigna el DNI al cuadro de texto "DNI"
            DNI1.Text = dni;
            _dnis = Convert.ToInt64(DNI1.Text);
        }
        private void CARGARDATOS_Click(object sender, EventArgs e)
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string DATOSLABORALES = "SELECT personal.`Fecha de Ingreso`, personal.MATRICULA, personal.Sector, personal.Decreto, personal.fechadenom AS 'FECHA DE NOMBRAMIENTO', personal.Categoria, personal.Funcion, personal.`Regimen Horario`, personal.`Cargo Desvirtuado`, personal.`DIA DE GUARDIA`, personal.resolucionteturalizacion10471 AS 'RESOLUCION DE TITULARIZACION LEY 10471', personal.RESOLUCIONDETITURALIZACION10430 AS 'RESOLUCION DE TITULARIZACION LEY 10430', personal.fechadetituralizacion10471 AS 'FECHA DE TITULARIZACION LEY 10471', personal.fechaderesoluciondelnombramientoINTERINO10430 AS 'RESOLUCION DE PASE DE INTERINO A PLANTA LEY 10430', personal.especialidad, personal.disciplina, personal.desvirtuadoafuncion AS 'DESVIRTUADO A FUNCION', personal.agrupamiento, personal.desvirtuadode AS 'DESVIRTUADO DE', personal.dependenciaoriginal AS 'DEPENDENCIA ORIGINAL', personal.RANGOHORARIO AS 'RANGO HORARIO', ocupacion.Ocupacion FROM ocupacion INNER JOIN (ley INNER JOIN personal ON ley.IDLEY = personal.Ley) ON ocupacion.IDESPECIALIDAD = personal.ocupacion WHERE personal.dni = '" + _dnis + "'";
            string[] CARGADATOSLABORAALES = new string[] { "Fecha de Ingreso:125", "MATRICULA:125", "SECTOR:125", "DECRETO:125", "FECHA DE NOMBRAMIENTO:175", "CATEGORIA:125", "FUNCION:125", "REGIMEN HORARIO:125", "CARGO DESVIRTUADO:150", "DIA DE GUARDIA:125", "RESOLUCION DE TITULARIZACION LEY 10471:275", "RESOLUCION DE TITULARIZACION LEY 10430:250", "FECHA DE TITULARIZACION LEY 10471:225", "RESOLUCION DE PASE DE INTERINO A PLANTA LEY 10430:325","ESPECIALIDAD:125", "DISCIPLINA:125", "DESVIRTUADO A FUNCION:225", "AGRUPAMIENTO:125", "DESVIRTUADO DE:125", "DEPENDENCIA ORIGINAL:225", "RANGO HORARIO:125" };
            loader.CargarDatosYAcciones(DATS, DATOSLABORALES, CARGADATOSLABORAALES);
        }

        private void apellido1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DNI1.Text) && long.TryParse(DNI1.Text, out long dniNumber))
            {
                // El DNI es válido y se asigna a la variable _dnis.
                // Coloca aquí cualquier otro código que necesites realizar cuando el DNI cambia.
                _dnis = Convert.ToInt64(DNI1.Text);
            }
            else
            {
                // Manejar el caso en el que el DNI es nulo o no válido.
                _dnis = 0; // O asigna un valor predeterminado o realiza alguna acción apropiada.
            }
        }

        private void CARGADATSPERSONALES_Click(object sender, EventArgs e)
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string DATOSLABORALES = "SELECT personal.`Fecha de Nacimento`, personal.`Cantidad de Hijos`, personal.Telefono, sexo.SEXO, personal.CUIL, personal.salario, personal.estadocivil AS 'ESTADO CIVIL', personal.Nacionalidad AS 'NACIONALIDAD' FROM sexo INNER JOIN personal ON sexo.ID = personal.Sexo WHERE personal.dni = '" + _dnis + "'";
            string[] CARGADATOSLABORAALES = new string[] { "Fecha de Nacimento:125", "Cantidad de Hijos:125", "Telefono:125", "SEXO:125", "CUIL:175", "SALARIO:125", "ESTADO CIVIL:125", "NACIONALIDAD:125"};
            loader.CargarDatosYAcciones(DATSPERSONALES, DATOSLABORALES, CARGADATOSLABORAALES);
        }

        private void CARGARPEDIDO_Click(object sender, EventArgs e)
        {

            string nombresSeleccionados = "";
            foreach (Control control in groupBox2.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    nombresSeleccionados += checkBox.Text + ", ";
                }
            }
            nombresSeleccionados = nombresSeleccionados.TrimEnd(',', ' ');
            string pedido = textoadjuntars.Text;
            string dni = _dnis.ToString();
            string agente = _agentedeatencions.ToString();
            DateTime fechaPedido = DateTime.Now;
            string pedidoCompleto = nombresSeleccionados + " " + pedido;
            MessageBox.Show("Valor en pedidoCompleto: " + pedidoCompleto);
            CARGARMESADEENTRADA formularioPrincipal = new CARGARMESADEENTRADA();
            formularioPrincipal.AgregarPedido("pedidos", "pedido, dni, agente, fechadepedido", groupBox2, pedidoCompleto, dni, agente, fechaPedido);
            crearTicket miCrearTicket = new crearTicket();
            // Establecer los valores de las propiedades
            miCrearTicket.agentedeatencion = _agentedeatencions.ToString();
            miCrearTicket.horadeatencion = DateTime.Now.ToString();
            miCrearTicket.motivodeconsulta = pedidoCompleto;
            miCrearTicket.explicaciondada = "RECORDA QUE IOMA SE RETIRA EN 48 HORAS SI LO SOLICITASTE EL RESTO SE AVISA POR EL TEL";
            miCrearTicket.agente = _dnis.ToString();
            // Calcular el ancho máximo en píxeles
            int anchoMaximoCm = 8; // Especificar el ancho máximo en centímetros
            int anchoMaximoPixels = (int)(anchoMaximoCm * 300 / 2.54); // Utilizar una aproximación de 300 DPI
            miCrearTicket.imprimir(miCrearTicket, anchoMaximoPixels);
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + _dnis + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            // Limpiar los CheckBox
            foreach (Control control in groupBox2.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
        }
    }
}

