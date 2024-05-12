using DocumentFormat.OpenXml.Office.Word;
using EjemploComboBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class FORMULARIODECARGA : Form
    {
        private CargarComboBoxes cargadorComboBoxes;
        private List<ListViewItem> itemsOriginales = new List<ListViewItem>();
        private Sexo gestionSexoYEstado;
        public FORMULARIODECARGA()
        {
            InitializeComponent();
            // Inicializar el objeto CargarComboBoxes
            CargarComboBoxes cargador = new CargarComboBoxes(PCIA, LOCALIDAD);            // Suscribirte al evento Load del formulario
            this.Load += FORMULARIODECARGA_Load;
            gestionSexoYEstado = new Sexo(SEXO, ESTADO);
            SUCURSALESDOS.MouseDoubleClick += SUCURSALESDOS_MouseDoubleClick;

        }
        private void CARGARCONTROLES_Click(object sender, EventArgs e)
        {
            // Llamar al método para verificar controles obligatorios, pasando el nombre del control que no se verificará
            var controlesIncompletos = VERIFICARCONTR.VerificarControlesObligatorios(this, "textBox1");
            if (controlesIncompletos.Count == 0)
            {
                // Verificar controles obligatorios
                if (controlesIncompletos.Count == 0)
                {
                    // Todos los controles obligatorios están completos, mostrar un MessageBox con opción de aceptar o cancelar
                    DialogResult result = MessageBox.Show("¿Estás seguro de continuar?", "Confirmar", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        // Si el usuario hace clic en "Aceptar", realizar la acción X
                        ////   Dnis_ = Convert.ToInt64(DNI.Text);
                        MessageBox.Show("Todos los controles obligatorios están completos");
                        //  _MESADEENTRADA.ShowDialog();
                    }
                    else
                    {
                        // Si el usuario hace clic en "Cancelar", no hacer nada
                    }
                }
                else
                {
                    // Mostrar los controles que no están completos
                    string mensaje = "Los siguientes controles obligatorios no están completos:\n";
                    foreach (var control in controlesIncompletos)
                    {
                        mensaje += control + "\n";
                    }
                    MessageBox.Show(mensaje);
                }

            }
            else
            {
                // Mostrar los controles que no están completos
                string mensaje = "Los siguientes controles obligatorios no están completos:\n";
                foreach (var control in controlesIncompletos)
                {
                    mensaje += control + "\n";
                }
                MessageBox.Show(mensaje);
            }
        }
        private void FORMULARIODECARGA_Load(object sender, EventArgs e)
        {
            CargarComboBoxes cargador = new CargarComboBoxes(PCIA, LOCALIDAD);            // Para manejar el evento de cambio de provincia y cargar los municipios correspondientes en otro ComboBox
            PCIA.SelectedIndexChanged += (senderPCIA, args) =>
            {
                cargador.ManejarCambioProvincia(senderPCIA, args, PARTIDO);
            };
            // Para manejar el evento de cambio de partido y cargar las localidades correspondientes en otro ComboBox
            PARTIDO.SelectedIndexChanged += (senderPARTIDO, args) =>
            {
                cargador.ManejarCambioPartido(senderPARTIDO, args, LOCALIDAD);
            };
            // Para cargar las provincias en un ComboBox
            cargador.CargarProvinciasEnComboBox(PCIA);
            cargador.CargarRegimenHorario(REGIMENHORARIO);
            cargador.Leyr(LEY);
            cargador.CargarSector(SECTOR);
            cargador.CargarEspecialidadesMedicas(ESPECIALIDAD);
            // Para manejar el evento de cambio de provincia y cargar los municipios correspondientes en otro ComboBox
            PCIA.SelectedIndexChanged += (senderPCIA, args) =>
            {
                cargador.ManejarCambioProvincia(senderPCIA, args, PARTIDO);
            };
            // Para manejar el evento de cambio de partido y cargar las localidades correspondientes en otro ComboBox
            PARTIDO.SelectedIndexChanged += (senderPARTIDO, args) =>
            {
                cargador.ManejarCambioPartido(senderPARTIDO, args, LOCALIDAD);
            };
            // Para manejar el evento de cambio de ley y cargar las ocupaciones correspondientes en otro ComboBox
            LEY.SelectedIndexChanged += (senderLey, args) =>
            {
                cargador.ManejarLeya(senderLey, args, OCUPACION);
            };
            // Cargar datos en el ListView
            CargarDatosListView();
            // Cerrar la conexión al finalizar
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "(SELECT sucursales.Id, sucursales.SUCURSAL, sucursales.DOMICILIO, sucursales.LOCALIDAD, sucursales.PARTIDO, sucursales.NUMERO FROM sucursales)";
            conexion.CargarResultadosConsulta(consulta, SUCURSALESDOS);
            SUCURSALESDOS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SUCURSALESDOS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            int ultimaColumnaIndex = SUCURSALESDOS.Columns.Count - 1;
            SUCURSALESDOS.Columns[ultimaColumnaIndex].Width += 35; // Ajusta el número para aumentar el ancho de la última columna según lo necesites
            CargarDatosListView();
        }
        private void SUCURSALESDOS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SUCURSALESDOS.SelectedItems.Count > 0)
            {
                // Obtener el texto de la columna de sucursal para el elemento seleccionado
                string sucursalSeleccionada = SUCURSALESDOS.SelectedItems[0].SubItems[5].Text;

                // Asignar el valor de la sucursal seleccionada al TextBox correspondiente
                sucursalelejida.Text = sucursalSeleccionada;
            }
        }
        private void CargarDatosListView()
        {
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "(SELECT sucursales.Id, sucursales.SUCURSAL, sucursales.DOMICILIO, sucursales.LOCALIDAD, sucursales.PARTIDO, sucursales.NUMERO FROM sucursales ORDER BY sucursales.NUMERO DESC)";
            conexion.CargarResultadosConsulta(consulta, SUCURSALESDOS);
            SUCURSALESDOS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            SUCURSALESDOS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            int ultimaColumnaIndex = SUCURSALESDOS.Columns.Count - 1;
            SUCURSALESDOS.Columns[ultimaColumnaIndex].Width += 35;

            // Guardamos los elementos originales en la lista
            itemsOriginales.AddRange(SUCURSALESDOS.Items.Cast<ListViewItem>());
        }
        private void FiltrarListView()
        {
            string filtroSucursal = txtFiltroSucursal.Text.Trim().ToLower();
            string filtroLocalidad = txtFiltroLocalidad.Text.Trim().ToLower();
            string filtroPartido = txtFiltroPartido.Text.Trim().ToLower();

            SUCURSALESDOS.Items.Clear();

            foreach (ListViewItem item in itemsOriginales)
            {
                string sucursal = item.SubItems[1].Text.ToLower();
                string localidad = item.SubItems[3].Text.ToLower();
                string partido = item.SubItems[4].Text.ToLower();

                if ((string.IsNullOrEmpty(filtroSucursal) || sucursal.Contains(filtroSucursal)) &&
                    (string.IsNullOrEmpty(filtroLocalidad) || localidad.Contains(filtroLocalidad)) &&
                    (string.IsNullOrEmpty(filtroPartido) || partido.Contains(filtroPartido)))
                {
                    SUCURSALESDOS.Items.Add(item);
                }
            }
        }
        private void txtFiltroSucursal_TextChanged(object sender, EventArgs e)
        {
            FiltrarListView();
        }
        private void txtFiltroLocalidad_TextChanged(object sender, EventArgs e)
        {
            FiltrarListView();
        }
        private void txtFiltroPartido_TextChanged(object sender, EventArgs e)
        {
            FiltrarListView();
        }
        private void LimpiarFiltros()
        {
            txtFiltroSucursal.Text = "";
            txtFiltroLocalidad.Text = "";
            txtFiltroPartido.Text = "";
            FiltrarListView();
        }
        private void txtFiltroSucursal_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltroSucursal.Text))
            {
                LimpiarFiltros();
            }
        }
        private void txtFiltroLocalidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltroLocalidad.Text))
            {
                LimpiarFiltros();
            }
        }
        private void txtFiltroPartido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFiltroPartido.Text))
            {
                LimpiarFiltros();
            }
        }
        private void ESTUDIOSUNIVERSITARIOS_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool primarioMarcado = ESTUDIOSUNIVERSITARIOS.CheckedItems.Contains("ESTUDIO PRIMARIO");
            bool secundarioMarcado = ESTUDIOSUNIVERSITARIOS.CheckedItems.Contains("ESTUDIO SECUNDARIO");

            // Si solo se ha marcado la opción "Primario" y no "Secundario"
            if (e.Index == ESTUDIOSUNIVERSITARIOS.Items.IndexOf("ESTUDIO PRIMARIO"))
            {
                MATRICULA.Text = "--------";
                ESCUELASECUNDARIA.Text = "--------";
                EGRESOSECUNDARIA.Text= "--------";
                ESCUELATERCIARIA.Text="--------";
                EGRESOTERCIARIA.Text= "--------";
                ESCUELAUNIVERSITARIA.Text= "--------";
                EGRESOUNIVERSITARIA.Text= "--------";
            }
            // Si solo se ha marcado la opción "Secundario" y no "Primario"
            else if (e.Index == ESTUDIOSUNIVERSITARIOS.Items.IndexOf("ESTUDIO SECUNDARIO"))
            {
                MATRICULA.Text = "--------";
                ESTUDIOPRRIMARIOS.Text = "--------";
                EGRESOPRIMARIA.Text = "--------";
            }
            // Si se han marcado ambas opciones "Primario" y "Secundario"
            else if (primarioMarcado && secundarioMarcado)
            {
                MATRICULA.Text = "--------";
            }
            // Si no se han marcado ninguna opción, dejar el cuadro de texto de la matrícula vacío
            else
            {
                MATRICULA.Text = "";
            }
        }
        private void SEXO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el sexo seleccionado del ComboBox
                string sexo = SEXO.SelectedItem.ToString();
                CuilCuitGenerator generador = new CuilCuitGenerator(SEXO.Text);
                string cuil_cuit = generador.GetCuilCuit(DNI.Text);
                CUILS.Text = cuil_cuit;

                // Imprimir el CUIL calculado en la consola
                Console.WriteLine("El CUIL calculado es: " + cuil_cuit);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el cálculo del CUIL
                Console.WriteLine("Error al calcular el CUIL: " + ex.Message);
            }
        }
        private void CARGARCONTROLES_Click_1(object sender, EventArgs e)
        {
            ConexionMySQL gestor = new ConexionMySQL();
            string nombreCompleto = $"{APEELIDOS.Text}, {NOMBRES.Text}";
            string fechaFormateada = FECHADENACIMIENTO.Value.ToString("dd/MM/yyyy");
            // Convertir la fecha formateada a un objeto DateTime
            DateTime fecha = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            MessageBox.Show("Fecha formateada: " + fechaFormateada);
            //    gestor.InsertarAgente(nombreCompleto, DNI.Text, (DATE_FORMAT('" + fechaFormateada + "', '%d/%m/%Y')), CANTIDADEHIJOS.Text, DIRECCIONES.Text, LOCALIDAD.SelectedValue?.ToString() ?? "1111111111", PARTIDO.SelectedValue?.ToString() ?? "1111111111", TELEFONOS.Text, OBSERVACIONES.Text, ESTADO.SelectedValue?.ToString() ?? "ValorPorDefecto", OCUPACION.SelectedValue?.ToString() ?? "1111111111", LEY.SelectedValue?.ToString() ?? "22222222", SEXO.SelectedValue?.ToString() ?? "ValorPorDefecto", REGIMENHORARIO.Text, MATRICULA.Text, CUIL.Text, NUMERO.Text, DEPTO.Text, PISO.Text, CP.Text, NACIONALIDAD.Text, ESTADOCIVIL.Text, PCIA.SelectedValue?.ToString() ?? "ValorPorDefecto", sucursalelejida.Text, EMAIL.Text, ESPECIALIDAD.SelectedValue?.ToString() ?? "ValorPorDefecto", DISCIPLINA.SelectedValue?.ToString() ?? "ValorPorDefecto", REGIMENHORARIO.Text, DEPENDENCIA.Text);
          gestor.InsertarAgente(
          nombreCompleto,
          DNI.Text,
          fecha, // Aquí pasamos el objeto DateTime directamente
          CANTIDADEHIJOS.Text,
          DIRECCIONES.Text,
          LOCALIDAD.SelectedValue?.ToString() ?? "1111111111",
          PARTIDO.SelectedValue?.ToString() ?? "1111111111",
          TELEFONOS.Text,
          OBSERVACIONES.Text,
          ESTADO.SelectedValue?.ToString() ?? "ValorPorDefecto",
          OCUPACION.SelectedValue?.ToString() ?? "1111111111",
          LEY.SelectedValue?.ToString() ?? "22222222",
          SEXO.SelectedValue?.ToString() ?? "ValorPorDefecto",
          REGIMENHORARIO.Text,
          MATRICULA.Text,
          CUIL.Text,
          NUMERO.Text,
          DEPTO.Text,
          PISO.Text,
          CP.Text,
          NACIONALIDAD.Text,
          ESTADOCIVIL.Text,
          PCIA.SelectedValue?.ToString() ?? "ValorPorDefecto",
          sucursalelejida.Text,
          EMAIL.Text,
          ESPECIALIDAD.SelectedValue?.ToString() ?? "ValorPorDefecto",
          DISCIPLINA.SelectedValue?.ToString() ?? "ValorPorDefecto",
          REGIMENHORARIO.Text,
          DEPENDENCIA.Text
         );
          gestor.InsertarEDUCACION(
          ESTUDIOPRRIMARIOS.Text,
          int.TryParse(EGRESOPRIMARIA.Text, out int egresoPrimaria) ? egresoPrimaria : 0,
          ESCUELASECUNDARIA.Text,
          int.TryParse(EGRESOSECUNDARIA.Text, out int egresosecundaria) ? egresosecundaria : 0,
          ESCUELATERCIARIA.Text,
          int.TryParse(EGRESOTERCIARIA.Text, out int egresoterciaria) ? egresoterciaria : 0,
          ESCUELAUNIVERSITARIA.Text,
          int.TryParse(EGRESOUNIVERSITARIA.Text, out int egresouniversitaria) ? egresouniversitaria : 0,
          int.TryParse(DNI.Text, out int DNISS) ? DNISS : 0

          );

        }
    }
}