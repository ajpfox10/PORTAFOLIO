using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CUMPLESS : Form
    {
        public CUMPLESS()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.CUMPLESS_Load); // Conecta el evento Load correctamente
            MessageBox.Show("Formulario CUMPLESS inicializado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    

    private void CUMPLESS_Load(object sender, EventArgs e) // Asegúrate de que el nombre del método sea correcto
        {
            try
            {
                // Código de inicialización
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en Load: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CARGA_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionMySQL conexion = new ConexionMySQL();
                DateTime fechaAnalizarValue = FECHAANALIZAR.Value;
                string consulta = "SELECT `APELLDO Y NOMBRE` AS 'APELLIDO Y NOMBRE', DATE_FORMAT(FECHAREALDENACIMIENTO, '%d/%m/%Y') AS 'FECHA DE NACIMIENTO' FROM PERSONAL WHERE ACTIVO = -1 AND MONTH(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Month + " AND DAY(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Day;
                conexion.CargarResultadosConsulta(consulta, CUMPLES);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en CARGA_Click: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
