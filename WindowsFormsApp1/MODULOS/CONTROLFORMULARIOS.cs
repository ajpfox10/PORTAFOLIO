using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class VERIFICARCONTR
    {
        public static void AnalyzeControls(Form form)
        {
            // Obtener todos los campos (controles) del formulario
            FieldInfo[] fields = form.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                // Verificar si el campo es de tipo Control
                if (typeof(Control).IsAssignableFrom(field.FieldType))
                {
                    Console.WriteLine("Control encontrado: " + field.Name);
                    // Aquí puedes realizar más análisis o acciones según lo necesites
                }
            }
        }

        public static bool VerificarControles(Control.ControlCollection controls)
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
        public static List<string> VerificarControlesObligatorios(Form form, string nombreControlNoVerificar)
        {
            List<string> controlesIncompletos = new List<string>();

            // Obtener la colección de controles del formulario
            Control.ControlCollection controles = form.Controls;

            foreach (Control control in controles)
            {
                // Verificar si el control no es el que se especificó para no verificar
                if (control.Name != nombreControlNoVerificar)
                {
                    // Verificar si el control está vacío
                    if (string.IsNullOrEmpty(control.Text))
                    {
                        control.BackColor = Color.LightBlue;
                        controlesIncompletos.Add(control.Name); // Agregar el nombre del control a la lista de controles incompletos
                    }
                    else
                    {
                        control.BackColor = Color.White;
                    }
                }
            }

            return controlesIncompletos;
        }
    }
}
