using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace WindowsFormsApp1
{
    public partial class CARGARFAMILIA : Form
    {
        public Int64 Dnis_;

        private readonly string Agentedeatencions_;
        public CARGARFAMILIA(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
        }
        private void CARGARFAMILIA_Load(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "(SELECT form1.idx AS ID, form1.PARENTESCO, form1.NOMBREYAPELLIDO AS 'NOMBRE Y APELLIDO', form1.VIVE, DATE_FORMAT(form1.FECHA, '%Y-%m-%d') AS 'FECHA DE NACIMIENTO', form1.JUB AS JUBILADO, form1.PROFESION, form1.cajajubilacion as 'CAJA DE JUBILACION', form1.SEXO, form1.DNIAGENTE FROM form1 WHERE DNIAGENTE='" + Dnis_ + "')"; 
            conexion.CargarResultadosConsulta(consulta, FAMILIAS);
            FAMILIAS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            string filePath = "c:/domicilio1.pdf"; // Ruta al archivo PDF
            webBrowser1.Navigate(filePath);
        }
        private void DATOSCARGAFAMILIA_Click(object sender, EventArgs e)
              {
                VERIFICARCONTR verificador = new VERIFICARCONTR();
                if (verificador.VerificarControles(this.Controls))
                {
                    // Todos los controles están completos, por lo que se puede insertar los datos en la base de datos
                    string DNIAGENTE1 = Dnis_.ToString();
                    string PARENTESCO1 = PARENTESCO.Text;
                    string NOMBREYAPELLIDO1 = APEELIDOYNOMBRE.Text;
                    string VIVE1 = VIVE.Text;
                    DateTime FECHA1 = fechanacimiento.Value;
                    string JUB1 = jubilacion.Text;
                    string CAJAJUBILACION1 = CAJADEJUBILACION.Text;
                    string PROFESION1 = PROFESION.Text;
                    string SEXO1 = sexo.Text;
                    ConexionMySQL conexion = new ConexionMySQL();
                    conexion.InsertarDatosdomicilio(DNIAGENTE1, PARENTESCO1, NOMBREYAPELLIDO1, VIVE1, FECHA1, JUB1, CAJAJUBILACION1, PROFESION1, SEXO1);
                    string consulta = "(SELECT form1.idx AS ID, form1.PARENTESCO, form1.NOMBREYAPELLIDO AS 'NOMBRE Y APELLIDO', form1.VIVE, DATE_FORMAT(form1.FECHA, '%Y-%m-%d') AS 'FECHA DE NACIMIENTO', form1.JUB AS JUBILADO, form1.PROFESION, form1.cajajubilacion as 'CAJA DE JUBILACION', form1.SEXO, form1.DNIAGENTE FROM form1 WHERE DNIAGENTE='" + Dnis_ + "')";
           
                    ControlHelper.LimpiarControles(this);
                    conexion.CargarResultadosConsulta(consulta, FAMILIAS);
                }
                else
                {
                    // Algunos controles están incompletos, se debe pedir al usuario que complete los controles requeridos.
                    MessageBox.Show("Por favor complete los campos faltantes.");
                }
        }
        private void FAMILIAS_DoubleClick(object sender, EventArgs e)
        {          
                ListViewItem selectedItem = FAMILIAS.SelectedItems[0];
                // Obtener los subelementos de la fila seleccionada
                string columna0 = selectedItem.SubItems[0].Text;
                string columna1 = selectedItem.SubItems[1].Text;
                string columna2 = selectedItem.SubItems[2].Text;
                string columna3 = selectedItem.SubItems[3].Text;
                string columna4 = selectedItem.SubItems[4].Text;
                string columna5 = selectedItem.SubItems[5].Text;
                string columna6 = selectedItem.SubItems[6].Text;
                string columna7 = selectedItem.SubItems[7].Text;
                string columna8 = selectedItem.SubItems[8].Text;
                // Asignar los valores de los subelementos a los controles correspondientes en el formulario
                ID.Text = columna0;
                PARENTESCO.Text = columna1;
                APEELIDOYNOMBRE.Text = columna2;
                VIVE.Text = columna3;
                fechanacimiento.Text = columna4;
                jubilacion.Text = columna5;
                CAJADEJUBILACION.Text = columna7;
                PROFESION.Text = columna6;
                sexo.Text = columna8;              
        }
        private void FAMILIAS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Right)
                {
                    ListViewItem selectedItem = FAMILIAS.SelectedItems[0]; // Obtén el elemento seleccionado
                    // Obtén el valor del campo "idt" del elemento seleccionado
                    string idtValue = selectedItem.SubItems[0].Text;
                    // Muestra un cuadro de diálogo para confirmar la eliminación
                    DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Elimina el elemento del ListView
                        FAMILIAS.Items.Remove(selectedItem);
                        ConexionMySQL conexion = new ConexionMySQL();
                        {
                            conexion.Conectar();
                            // Consulta SQL para eliminar el registro
                            string query = "DELETE FROM form1 WHERE idx = @idt";
                            using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                            {
                                command.Parameters.AddWithValue("@idt", idtValue);
                                command.ExecuteNonQuery();
                            }
                        string consulta = "(SELECT form1.idx AS ID, form1.PARENTESCO, form1.NOMBREYAPELLIDO AS 'NOMBRE Y APELLIDO', form1.VIVE, DATE_FORMAT(form1.FECHA, '%Y-%m-%d') AS 'FECHA DE NACIMIENTO', form1.JUB AS JUBILADO, form1.PROFESION, form1.cajajubilacion as 'CAJA DE JUBILACION', form1.SEXO, form1.DNIAGENTE FROM form1 WHERE DNIAGENTE='" + Dnis_ + "')";
            
                        conexion.CargarResultadosConsulta(consulta, FAMILIAS);
                    }
                    }
                }
            }
        private void CARGARPDF_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = Dnis_.ToString(); // Obtener el nombre de la carpeta adicional desde otra fuente (por ejemplo, otro formulario)
            rellenafamiliares formFiller = new rellenafamiliares(nombreCarpeta);
            formFiller.FillPdfForm(Dnis_.ToString());
        }
        private void Cargafamilia_Click(object sender, EventArgs e)
      
            {
                string PARENTESCOSS = PARENTESCO.Text;
                string NOMBRESS = APEELIDOYNOMBRE.Text;
                string VIVESS = VIVE.Text;
                DateTime FECHASSS = DateTime.Parse(fechanacimiento.Text);
                string CAJAJUBILACIONS = CAJADEJUBILACION.Text;
                string PROFESIONS = PROFESION.Text;
                string SEXOS = sexo.Text;
                String ID1 = ID.Text;
                String JUBS = jubilacion.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.ActualizarDatosFAMILIA(PARENTESCOSS, NOMBRESS, VIVESS, FECHASSS, CAJAJUBILACIONS, PROFESIONS, SEXOS, ID1, JUBS);
                string consulta = "(SELECT form1.idx AS ID, form1.PARENTESCO, form1.NOMBREYAPELLIDO AS 'NOMBRE Y APELLIDO', form1.VIVE, DATE_FORMAT(form1.FECHA, '%Y-%m-%d') AS 'FECHA DE NACIMIENTO', form1.JUB AS JUBILADO, form1.PROFESION, form1.cajajubilacion as 'CAJA DE JUBILACION', form1.SEXO, form1.DNIAGENTE FROM form1 WHERE DNIAGENTE='" + Dnis_ + "')";
                conexion.CargarResultadosConsulta(consulta, FAMILIAS);
            }
    }
}
  