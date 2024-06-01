using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1.FORMULARIOS
{
    public partial class CARGARRESOLUCIONES : Form
    {
        private ComparadorArchivos comparador;
        public string resolucion;
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly ConexionMySQL conexionMySQL = new ConexionMySQL();
        string carpetaArchivos = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\";
         MODULOS.PersonaLEVENTOS personaLEVENTOS;



        public CARGARRESOLUCIONES(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
            apellido1.Enter += Apellido1_Enter;

        }



        private void resolucionesd_MouseDoubleClick(object sender, MouseEventArgs e)
        {

                ListViewItem item = resolucionesd.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    string nombreArchivo = item.SubItems[1].Text;
                    string rutaCompleta = Path.Combine(carpetaArchivos, nombreArchivo);

                    try
                    {
                        if (File.Exists(rutaCompleta))
                        {
                            // Cargar el archivo en el WebBrowser
                            VISORRESO.Url = new Uri(rutaCompleta);


                            // Copiar el nombre del archivo al TextBox
                            RESOTRABAJAR.Text = nombreArchivo;
                        }
                        else
                        {
                            MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ListViewItem filaSeleccionada1 = item;
                        filaSeleccionada1.ForeColor = Color.Yellow;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
        }

        private void Apellido1_Enter(object sender, EventArgs e)
        {
            ((System.Windows.Forms.ComboBox)sender).SelectAll();
        }

        private void DNI_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
                {
                    Dnis_ = nuevoDnisValor;
                    DNI.BackColor = System.Drawing.Color.Yellow; // Cambia el color de fondo a amarillo
                    Console.WriteLine("Color de fondo cambiado a amarillo.");
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es válido. Debe ser un número de DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CARGARESO_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los controles estén llenos y pintar el fondo de amarillo si es necesario
                if (string.IsNullOrEmpty(DNI.Text))
                {
                    DNI.BackColor = Color.Yellow; // Pintar de amarillo si el campo está vacío
                    Console.WriteLine("DNI no puede estar vacío.");
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    DNI.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                if (FECHADERESOLUCION.Value == DateTime.MinValue)
                {
                    FECHADERESOLUCION.BackColor = Color.Yellow; // Pintar de amarillo si la fecha no está seleccionada
                    Console.WriteLine("Fecha de resolución no seleccionada.");
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    FECHADERESOLUCION.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                if (string.IsNullOrEmpty(RESOTRABAJAR.Text))
                {
                    RESOTRABAJAR.BackColor = Color.Yellow; // Pintar de amarillo si el campo está vacío
                    Console.WriteLine("El campo de resolución a trabajar está vacío.");
                    return; // Salir del método sin ejecutar el procedimiento
                }
                else
                {
                    RESOTRABAJAR.BackColor = SystemColors.Window; // Restaurar el color de fondo
                }

                // Si todos los controles están llenos, ejecutar el procedimiento
                GestionResoluciones gestionResoluciones = new GestionResoluciones();
                int dni = int.Parse(DNI.Text);
                string tipoResolucionValueMember = TIPORESOLUCION.SelectedValue.ToString();
                DateTime fechaResolucion = FECHADERESOLUCION.Value.Date;
                string resolucion = RESOTRABAJAR.Text;
                gestionResoluciones.InsertarResolucion(dni, resolucion, tipoResolucionValueMember, fechaResolucion, resolucion);
                resolucionesd.Items.Clear();

                // Vaciar los TextBox después de ejecutar el procedimiento
                DNI.Clear();
                FECHADERESOLUCION.Value = DateTime.Today; // Establecer la fecha actual
                RESOTRABAJAR.Clear();
                comparador = new ComparadorArchivos(carpetaArchivos, resolucionesd, CANTIDADS);
                comparador.ListarArchivosYComparar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CARGARRESOLUCIONES_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("CARGARRESOLUCIONES_Load iniciado.");
                comparador = new ComparadorArchivos(carpetaArchivos, resolucionesd, CANTIDADS);
                comparador.ListarArchivosYComparar();
                Console.WriteLine("Comparación completada correctamente.");
                string consultaTIPORESO = @"SELECT tipoderesolucion.resolucion, tipoderesolucion.id FROM tipoderesolucion";
                conexionMySQL.LlenarComboBox(consultaTIPORESO, TIPORESOLUCION, "resolucion", "id");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la carga del formulario: " + ex.Message);
                MessageBox.Show("Error durante la carga del formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            // Llamar al método que carga los datos en el TextBox
            CargarDatosEnTextBox();
        }






        private void CargarDatosEnTextBox()
        {
          

            // Cambiar el color del texto del elemento correspondiente en el ListView
            foreach (ListViewItem item in resolucionesd.Items)
            {
                if (item.SubItems[0].Text == RESOTRABAJAR.Text)
                {
                    item.ForeColor = Color.Blue;
                    break; // Detener la búsqueda una vez que se encuentra el elemento
                }
            }
        }



    }
}