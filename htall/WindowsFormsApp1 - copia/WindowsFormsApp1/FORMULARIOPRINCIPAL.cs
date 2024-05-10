using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class FORMULARIOPRINCIPAL : Form

    {
        public static Int64 _dnis { get; set; }
        public static string _agentedeatencions { get; set; }
        public FORMULARIOPRINCIPAL()
        {
            InitializeComponent();
            _dnis = Convert.ToInt64(DNI.Text);
            _agentedeatencions = AGENTE.Text;
            apellido1.DropDownStyle = ComboBoxStyle.DropDown;

            // Agrega el evento Enter para seleccionar todo el texto al hacer clic en el ComboBox.
            apellido1.Enter += (s, ev) => {
                ((ComboBox)s).SelectAll();
            };
        }

        private void FORMULARIOPRINCIPAL_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            var conexion = new ConexionMySQL();
            AGENTE.Items.AddRange(conexion.ObtenerUsuarios().ToArray());

            try
            {
                apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> valoresApellido = conexion.EjecutarConsulta(consulta, "APELLIDO");
                List<string> valoresDNI = conexion.EjecutarConsulta(consulta, "DNI");

                apellido1.Items.Clear();
                var diccionarioDNI = new Dictionary<string, string>();

                for (int i = 0; i < valoresApellido.Count; i++)
                {
                    diccionarioDNI[valoresDNI[i]] = valoresApellido[i];
                }

                apellido1.Items.AddRange(valoresApellido.ToArray());
                apellido1.Tag = diccionarioDNI;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private void MESAENTRADA_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    MESADEENTRADA _MESADEENTRADA = new MESADEENTRADA(this, _dnis, _agentedeatencions);
                    _dnis = Convert.ToInt64(DNI.Text);
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());
                    _MESADEENTRADA.ShowDialog();
                }
                else
                {
                    // No continúa si aún faltan controles por completar
                }
            }
            else
            {
                MessageBox.Show("Selecciona un agente antes de continuar.");
            }
        }
        private void CARGADAMICILIO_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a _dnis y _agentedeatencions
                _dnis = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto CARGADEDOMICILIO
                    CARGADEDOMICILIO _CARGADEDOMICILIO = new CARGADEDOMICILIO(this, _dnis, _agentedeatencions);

                    // Finalmente, muestra el formulario _CARGADEDOMICILIO
                    _CARGADEDOMICILIO.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
        private void CARGARFAMILIA_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a _dnis y _agentedeatencions
                _dnis = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto CARGARFAMILIA
                    CARGARFAMILIA _CARGARFAMILIA = new CARGARFAMILIA(this, _dnis, _agentedeatencions);

                    // Finalmente, muestra el formulario _CARGARFAMILIA
                    _CARGARFAMILIA.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
        private void BOTONCARGAFAMILIA_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a _dnis y _agentedeatencions
                _dnis = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto HVIDA
                    HVIDA _HVIDA = new HVIDA(this, _dnis, _agentedeatencions);

                    // Finalmente, muestra el formulario _HVIDA
                    _HVIDA.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a _dnis y _agentedeatencions
                _dnis = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto FORMULARIODESIGNACION
                    FORMULARIODESIGNACION _FORMULARIODESIGNACION = new FORMULARIODESIGNACION(this, _dnis, _agentedeatencions);

                    // Finalmente, muestra el formulario _FORMULARIODESIGNACION
                    _FORMULARIODESIGNACION.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
        private void BONIFICACIONS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a _dnis y _agentedeatencions
                _dnis = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto BONIFICACIONES
                    BONIFICACIONES _BONIFICACIONES = new BONIFICACIONES(this, _dnis, _agentedeatencions);

                    // Finalmente, muestra el formulario _BONIFICACIONES
                    _BONIFICACIONES.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
        private void CUMPLEAÑOSS_Click(object sender, EventArgs e)
        {
           CUMPLESS form2 = new CUMPLESS();
           form2.Show();
        }
        private void GESTIONRRHH_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                _dnis = Convert.ToInt64(DNI.Text);

                // Verificar si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());
                    gestionrr _gestionrr = new gestionrr(this, _dnis, _agentedeatencions);
                    _gestionrr.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
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
                DNI.Text = dni;
                _dnis = Convert.ToInt64(DNI.Text);
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
                DNI.Text = dni;
                _dnis = Convert.ToInt64(DNI.Text);
            }
        }
        private void DNI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out long dniNumber))
                {
                    _dnis = dniNumber;
                    var diccionarioDNI = apellido1.Tag as Dictionary<string, string>;

                    if (diccionarioDNI != null)
                    {
                        string dniString = dniNumber.ToString();

                        if (diccionarioDNI.ContainsKey(dniString))
                        {
                            string apellidoNombre = diccionarioDNI[dniString];
                            apellido1.SelectedItem = apellidoNombre;
                            _agentedeatencions = AGENTE.Text;
                            _dnis = Convert.ToInt64(DNI.Text);
                        }
                        else
                        {
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

        private void apellido1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ComboBox comboBox = (ComboBox)sender;
                comboBox.SelectionLength = 0;

                if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out long dniNumber))
                {
                    _dnis = dniNumber;
                    var diccionarioDNI = comboBox.Tag as Dictionary<string, string>;

                    if (diccionarioDNI != null)
                    {
                        string dniString = dniNumber.ToString();

                        if (diccionarioDNI.ContainsKey(dniString))
                        {
                            string apellidoNombre = diccionarioDNI[dniString];
                            comboBox.SelectedItem = apellidoNombre;
                            _agentedeatencions = AGENTE.Text;
                            _dnis = Convert.ToInt64(DNI.Text);
                        }
                        else
                        {
                            // Si no se encuentra coincidencia, puedes realizar alguna acción apropiada, como limpiar la selección.
                            comboBox.SelectedIndex = -1;
                            comboBox.Text = string.Empty; // Limpiar el texto del ComboBox
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
        
        private void DNI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out long dniNumber))
            {
                // El DNI es válido y se asigna a la variable _dnis.
                // Coloca aquí cualquier otro código que necesites realizar cuando el DNI cambia.
                _dnis = Convert.ToInt64(DNI.Text);
            }
                else
                {
                    // Manejar el caso en el que el DNI es nulo o no válido.
                    _dnis = 0; // O asigna un valor predeterminado o realiza alguna acción apropiada.
                }
          
        }
        private void btnpedidos_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    PEDIDOSS _PEDIDOS = new PEDIDOSS(this, _dnis, _agentedeatencions);
                    _dnis = Convert.ToInt64(DNI.Text);
                    _agentedeatencions = Convert.ToString(AGENTE.SelectedItem.ToString());
                    _PEDIDOS.ShowDialog();
                }
                else
                {
                    // No continúa si aún faltan controles por completar
                }
            }
            else
            {
                MessageBox.Show("Selecciona un agente antes de continuar.");
            }
        }

        private void BOTONBAJA_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);
            if (todosCompletos)
            {
                // Continúa con el resto del código si todos los controles se han completado correctamente
                bajaformulario _BAJAFAMILIA = new bajaformulario();  
                _BAJAFAMILIA.ShowDialog();
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            _dnis = 0;
            DNI.Text = "0";
            apellido1.Text = "";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            _dnis = 0;
            DNI.Text = "0";
            apellido1.Text = "";
        }

        private void CORREGIRERRORES_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);
            if (todosCompletos)
            {
                // Continúa con el resto del código si todos los controles se han completado correctamente
                CORREGIRERRORES _CORREGIRERRORES = new CORREGIRERRORES();
                _CORREGIRERRORES.ShowDialog();
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
        }
    }
}