using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.MODULOS
{
    public class ListViewManager
    {
        private ListView listView;
        private RichTextBox datosAnalizarTextBox;
        private long Dnis_;
        private string _Agentedeatencions;
        private WebBrowser webBrowser;
        public ListViewManager(ListView listView, RichTextBox datosAnalizarTextBox, long dnis, string Agentedeatencions_, WebBrowser webBrowser)
        {
            this.listView = listView;
            this.datosAnalizarTextBox = datosAnalizarTextBox;
            this.Dnis_ = dnis;
            this._Agentedeatencions = Agentedeatencions_;
            this.webBrowser = webBrowser; // Asignamos el control WebBrowser
            ConfigureListView();
        }
        private void ConfigureListView()
        {
            listView.MouseUp += ListView_MouseUp;
            listView.MouseClick += ListView_MouseClick;
            listView.MouseDoubleClick += ListView_MouseDoubleClick;
            listView.MouseDown += ListView_MouseDown;
        }
        private void ListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listView.SelectedItems.Count > 0)
            {
                string campo3Value = listView.SelectedItems[0].SubItems[3].Text;
                datosAnalizarTextBox.Text = campo3Value;
            }
        }
        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string campo3Value = listView.SelectedItems[0].SubItems[2].Text; 
                datosAnalizarTextBox.Text = campo3Value;
            }
        }
        public void ListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var conexion = new ConexionMySQL();
            if (listView.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(listView.SelectedItems[0].SubItems[0].Text);
                if (listView.Name == "citaciones")
                {
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la citación con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        conexion.ActualizarCierreDeCitacion(id);
                        RecargarCitaciones();
                    }
                }
                else if (listView.Name == "PEDIDOS")
                {
                    string entregada = "ENTREGADO";
                    int dniss = (int)Dnis_;
                    DialogResult result = MessageBox.Show("¿Está seguro de que desea actualizar la entrega con ID " + id + "?", "Confirmar actualización", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        conexion.ActualizarCIERREDEPEDIDO(id, dniss, entregada);
                        CrearTicket miCrearTicket = new CrearTicket
                        {
                            Agentedeatencion = _Agentedeatencions,
                            Horadeatencion = DateTime.Now.ToString(),
                            Motivodeconsulta = "ENTREGA DEL " + id,
                            Explicaciondada = "ENTREGADO",
                            Agente = Dnis_.ToString()
                        };
                        miCrearTicket.Imprimir();
                        RecargarPedidos();
                    }
                }
                else if (listView.Name == "RESOLUCIONES") 
                {

                    if (listView.SelectedItems.Count > 0)
                {
                    // Busca el índice de la columna que contiene el nombre del archivo
                    int columnIndex = -1;
                    foreach (ColumnHeader column in listView.Columns)
                    {
                        if (column.Text == "COMBINACION") // Reemplaza "NombreDeLaColumna" con el nombre real de la columna
                        {
                            columnIndex = column.Index;
                            break;
                        }
                    }
                    // Verifica si se encontró el índice de la columna
                    if (columnIndex >= 0)
                    {
                        // Obtén el valor de la columna deseada del elemento seleccionado
                        string nombreArchivo = listView.SelectedItems[0].SubItems[columnIndex].Text.Trim();
                        string rutaCompleta = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\" + nombreArchivo;
                        string url = "file:///" + rutaCompleta.Replace("\\", "/");
                        MessageBox.Show("Se abrirá la siguiente ruta:\n\n" + rutaCompleta);
                        webBrowser.Navigate(url);
                    }
                    else
                    {
                        // No se encontró la columna con el nombre especificado
                        MessageBox.Show("No se encontró la columna especificada.");
                    }
                }
                }
                else if (listView.Name == "RESOLUCIONES")
                {
                    if (listView.SelectedItems.Count > 0)
                    {
                        // Busca el índice de la columna que contiene el nombre del archivo
                        int columnIndex = -1;
                        foreach (ColumnHeader column in listView.Columns)
                        {
                            if (column.Text == "COMBINACION") // Reemplaza "NombreDeLaColumna" con el nombre real de la columna
                            {
                                columnIndex = column.Index;
                                break;
                            }
                        }
                        // Verifica si se encontró el índice de la columna
                        if (columnIndex >= 0)
                        {
                            // Obtén el valor de la columna deseada del elemento seleccionado
                            string nombreArchivo = listView.SelectedItems[0].SubItems[columnIndex].Text.Trim();
                            string rutaCompleta = @"\\192.168.0.21\g\RESOLUCIONES Y VARIOS\" + nombreArchivo;
                            string url = "file:///" + rutaCompleta.Replace("\\", "/");
                            MessageBox.Show("Se abrirá la siguiente ruta:\n\n" + rutaCompleta);
                            webBrowser.Navigate(url);
                        }
                        else
                        {
                            // No se encontró la columna con el nombre especificado
                            MessageBox.Show("No se encontró la columna especificada.");
                        }
                    }
                }
            }
        }
        private void ListView_MouseDown(object sender, MouseEventArgs e)
        {
            // Implement mouse down logic here if needed.
        }
        public void LoadData(string query, string[] columns)
        {
            // IMPLEMENTARLALOGICAPARACARGARDATOS
        }
        public void RecargarCitaciones()
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaCitaciones = "SELECT dni, citadopor AS 'CITADO POR', id, MOTIVODECITACION AS 'MOTIVO DE LA CITACION', CITACIONACTIVA AS 'CITACION ACTIVA', FECHADECITACION AS 'FECHA DE CITACION', CIERREDECITACION AS 'CIERRE DE CITACION' FROM citaciones WHERE CIERREDECITACION IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasCitaciones = { "ID:75", "DNI:0", "CITADO POR:100", "MOTIVO DE LA CITACION:450", "CITACION ACTIVA:125", "FECHA DE CITACION:125", "CIERRE DE CITACION:0" };
            loader.CargarDatosYAcciones(listView, consultaCitaciones, columnasCitaciones);
        }
        public void RecargarPedidos()
        {
            DatosYAccionesLoader loader = new DatosYAccionesLoader(Dnis_);
            string consultaPedidos = "SELECT dni, id, PEDIDO, AGENTE, fechadepedido AS 'FECHA DE PEDIDO', fechaderetiro AS 'FECHA DE RETIRO', agenteqretiro AS 'AGENTE QUE RETIRO', activa FROM pedidos WHERE activa IS NULL AND dni='" + Dnis_ + "' ORDER BY id DESC";
            string[] columnasPedidos = { "DNI:0", "ID:75", "PEDIDO:300", "AGENTE:175", "FECHA DE PEDIDO:125", "FECHA DE RETIRO:125", "AGENTE QUE RETIRO:0" };
            loader.CargarDatosYAcciones(listView, consultaPedidos, columnasPedidos);
        }
    }
}
