using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApp1.MODULOS
{
    public class PersonaLEVENTOS
    {
        private ComboBox apellido1;
        private TextBox DNI;
        private RadioButton PORDNI;
        private RadioButton PORAPELLIDO;
        private Timer searchTimer;
        private bool searchingByDNI = false;
        private string AGENTE; // Nuevo campo para almacenar el agente
        private long Dnis_;
        private bool searchingByApellido = false;
        private bool isSearching = false;
        private string lastSearchedApellido = "";
        private Dictionary<string, string> dictionary; // Declarar dictionary aquí
        public PersonaLEVENTOS(ComboBox apellido1, TextBox DNI, RadioButton PORDNI, RadioButton PORAPELLIDO, string AGENTE, long Dnis_)
        {
            this.apellido1 = apellido1;
            this.DNI = DNI;
            this.PORDNI = PORDNI;
            this.PORAPELLIDO = PORAPELLIDO;
            this.AGENTE = AGENTE;
            this.Dnis_ = Dnis_;
            InitializeEventHandlers();
            InitializeTimer();
            this.dictionary = new Dictionary<string, string>();
            LoadDataIntoDictionary();
        }
        private void InitializeEventHandlers()
        {
            apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
            DNI.TextChanged += DNI_TextChanged;
            PORDNI.CheckedChanged += (sender, e) => { searchingByDNI = PORDNI.Checked; };
            PORAPELLIDO.CheckedChanged += (sender, e) =>
            {
                if (PORAPELLIDO.Checked)
                {
                    searchingByDNI = false;
                    DNI.Text = "0";

                    // Desactivar temporalmente el manejo de eventos del ComboBox
                    apellido1.SelectedIndexChanged -= Apellido1_SelectedIndexChanged;
                    apellido1.Text = "";
                    apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
                }
                else if (PORDNI.Checked)
                {
                    searchingByDNI = true;
                    DNI.Text = "0";
                    apellido1.Text = "";
                }

            };

            // Agregar evento KeyUp al ComboBox
               apellido1.KeyUp += Apellido1_KeyUp;
           // apellido1.TextChanged += Apellido1_TextChanged;
        }
        private void Apellido1_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto ingresado por el usuario
            string searchText = this.apellido1.Text;

            // Filtrar los elementos del ComboBox basados en el texto ingresado
            this.apellido1.Items.Clear();
            foreach (string item in dictionary.Values)
            {
                if (item.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    this.apellido1.Items.Add(item);
                }
            }

            // Seleccionar el texto ingresado para facilitar la escritura
            this.apellido1.Select(searchText.Length, 0);
        }
        private void InitializeTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 10000; 
            searchTimer.Tick += SearchTimer_Tick;
        }
        private void LoadDataIntoDictionary()
        {
            try
            {
                // Cargar datos desde la base de datos y llenar el diccionario
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> apellidoList = new ConexionMySQL().EjecutarConsulta(consulta, "APELLIDO");
                List<string> dniList = new ConexionMySQL().EjecutarConsulta(consulta, "DNI");

                for (int i = 0; i < apellidoList.Count; i++)
                {
                    dictionary[dniList[i]] = apellidoList[i];
                }

                // Agregar datos al ComboBox
                apellido1.Items.AddRange(apellidoList.ToArray());
                apellido1.Tag = dictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private void Apellido1_KeyUp(object sender, KeyEventArgs e)
        {
            // Obtener el texto ingresado por el usuario
            string searchText = this.apellido1.Text;

            // Filtrar los elementos del ComboBox basados en el texto ingresado
            this.apellido1.Items.Clear();
            foreach (string item in dictionary.Values)
            {
                if (item.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    this.apellido1.Items.Add(item);
                }
            }

            // Seleccionar el texto ingresado para facilitar la escritura
            this.apellido1.Select(searchText.Length, 0);
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop(); // Detener el temporizador

            // Realizar la búsqueda si no se está buscando actualmente
            if (!isSearching)
            {
                if (searchingByDNI)
                    SearchByDNI();
                else
                    SearchByApellido();
            }

            // Volver a iniciar el temporizador después de completar la búsqueda
            searchTimer.Start();

            // Restablecer el estado de búsqueda
            isSearching = false;
        }
        private void DNI_TextChanged(object sender, EventArgs e)
        {
            if (!searchTimer.Enabled) // Solo si el temporizador no está activo
            {
                searchTimer.Stop();
                searchTimer.Start();
            }
        }
        private void SearchByDNI()
        {
            isSearching = true;
            Console.WriteLine("Método SearchByDNI() llamado.");
            if (DNI.Text == "0")
            {
                return;
            }
            if (DNI.Text == Dnis_.ToString())
            {
                isSearching = false;
                return; // Si el DNI no ha cambiado, salir del método
            }
            MessageBox.Show("Iniciando búsqueda por DNI...");

            if (!long.TryParse(DNI.Text, out long dni))
            {
                MessageBox.Show("Búsqueda infructuosa: DNI no válido");
                return;
            }
            string apellido = new ConexionMySQL().EjecutarConsulta($"SELECT `apelldo y nombre` FROM personal WHERE dni = '{dni}'", "apelldo y nombre").FirstOrDefault<string>();
            if (apellido != null)
            {
                apellido1.Text = apellido;
                Dnis_ = dni; // Asignar el valor de DNI a Dnis_
                MessageBox.Show("Búsqueda exitosa: Se ha encontrado el apellido");
            }
            else
            {
                MessageBox.Show("Búsqueda infructuosa: No se encontró ningún resultado");
            }
            isSearching = false;
        }
        private void SearchByApellido()
        {
            isSearching = true;

            // Desactivar temporalmente el manejo de eventos del ComboBox
            apellido1.SelectedIndexChanged -= Apellido1_SelectedIndexChanged;

            if (apellido1.Text != lastSearchedApellido)
            {
                Console.WriteLine("Método SearchByApellido() llamado.");

                MessageBox.Show("Iniciando búsqueda por Apellido...");

                // Desactivar temporalmente el manejo de eventos del TextBox de DNI
                DNI.TextChanged -= DNI_TextChanged;

                // Realizar la búsqueda por apellido
                if (apellido1.SelectedItem == null)
                {
                    MessageBox.Show("Búsqueda infructuosa: Apellido no seleccionado");

                    // Reactivar el manejo de eventos del TextBox de DNI
                    DNI.TextChanged += DNI_TextChanged;

                    // Reactivar el manejo de eventos del ComboBox
                    apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
                    isSearching = false;
                    return;
                }

                string dni = new ConexionMySQL().EjecutarConsulta($"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellido1.SelectedItem.ToString()}'", "dni").FirstOrDefault<string>();
                if (dni != null)
                {
                    DNI.Text = dni;
                    Dnis_ = Convert.ToInt64(dni); // Asigna el valor de DNI a Dnis_
                    MessageBox.Show("Búsqueda exitosa: Se ha encontrado el DNI");
                }
                else
                {
                    MessageBox.Show("Búsqueda infructuosa: No se encontró ningún resultado");
                }

                // Reactivar el manejo de eventos del TextBox de DNI
                DNI.TextChanged += DNI_TextChanged;
                lastSearchedApellido = apellido1.Text;
            }

            // Reactivar el manejo de eventos del ComboBox
            apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;

            isSearching = false;
        }
        private void Apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un apellido seleccionado y si es diferente al DNI actual
            if (!searchingByDNI && apellido1.SelectedItem != null && apellido1.SelectedItem.ToString() != DNI.Text)
            {
                // Limpiar el TextBox de DNI y establecerlo en 0 solo si no estamos buscando por DNI
                if (!searchingByDNI)
                {
                    DNI.Text = "0";
                }

                // Verificar si ya estamos buscando por apellido
                if (!searchingByApellido)
                {
                    searchingByApellido = true; // Marcar que estamos realizando una búsqueda por apellido

                    Console.WriteLine("Iniciando búsqueda por Apellido...");
                    // Realizar la búsqueda por apellido
                    SearchByApellido();

                    searchingByApellido = false; // Restablecer la bandera después de completar la búsqueda
                }
            }
        }
        public long GetDnis()
        {
            return Dnis_;
        }
        public void ActualizarDnis(long nuevoDnis)
        {
            Dnis_ = nuevoDnis;
        }

    }
}
