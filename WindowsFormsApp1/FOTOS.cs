using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class FOTOS : Form
    {
        public static string Agentedeatencions_ { get; set; }
        private long DniAnterior = 0;
        public static long Dnis_ { get; set; }
        private Timer timerActualizarRuta;
        private PersonaLEVENTOS personaLEVENTOS;
        public FOTOS()
        {           
            this.InitializeComponent();
            VisorArbol.FullRowSelect = true;
            this.personaLEVENTOS = new PersonaLEVENTOS(this.apellido1, this.DNI, this.PORDNI, this.PORAPELLIDO, "AGENTE", FOTOS.Dnis_);
            this.apellido1.Enter += (EventHandler)((s, ev) => ((ComboBox)s).SelectAll());
            FOTOS.Dnis_ = Convert.ToInt64(this.DNI.Text);
            this.apellido1.DropDownStyle = ComboBoxStyle.DropDown;
            this.VisorArbol.AfterSelect += new TreeViewEventHandler(this.VisorArbol_AfterSelect);
            this.timerActualizarRuta = new Timer();
            this.timerActualizarRuta.Interval = 50000;
            this.timerActualizarRuta.Start();
            this.timerActualizarRuta.Tick += new EventHandler(this.TimerActualizarRuta_Tick);
            this.apellido1.Enter += (EventHandler)((s, ev) => ((ComboBox)s).SelectAll());

            ContextMenuStrip menuContextual = new ContextMenuStrip();
            this.Visor.ContextMenuStrip = menuContextual;
            // Crear el elemento de menú
            ToolStripMenuItem copiarDireccionMenuItem = new ToolStripMenuItem("Copiar dirección de archivo");
            copiarDireccionMenuItem.Click += CopiarDireccionMenuItem_Click;

            // Agregar el elemento de menú al ContextMenuStrip
            menuContextual.Items.Add(copiarDireccionMenuItem);
            //this.apellido1.SelectedIndexChanged += new EventHandler(apellido1_SelectedIndexChanged);
        }
        private void Fotoss_Load(object sender, EventArgs e)
        {
            string str = string.Format("\\\\192.168.0.21\\g\\DOCU\\{0}", (object)FOTOS.Dnis_);
            if (Directory.Exists(str))
            {
                int num = (int)MessageBox.Show("Archivos cargados correctamente.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.AgregarNodosAlArbol(str, this.VisorArbol.Nodes);
            }
            else
            {
                int num1 = (int)MessageBox.Show("La dirección de red no es válida o no se puede acceder.");
            }
            this.BackColor = Color.MediumPurple;
            ConexionMySQL conexionMySql = new ConexionMySQL();
            try
            {
                this.apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> second = conexionMySql.EjecutarConsulta(consulta, "APELLIDO");
                List<string> first = conexionMySql.EjecutarConsulta(consulta, "DNI");
                this.apellido1.Items.Clear();
                Dictionary<string, string> dictionary = first.Zip((IEnumerable<string>)second, (dni, apellido) => new
                {
                    dni = dni,
                    apellido = apellido
                }).ToDictionary(x => x.dni, x => x.apellido);
                this.apellido1.Items.AddRange((object[])second.ToArray());
                this.apellido1.Tag = (object)dictionary;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox: " + ex.Message);
            }
        }
        private void AgregarNodosAlArbol(string ruta, TreeNodeCollection nodos)
        {
            foreach (string directory in Directory.GetDirectories(ruta))
            {
                TreeNode node = new TreeNode(Path.GetFileName(directory));
                nodos.Add(node);
                this.AgregarNodosAlArbol(directory, node.Nodes);
            }
            foreach (string path in ((IEnumerable<string>)((IEnumerable<string>)Directory.GetFiles(ruta, "*.bmp", SearchOption.TopDirectoryOnly)).Concat<string>((IEnumerable<string>)Directory.GetFiles(ruta, "*.jpg", SearchOption.TopDirectoryOnly)).ToArray<string>()).Concat<string>((IEnumerable<string>)Directory.GetFiles(ruta, "*.PNG", SearchOption.TopDirectoryOnly)).ToArray<string>())
            {
                TreeNode node = new TreeNode(Path.GetFileName(path));
                nodos.Add(node);
            }
        }
        private void Apellido1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.apellido1.SelectedItem == null)
                return;
            this.DNI.Text = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + this.apellido1.SelectedItem.ToString() + "'", "dni").FirstOrDefault<string>();
            FOTOS.Dnis_ = Convert.ToInt64(this.DNI.Text);
            this.VisorArbol.Nodes.Clear();
            this.ActualizarRutaYArchivos();
            Console.WriteLine("Actualización de ruta y archivos llamada desde DNI_Validating");
        }
        private void Apellido1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.apellido1.SelectedItem == null)
                return;
            this.DNI.Text = new ConexionMySQL().EjecutarConsulta("SELECT dni FROM personal WHERE `apelldo y nombre` = '" + this.apellido1.SelectedItem.ToString() + "'", "dni").FirstOrDefault<string>();
            FOTOS.Dnis_ = Convert.ToInt64(this.DNI.Text);
            this.VisorArbol.Nodes.Clear();
            this.ActualizarRutaYArchivos();
            Console.WriteLine("Actualización de ruta y archivos llamada desde DNI_Validating");
        }
        private void DNI_Validating(object sender, CancelEventArgs e)
        {
            if (!this.PORDNI.Checked)
                return;
            long result;
            if (!string.IsNullOrWhiteSpace(this.DNI.Text) && long.TryParse(this.DNI.Text, out result))
            {
                FOTOS.Dnis_ = result;
                if (this.apellido1.Tag is Dictionary<string, string> tag)
                {
                    string key = result.ToString();
                    if (tag.ContainsKey(key))
                    {
                        this.apellido1.SelectedItem = (object)tag[key];
                        FOTOS.Dnis_ = Convert.ToInt64(this.DNI.Text);
                        this.ActualizarRutaYArchivos();
                        Console.WriteLine("Actualización de ruta y archivos llamada desde DNI_Validating");
                    }
                    else
                    {
                        this.apellido1.SelectedIndex = -1;
                        int num = (int)MessageBox.Show("No se encontró un APELLIDO Y NOMBRE correspondiente al DNI ingresado.");
                    }
                }
            }
            else
            {
                int num1 = (int)MessageBox.Show("El campo DNI no es válido. Debe ingresar un número válido.");
            }
        }
        private void DNI_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.DNI.Text) && long.TryParse(this.DNI.Text, out long _))
            {
                this.timerActualizarRuta.Stop();
                this.timerActualizarRuta.Start();
                FOTOS.Dnis_ = Convert.ToInt64(this.DNI.Text);
                this.VisorArbol.Nodes.Clear();
                this.ActualizarRutaYArchivos();
                Console.WriteLine("Actualización de ruta y archivos llamada desde DNI_Validating");
            }
            else
                FOTOS.Dnis_ = 0L;
        }
        private void CARGARFOTO_Click(object sender, EventArgs e)
        {
            ConexionMySQL conexionMySql = new ConexionMySQL();
            string columna = "foto";
            string nuevoValor = "1";
            string str = conexionMySql.SeleccionarRegistros("personal", columna, Convert.ToInt32(FOTOS.Dnis_));
            if (string.IsNullOrEmpty(str))
            {
                conexionMySql.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(FOTOS.Dnis_));
                int num = (int)MessageBox.Show("La foto se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (str == "1")
            {
                int num1 = (int)MessageBox.Show("La foto ya tiene el valor no se requiere actualización.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                int num2 = (int)MessageBox.Show("No se pudo determinar el estado de la foto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void VisorArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Visor.Image = null;
            if (!File.Exists(string.Format("\\\\192.168.0.21\\G\\DOCU\\{0}\\{1}", (object)FOTOS.Dnis_, (object)e.Node.FullPath)))
                return;
         //   this.Visor.Image = Image.FromFile(Path.Combine(string.Format("\\\\192.168.0.21\\G\\DOCU\\{0}\\", (object)FOTOS.Dnis_), e.Node.FullPath));
            Image imagen = Image.FromFile(Path.Combine(string.Format("\\\\192.168.0.21\\G\\DOCU\\{0}\\", (object)FOTOS.Dnis_), e.Node.FullPath));
            this.Visor.SizeMode = PictureBoxSizeMode.Zoom;
            this.Visor.Image = imagen;
            Console.WriteLine("Método VisorArbol_AfterSelect llamado correctamente.");
        }
        private void TimerActualizarRuta_Tick(object sender, EventArgs e)
        {
            this.timerActualizarRuta.Stop();
            if (string.IsNullOrWhiteSpace(this.DNI.Text) || !long.TryParse(this.DNI.Text, out long _))
                return;
            this.ActualizarRutaYArchivos();
        }
        private void ActualizarRutaYArchivos()
        {
            string str = string.Format("\\\\192.168.0.21\\g\\DOCU\\{0}", (object)FOTOS.Dnis_);
            if (!Directory.Exists(str))
                return;
            this.VisorArbol.Nodes.Clear();
            this.AgregarNodosAlArbol(str, this.VisorArbol.Nodes);

        }
        private void CopiarDireccionMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si hay una imagen cargada en el visor
            if (this.Visor.Image != null)
            {
                // Copiar la dirección del archivo al portapapeles
                string direccionArchivo = ObtenerDireccionArchivoCargado();
                Clipboard.SetText(direccionArchivo);

                // Opcional: Mostrar un mensaje indicando que la dirección se ha copiado al portapapeles
                MessageBox.Show("La dirección del archivo se ha copiado al portapapeles.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Método para obtener la dirección del archivo cargado en el visor
        private string ObtenerDireccionArchivoCargado()
        {
            // Verificar si hay una imagen cargada en el visor
            if (this.Visor.Image != null)
            {
                // Obtener la ruta completa del archivo cargado
                string rutaCompleta = this.VisorArbol.SelectedNode.FullPath;

                // Obtener el nombre del archivo de la ruta completa
                string nombreArchivo = Path.GetFileName(rutaCompleta);

                // Construir y devolver la dirección completa del archivo
                return string.Format("\\\\192.168.0.21\\G\\DOCU\\{0}\\{1}", (object)FOTOS.Dnis_, (object)nombreArchivo);
            }
            else
            {
                // En caso de que no haya una imagen cargada, devolver una cadena vacía
                return "";
            }
        }
    }
}
