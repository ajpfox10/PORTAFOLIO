using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EjemploComboBox
{
    public class Sexo
    {
        // Clase para representar las opciones del ComboBox
        class OpcionCombo
        {
            public string Texto { get; set; }
            public int ValorNumerico { get; set; }
        }

        private ComboBox comboBoxSexo;
        private ComboBox comboBoxEstado;

        public Sexo(ComboBox comboBoxSexo, ComboBox comboBoxEstado)
        {
            this.comboBoxSexo = comboBoxSexo;
            this.comboBoxEstado = comboBoxEstado;

            InicializarComboBoxSexo();
            InicializarComboBoxEstado();
        }

        private void InicializarComboBoxSexo()
        {
            // Crear una lista de opciones para el ComboBox de Sexo
            List<OpcionCombo> opcionesSexo = new List<OpcionCombo>
            {
                new OpcionCombo { Texto = "Masculino", ValorNumerico = 1 },
                new OpcionCombo { Texto = "Femenino", ValorNumerico = 2 }
            };

            // Asignar la lista como fuente de datos para el ComboBox de Sexo
            comboBoxSexo.DataSource = opcionesSexo;
            comboBoxSexo.DisplayMember = "Texto"; // Columna a mostrar en el ComboBox de Sexo
            comboBoxSexo.ValueMember = "ValorNumerico"; // Columna a utilizar como valor en el ComboBox de Sexo

            // Establecer el valor predeterminado
            comboBoxSexo.SelectedIndex = 0;
        }

        private void InicializarComboBoxEstado()
        {
            // Crear una lista de opciones para el ComboBox de Estado
            List<OpcionCombo> opcionesEstado = new List<OpcionCombo>
            {
                new OpcionCombo { Texto = "TRAMITE", ValorNumerico = 0 },
                new OpcionCombo { Texto = "PERMANENTE", ValorNumerico = 1 },
                new OpcionCombo { Texto = "INTERINO", ValorNumerico = 2 },
                new OpcionCombo { Texto = "TEMPORARIO", ValorNumerico = 3 },
                new OpcionCombo { Texto = "BECA", ValorNumerico = 4 },
                new OpcionCombo { Texto = "CONCURRENTE", ValorNumerico = 5 },
                new OpcionCombo { Texto = "RESIDENTE", ValorNumerico = 6 }
            };

            // Asignar la lista como fuente de datos para el ComboBox de Estado
            comboBoxEstado.DataSource = opcionesEstado;
            comboBoxEstado.DisplayMember = "Texto"; // Columna a mostrar en el ComboBox de Estado
            comboBoxEstado.ValueMember = "ValorNumerico"; // Columna a utilizar como valor en el ComboBox de Estado

            // Establecer el valor predeterminado
            comboBoxEstado.SelectedIndex = 0;
        }

        public int ObtenerValorNumericoSexoSeleccionado()
        {
            // Obtener la opción seleccionada del ComboBox de Sexo
            OpcionCombo opcionSeleccionada = (OpcionCombo)comboBoxSexo.SelectedItem;
            return opcionSeleccionada.ValorNumerico;
        }

        public int ObtenerValorNumericoEstadoSeleccionado()
        {
            // Obtener la opción seleccionada del ComboBox de Estado
            OpcionCombo opcionSeleccionada = (OpcionCombo)comboBoxEstado.SelectedItem;
            return opcionSeleccionada.ValorNumerico;
        }
    }
}
