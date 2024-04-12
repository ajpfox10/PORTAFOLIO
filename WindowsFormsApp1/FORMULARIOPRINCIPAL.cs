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
            this.InitializeComponent();
            FORMULARIOPRINCIPAL.Dnis_ = Convert.ToInt64(this.DNI.Text);
            FORMULARIOPRINCIPAL.Agentedeatencions_ = this.AGENTE.Text;
            this.apellido1.DropDownStyle = ComboBoxStyle.DropDown;
            this.personaLEVENTOS = new PersonaLEVENTOS(this.apellido1, this.DNI, this.PORDNI, this.PORAPELLIDO, this.AGENTE.ToString(), FORMULARIOPRINCIPAL.Dnis_);
            this.apellido1.Enter += (EventHandler)((s, ev) => ((ComboBox)s).SelectAll());
        }
        private void FORMULARIOPRINCIPAL_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            ConexionMySQL conexionMySql = new ConexionMySQL();
            this.AGENTE.Items.AddRange((object[])conexionMySql.ObtenerUsuarios().ToArray<string>());
            try
            {
                this.apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> stringList1 = conexionMySql.EjecutarConsulta(consulta, "APELLIDO");
                List<string> stringList2 = conexionMySql.EjecutarConsulta(consulta, "DNI");
                this.apellido1.Items.Clear();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                for (int index = 0; index < stringList1.Count; ++index)
                    dictionary[stringList2[index]] = stringList1[index];
                this.apellido1.Items.AddRange((object[])stringList1.ToArray());
                this.apellido1.Tag = (object)dictionary;
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
                    MESADEENTRADA _MESADEENTRADA = new MESADEENTRADA(Dnis_, Agentedeatencions_);
                    Dnis_ = Convert.ToInt64(DNI.Text);
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
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

                // Primero, asigna los valores a Dnis_ y Agentedeatencions_
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto CARGADEDOMICILIO
                    CARGADEDOMICILIO _CARGADEDOMICILIO = new CARGADEDOMICILIO(Dnis_, Agentedeatencions_);

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

                // Primero, asigna los valores a Dnis_ y Agentedeatencions_
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto CARGARFAMILIA
                    CARGARFAMILIA _CARGARFAMILIA = new CARGARFAMILIA(Dnis_, Agentedeatencions_);

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

                // Primero, asigna los valores a Dnis_ y Agentedeatencions_
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto HVIDA
                    HVIDA _HVIDA = new HVIDA(Dnis_, Agentedeatencions_);

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
        private void FORMULARIODESIGNACION_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                // Solo continúa si todos los controles se han completado correctamente

                // Primero, asigna los valores a Dnis_ y Agentedeatencions_
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto FORMULARIODESIGNACION
                    FORMULARIODESIGNACION _FORMULARIODESIGNACION = new FORMULARIODESIGNACION(Dnis_);

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

                // Primero, asigna los valores a Dnis_ y Agentedeatencions_
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verifica si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());

                    // Luego, instanciar el objeto BONIFICACIONES
                    BONIFICACIONES _BONIFICACIONES = new BONIFICACIONES(Dnis_);

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
           CUMPLESS CUMPLE = new CUMPLESS();
           CUMPLE.Show();
        }
        private void GESTIONRRHH_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            bool todosCompletos = verificador.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);

                // Verificar si AGENTE.SelectedItem es null antes de convertirlo
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    Gestionrr _gestionrr = new Gestionrr(Dnis_, Agentedeatencions_);
                    _gestionrr.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un agente de atención.");
                }
            }

        }
        private void Btnpedidos_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    PEDIDOSS _PEDIDOS = new PEDIDOSS(Dnis_, Agentedeatencions_);
                    Dnis_ = Convert.ToInt64(DNI.Text);
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
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
                BAJAFORMULARIO _BAJAFAMILIA = new BAJAFORMULARIO();  
                _BAJAFAMILIA.ShowDialog();
            }
            else
            {
                // No continúa si aún faltan controles por completar
            }
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
        private void TAREASASIGNAR_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    Tareas _Tareas = new Tareas(Agentedeatencions_);
                    Dnis_ = Convert.ToInt64(DNI.Text);
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    _Tareas.ShowDialog();
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
        private void ASIGNACIONTAREAS_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    ASIGNARTAREAS _ASIGNARTAREAS = new ASIGNARTAREAS();
                    _ASIGNARTAREAS.ShowDialog();
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
        private void FOTOTARJETA_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = verificador.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    // Continúa con el resto del código si todos los controles se han completado correctamente
                    FOTOS _AFOTOS = new FOTOS();
                    _AFOTOS.ShowDialog();
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
    }
}