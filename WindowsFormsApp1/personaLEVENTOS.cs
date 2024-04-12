using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace WindowsFormsApp1.MODULOS
{
    public class PersonaLEVENTOS
    {
        public ComboBox apellido1;
        public TextBox DNI;
        public RadioButton PORDNI;
        public RadioButton PORAPELLIDO;
        public string AGENTE;
        public long Dnis_;
        public string Agentedeatencions_;
        public bool DNISelectionChecked = false;

        public string Agente { get; set; }

        public PersonaLEVENTOS(
          ComboBox apellido1,
          TextBox DNI,
          RadioButton PORDNI,
          RadioButton PORAPELLIDO,
          string AGENTE,
          long Dnis_)
        {
            this.apellido1 = apellido1;
            this.DNI = DNI;
            this.PORDNI = PORDNI;
            this.PORAPELLIDO = PORAPELLIDO;
            this.AGENTE = AGENTE;
            this.Dnis_ = Convert.ToInt64(DNI.Text);
            apellido1.SelectedIndexChanged += new EventHandler(this.Apellido1_SelectedIndexChanged);
            apellido1.SelectedValueChanged += new EventHandler(this.Apellido1_SelectedValueChanged);
            DNI.Validating += new CancelEventHandler(this.DNI_Validating);
            apellido1.TextChanged += new EventHandler(this.Apellido1_TextChanged);
            DNI.TextChanged += new EventHandler(this.DNI_TextChanged);
            PORDNI.Click += new EventHandler(this.PORDNI_Click);
        }

        public void PORDNI_Click(object sender, EventArgs e)
        {
            if (this.PORDNI.Checked)
            {
                this.DNISelectionChecked = true;
                this.Dnis_ = 0L;
                this.DNI.Text = "0";
                this.apellido1.Text = "";
            }
            else
                this.DNISelectionChecked = false;
        }

        public void ProcesarEntradaUsuario()
        {
            string text = this.DNI.Text;
            if (!this.DNISelectionChecked)
                return;
            long result;
            if (long.TryParse(text, out result))
            {
                this.Dnis_ = result;
                this.BuscarApellidoPorDNI();
            }
            else
                this.LimpiarCampos();
        }

        public void DNI_Validating(object sender, CancelEventArgs e)
        {
            if (this.PORDNI.Checked)
            {
                long result;
                if (!string.IsNullOrWhiteSpace(this.DNI.Text) && long.TryParse(this.DNI.Text, out result))
                {
                    this.Dnis_ = result;
                    if (!(this.apellido1.Tag is Dictionary<string, string> tag))
                        return;
                    string key = result.ToString();
                    if (tag.ContainsKey(key))
                    {
                        this.apellido1.SelectedItem = (object)tag[key];
                        this.Agentedeatencions_ = this.AGENTE;
                        this.Dnis_ = Convert.ToInt64(this.DNI.Text);
                    }
                    else
                    {
                        this.apellido1.SelectedIndex = -1;
                        int num = (int)MessageBox.Show("No se encontró un APELLIDO Y NOMBRE correspondiente al DNI ingresado.");
                    }
                }
                else
                {
                    int num1 = (int)MessageBox.Show("El campo DNI no es válido. Debe ingresar un número válido.");
                }
            }
            else
            {
                int num2 = (int)MessageBox.Show("Debe seleccionar 'Buscar por DNI' para realizar esta acción.");
            }
        }

        public void ActualizarDNI(long nuevoDNI) => this.Dnis_ = nuevoDNI;

        public void Apellido1_TextChanged(object sender, EventArgs e)
        {
            if (!this.PORAPELLIDO.Checked)
                return;
            ComboBox comboBox = (ComboBox)sender;
            comboBox.SelectionLength = 0;
            if (comboBox.Tag is Dictionary<string, string>)
            {
                string str = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + comboBox.Text + "'", "dni").FirstOrDefault<string>();
                if (!string.IsNullOrEmpty(str))
                {
                    this.DNI.Text = str;
                    this.Dnis_ = Convert.ToInt64(this.DNI.Text);
                    this.Agentedeatencions_ = this.AGENTE;
                }
                else
                {
                    this.DNI.Text = "0";
                    this.Dnis_ = 0L;
                    int num = (int)MessageBox.Show("No se encontró un DNI correspondiente al apellido ingresado.");
                }
            }
        }

        public void DNI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DNI.Text) && long.TryParse(this.DNI.Text, out long _))
                this.Dnis_ = Convert.ToInt64(this.DNI.Text);
            else
                this.Dnis_ = 0L;
        }

        public void BuscarApellidoPorDNI()
        {
            string str = new ConexionMySQL().EjecutarConsulta(string.Format("SELECT personal.`APELLDO Y NOMBRE` as 'apellido' FROM personal WHERE dni = '{0}'", (object)this.Dnis_), "apellido").FirstOrDefault<string>();
            if (!string.IsNullOrEmpty(str))
                this.apellido1.Text = str;
            else
                this.apellido1.Text = "";
        }

        public void MostrarError(string mensaje)
        {
            int num = (int)MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public void ProcesarSeleccionApellido()
        {
            if (!this.PORDNI.Checked && !this.PORAPELLIDO.Checked)
            {
                this.MostrarError("Debes primero elegir cómo buscar, ya sea por DNI o por apellido, antes de completar el campo.");
                this.LimpiarCampos();
            }
            else if (this.apellido1.SelectedItem != null)
            {
                if (!this.PORAPELLIDO.Checked)
                    return;
                this.DNI.Text = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + this.apellido1.SelectedItem.ToString() + "'", "dni").FirstOrDefault<string>();
                this.Dnis_ = Convert.ToInt64(this.DNI.Text);
            }
            else
                this.MostrarError("Debe seleccionar un apellido");
        }

        public void LimpiarCampos()
        {
            this.DNI.Text = "0";
            this.Dnis_ = 0L;
            this.apellido1.Text = "";
        }

        public void Apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PORAPELLIDO.Checked)
            {
                if (this.apellido1.SelectedItem == null)
                    return;
                this.DNI.Text = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + this.apellido1.SelectedItem.ToString() + "'", "dni").FirstOrDefault<string>();
            }
            else
            {
                if (this.PORDNI.Checked)
                    return;
                int num = (int)MessageBox.Show("Debe seleccionar 'Buscar por Apellido' para realizar esta acción.");
            }
        }

        public void Apellido1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.PORAPELLIDO.Checked)
            {
                if (this.apellido1.SelectedItem == null)
                    return;
                this.DNI.Text = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + this.apellido1.SelectedItem.ToString() + "'", "dni").FirstOrDefault<string>();
            }
            else
            {
                if (this.PORDNI.Checked)
                    return;
                int num = (int)MessageBox.Show("Debe seleccionar 'Buscar por Apellido' para realizar esta acción.");
            }
        }





    }
}
