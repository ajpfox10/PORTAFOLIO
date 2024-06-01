using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class BAJAFORMULARIO : Form
    {
        private long Dnis_;
    
        private long DniAnterior = 0;
        private Timer timerActualizarRuta;
        public string Agentedeatencions_;
        MODULOS.PersonaLEVENTOS personaLEVENTOS;

        public BAJAFORMULARIO(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Agentedeatencions_ = agenteDeAtencion;
            Dnis_ = DNI;
            // Initialize PersonaLEVENTOS once
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
            // Event for selecting all text on entering the ComboBox
            apellido1.Enter += (s, ev) => ((ComboBox)s).SelectAll();
            // Configure TreeView
            VisorArbol.FullRowSelect = true;
            VisorArbol.AfterSelect += VisorArbol_AfterSelect;
            VisorArbol.NodeMouseDoubleClick += VisorArbol_NodeMouseDoubleClick;
            // Initialize and start the timer
            timerActualizarRuta = new Timer();
            timerActualizarRuta.Interval = 500;
            timerActualizarRuta.Tick += TimerActualizarRuta_Tick;
            timerActualizarRuta.Start();
            // Context menu for copying file path
            ContextMenuStrip menuContextual = new ContextMenuStrip();
            ToolStripMenuItem copiarDireccionMenuItem = new ToolStripMenuItem("Copiar dirección de archivo");
            copiarDireccionMenuItem.Click += CopiarDireccionMenuItem_Click;
            menuContextual.Items.Add(copiarDireccionMenuItem);
            Visor.ContextMenuStrip = menuContextual;
            // Subscribe to the TextChanged event for the DNI textbox
            this.DNI.TextChanged += DNI_TextChanged;
            // Elemento de menú para imprimir el archivo
            ToolStripMenuItem imprimirMenuItem = new ToolStripMenuItem("Imprimir archivo");
            imprimirMenuItem.Click += ImprimirMenuItem_Click;
            menuContextual.Items.Add(imprimirMenuItem);

            // Elemento de menú para abrir el archivo
            ToolStripMenuItem abrirMenuItem = new ToolStripMenuItem("Abrir archivo");
            abrirMenuItem.Click += AbrirMenuItem_Click;
            menuContextual.Items.Add(abrirMenuItem);

            // Elemento de menú para copiar en memoria el archivo
            ToolStripMenuItem copiarArchivoMenuItem = new ToolStripMenuItem("Copiar archivo en memoria con copia");
            copiarArchivoMenuItem.Click += CopiarArchivoMenuItem_Click;
            menuContextual.Items.Add(copiarArchivoMenuItem);


            // Elemento de menú para pegar en el escritorio
            ToolStripMenuItem pegarEnEscritorioMenuItem = new ToolStripMenuItem("Pegar en Escritorio");
            pegarEnEscritorioMenuItem.Click += PegarEnEscritorioMenuItem_Click;
            menuContextual.Items.Add(pegarEnEscritorioMenuItem);

            // Asignar el menú contextual al PictureBox
            Visor.ContextMenuStrip = menuContextual;
        }
        public static class InputDialog
        {
            public static string Show(string prompt, string title)
            {
                using (Form form = new Form())
                {
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

                    return form.ShowDialog() == DialogResult.OK ? textBox.Text : "";
                }
            }
        }




        private void CopiarDireccionMenuItem_Click(object sender, EventArgs e)
        {
            if (Visor.ImageLocation != null)
            {
                Clipboard.SetText(Visor.ImageLocation);
            }
            else
            {
                MessageBox.Show("No hay una imagen cargada para copiar la dirección.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirMenuItem_Click(object sender, EventArgs e)
        {
            if (Visor.ImageLocation != null)
            {
                try
                {
                    // Configura el diálogo de impresión
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.Document = new PrintDocument();
                    printDialog.UseEXDialog = true;

                    // Muestra el diálogo de impresión y si el usuario elige una impresora, imprime el archivo
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                        pd.PrintPage += delegate (object sender2, System.Drawing.Printing.PrintPageEventArgs e2)
                        {
                            e2.Graphics.DrawImage(Visor.Image, 0, 0);
                        };

                        pd.Print();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al imprimir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay una imagen cargada para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AbrirMenuItem_Click(object sender, EventArgs e)
        {
            // Implementa la lógica para abrir el archivo aquí
            // Puedes usar la ruta de la imagen cargada: Visor.ImageLocation
            // Por ejemplo:
            if (Visor.ImageLocation != null)
            {
                try
                {
                    System.Diagnostics.Process.Start(Visor.ImageLocation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay una imagen cargada para abrir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CopiarArchivoMenuItem_Click(object sender, EventArgs e)
        {
            if (Visor.ImageLocation != null)
            {
                try
                {
                    string fileName = Path.GetFileName(Visor.ImageLocation);
                    string directory = Path.GetDirectoryName(Visor.ImageLocation);
                    string extension = Path.GetExtension(Visor.ImageLocation);

                    string newFileName = Path.Combine(directory, fileName.Replace(extension, "_copia" + extension));

                    File.Copy(Visor.ImageLocation, newFileName, true); // Sobrescribe si existe

                    MessageBox.Show("Archivo copiado en memoria como " + newFileName + ". Puedes pegar la ruta manualmente usando Ctrl + V.", "Archivo copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Error de acceso no autorizado al copiar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error de E/S al copiar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al copiar el archivo en memoria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay una imagen cargada para copiar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PegarEnEscritorioMenuItem_Click(object sender, EventArgs e)
        {
            if (Visor.ImageLocation != null)
            {
                try
                {
                    string fileName = Path.GetFileName(Visor.ImageLocation);
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string newFilePath = Path.Combine(desktopPath, fileName);

                    File.Copy(Visor.ImageLocation, newFilePath);

                    MessageBox.Show("Archivo pegado en el escritorio como " + newFilePath, "Archivo pegado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al pegar el archivo en el escritorio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay una imagen cargada para pegar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






















        private void VisorArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = e.Node.Tag as string;
            try
            {
                if (File.Exists(selectedPath))
                {
                    Visor.ImageLocation = selectedPath; // Actualizar ImageLocation
                    Visor.SizeMode = PictureBoxSizeMode.Zoom;
                    Console.WriteLine("Imagen cargada: " + selectedPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VisorArbol_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string selectedPath = e.Node.Tag as string;
            try
            {
                if (File.Exists(selectedPath))
                {
                    Visor.ImageLocation = selectedPath; // Actualizar ImageLocation
                    Visor.SizeMode = PictureBoxSizeMode.Zoom;
                    Console.WriteLine("Imagen cargada: " + selectedPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TimerActualizarRuta_Tick(object sender, EventArgs e)
        {
            if (DniAnterior != Dnis_)
            {
                DniAnterior = Dnis_;
                ActualizarRutaYArchivos();
            }
        }
        private void ActualizarRutaYArchivos()
        {
            string ruta = $"\\\\192.168.0.21\\g\\DOCU\\{Dnis_}";
            if (Directory.Exists(ruta))
            {
                VisorArbol.Nodes.Clear();
                Visor.Image = null;
                AgregarNodosAlArbol(ruta, VisorArbol.Nodes);
            }
        }
        private void AgregarNodosAlArbol(string ruta, TreeNodeCollection nodos)
        {
            var archivos = Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".png", StringComparison.OrdinalIgnoreCase));
            foreach (string archivo in archivos)
            {
                TreeNode node = new TreeNode(Path.GetFileName(archivo))
                {
                    Tag = archivo
                };
                nodos.Add(node);
            }
        }
        private void DNI_TextChanged(object sender, EventArgs e)
        {
            if (long.TryParse(DNI.Text, out long nuevoDni))
            {
                Dnis_ = nuevoDni;
                ActualizarRutaYArchivos();
            }
            else
            {
                MessageBox.Show("DNI no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timerActualizarRuta.Stop();
            timerActualizarRuta.Dispose();
            base.OnFormClosed(e);
        }

    }
}
