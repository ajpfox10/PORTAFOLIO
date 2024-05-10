using System.Windows.Forms;
using System.Drawing;
using System;

namespace WindowsFormsApp1
{
    public class VERIFICARCONTR
    {
        public bool VerificarControles(Control.ControlCollection controls)
        {
            bool todosCompletos = true;

            foreach (Control control in controls)
            {
                // Verificar si el control es un RadioButton
                if (control is RadioButton)
                {
                    continue; // Saltar la verificación de RadioButton
                }

                // Verificar otros controles (TextBox, ComboBox, etc.)
                switch (control)
                {
                    case TextBox textBox:
                        if (string.IsNullOrEmpty(textBox.Text))
                        {
                            textBox.BackColor = Color.LightBlue;
                            MessageBox.Show($"Falta completar {textBox.Name}");
                            todosCompletos = false;
                        }
                        else
                        {
                            textBox.BackColor = Color.White;
                        }
                        break;
                    // Agrega más casos para otros tipos de controles que necesites verificar
                    default:
                        // Si el control no es de ningún tipo conocido, se ignora
                        break;
                }

                if (!todosCompletos)
                {
                    break;
                }
            }
            return todosCompletos;
        }
    }

}
