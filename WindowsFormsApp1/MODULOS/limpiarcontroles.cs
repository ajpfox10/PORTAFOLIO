using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1.MODULOS
{
  
public static class ControlHelper
    {
        public static void LimpiarControles(Form formulario)
        {
            // Recorrer todos los controles en el formulario
            foreach (Control control in formulario.Controls)
            {
                // Si el control es un ListView, exclúyelo de la limpieza
                if (control is ListView)
                {
                    continue;
                }

                // Si el control es un TextBox, limpiar su contenido
                if (control is TextBox box)
                {
                    box.Text = "";
                }
                // Si el control es un ComboBox, limpiar su selección
                else if (control is ComboBox box1)
                {
                    box1.SelectedIndex = -1;
                }
                // Si el control es un NumericUpDown, establecer su valor en cero
                else if (control is NumericUpDown down)
                {
                    down.Value = 0;
                }
                // Si el control es un DateTimePicker, establecer su valor en la fecha y hora actual
                else if (control is DateTimePicker picker)
                {
                    picker.Value = DateTime.Now;
                }
                // Si el control es un CheckBox, desmarcarlo
                else if (control is CheckBox box2)
                {
                    box2.Checked = false;
                }
                // Si el control es un RadioButton, desmarcarlo
                else if (control is RadioButton button)
                {
                    button.Checked = false;
                }
                // Agrega otras condiciones para cada tipo de control que desees limpiar
            }
        }
    }
}

