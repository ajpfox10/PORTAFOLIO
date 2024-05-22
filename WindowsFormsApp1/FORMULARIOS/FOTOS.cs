using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;
using System.Diagnostics; // Necesario para Process.Start
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
            this.VisorArbol.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.VisorArbol_NodeMouseDoubleClick);

            this.timerActualizarRuta = new Timer();
            this.timerActualizarRuta.Interval = 50000;
            this.timerActualizarRuta.Start();
            this.timerActualizarRuta.Tick += new EventHandler(this.TimerActualizarRuta_Tick);
            this.apellido1.Enter += (EventHandler)((s, ev) => ((ComboBox)s).SelectAll());

            ContextMenuStrip menuContextual = new ContextMenuStrip();
            this.Visor.ContextMenuStrip = menuContextual;
            ToolStripMenuItem copiarDireccionMenuItem = new ToolStripMenuItem("Copiar dirección de archivo");
            copiarDireccionMenuItem.Click += CopiarDireccionMenuItem_Click;
            menuContextual.Items.Add(copiarDireccionMenuItem);

            // Crear ListView
            listViewFaltantes.View = View.Details;
            listViewFaltantes.Columns.Add("DNI", 150, HorizontalAlignment.Left);
            listViewFaltantes.Columns.Add("Apellido", 190, HorizontalAlignment.Left);
            listViewFaltantes.Columns.Add("DEPENDENCIA", 170, HorizontalAlignment.Left);

            upa4sinfoto.View = View.Details;
            upa4sinfoto.Columns.Add("DNI", 150, HorizontalAlignment.Left);
            upa4sinfoto.Columns.Add("Apellido", 190, HorizontalAlignment.Left);
            upa4sinfoto.Columns.Add("Dependencia", 170, HorizontalAlignment.Left);

            UPA18SINFOTO.View = View.Details;
            UPA18SINFOTO.Columns.Add("DNI", 150, HorizontalAlignment.Left);
            UPA18SINFOTO.Columns.Add("Apellido", 190, HorizontalAlignment.Left);
            UPA18SINFOTO.Columns.Add("Dependencia", 170, HorizontalAlignment.Left);
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

            VerificarCarpetasSinCredencial("\\\\192.168.0.21\\g\\DOCU");
        }
        private void AgregarNodosAlArbol(string ruta, TreeNodeCollection nodos)
        {
            var archivos = Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".png", StringComparison.OrdinalIgnoreCase));

            foreach (string archivo in archivos)
            {
                TreeNode node = new TreeNode(Path.GetFileName(archivo));
                node.Tag = archivo;
                nodos.Add(node);
            }
        }
        public class ListViewItemComparer : IComparer
        {
            private int column;
            private SortOrder sortOrder;
            public ListViewItemComparer(int column, SortOrder sortOrder)
            {
                this.column = column;
                this.sortOrder = sortOrder;
            }
            public int Compare(object x, object y)
            {
                // Comparar los subítems por apellido en orden ascendente
                int compareResult = string.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);
                return sortOrder == SortOrder.Ascending ? compareResult : -compareResult;
            }
        }



        private void VerificarCarpetasSinCredencial1(string rutaBase)
        {
            // Limpiar los ListView antes de empezar
            upa4sinfoto.Items.Clear();
            UPA18SINFOTO.Items.Clear();
            listViewFaltantes.Items.Clear();

            try
            {
                // Consulta para obtener los datos del personal activo
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni, personal.DEPENDENCIA FROM personal WHERE personal.activo = -1";
                DataTable dataTable = new ConexionMySQL().EjecutarConsulta(consulta);

                // Iterar sobre las filas obtenidas de la consulta
                foreach (DataRow row in dataTable.Rows)
                {
                    string dni = row["dni"].ToString();
                    string apellido = row["APELLIDO"].ToString();
                    string dependencia = row["DEPENDENCIA"].ToString();
                    string directorio = Path.Combine(rutaBase, dni);

                    if (dni.StartsWith("31912148"))
                    {
                        // Mensaje para mostrar la verificación de la carpeta
                        MessageBox.Show("Verificando carpeta para DNI " + dni + ": " + directorio);

                        if (!Directory.Exists(directorio))
                        {
                            // Mensaje para indicar que el directorio no se encontró
                            MessageBox.Show("Directorio no encontrado: " + directorio);
                            continue; // Saltar a la siguiente iteración si el directorio no existe
                        }

                        // Comprobar si el archivo "CREDENCIAL EMPLEADO FINAL" existe en la carpeta
                        string nombreArchivoCredencial = "CREDENCIAL EMPLEADO FINAL.PNG";
                        string archivoCredencial = Path.Combine(directorio, nombreArchivoCredencial);

                        if (File.Exists(archivoCredencial))
                        {
                            // Abrir el archivo "CREDENCIAL EMPLEADO FINAL"
                            try
                            {
                                Process.Start("explorer.exe", archivoCredencial);

                                // Mensaje para indicar que el archivo se encontró y se abrió
                                MessageBox.Show("Archivo encontrado y abierto: " + archivoCredencial);
                            }
                            catch (Exception ex)
                            {
                                // Mensaje para mostrar el error al abrir el archivo
                                MessageBox.Show("Error al abrir el archivo: " + ex.Message);
                            }
                        }
                        else
                        {
                            // Mensaje para indicar que el archivo no se encontró
                            MessageBox.Show("Archivo 'CREDENCIAL EMPLEADO FINAL' no encontrado en: " + directorio);

                            // Actualizar el campo 'foto' a 1 en la tabla 'personal' para este DNI
                            ActualizarCampoFoto(dni);

                            // Crear un nuevo elemento para el ListView
                            ListViewItem item = new ListViewItem(dni);
                            item.SubItems.Add(apellido);
                            item.SubItems.Add(dependencia);

                            // Agregar el elemento al ListView correspondiente según la dependencia
                            if (dependencia.IndexOf("UPA 4", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                upa4sinfoto.Items.Add(item);
                            }
                            else if (dependencia.IndexOf("UPA 18", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                UPA18SINFOTO.Items.Add(item);
                            }
                            else
                            {
                                listViewFaltantes.Items.Add(item);
                            }
                        }
                    }
                }

                // Ordenar ListViews por apellido de forma descendente
                OrdenarListViewPorApellidoDescendente(upa4sinfoto);
                OrdenarListViewPorApellidoDescendente(UPA18SINFOTO);
                OrdenarListViewPorApellidoDescendente(listViewFaltantes);
            }
            catch (Exception ex)
            {
                // Mensaje para mostrar el error general al verificar carpetas sin credencial
                MessageBox.Show("Error al verificar carpetas sin credencial: " + ex.Message);
            }
        }

        private void VerificarCarpetasSinCredencial(string rutaBase)
        {
            // Limpiar los ListView antes de empezar
            upa4sinfoto.Items.Clear();
            UPA18SINFOTO.Items.Clear();
            listViewFaltantes.Items.Clear();

            try
            {
                // Consulta para obtener los datos del personal activo
                string consulta = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni, personal.DEPENDENCIA FROM personal WHERE personal.activo = -1";
                DataTable dataTable = new ConexionMySQL().EjecutarConsulta(consulta);

                // Iterar sobre las filas obtenidas de la consulta
                foreach (DataRow row in dataTable.Rows)
                {
                    string dni = row["dni"].ToString();
                    string apellido = row["APELLIDO"].ToString();
                    string dependencia = row["DEPENDENCIA"].ToString();
                    string directorio = Path.Combine(rutaBase, dni);

                    // Mensaje para mostrar la verificación de la carpeta
                 //   MessageBox.Show("Verificando carpeta para DNI " + dni + ": " + directorio);

                    if (!Directory.Exists(directorio))
                    {
                        // Mensaje para indicar que el directorio no se encontró
                        MessageBox.Show("Directorio no encontrado: " + directorio);
                        continue; // Saltar a la siguiente iteración si el directorio no existe
                    }

                    // Comprobar si el archivo "CREDENCIAL EMPLEADO FINAL" existe en la carpeta
                    string nombreArchivoCredencial = "CREDENCIAL EMPLEADO FINAL.PNG";
                    string archivoCredencial = Path.Combine(directorio, nombreArchivoCredencial);

                    if (File.Exists(archivoCredencial))
                    {
                        // Abrir el archivo "CREDENCIAL EMPLEADO FINAL"
                       

                    }
                    else
                    {
                        // Mensaje para indicar que el archivo no se encontró
                      //  MessageBox.Show("Archivo 'CREDENCIAL EMPLEADO FINAL' no encontrado en: " + directorio);

                        // Actualizar el campo 'foto' a 1 en la tabla 'personal' para este DNI
                        ActualizarCampoFoto(dni);

                        // Crear un nuevo elemento para el ListView
                        ListViewItem item = new ListViewItem(dni);
                        item.SubItems.Add(apellido);
                        item.SubItems.Add(dependencia);

                        // Agregar el elemento al ListView correspondiente según la dependencia
                        if (dependencia.IndexOf("UPA 4", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            upa4sinfoto.Items.Add(item);
                        }
                        else if (dependencia.IndexOf("UPA 18", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            UPA18SINFOTO.Items.Add(item);
                        }
                        else
                        {
                            listViewFaltantes.Items.Add(item);
                        }
                    }
                }

                // Ordenar ListViews por apellido de forma descendente
                OrdenarListViewPorApellidoDescendente(upa4sinfoto);
                OrdenarListViewPorApellidoDescendente(UPA18SINFOTO);
                OrdenarListViewPorApellidoDescendente(listViewFaltantes);
            }
            catch (Exception ex)
            {
                // Mensaje para mostrar el error general al verificar carpetas sin credencial
                MessageBox.Show("Error al verificar carpetas sin credencial: " + ex.Message);
            }
        }












        private void OrdenarListViewPorApellidoDescendente(ListView listView)
        {
            listView.ListViewItemSorter = (IComparer)new ListViewItemComparer(1, SortOrder.Ascending);
            listView.Sort();
        }
        private void CopiarDireccionMenuItem_Click(object sender, EventArgs e)
        {
            if (Visor.Image != null)
            {
                Clipboard.SetText(Visor.ImageLocation);
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
        private void VisorArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.FullPath;
            if (File.Exists(selectedPath))
            {
                Visor.Image = Image.FromFile(selectedPath);
                Visor.SizeMode = PictureBoxSizeMode.Zoom;
                Console.WriteLine("Imagen cargada: " + selectedPath);
            }
        }
        private void VisorArbol_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is string filePath && File.Exists(filePath))
            {
                this.Visor.Image = Image.FromFile(filePath);
                this.Visor.SizeMode = PictureBoxSizeMode.Zoom;
                Console.WriteLine("Imagen cargada: " + filePath);
            }
        }
        private void TimerActualizarRuta_Tick(object sender, EventArgs e)
        {
            if (this.DniAnterior != FOTOS.Dnis_)
            {
                this.DniAnterior = FOTOS.Dnis_;
                this.ActualizarRutaYArchivos();
            }
        }
        private void ActualizarRutaYArchivos()
        {
            string str = string.Format("\\\\192.168.0.21\\g\\DOCU\\{0}", (object)FOTOS.Dnis_);
            if (!Directory.Exists(str))
                return;
            this.VisorArbol.Nodes.Clear();
            this.AgregarNodosAlArbol(str, this.VisorArbol.Nodes);
            VerificarCarpetasSinCredencial("\\\\192.168.0.21\\g\\DOCU");
        }
        private void ActualizarCampoFoto(string dni)
        {
            try
            {
                // Conexión a la base de datos
                ConexionMySQL conexionMySQL = new ConexionMySQL();

                // Consulta SQL para actualizar el campo 'foto' a 1
                string consulta = "UPDATE personal SET foto = 1 WHERE dni = @dni";

                // Parámetros para la consulta
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@dni", dni);

                // Ejecutar la consulta
                conexionMySQL.EjecutarNonQuery(consulta, parametros);
                Console.WriteLine("Campo 'foto' actualizado para el DNI: " + dni);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar campo 'foto' para el DNI " + dni + ": " + ex.Message);
            }
        }
    }
}
