﻿using Mysqlx.Cursor;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class PEDIDOSS : Form
    {
        private string _agentedeatencions;
        public Int64 _dnis;
        public PEDIDOSS(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            _agentedeatencions = agenteDeAtencion;
        }
        private void PEDIDOSS_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
            string consultaPedidos = "SELECT pedidos.ID, personal.DNI, personal.`apelldo y nombre` AS 'APELLIDO Y NOMBRE', pedidos.PEDIDO, pedidos.agente FROM pedidos INNER JOIN personal ON pedidos.dni = personal.dni WHERE activa IS NULL  ORDER BY id DESC";
            string[] columnasPedidos = new string[] { "ID:0", "DNI:0", "APELLIDO Y NOMBRE:250", "PEDIDO:500", "AGENTE:175"};
            loader.CargarDatosYAcciones(listView1, consultaPedidos, columnasPedidos);
            listView1.MultiSelect = true;

        }
        private void CargarDatosEnTextBox(string dni, string pedido, string agente)
        {
            textBoxDNI.Text = dni;
            richpedidos.Text = pedido;
     
        }
        private void CBTRA_Click(object sender, EventArgs e)
        {
            string dniValue = _dnis.ToString();

            // Create an instance of generarcertificadodetrabajo
            generarcertificadodetrabajo generador = new generarcertificadodetrabajo(dniValue);

            // Call the GenerateCertificate method to generate the certificate
            generador.GenerateCertificate();
        }
        private void BIOMA_Click(object sender, EventArgs e)
        {
            try
            {
                //F:\\LALA\\1.docx
                string rutaDocumento = "F:\\LALA\\1.docx";
                string tempFilePath = Path.GetTempFileName() + ".docx";
                IOMA documentProcessor = new IOMA();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (FileStream fileStream = new FileStream(rutaDocumento, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(memoryStream);
                    }
                    using (ConexionMySQL conexionMySQL = new ConexionMySQL())
                    {
                        string consultaSQL = "SELECT personal.`apelldo y nombre` AS 'APELLIDOYNOMBRE', personal.dni, personal.dependencia, personal.Decreto, personal.legajo, personal.`Fecha de Ingreso` AS 'FECHAP' FROM personal WHERE dni = '" + _dnis + "'";
                        var dataTable = conexionMySQL.EjecutarConsulta(consultaSQL);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string cadenaReemplazo = row["APELLIDOYNOMBRE"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "APELLDOYNOMBRE", cadenaReemplazo);
                            cadenaReemplazo = row["dni"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "DNIP", cadenaReemplazo);
                            cadenaReemplazo = row["dependencia"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", cadenaReemplazo);
                            cadenaReemplazo = row["Decreto"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "DECRETOS", cadenaReemplazo);
                            cadenaReemplazo = row["FECHAP"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "FECHASS", cadenaReemplazo);
                            cadenaReemplazo = row["legajo"].ToString();
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "LEGAJOS", cadenaReemplazo);

                            string cadenaReemplazoFecha = DateTime.Now.ToString("dd/MM/yyyy");
                            documentProcessor.ProcesarDocumentoEnMemoria(memoryStream, "FFFFFFFFFFFFFFFFF", cadenaReemplazoFecha);




                        }
                      
                    }
                    using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        memoryStream.Position = 0; // Reset the position to the beginning
                        memoryStream.CopyTo(fileStream);
                    }

                    Process.Start("WINWORD.EXE", tempFilePath);
                }

                MessageBox.Show("Reemplazo completado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (listView1.SelectedItems.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                string entregada = "ENTREGADO";
                int dniss = (int)_dnis;
                // Mostrar mensaje de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entregada con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {  // Actualizar el campo "cierredecitacion" de la citación correspondient                    
                    conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                }

                DatosYAccionesLoader loader = new DatosYAccionesLoader(_dnis);
                string consultaPedidos = "SELECT pedidos.ID, personal.DNI, personal.`apelldo y nombre` AS 'APELLIDO Y NOMBRE', pedidos.PEDIDO, pedidos.agente FROM pedidos INNER JOIN personal ON pedidos.dni = personal.dni WHERE activa IS NULL  ORDER BY id DESC";
                string[] columnasPedidos = new string[] { "ID:0", "DNI:0", "APELLIDO Y NOMBRE:250", "PEDIDO:500", "AGENTE:175" };
                loader.CargarDatosYAcciones(listView1, consultaPedidos, columnasPedidos);

            }



        }
        private void listView1_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
            string dni = selectedItem.SubItems[1].Text;
            string pedido = selectedItem.SubItems[3].Text;
            string agente = selectedItem.SubItems[4].Text;
            string textoDnis = selectedItem.SubItems[1].Text;
            long.TryParse(textoDnis, out _dnis);



            // Llama a tu método para cargar datos en TextBox
            CargarDatosEnTextBox(dni, pedido, agente);
        }
    }
}