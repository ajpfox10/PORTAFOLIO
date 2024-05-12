using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class BAJAFORMULARIO : Form
    {
        private long Dnis_;
        private bool claveVerificada = false;

        public BAJAFORMULARIO()
        {
            InitializeComponent();
            Dnis_ = 0; // Inicializa Dnis_ con un valor predeterminado
            DNI.Text = Dnis_.ToString(); // Asigna el valor de Dnis_ al cuadro de texto DNI
            apellido1.DropDownStyle = ComboBoxStyle.DropDown;
            ALTABAJAS.CheckedChanged += ManejarCambioCheckBox;
            ALTASBAJAS1.CheckedChanged += ManejarCambioCheckBox; // Agregamos el manejo de eventos para ALTASBAJAS1
        }

        private void DNI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out _))
            {
                // El DNI es válido y se asigna a la variable Dnis_.
                // Coloca aquí cualquier otro código que necesites realizar cuando el DNI cambia.
                Dnis_ = Convert.ToInt64(DNI.Text);
            }
            else
            {
                // Manejar el caso en el que el DNI es nulo o no válido.
                Dnis_ = 0; // O asigna un valor predeterminado o realiza alguna acción apropiada.
            }

        }

        private void DNI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Validación del DNI
            if (radioButton1.Checked)
            {
                if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out long dniNumber))
                {
                    // Validación del DNI en la base de datos
                    if (apellido1.Tag is Dictionary<string, (string Apellido, string Activo)> diccionarioDNI)
                    {
                        string dniString = dniNumber.ToString();

                        if (diccionarioDNI.ContainsKey(dniString))
                        {
                            string apellidoNombre = diccionarioDNI[dniString].Apellido;
                            string activo = diccionarioDNI[dniString].Activo;

                            apellido1.SelectedItem = apellidoNombre;

                            // Asigna el DNI al cuadro de texto "DNI"
                            DNI.Text = dniNumber.ToString();
                            Dnis_ = dniNumber;

                            // Asigna el valor al CheckBox
                            ALTASBAJAS1.Checked = activo == "-1";
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

        private void ManejarCambioCheckBox(object sender, EventArgs e)
        {
            // Verifica el estado actual del CheckBox
            if (sender == ALTABAJAS || sender == ALTASBAJAS1)
            {
                // Ejecutar el proceso cuando está tildado
                MessageBox.Show("Iniciando proceso...");

                if (!claveVerificada)
                {
                    string codigoIngresado = InputDialog.Show("Ingrese el código:", "Verificación de código");

                    if (codigoIngresado == "28305607")  // Reemplaza "TuCodigoCorrecto" con el código correcto que esperas
                    {
                        claveVerificada = true;
                    }
                    else
                    {
                        // Mostrar mensaje de error si el código no es correcto
                        MessageBox.Show("Código incorrecto. Proceso cancelado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                try
                {
                    // Crear una instancia de ConexionMySQL
                    using (ConexionMySQL conexionMySQL = new ConexionMySQL())
                    {
                        int activo = (sender == ALTABAJAS) ? 0 : -1; // Dependiendo del sender, determina el valor de activo
                        long Dnis_s = Dnis_; // Valor de Dnis_s
                        // Llamar al método ActualizarESTADOAGENTE
                        conexionMySQL.ActualizarESTADOAGENTE(activo, Dnis_s);
                        ALTABAJAS.Checked = (sender == ALTABAJAS) ? false : true;
                        ALTASBAJAS1.Checked = (sender == ALTASBAJAS1) ? true : false;
                        // Mostrar mensaje de éxito
                        MessageBox.Show($"Proceso ejecutado correctamente. Se dio de {(sender == ALTABAJAS ? "baja" : "alta")} al agente. Controle {(sender == ALTABAJAS ? "la baja" : "el alta")} del agente en SIAPE y demás.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante el proceso
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static class InputDialog
        {
            public static string Show(string prompt, string title)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();

                form.Text = title;
                label.Text = prompt;

                buttonOk.Text = "OK";
                buttonOk.DialogResult = DialogResult.OK;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor |= AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;

                DialogResult dialogResult =
                    form.ShowDialog();
                return (dialogResult == DialogResult.OK) ? textBox.Text : "";
            }
        }
        private void DARDEBAJA_Click(object sender, EventArgs e)
        {
            try
            {
                // Pedir al usuario que ingrese el código
                string codigoIngresado = InputDialog.Show("Ingrese el código:", "Verificación de código");

                // Verificar si el código ingresado es correcto
                if (codigoIngresado == "28305607")  // Reemplaza "TuCodigoCorrecto" con el código correcto que esperas
                {
                    // Crear una instancia de ConexionMySQL
                    using (ConexionMySQL conexionMySQL = new ConexionMySQL())
                    {
                        // Supongamos que tienes valores para activo y Dnis_s
                        int activo = 0; // Valor de activo (1 o 0)
                        long Dnis_s = Dnis_; // Valor de Dnis_s

                        // Llamar al método ActualizarESTADOAGENTE
                        conexionMySQL.ActualizarESTADOAGENTE(activo, Dnis_s);
                        ALTABAJAS.Checked = false;

                        // Mostrar mensaje de éxito
                        MessageBox.Show("Proceso ejecutado correctamente controle la baja del agente en SIAPE Y EN SISTEMA DE SUELDOS", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Mostrar mensaje de error si el código no es correcto
                    MessageBox.Show("Código incorrecto. Proceso cancelado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DARALTA_Click(object sender, EventArgs e)
        {
            try
            {
                // Pedir al usuario que ingrese el código
                string codigoIngresado = InputDialog.Show("Ingrese el código:", "Verificación de código");
                // Verificar si el código ingresado es correcto
                if (codigoIngresado == "28305607")  // Reemplaza "TuCodigoCorrecto" con el código correcto que esperas
                {
                    // Crear una instancia de ConexionMySQL
                    using (ConexionMySQL conexionMySQL = new ConexionMySQL())
                    {
                        // Supongamos que tienes valores para activo y Dnis_s
                        int activo = -1; // Valor de activo (1 o 0)
                        long Dnis_s = Dnis_; // Valor de Dnis_s
                                             // Llamar al método ActualizarESTADOAGENTE
                        conexionMySQL.ActualizarESTADOAGENTE1(activo, Dnis_s);
                        ALTABAJAS.Checked = true;
                        // Mostrar mensaje de éxito
                        MessageBox.Show("Proceso ejecutado correctamente se dio de ALTA al agente controle EL ALTA de SIAPE y demas", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Mostrar mensaje de error si el código no es correcto
                    MessageBox.Show("Código incorrecto. Proceso cancelado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RadioButton1_Click(object sender, EventArgs e)
        {
            DNI.Text = "";
            apellido1.Text = "";
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            DNI.Text = "";
            apellido1.Text = "";
        }

        private void Apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();

                // Realiza una consulta para obtener el DNI y el estado activo correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni, activo FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                var resultadoConsulta = conexion.EjecutarConsulta(consultaDNI);

                if (resultadoConsulta != null && resultadoConsulta.Rows.Count > 0)
                {
                    string dni = resultadoConsulta.Rows[0]["dni"].ToString();
                    int activo = Convert.ToInt32(resultadoConsulta.Rows[0]["activo"]);

                    // Asigna el DNI al cuadro de texto "DNI"
                    DNI.Text = dni;
                    Dnis_ = Convert.ToInt64(DNI.Text);

                    // Asigna el valor al CheckBox
                    ALTASBAJAS1.Checked = activo == -1;
                }
                else
                {
                    // Limpiar el DNI y desmarcar el CheckBox si no se encontró ninguna coincidencia
                    DNI.Text = string.Empty;
                    ALTABAJAS.Checked = false;
                }
            }
        }


        private void Apellido1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();

                // Realiza una consulta para obtener el DNI y el estado activo correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT personal.dni, personal.activo FROM personal WHERE `Apelldo y Nombre` = '{apellidoSeleccionado}'";

                var conexion = new ConexionMySQL();
                var resultadoConsulta = conexion.EjecutarConsulta(consultaDNI);

                if (resultadoConsulta != null && resultadoConsulta.Rows.Count > 0)
                {
                    int dni = (int)resultadoConsulta.Rows[0]["dni"];
                    int activo = (int)resultadoConsulta.Rows[0]["activo"];

                    // Asigna el DNI al cuadro de texto "DNI"
                    DNI.Text = dni.ToString();

                    // Asigna el valor al CheckBox
                    ALTASBAJAS1.Checked = activo == -1;
                }
                else
                {
                    // Limpiar el DNI y desmarcar el CheckBox si no se encontró ninguna coincidencia
                    DNI.Text = string.Empty;
                    ALTASBAJAS1.Checked = false;
                }
            }
        }



        private void Bajaformulario_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            var conexion = new ConexionMySQL();

            try
            {
                apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni, personal.activo FROM personal ORDER BY APELLIDO DESC";
                DataTable resultadoConsulta = conexion.EjecutarConsulta(consulta);

                apellido1.Items.Clear();
                var diccionarioDNI = new Dictionary<string, (string Apellido, string Activo)>();

                foreach (DataRow row in resultadoConsulta.Rows)
                {
                    string apellido = row["APELLIDO"].ToString();
                    string dni = row["dni"].ToString();
                    string activo = row["activo"].ToString();

                    diccionarioDNI[dni] = (apellido, activo);
                    apellido1.Items.Add(apellido);
                }

                apellido1.Tag = diccionarioDNI;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }


    }
}