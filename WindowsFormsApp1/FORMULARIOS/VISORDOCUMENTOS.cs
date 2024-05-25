﻿using System;
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
    public partial class BAJAFORMULARIO : Form
    {
        private long Dnis_;
        private bool claveVerificada = false;
        private long DniAnterior = 0;
        private Timer timerActualizarRuta;
        public string Agentedeatencions_;
        private MODULOS.PersonaLEVENTOS personaLEVENTOS;

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
            timerActualizarRuta.Interval = 50000;
            timerActualizarRuta.Tick += TimerActualizarRuta_Tick;
            timerActualizarRuta.Start();

            // Context menu for copying file path
            ContextMenuStrip menuContextual = new ContextMenuStrip();
            ToolStripMenuItem copiarDireccionMenuItem = new ToolStripMenuItem("Copiar dirección de archivo");
            copiarDireccionMenuItem.Click += CopiarDireccionMenuItem_Click;
            menuContextual.Items.Add(copiarDireccionMenuItem);
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
            if (Visor.Image != null)
            {
                Clipboard.SetText(Visor.ImageLocation);
            }
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
                Visor.Image = Image.FromFile(filePath);
                Visor.SizeMode = PictureBoxSizeMode.Zoom;
                Console.WriteLine("Imagen cargada: " + filePath);
            }
        }

        private void TimerActualizarRuta_Tick(object sender, EventArgs e)
        {
            if (DniAnterior != FOTOS.Dnis_)
            {
                DniAnterior = FOTOS.Dnis_;
                ActualizarRutaYArchivos();
            }
        }

        private void ActualizarRutaYArchivos()
        {
            string ruta = $"\\\\192.168.0.21\\g\\DOCU\\{FOTOS.Dnis_}";
            if (Directory.Exists(ruta))
            {
                VisorArbol.Nodes.Clear();
                AgregarNodosAlArbol(ruta, VisorArbol.Nodes);
            }
        }

        private void AgregarNodosAlArbol(string ruta, TreeNodeCollection nodos)
        {
            var archivos = Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                            s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
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
    }
}