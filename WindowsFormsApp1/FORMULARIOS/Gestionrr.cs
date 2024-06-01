﻿using iText.StyledXmlParser.Jsoup.Select;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace WindowsFormsApp1
{
    public partial class Gestionrr : Form
    {
        public Int64 Dnis_;
        public string Agentedeatencions_;
   
        private readonly ConexionMySQL conexionMySQL = new ConexionMySQL();
        private PersonaLEVENTOS personaLEVENTOS;
        public Gestionrr(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            DATS.MouseClick += new MouseEventHandler(DATS_MouseClick);
            DATSPERSONALES.MouseDoubleClick += new MouseEventHandler(DATOSS_MouseClick);
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_); apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();
            apellido1.Enter += (s, ev) => ((System.Windows.Forms.ComboBox)s).SelectAll();
        }
        private void Gestionrr_Load(object sender, EventArgs e)
        {          
            DNI.DoubleClick += DNI_DoubleClick;
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);
            string CARGAACTOS22 = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS222 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:200" };
            loader.CargarDatosYAcciones(GDEBANOTAS, CARGAACTOS22, CARGAACTOS222);       
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE dni='" + Dnis_ + "' AND activa = '' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:375", "ARCHIVO:325" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.resolucion AS 'RESOLUCION', resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', tipoderesolucion.resolucion AS 'RESOLUCION DE' FROM tipoderesolucion INNER JOIN resoluciones ON tipoderesolucion.id = resoluciones.tipoderesolucion WHERE dni = '" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:30", "RESOLUCION:135", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "RESOLUCION DE:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + Dnis_ + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(consultasechas, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, DNI, legajohecho, REALIZODOMICILIO, JURADASALARIO };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALRIO" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
            var conexion = new ConexionMySQL();
            var usuarios = conexion.ObtenerUsuarios().ToList();
            try
            {
                string consulta1 = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.DNI FROM personal ORDER BY APELLIDO DESC";
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
            try {
                string consulta3 = "SELECT reparticiones.NOMBREREPARTICION AS REPARTICION, reparticiones.ID FROM reparticiones ORDER BY REPARTICION DESC";
                List<string> valoresDEPENDENCIAS = conexion.EjecutarConsulta(consulta3, "REPARTICION");
                List<string> valoresDEPENDENCIAS1= conexion.EjecutarConsulta(consulta3, "ID");
                // Limpiamos el ComboBox antes de agregar los valores
                REPARTICION.Items.Clear();
                // Crear un diccionario para asociar DNI con apellidos y nombres
                var diccionarioDEPENDENCIAS = new Dictionary<string, string>();
                for (int i = 0; i < valoresDEPENDENCIAS.Count; i++)
                {
                    diccionarioDEPENDENCIAS[valoresDEPENDENCIAS1[i]] = valoresDEPENDENCIAS[i];
                }
                // Agregamos los valores al ComboBox, mostrando solo los apellidos
                REPARTICION.Items.AddRange(valoresDEPENDENCIAS.ToArray());
                // Asociamos el diccionario como un Tag al ComboBox
                REPARTICION.Tag = diccionarioDEPENDENCIAS;
            } 
            catch (Exception ex) { Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message); }
            string consultaTIPORESO = @"SELECT tipoderesolucion.resolucion, tipoderesolucion.id FROM tipoderesolucion";
            // Llenar el ComboBox con los resultados de la consulta
            conexionMySQL.LlenarComboBox(consultaTIPORESO, TIPORESOLUCION, "resolucion", "id");
            ComboBoxItem itemDecreto = new ComboBoxItem { DisplayMember = "DECRETO", ValueMember = 0 };
            ComboBoxItem itemResolucion = new ComboBoxItem { DisplayMember = "RESOLUCION", ValueMember = 11112 };
            ComboBoxItem iteexpediediente = new ComboBoxItem { DisplayMember = "EXPEDIENTE", ValueMember = 2910 };
            ComboBoxItem iteDISPOSCION = new ComboBoxItem { DisplayMember = "DISPOSICION", ValueMember = 2};
            ComboBoxItem iteDISPOSCIONGDEBA = new ComboBoxItem { DisplayMember = "DISPOSICION GDEBA", ValueMember = 3 };
            ComboBoxItem RESOGDEBANGDEBA = new ComboBoxItem { DisplayMember = "RESOLUCION GDEBA SALUD", ValueMember = 4 };
            ComboBoxItem RESOGDEBANGDEBAS = new ComboBoxItem { DisplayMember = "RESOLUCION GDEBA GOBIERNO", ValueMember = 5 };
            ComboBoxItem RESOLGDEBANGDEBAS = new ComboBoxItem { DisplayMember = "RESOL", ValueMember = 6 };
            ComboBoxItem RESOLNU = new ComboBoxItem { DisplayMember = "RS", ValueMember = 7};
            // Limpiar ítems existentes (opcional)
            ACTOTIPO.Items.Clear();
            // Agregar los ítems al ComboBox
            ACTOTIPO.Items.Add(itemDecreto);
            ACTOTIPO.Items.Add(itemResolucion);
            // Configurar DisplayMember y ValueMember
            ACTOTIPO.DisplayMember = "DisplayMember";
            ACTOTIPO.ValueMember = "ValueMember";
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
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);

        }
        private void Consultasechas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            {
                if (consultasechas.SelectedItems.Count > 0)
                {
                    string campo3Value = consultasechas.SelectedItems[0].SubItems[3].Text;
                    datosaanalizar.Text = campo3Value;
            
                    DATOSANALIZAR.Focus();
                }
            }
        }
        private void PEDIDOS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Código para el clic izquierdo
                if (PEDIDOS.SelectedItems.Count > 0)
                {
                    string campo3Value = PEDIDOS.SelectedItems[0].SubItems[2].Text;
                    DATOSANALIZAR.Text = campo3Value;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Código para el clic derecho
                if (PEDIDOS.SelectedItems.Count > 0)
                {
                    string campo4Value = PEDIDOS.SelectedItems[0].SubItems[3].Text;
                    DATOSANALIZAR.Text = campo4Value;
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
                    if (column.Text == "RESOLUCION") // Reemplaza "NombreDeLaColumna" con el nombre real de la columna
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
        private void PEDIDOS_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (PEDIDOS.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(PEDIDOS.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)Dnis_;
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondient                    
                    conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                }
                DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
                string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
                string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
                loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
             }
         }
        private void CARGAREXPEDIENTES_Click(object sender, EventArgs e)
        {
            // Aquí obtén los valores necesarios y llama al método
  
            long dni = Dnis_; // Reemplaza con el valor adecuado
            string atendidoPor = Agentedeatencions_; // Reemplaza con el valor adecuado
            string notanumero = NUMEROS.Text; // Reemplaza con el valor adecuado
            string año = AÑOS.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string reparticion = REPARTICION.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string memo = MEMOS.Text; // Reemplaza con el valor adecuado
            string save = $"{tipos1.SelectedItem}-{año}-{notanumero}-GDEBA-{reparticion}";  // Reemplaza con el valor adecuado
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
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXP2, consultaExpedientes, columnasExpedientes);
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);
        }
        private void Cargacita_Click(object sender, EventArgs e)
        {
            int dni = (int)Dnis_;
            string CITADOPOR = Agentedeatencions_;
            string MOTIVACION = txtcargadecitacion.Text;
            string CITACIONACTIVA = "A REALIZAR";
            DateTime fechadecitacion = DateTime.Now;
            string campoIncompleto = "";

            if (string.IsNullOrEmpty(CITADOPOR))
            {
                campoIncompleto = "CITADOPOR";
            }
            else if (string.IsNullOrEmpty(MOTIVACION))
            {
                campoIncompleto = "MOTIVACION";
            }
            else if (string.IsNullOrEmpty(CITACIONACTIVA))
            {
                campoIncompleto = "CITACIONACTIVA";
            }
            else if (fechadecitacion == DateTime.MinValue)
            {
                campoIncompleto = "fechadecitacion";
            }
       
            if (!string.IsNullOrEmpty(campoIncompleto))
            {
                MessageBox.Show($"El campo {campoIncompleto} está incompleto. Asegúrate de completarlo antes de ejecutar la consulta.", "Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conexionMySQL.CARGADECITACION(dni, CITADOPOR, MOTIVACION, fechadecitacion);
            }
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);

        }
        private void DNI_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
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
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXP2, CARGAACTOS, CARGAACTOS2);
            string CARGAACTOS22 = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS222 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(GDEBANOTAS, CARGAACTOS22, CARGAACTOS222);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(CITA, consultaCitaciones, columnasCitaciones);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(PEDIDOS, consultaPedidos, columnasPedidos);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXPEDIENTES, consultaExpedientes, columnasExpedientes);
            string consultaResoluciones = "SELECT RESOLUCIONES.id, resoluciones.resolucion AS 'RESOLUCION', resoluciones.FECHADERESOLUCION AS 'FECHA DE RESOLUCION', resoluciones.FECHADENOTIFICACION AS 'FECHA DE NOTIFICACION', tipoderesolucion.resolucion AS 'RESOLUCION DE' FROM tipoderesolucion INNER JOIN resoluciones ON tipoderesolucion.id = resoluciones.tipoderesolucion WHERE dni = '" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasResoluciones = new string[] { "ID:30", "RESOLUCION:135", "FECHA DE RESOLUCION:155", "FECHA DE NOTIFICACION:155", "RESOLUCION DE:145" };
            loader.CargarDatosYAcciones(RESOLUCIONES, consultaResoluciones, columnasResoluciones);
            string consultaViejas = "SELECT IDDECONSULTA AS 'ID', DNI, MOTIVODECONSULTA AS 'MOTIVO DE CONSULTA', EXPLICACIONDADA AS 'EXPLICACION DADA', ATENDIDOPOR AS 'ATENDIDO POR', HORADEATENCION AS 'HORA DE ATENCION' FROM consultas WHERE DNI='" + Dnis_ + "' ORDER BY IDDECONSULTA DESC";
            string[] columnasViejas = new string[] { "ID:75", "DNI:0", "MOTIVO DE CONSULTA:300", "EXPLICACION DADA:175", "ATENDIDO POR:125", "HORA DE ATENCION:125" };
            loader.CargarDatosYAcciones(consultasechas, consultaViejas, columnasViejas);
            List<Control> controles = new List<Control> { apellynombre, legajo, DNI, legajohecho, REALIZODOMICILIO, JURADASALARIO, foto };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALRIO", "foto" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO, personal.foto FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }
        private void CARGARDATOS_Click(object sender, EventArgs e)
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string DATOSLABORALES = "SELECT ocupacion.Ocupacion, personal.`Fecha de Ingreso`, personal.MATRICULA, personal.Sector, personal.Decreto, personal.fechadenom AS 'FECHA DE NOMBRAMIENTO', personal.Categoria, personal.Funcion, personal.`Regimen Horario`, personal.`Cargo Desvirtuado`, personal.`DIA DE GUARDIA`, personal.resolucionteturalizacion10471 AS 'RESOLUCION DE TITULARIZACION LEY 10471', personal.RESOLUCIONDETITURALIZACION10430 AS 'RESOLUCION DE TITULARIZACION LEY 10430', personal.fechadetituralizacion10471 AS 'FECHA DE TITULARIZACION LEY 10471', personal.fechaderesoluciondelnombramientoINTERINO10430 AS 'RESOLUCION DE PASE DE INTERINO A PLANTA LEY 10430', personal.especialidad, personal.disciplina, personal.desvirtuadoafuncion AS 'DESVIRTUADO A FUNCION', personal.agrupamiento, personal.desvirtuadode AS 'DESVIRTUADO DE', personal.dependenciaoriginal AS 'DEPENDENCIA ORIGINAL', personal.RANGOHORARIO AS 'RANGO HORARIO'  FROM ocupacion INNER JOIN (ley INNER JOIN personal ON ley.IDLEY = personal.Ley) ON ocupacion.IDESPECIALIDAD = personal.ocupacion WHERE personal.dni = '" + Dnis_ + "'";
            string[] CARGADATOSLABORAALES = new string[] { "OCUPACION:125", "Fecha de Ingreso:125", "MATRICULA:110", "SECTOR:125", "DECRETO:125", "FECHA DE NOMBRAMIENTO:175", "CATEGORIA:100", "FUNCION:125", "REGIMEN HORARIO:125", "CARGO DESVIRTUADO:150", "DIA DE GUARDIA:125", "RESOLUCION DE TITULARIZACION LEY 10471:275", "RESOLUCION DE TITULARIZACION LEY 10430:250", "FECHA DE TITULARIZACION LEY 10471:225", "RESOLUCION DE PASE DE INTERINO A PLANTA LEY 10430:325","ESPECIALIDAD:125", "DISCIPLINA:125", "DESVIRTUADO A FUNCION:225", "AGRUPAMIENTO:125", "DESVIRTUADO DE:125", "DEPENDENCIA ORIGINAL:225", "RANGO HORARIO:125"};
            loader.CargarDatosYAcciones(DATS, DATOSLABORALES, CARGADATOSLABORAALES);
        }
        private void CARGADATSPERSONALES_Click(object sender, EventArgs e)
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string DATOSLABORALES = "SELECT personal.`Fecha de Nacimento`, personal.`Cantidad de Hijos`, personal.Telefono, sexo.SEXO, personal.CUIL, personal.salario, personal.estadocivil AS 'ESTADO CIVIL', personal.Nacionalidad AS 'NACIONALIDAD' FROM sexo INNER JOIN personal ON sexo.ID = personal.Sexo WHERE personal.dni = '" + Dnis_ + "'";
            string[] CARGADATOSLABORAALES = new string[] { "Fecha de Nacimento:125", "Cantidad de Hijos:100", "Telefono:175", "SEXO:75", "CUIL:100", "SALARIO:75", "ESTADO CIVIL:125", "NACIONALIDAD:125"};
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
            string dni = Dnis_.ToString();
            string agente = Agentedeatencions_.ToString();
            DateTime fechaPedido = DateTime.Now;
            string pedidoCompleto = nombresSeleccionados + " " + pedido;
            MessageBox.Show("Valor en pedidoCompleto: " + pedidoCompleto);
            CARGARMESADEENTRADA formularioPrincipal = new CARGARMESADEENTRADA();
            formularioPrincipal.AgregarPedido("pedidos", "pedido, dni, agente, fechadepedido", groupBox2, pedidoCompleto, dni, agente, fechaPedido);
            CrearTicket miCrearTicket = new CrearTicket
            {
                // Establecer los valores de las propiedades
                Agentedeatencion = Agentedeatencions_.ToString(),
                Horadeatencion = DateTime.Now.ToString(),
                Motivodeconsulta = pedidoCompleto,
                Explicaciondada = "RECORDA QUE IOMA SE RETIRA EN 48 HORAS SI LO SOLICITASTE EL RESTO SE AVISA POR EL TEL",
                Agente = Dnis_.ToString()
            };
            miCrearTicket.Imprimir();
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
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
        private void CARGAR_Click(object sender, EventArgs e)
        {
            // Aquí obtén los valores necesarios y llama al método
            long dni = Dnis_; // Reemplaza con el valor adecuado
            string atendidoPor = Agentedeatencions_; // Reemplaza con el valor adecuado
            string notanumero = NUMERO.Text; // Reemplaza con el valor adecuado
            string año = AÑO.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string reparticion = REPART.SelectedItem.ToString(); // Reemplaza con el valor adecuado
            string memo = MEMO.Text; // Reemplaza con el valor adecuado
            string save = $"{tipos1.SelectedItem}-{año}-{notanumero}-GDEBA-{reparticion}";  // Reemplaza con el valor adecuado
            if (string.IsNullOrEmpty(notanumero) || string.IsNullOrEmpty(año) || string.IsNullOrEmpty(reparticion))
            {
                MessageBox.Show("Asegúrate de completar todos los campos necesarios antes de ejecutar la consulta.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Verificar el valor de tipos1 y ejecutar la consulta adicional si cumple con la condición
                if (TIPO.SelectedItem.ToString() == "EX")
                {
                    conexionMySQL.AgregarexpedientesDIRE(dni, atendidoPor, notanumero, año, memo, save);
                }
                else
                {
                    // Llamar al método para agregar notas de expedientes solo si tipos1 no es "EX"
                    conexionMySQL.AgregarnotasexpedientesDIRE(dni, atendidoPor, notanumero, año, reparticion, memo, save);
                }
            }
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaExpedientes = "SELECT id, AGENTE, expedientenumero AS 'EXPEDIENTE NUMERO', MEMO, archivo FROM expedientes WHERE AGENTE='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasExpedientes = new string[] { "ID:75", "AGENTE:0", "EXPEDIENTE NUMERO:300", "MEMO:175", "ARCHIVO:125" };
            loader.CargarDatosYAcciones(EXPDIRECCION, consultaExpedientes, columnasExpedientes);
            string CARGAACTOS = "SELECT ccoodegdeba.id, ccoodegdeba.agente, ccoodegdeba.agentequetramito AS 'AGENTE QUE TRAMITO', ccoodegdeba.notanumero AS 'NUMERO', ccoodegdeba.año, ccoodegdeba.reparticion, ccoodegdeba.memo, ccoodegdeba.save FROM ccoodegdeba WHERE AGENTE='" + Dnis_ + "' ORDER BY ccoodegdeba.save DESC";
            string[] CARGAACTOS2 = new string[] { "ID:75", "AGENTE:0", "AGENTE QUE TRAMITO:300", "NUMERO:175", "AÑO:125", "REPARTICION:125", "MEMO:125", "SAVE:190" };
            loader.CargarDatosYAcciones(EXPDIRECCION, CARGAACTOS, CARGAACTOS2);
        }
        private void DATS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = DATS.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < DATS.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + DATS.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += DATS.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = DATS.PointToScreen(new Point(mouseX, mouseY));

                    ContextMenuStrip menu = new ContextMenuStrip();

                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < DATS.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {DATS.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, DATS);
                        menu.Items.Add(itemCopiarColumna);
                    }

                    menu.Show(screenPoint);
                }
            }
        }
        private void ItemCopiarColumna_Click(object sender, EventArgs e, int columnIndex, ListView listView)
        {
            StringBuilder datosCopiados = new StringBuilder();

            // Iterar a través de los elementos en el ListView
            foreach (ListViewItem item in listView.Items)
            {
                // Verificar si hay suficientes subítemas en este elemento y si la columna está dentro de los límites
                if (item.SubItems.Count > columnIndex && columnIndex >= 0 && columnIndex < DATS.Columns.Count)
                {
                    // Obtener el texto de la subítema en la columna especificada
                    string textoColumna = item.SubItems[columnIndex].Text;
                    datosCopiados.AppendLine(textoColumna); // Agregar una nueva línea al final de cada fila
                }
            }

            Clipboard.SetText(datosCopiados.ToString());
        }
        private void ItemCopiar_Click(object sender, EventArgs e)
        {
            // Verifica si hay elementos seleccionados en el ListView
            if (DATS.SelectedItems.Count > 0)
            {
                // Crea una cadena para almacenar los datos copiados
                string datosCopiados = "";
                // Itera a través de los elementos seleccionados en el ListView
                foreach (ListViewItem item in DATS.SelectedItems)
                {
                    // Itera a través de las subitems de cada elemento
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        // Agrega el texto de cada subitem a la cadena de datos copiados
                        datosCopiados += subItem.Text + "\t"; // Agrega un tabulador entre cada columna
                    }
                    // Agrega una nueva línea al final de cada fila
                    datosCopiados += Environment.NewLine;
                }
                // Copia los datos al portapapeles
                Clipboard.SetText(datosCopiados);
            }
        }
        private void DATOSS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = DATSPERSONALES.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < DATSPERSONALES.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + DATSPERSONALES.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += DATSPERSONALES.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = DATSPERSONALES.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < DATSPERSONALES.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {DATSPERSONALES.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, DATSPERSONALES);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
        }
        private void ItemCopiarColumna1_Click( EventArgs e, int columnIndex, ListView listView)
        {
            StringBuilder datosCopiados = new StringBuilder();

            // Iterar a través de los elementos en el ListView
            foreach (ListViewItem item in listView.Items)
            {
                // Verificar si hay suficientes subítemas en este elemento y si la columna está dentro de los límites
                if (item.SubItems.Count > columnIndex && columnIndex >= 0 && columnIndex < DATSPERSONALES.Columns.Count)
                {
                    // Obtener el texto de la subítema en la columna especificada
                    string textoColumna = item.SubItems[columnIndex].Text;
                    datosCopiados.AppendLine(textoColumna); // Agregar una nueva línea al final de cada fila
                }
            }

            Clipboard.SetText(datosCopiados.ToString());
        }
        private void ItemCopiar1_Click(object sender, EventArgs e)
        {
            // Verifica si hay elementos seleccionados en el ListView
            if (DATSPERSONALES.SelectedItems.Count > 0)
            {
                // Crea una cadena para almacenar los datos copiados
                string datosCopiados = "";

                // Itera a través de los elementos seleccionados en el ListView
                foreach (ListViewItem item in DATSPERSONALES.SelectedItems)
                {
                    // Itera a través de las subitems de cada elemento
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        // Agrega el texto de cada subitem a la cadena de datos copiados
                        datosCopiados += subItem.Text + "\t"; // Agrega un tabulador entre cada columna
                    }
                    // Agrega una nueva línea al final de cada fila
                    datosCopiados += Environment.NewLine;
                }
                // Copia los datos al portapapeles
                Clipboard.SetText(datosCopiados);
            }
        }
        private void EXPEDIENTES_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = EXPEDIENTES.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < EXPEDIENTES.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + EXPEDIENTES.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += EXPEDIENTES.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = EXPEDIENTES.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < EXPEDIENTES.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {EXPEDIENTES.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, EXPEDIENTES);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
        }
        private void Consultasechas_MouseClick(object sender, MouseEventArgs e)
        {
            {
                if (consultasechas.SelectedItems.Count > 0)
                {
                    string campo2Value = consultasechas.SelectedItems[0].SubItems[2].Text;
                    datosaanalizar.Text = campo2Value;

                    DATOSANALIZAR.Focus();
                }
            }
        }
        private void RESOLUCIONES_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = RESOLUCIONES.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < RESOLUCIONES.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + RESOLUCIONES.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += RESOLUCIONES.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = RESOLUCIONES.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < RESOLUCIONES.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {RESOLUCIONES.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, RESOLUCIONES);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
        }
        private void GDEBANOTAS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = GDEBANOTAS.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < GDEBANOTAS.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + GDEBANOTAS.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += GDEBANOTAS.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = GDEBANOTAS.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < GDEBANOTAS.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {GDEBANOTAS.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, GDEBANOTAS);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
        }
        private void EXP2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = EXP2.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < EXP2.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + EXP2.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += EXP2.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = EXP2.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < EXP2.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {EXP2.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, EXP2);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
        }
        private void EXPEDIENTES_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = EXPEDIENTES.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < EXPEDIENTES.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + EXPEDIENTES.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += EXPEDIENTES.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = EXPEDIENTES.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < EXPEDIENTES.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {EXPEDIENTES.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, EXPEDIENTES);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    menu.Show(screenPoint);
                }
            }
            else
            {
                if (EXPEDIENTES.SelectedItems.Count > 0)
                {
                    string campo3Value = EXPEDIENTES.SelectedItems[0].SubItems[3].Text;
                    DATOSANALIZAR.Text = campo3Value;
                }
            }
        }
        private void CARGADATODOMICILIO_Click(object sender, EventArgs e)
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string DATOSDOMI = "SELECT personal.DOMICILIO, personal.NUMERO, personal.DEPARTAMENTO, personal.PISO, localidades1.NOMBRE, localidades1.MUNICIPIO, localidades1.PROVINCIA, personal.OBSERVACION FROM personal INNER JOIN localidades1 ON (personal.PROVINCIA = localidades1.PROVINCIA_ID) AND (personal.LOCALIDAD = localidades1.IDLOCALIDAD) AND (personal.PARTIDO = localidades1.MUNICIPIO_ID) AND personal.DNI = '" + Dnis_ + "'";
            string[] CARGADATOSDOMICILIO = new string[] { "DOMICILIO:250", "NUMERO:100", "DEPARTAMENTO:75", "PISO:100", "NOMBRE:175", "MUNICIPIO:175", "PROVINCIA:125", "OBSERVACION:325" };
            loader.CargarDatosYAcciones(DOMICILIOS, DATOSDOMI, CARGADATOSDOMICILIO);
        }
        private void DOMICILIOS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Convertir las coordenadas del clic del ratón a coordenadas locales del ListView
                Point localPoint = DOMICILIOS.PointToClient(new Point(e.X, e.Y));
                // Determinar la columna en la que se hizo clic
                int columnIndex = -1;
                int currentPosition = 0;
                for (int i = 0; i < DOMICILIOS.Columns.Count; i++)
                {
                    if (localPoint.X >= currentPosition && localPoint.X <= currentPosition + DOMICILIOS.Columns[i].Width)
                    {
                        columnIndex = i;
                        break;
                    }
                    currentPosition += DOMICILIOS.Columns[i].Width;
                }
                // Si se hizo clic en una columna, mostrar el menú contextual
                if (columnIndex != -1)
                {
                    int mouseX = e.X;
                    int mouseY = e.Y;
                    Point screenPoint = DOMICILIOS.PointToScreen(new Point(mouseX, mouseY));
                    ContextMenuStrip menu = new ContextMenuStrip();
                    // Iterar sobre cada columna y agregar un elemento de menú para copiarla
                    for (int i = 0; i < DOMICILIOS.Columns.Count; i++)
                    {
                        int index = i; // Guardar el índice en una variable local para el cierre del bucle
                        ToolStripMenuItem itemCopiarColumna = new ToolStripMenuItem($"Copiar {DOMICILIOS.Columns[i].Text}");
                        itemCopiarColumna.Click += (senderObj, args) => ItemCopiarColumna_Click(senderObj, args, index, DOMICILIOS);
                        menu.Items.Add(itemCopiarColumna);
                    }
                    // Agregar la opción para copiar todos los datos separados por un espacio
                    ToolStripMenuItem itemCopiarTodos = new ToolStripMenuItem("Copiar todos los datos (separados por espacio)");
                    itemCopiarTodos.Click += (senderObj, args) => ItemCopiarTodos_Click(senderObj, args, DOMICILIOS);
                    menu.Items.Add(itemCopiarTodos);
                    menu.Show(screenPoint);
                }
            }
        }
        private void ItemCopiarTodos_Click(object sender, EventArgs e, ListView listView)
        {
            StringBuilder datosCopiados = new StringBuilder();
            // Iterar a través de los elementos en el ListView
            foreach (ListViewItem item in listView.Items)
            {
                // Iterar a través de las subitems de cada elemento
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    // Agregar el texto de cada subitem a la cadena de datos copiados
                    datosCopiados.Append(subItem.Text).Append(" "); // Agrega un espacio entre cada dato
                }
            }
            Clipboard.SetText(datosCopiados.ToString());
        }
        public class ComboBoxItem
        {
            public string DisplayMember { get; set; }
            public int ValueMember { get; set; }
            public override string ToString()
            {
                return DisplayMember;
            }
        }// SEPARARLA EN UNA CLASE DIFERENTE O INTEGRARLA
        private void CARGARRESOL_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si los campos están llenos
                if (Dnis_ == null || string.IsNullOrEmpty(NRORESOLUCION.Text) || TIPORESOLUCION.SelectedValue == null || FECHADERESOLUCION.Value == null || ANIO.SelectedItem == null || ACTOTIPO.SelectedItem == null)
                {
                    throw new ArgumentException("Debe completar todos los campos.");
                }
                GestionResoluciones gestionResoluciones = new GestionResoluciones();
                // Obtener valores de los controles del formulario
                int dni = (int)Dnis_;
                string numeroResolucion = NRORESOLUCION.Text;
                string tipoResolucionValueMember = TIPORESOLUCION.SelectedValue.ToString();
                DateTime fechaResolucion = FECHADERESOLUCION.Value.Date;
                int anio = int.Parse(ANIO.SelectedItem.ToString());
                string combinacion;
                ComboBoxItem selectedItem = (ComboBoxItem)ACTOTIPO.SelectedItem;
                // Evaluar el valor seleccionado del tipo de acto y establecer la combinación adecuada
                switch ((int)selectedItem.ValueMember)
                {
                    case 11112:
                        combinacion = $"11112-{numeroResolucion}-{anio}.pdf";
                        break;
                    case 0:
                        combinacion = $"DECT-{numeroResolucion}-{anio}.pdf";
                        break;
                    case 2:
                        combinacion = $"DI-{numeroResolucion}-{anio}.pdf";
                        break;
                    case 3:
                        combinacion = $"DI-{numeroResolucion}-{anio}-GDEBA.pdf";
                        break;
                    case 4:
                        combinacion = $"RESO-{numeroResolucion}-{anio}-GDEBA.pdf";
                        break;
                    case 5:
                        combinacion = $"RESO-{numeroResolucion}-{anio}-GOB-GDEBA.pdf";
                        break;
                    case 6:
                        combinacion = $"RESOL-{numeroResolucion}-{anio}-GOB-GDEBA.pdf";
                        break;
                    case 7:
                        combinacion = $"RS-20{anio}-{numeroResolucion}-GDEBA-MSALGP.pdf";
                        break;
                    default:
                        throw new ArgumentException("Valor de tipo de resolución no válido");
                }
                // Insertar la resolución
                gestionResoluciones.InsertarResolucion(dni, combinacion, tipoResolucionValueMember, fechaResolucion, combinacion);
                // Limpiar los campos después de la carga exitosa          
                NRORESOLUCION.Clear();
                FECHADERESOLUCION.Value = DateTime.Today;
                ANIO.SelectedIndex = -1;
                ACTOTIPO.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DNI_TextChanged(object sender, EventArgs e)
        {
            DNI1.Text = DNI.Text;
        }

        private void DNI1_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
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