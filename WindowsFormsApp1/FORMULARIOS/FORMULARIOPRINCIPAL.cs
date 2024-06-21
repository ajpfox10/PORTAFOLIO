using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class FORMULARIOPRINCIPAL : Form
    {
        private PersonaLEVENTOS personaLEVENTOS;
        public static Int64 Dnis_ { get; set; }
        public static string Agentedeatencions_ { get; set; }

        public FORMULARIOPRINCIPAL()
        {
            try
            {
                InitializeComponent();
                if (string.IsNullOrEmpty(DNI.Text) || !long.TryParse(DNI.Text, out long dni))
                {
                    throw new InvalidOperationException("El DNI es inválido.");
                }
                Dnis_ = dni;
                Agentedeatencions_ = AGENTE.Text ?? throw new InvalidOperationException("El agente de atención es inválido.");

                apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                personaLEVENTOS = new PersonaLEVENTOS(apellido1, DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
                apellido1.Enter += (s, ev) => ((ComboBox)s).SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el constructor: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FORMULARIOPRINCIPAL_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            ConexionMySQL conexionMySql = new ConexionMySQL();
            AGENTE.Items.AddRange(conexionMySql.ObtenerUsuarios().ToArray());

            try
            {
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> apellidos = conexionMySql.EjecutarConsulta(consulta, "APELLIDO");
                List<string> dnis = conexionMySql.EjecutarConsulta(consulta, "DNI");

                apellido1.Items.Clear();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int i = 0; i < apellidos.Count; ++i)
                {
                    dictionary[dnis[i]] = apellidos[i];
                }
                apellido1.Items.AddRange(apellidos.ToArray());
                apellido1.Tag = dictionary;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los valores en el ComboBox: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreControlsComplete()
        {
            try
            {
                return VERIFICARCONTR.VerificarControles(this.Controls);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar los controles: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SetDniAndAgent()
        {
            try
            {
                Dnis_ = Convert.ToInt64(DNI.Text);

                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = AGENTE.SelectedItem.ToString();
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningún agente de atención. La aplicación se cerrará.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al establecer DNI y Agente: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDialogIfControlsComplete<T>(Func<T> formFactory) where T : Form
        {
            if (AreControlsComplete())
            {
                SetDniAndAgent();
                if (AGENTE.SelectedItem != null)
                {
                    using (T form = formFactory())
                    {
                        form.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }
        }

        private void MESAENTRADA_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new MESADEENTRADA(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en MESAENTRADA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CARGADAMICILIO_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new CARGADEDOMICILIO(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CARGADAMICILIO_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CARGARFAMILIA_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new CARGARFAMILIA(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CARGARFAMILIA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BOTONCARGAFAMILIA_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new HVIDA(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en BOTONCARGAFAMILIA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FORMULARIODESIGNACION_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new FORMULARIODESIGNACION(Dnis_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en FORMULARIODESIGNACION_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BONIFICACIONS_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new BONIFICACIONES(Dnis_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en BONIFICACIONS_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CUMPLEAÑOSS_Click(object sender, EventArgs e)
        {       
                try
                {
                    CUMPLEAÑOSSSS cumple = new CUMPLEAÑOSSSS();
                    cumple.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en CUMPLEAÑOSS_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void GESTIONRRHH_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new Gestionrr(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en GESTIONRRHH_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnpedidos_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new PEDIDOSS(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Btnpedidos_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BOTONBAJA_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new BAJAFORMULARIO(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en BOTONBAJA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CORREGIRERRORES_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoIngresado = BAJAFORMULARIO.InputDialog.Show("Ingrese el código:", "Verificación de código");

                if (codigoIngresado == "28305607")
                {
                    ShowDialogIfControlsComplete(() => new CORREGIRERRORES());
                }
                else
                {
                    MessageBox.Show("Código incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CORREGIRERRORES_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TAREASASIGNAR_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new Tareas(Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en TAREASASIGNAR_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ASIGNACIONTAREAS_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new ASIGNARTAREAS());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en ASIGNACIONTAREAS_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FOTOTARJETA_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new FOTOS());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en FOTOTARJETA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CPOSTULANTES_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new FORMULARIODECARGA());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CPOSTULANTES_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaresoluciones_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new FORMULARIOS.CARGARRESOLUCIONES(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en cargaresoluciones_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CPIARDNIAGENTE_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(DNI.Text))
                {
                    DNI.Enabled = true;
                    DNI.SelectAll();
                    Clipboard.SetText(DNI.SelectedText);
                    DNI.Enabled = false;
                    MessageBox.Show("DNI copiado al portapapeles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CPIARDNIAGENTE_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CRGTAREASVENTANILLAS_Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new formulariodetareasadquiridasenventanilla(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CRGTAREASVENTANILLAS_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void INCONVENIENTES__Click(object sender, EventArgs e)
        {
            try
            {
                ShowDialogIfControlsComplete(() => new Sistemasdenovedadesagente(Dnis_, Agentedeatencions_));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en INCONVENIENTES__Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stras_Click(object sender, EventArgs e)
        {
            try
            {
                stass ESTAD = new stass();
                ESTAD.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CUMPLEAÑOSS_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
