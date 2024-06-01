using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp1.MODULOS
{
    public class PersonaLEVENTOS
    {
        private ComboBox apellido1;
        private TextBox DNI;
        private RadioButton PORDNI;
        private RadioButton PORAPELLIDO;
        private bool searchingByDNI = false;
        private string AGENTE;
        private long Dnis_;
        private Dictionary<string, string> dictionary;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        private bool searchingByApellido = false;



        public PersonaLEVENTOS(ComboBox apellido1, TextBox DNI, RadioButton PORDNI, RadioButton PORAPELLIDO, string AGENTE, long Dnis_)
        {
            this.apellido1 = apellido1;
            this.DNI = DNI;
            this.PORDNI = PORDNI;
            this.PORAPELLIDO = PORAPELLIDO;
            this.AGENTE = AGENTE;
            this.Dnis_ = Dnis_;
            InitializeEventHandlers();
            this.dictionary = new Dictionary<string, string>();
            LoadDataIntoDictionaryAsync().Wait();
            DisableInputControls();

        }

        private void InitializeEventHandlers()
        {
            apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
         
            DNI.KeyPress += DNI_KeyPress;
            DNI.Leave += DNI_Leave;
            DNI.KeyDown += DNI_KeyDown; // Agregamos el evento KeyDown aquí
            apellido1.KeyDown += Apellido1_KeyDown;
            apellido1.Leave += Apellido1_Leave;
            PORDNI.CheckedChanged += (sender, e) =>
            {
                searchingByDNI = PORDNI.Checked;
                SetInputControlState();

                // Si cambiamos a buscar por DNI, establecemos searchingByApellido en false
                if (searchingByDNI)
                {
                    searchingByApellido = false;
                }
            };
            PORAPELLIDO.CheckedChanged += (sender, e) =>
            {
                if (PORAPELLIDO.Checked)
                {
                    searchingByDNI = false;
                    DNI.Text = "0";
                    SetInputControlState();
                }
                else if (PORDNI.Checked)
                {
                    searchingByDNI = true;
                    DNI.Text = "0";
                    apellido1.Text = "";
                    SetInputControlState();
                }
            };
        }
        private async Task LoadDataIntoDictionaryAsync()
        {
            try
            {
                string consulta = "SELECT `apelldo y nombre` AS APELLIDO, dni FROM personal ORDER BY APELLIDO DESC";
                var resultados = await new ConexionMySQL().EjecutarConsultaAsync(consulta);

                dictionary = resultados.ToDictionary(row => row["dni"], row => row["APELLIDO"]);
                apellido1.Items.AddRange(dictionary.Values.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private void Apellido1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }
        private void Apellido1_Leave(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private async Task PerformSearchAsync()
        {
            await semaphore.WaitAsync();
            try
            {
                if (DNI.Text.Length > 0)
                {
                    await Task.Delay(500); // Debounce delay
                    if (DNI.Text.Length > 0)
                    {
                        SearchByDNI();
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
 
      
        private async void SearchByDNI()
        {
            Console.WriteLine("Método SearchByDNI() llamado.");
            if (DNI.Text == "0")
            {
                return;
            }
            if (DNI.Text == Dnis_.ToString())
            {
                return;
            }

            MessageBox.Show("Iniciando búsqueda por DNI...");

            if (!long.TryParse(DNI.Text, out long dni))
            {
                MessageBox.Show("Búsqueda infructuosa: DNI no válido");
                return;
            }

            var resultado = await new ConexionMySQL().EjecutarConsultaAsync($"SELECT `apelldo y nombre` FROM personal WHERE dni = '{dni}'");
            string apellido = resultado.FirstOrDefault()?["apelldo y nombre"];

            if (apellido != null)
            {
                apellido1.Text = apellido;
                Dnis_ = dni;
                MessageBox.Show("Búsqueda exitosa: Se ha encontrado el apellido");
            }
            else
            {
                MessageBox.Show("Búsqueda infructuosa: No se encontró ningún resultado");
            }
        }
        private async void SearchByApellido()
        {
            Console.WriteLine("Método SearchByApellido() llamado.");
            MessageBox.Show("Iniciando búsqueda por Apellido...");

            if (apellido1.SelectedItem == null)
            {
                MessageBox.Show("Búsqueda infructuosa: Apellido no seleccionado");
                return;
            }

            var resultado = await new ConexionMySQL().EjecutarConsultaAsync($"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellido1.SelectedItem.ToString()}'");
            string dni = resultado.FirstOrDefault()?["dni"];

            if (dni != null)
            {
                DNI.Text = dni;
                Dnis_ = Convert.ToInt64(dni);
                MessageBox.Show("Búsqueda exitosa: Se ha encontrado el DNI");
            }
            else
            {
                MessageBox.Show("Búsqueda infructuosa: No se encontró ningún resultado");
            }
        }
        private void DisableInputControls()
        {
            DNI.Enabled = false;
            apellido1.Enabled = false;
        }
        private void SetInputControlState()
        {
            DNI.Enabled = searchingByDNI;
            apellido1.Enabled = !searchingByDNI;

            if (searchingByDNI)
            {
                apellido1.Text = "";
            }
            else
            {
                DNI.Text = "0";
            }
        }
        private void DNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!PORDNI.Checked)
            {
                e.Handled = true;
                MessageBox.Show("Debe seleccionar la opción 'Buscar por DNI' para escribir en este campo.");
            }
        }
        private void Apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchingByApellido && apellido1.SelectedItem != null && apellido1.SelectedItem.ToString() != DNI.Text)
            {
                DNI.Text = "0";

                // Solo inicia la búsqueda si no está buscando por DNI
                if (!searchingByDNI)
                {
                    Console.WriteLine("Iniciando búsqueda por Apellido...");
                    SearchByApellido();
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
        private void DNI_Leave(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void DNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearch();
            }
        }
        private void PerformSearch()
        {
            if (searchingByDNI)
            {
                SearchByDNI();
            }
            else
            {
                SearchByApellido();
            }
        }



    }
}