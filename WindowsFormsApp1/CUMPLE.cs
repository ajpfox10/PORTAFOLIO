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
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void CARGA_Click(object sender, EventArgs e)        
        {
            ConexionMySQL conexion = new ConexionMySQL();
            DateTime fechaAnalizarValue = FECHAANALIZAR.Value;
            string consulta = "SELECT `APELLDO Y NOMBRE` AS 'APELLIDO Y NOMBRE', DATE_FORMAT(FECHAREALDENACIMIENTO, '%d/%m/%Y') AS 'FECHA DE NACIMIENTO' FROM PERSONAL WHERE ACTIVO = -1 AND MONTH(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Month + " AND DAY(FECHAREALDENACIMIENTO) = " + fechaAnalizarValue.Day;
            conexion.CargarResultadosConsulta(consulta, CUMPLES);
        }
    }
}
