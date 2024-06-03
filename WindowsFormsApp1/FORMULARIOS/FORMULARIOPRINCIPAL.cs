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
            InitializeComponent();
            Dnis_ = Convert.ToInt64(DNI.Text);
            Agentedeatencions_ = AGENTE.Text;
            apellido1.DropDownStyle = ComboBoxStyle.DropDown;
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_); // Corregido aquí
            apellido1.Enter += (s, ev) => ((ComboBox)s).SelectAll();
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
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private bool AreControlsComplete()
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            return VERIFICARCONTR.VerificarControles(this.Controls);
        }
        private void SetDniAndAgent()
        {
            Dnis_ = Convert.ToInt64(DNI.Text);
            Agentedeatencions_ = AGENTE.SelectedItem?.ToString();
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
            ShowDialogIfControlsComplete(() => new MESADEENTRADA(Dnis_, Agentedeatencions_));
        }
        private void CARGADAMICILIO_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new CARGADEDOMICILIO(Dnis_, Agentedeatencions_));
        }
        private void CARGARFAMILIA_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new CARGARFAMILIA(Dnis_, Agentedeatencions_));
        }
        private void BOTONCARGAFAMILIA_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new HVIDA(Dnis_, Agentedeatencions_));
        }
        private void FORMULARIODESIGNACION_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new FORMULARIODESIGNACION(Dnis_));
        }
        private void BONIFICACIONS_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new BONIFICACIONES(Dnis_));
        }
        private void CUMPLEAÑOSS_Click(object sender, EventArgs e)
        {
            using (CUMPLESS cumple = new CUMPLESS())
            {
                cumple.Show();
            }
        }
        private void GESTIONRRHH_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new Gestionrr(Dnis_, Agentedeatencions_));
        }
        private void Btnpedidos_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new PEDIDOSS(Dnis_, Agentedeatencions_));
        }
        private void BOTONBAJA_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new BAJAFORMULARIO(Dnis_, Agentedeatencions_));
        }
        private void CORREGIRERRORES_Click(object sender, EventArgs e)
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
        private void TAREASASIGNAR_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new Tareas(Agentedeatencions_));
        }
        private void ASIGNACIONTAREAS_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new ASIGNARTAREAS());
        }
        private void FOTOTARJETA_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new FOTOS());
        }
        private void CPOSTULANTES_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new FORMULARIODECARGA());
        }
        private void cargaresoluciones_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new FORMULARIOS.CARGARRESOLUCIONES(Dnis_, Agentedeatencions_));
        }

        private void CPIARDNIAGENTE_Click(object sender, EventArgs e)
        {
            if (DNI.Text!="")
            {
                // Habilitar temporalmente el TextBox
                DNI.Enabled = true;
                // Seleccionar todo el texto
                DNI.SelectAll();
                // Copiar el texto seleccionado al portapapeles
                Clipboard.SetText(DNI.SelectedText);
                // Deshabilitar el TextBox nuevamente
                DNI.Enabled = false;

                // Mostrar un MessageBox indicando que el DNI fue copiado
                MessageBox.Show("DNI copiado al portapapeles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("ERROR.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CRGTAREASVENTANILLAS_Click(object sender, EventArgs e)
        {
            ShowDialogIfControlsComplete(() => new formulariodetareasadquiridasenventanilla(Dnis_, Agentedeatencions_));
        }
    }
}
