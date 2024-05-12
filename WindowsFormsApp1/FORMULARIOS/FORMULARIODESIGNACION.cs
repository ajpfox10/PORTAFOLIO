
using System;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.MODULOS;
namespace WindowsFormsApp1
{
    public partial class FORMULARIODESIGNACION : Form
{
        private readonly CargarComboBoxes cargadorComboBoxes;
        public Int64 Dnis_;

    public FORMULARIODESIGNACION(Int64 DNI)
    {
        InitializeComponent();
        Dnis_ = DNI;
            cargadorComboBoxes = new CargarComboBoxes(CARGOS, Regimenhorario);
        }

    private void FORMULARIODESIGNACION_Load(object sender, EventArgs e)
    {
        // Cargar datos en los ComboBox
        cargadorComboBoxes.Nomenclador(CARGOS);
        cargadorComboBoxes.CargarRegimenHorario(Regimenhorario);
        cargadorComboBoxes.CargarMinisterios(Ministerios);
        cargadorComboBoxes.CargarCategoria(CATEGORIA);

        // Realizar la consulta y cargar los resultados en el ListView DESIGNACIONESSS
        ConexionMySQL conexion = new ConexionMySQL();
        string consulta = @"
               SELECT cargosdeinicio.ID,
               cargosdeinicio.CARGODEINICIOS AS 'CARGO',
               ministerios.MINISTERIO AS 'MINISTERIO',
               DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION',
               cargosdeinicio.CATEGORIA,
               regimenhorario.`REGIMEN HORARIO` AS 'REGIMEN HORARIO',
               DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA',
               cargosdeinicio.DEPENDENCIA,
               cargosdeinicio.RESOLUCION,
               cargosdeinicio.DNIAGENTE AS 'DNI',
               cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA',
               cargosdeinicio.IFGRADENOMBRAMIENTO AS 'IFGRA DE NOMBRAMIENTO'
        FROM ministerios
        INNER JOIN (
            cargosdeinicio
            INNER JOIN regimenhorario ON cargosdeinicio.REGIMENHORARIO = regimenhorario.ID
        ) ON ministerios.ID = cargosdeinicio.MINISTERIODEDESIGNACION
        WHERE cargosdeinicio.DNIAGENTE = '" + Dnis_ + "'";

        conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);

        // Liberar recursos al finalizar
        conexion.Dispose();
    }

   private void CARGARDATOS_Click(object sender, EventArgs e)
    {
        VERIFICARCONTR verificador = new VERIFICARCONTR();
        if (VERIFICARCONTR.VerificarControles(this.Controls))
        {
            // Todos los controles están completos, por lo que se puede insertar los datos en la base de datos
            string A2 = (CARGOS.SelectedItem).ToString();
            string A3 = (Ministerios.SelectedItem).ToString();
            DateTime A4 = INGRESO.Value;
            int A5 = Convert.ToInt32((CATEGORIA.SelectedItem).ToString());
            int A6 = Convert.ToInt32((Regimenhorario.SelectedItem).ToString());
            string A8 = DEPENDENCIA.Text;
            string A9 = RESOLUCION.Text;
            string A11 = Dnis_.ToString();
            string A12 = IFGRA.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.INSERTARDATOSIFGRA(A2, A3, A4, A5, A6, A8, A9, A11, A12);
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.Regimenhorario AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + Dnis_ + "'";
            conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);
        }
        else
        {
            MessageBox.Show("Por favor complete los campos faltantes.");
        }
        }
        private void EDITARDATOS_Click(object sender, EventArgs e)
        {
            string A2 = CARGOS.ValueMember;
            string A3 = Ministerios.ValueMember;
            DateTime A4 = INGRESO.Value;
            int A5 = Convert.ToInt32(CATEGORIA.SelectedValue);
            int A6 = Convert.ToInt32(Regimenhorario.SelectedValue);
            DateTime A7=BAJA.Value;
            string A8 = DEPENDENCIA.Text;
            string A9 = RESOLUCION.Text;
            string A10 = MOTIVODEBAJA.Text;
            string A12 = IFGRA.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.ActualizarDatosdesignaciones(A2, A3, A4, A5, A6, A7, A8, A9, A10, A12);
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.Regimenhorario AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + Dnis_ + "'";

            conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);
        }
        private void DESIGNACIONESSS_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = DESIGNACIONESSS.SelectedItems[0];
            // Obtener los subelementos de la fila seleccionada
            string columna0 = selectedItem.SubItems[0].Text;
            string columna1 = selectedItem.SubItems[1].Text;
            string columna2 = selectedItem.SubItems[2].Text;
            string fechaTexto1 = selectedItem.SubItems[3].Text;
            string formatoFecha = "yyyy-MM-dd";
            if (DateTime.TryParseExact(fechaTexto1, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime columna3))
            {
                string fechaFormateada = columna3.ToString("dd/MM/yyyy");
                INGRESO.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna4 = selectedItem.SubItems[4].Text;
            string columna5 = selectedItem.SubItems[5].Text;
            string fechaTexto2 = selectedItem.SubItems[6].Text;
            if (DateTime.TryParseExact(fechaTexto2, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime columna6))
            {
                string fechaFormateada = columna6.ToString("dd/MM/yyyy");
                BAJA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna7 = selectedItem.SubItems[7].Text;
            string columna8 = selectedItem.SubItems[8].Text;
            //string columna9 = selectedItem.SubItems[9].Text;
            string columna10 = selectedItem.SubItems[10].Text;
            string columna11 = selectedItem.SubItems[11].Text;
            ID.Text = columna0;
            CARGOS.Text = columna1;
            Ministerios.Text = columna2;
            INGRESO.Value = columna3;
            CATEGORIA.SelectedItem = columna4;
            Regimenhorario.SelectedItem = columna5;
            DEPENDENCIA.Text = columna7;
            RESOLUCION.Text = columna8;

            MOTIVODEBAJA.Text = columna10;
            IFGRA.Text = columna11;
        }
        private void DESIGNACIONESSS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem selectedItem = DESIGNACIONESSS.SelectedItems[0]; // Obtén el elemento seleccionado
                // Obtén el valor del campo "idt" del elemento seleccionado
                string idtValue = selectedItem.SubItems[0].Text;
                // Muestra un cuadro de diálogo para confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Elimina el elemento del ListView
                    DESIGNACIONESSS.Items.Remove(selectedItem);
                    ConexionMySQL conexion = new ConexionMySQL();
                    {
                        conexion.Conectar();
                        // Consulta SQL para eliminar el registro
                        string query = "DELETE FROM cargosdeinicio WHERE ID = @idt";
                        using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@idt", idtValue);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void CARGARPDF_Click(object sender, EventArgs e)
        
            {
                int trackBarValue = trackBar2.Value;

                if (trackBarValue >= 0 && trackBarValue < 25)
                {
                    string nombreCarpeta = Dnis_.ToString(); 
                    rellenACARGODEINICIO formFiller = new rellenACARGODEINICIO(nombreCarpeta);
                    formFiller.FillPdfForm(Dnis_.ToString()); ;
                }
                else if (trackBarValue >= 50 && trackBarValue < 100)
                {
                string nombreCarpeta = Dnis_.ToString(); 
                rellenrcargosdos formFiller = new rellenrcargosdos(nombreCarpeta);
                formFiller.FillPdfForm(Dnis_.ToString());
            }
              
        }

        private void EDITARBAJA_Click(object sender, EventArgs e)
        {
            string A8 = ID.Text;
            DateTime A7 = BAJA.Value;
            string A10 = MOTIVODEBAJA.Text;
            ConexionMySQL conexion = new ConexionMySQL();
            conexion.ActualizarDatosdesignacionesBAJADECAR( A7, A10, A8);
            string consulta = "SELECT cargosdeinicio.ID, cargosdeinicio.CARGODEINICIOS AS 'CARGO', cargosdeinicio.MINISTERIODEDESIGNACION AS 'MINISTERIO', DATE_FORMAT(cargosdeinicio.FECHADEDESIGNACION, '%Y-%m-%d') AS 'FECHA DE DESIGNACION', cargosdeinicio.CATEGORIA, cargosdeinicio.Regimenhorario AS 'REGIMEN HORARIO', DATE_FORMAT(cargosdeinicio.FECHADEBAJA, '%Y-%m-%d') AS 'FECHA DE BAJA', cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE AS 'DNI', cargosdeinicio.MOTIVODEBAJA AS 'MOTIVO DE BAJA', cargosdeinicio.ifgradenombramiento as 'IFGRA DE NOMBRAMIENTO' FROM cargosdeinicio WHERE cargosdeinicio.DNIAGENTE = '" + Dnis_ + "'";

            conexion.CargarResultadosConsulta(consulta, DESIGNACIONESSS);
        }

      
    }
}
