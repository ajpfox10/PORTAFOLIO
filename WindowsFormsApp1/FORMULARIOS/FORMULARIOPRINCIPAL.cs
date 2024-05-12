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
            this.AGENTE.Items.AddRange((object[])conexionMySql.ObtenerUsuarios().ToArray<string>());
            try
            {
                 this.apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                //this.apellido1.DropDownStyle = ComboBoxStyle.DropDownList;
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
               
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    CARGADEDOMICILIO _CARGADEDOMICILIO = new CARGADEDOMICILIO(Dnis_, Agentedeatencions_);
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    CARGARFAMILIA _CARGARFAMILIA = new CARGARFAMILIA(Dnis_, Agentedeatencions_);
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    HVIDA _HVIDA = new HVIDA(Dnis_, Agentedeatencions_);
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    FORMULARIODESIGNACION _FORMULARIODESIGNACION = new FORMULARIODESIGNACION(Dnis_);
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                 Dnis_ = Convert.ToInt64(DNI.Text);
                if (AGENTE.SelectedItem != null)
                {
                    Agentedeatencions_ = Convert.ToString(AGENTE.SelectedItem.ToString());
                    BONIFICACIONES _BONIFICACIONES = new BONIFICACIONES(Dnis_);
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

            if (todosCompletos)
            {
                Dnis_ = Convert.ToInt64(DNI.Text);
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
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);
                if (todosCompletos)
                {
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);
            if (todosCompletos)
            {
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
            bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);
            if (todosCompletos)
            {
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
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

                if (todosCompletos)
                {
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
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);
                if (todosCompletos)
                {
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
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

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
        private void CPOSTULANTES_Click(object sender, EventArgs e)
        {
            // Verifica si hay un elemento seleccionado en el ComboBox "AGENTE"
            if (AGENTE.SelectedItem != null)
            {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                bool todosCompletos = VERIFICARCONTR.VerificarControles(this.Controls);

                if (todosCompletos)
                {
                    FORMULARIODECARGA _AFORMULARIODECARGA = new FORMULARIODECARGA();
                    _AFORMULARIODECARGA.ShowDialog();
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