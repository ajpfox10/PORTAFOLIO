using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp1.MODULOS
{
    public class PersonaLEVENTOS2
    {
        private ComboBox apellido1;
        private TextBox DNI;
        private RadioButton PORDNI;
        private RadioButton PORAPELLIDO;
        private Timer searchTimer;
        private bool searchingByDNI = false;
        private string AGENTE;
        private long Dnis_;
        private bool searchingByApellido = false;
        private bool isSearching = false;
        private string lastSearchedApellido = "";
        private Dictionary<string, string> dictionary;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public PersonaLEVENTOS2(ComboBox apellido1, TextBox DNI, RadioButton PORDNI, RadioButton PORAPELLIDO, string AGENTE, long Dnis_)
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
            LoadDataIntoDictionaryAsync().Wait();
            DisableInputControls();
        }

        private void InitializeEventHandlers()
        {
            apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
            DNI.TextChanged += DNI_TextChanged;
            PORDNI.CheckedChanged += (sender, e) =>
            {
                searchingByDNI = PORDNI.Checked;
                SetInputControlState();
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
            apellido1.KeyUp += Apellido1_KeyUp;
            apellido1.KeyPress += Apellido1_KeyPress;
            DNI.KeyPress += DNI_KeyPress;
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

        private void FiltrarApellidos(string searchText)
        {
            apellido1.Items.Clear();
            foreach (string item in dictionary.Values)
            {
                if (item.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    apellido1.Items.Add(item);
                }
            }
            apellido1.Select(searchText.Length, 0);
        }

        private void Apellido1_KeyUp(object sender, KeyEventArgs e)
        {
            FiltrarApellidos(apellido1.Text);
        }

        private void Apellido1_TextChanged(object sender, EventArgs e)
        {
            FiltrarApellidos(apellido1.Text);
        }

        private void InitializeTimer()
        {
            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 10000;
            searchTimer.Tick += SearchTimer_Tick;
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            if (!isSearching)
            {
                if (searchingByDNI)
                    SearchByDNI();
                else
                    SearchByApellido();
            }
            searchTimer.Start();
            isSearching = false;
        }

        private async void DNI_TextChanged(object sender, EventArgs e)
        {
            await semaphore.WaitAsync();
            try
            {
                if (!searchTimer.Enabled)
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
            isSearching = true;
            Console.WriteLine("Método SearchByDNI() llamado.");
            if (DNI.Text == "0")
            {
                return;
            }
            if (DNI.Text == Dnis_.ToString())
            {
                isSearching = false;
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
            isSearching = false;
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
            isSearching = false;
        }

        private async void SearchByApellido()
        {
            isSearching = true;
            apellido1.SelectedIndexChanged -= Apellido1_SelectedIndexChanged;

            if (apellido1.Text != lastSearchedApellido)
            {
                Console.WriteLine("Método SearchByApellido() llamado.");
                MessageBox.Show("Iniciando búsqueda por Apellido...");
                DNI.TextChanged -= DNI_TextChanged;

                if (apellido1.SelectedItem == null)
                {
                    MessageBox.Show("Búsqueda infructuosa: Apellido no seleccionado");
                    DNI.TextChanged += DNI_TextChanged;
                    apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
                    isSearching = false;
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
                DNI.TextChanged += DNI_TextChanged;
                lastSearchedApellido = apellido1.Text;
            }

            apellido1.SelectedIndexChanged += Apellido1_SelectedIndexChanged;
            isSearching = false;
        }

        private void Apellido1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!searchingByDNI && apellido1.SelectedItem != null && apellido1.SelectedItem.ToString() != DNI.Text)
            {
                if (!searchingByDNI)
                {
                    DNI.Text = "0";
                }

                if (!searchingByApellido)
                {
                    searchingByApellido = true;
                    Console.WriteLine("Iniciando búsqueda por Apellido...");
                    SearchByApellido();
                    searchingByApellido = false;
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

        private void Apellido1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!PORAPELLIDO.Checked)
            {
                e.Handled = true;
                MessageBox.Show("Debe seleccionar la opción 'Buscar por Apellido' para escribir en este campo.");
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
    }
}