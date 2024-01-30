using iText.StyledXmlParser.Jsoup.Select;
using System;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.MODULOS;
using ListView = System.Windows.Forms.ListView;
using ToolTip = System.Windows.Forms.ToolTip;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class HVIDA : Form
    {
        public Int64 _dnis;
        private readonly string _agentedeatencions;
        public HVIDA(FORMULARIOPRINCIPAL formularioPrincipal, Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            _dnis = DNI;
            _agentedeatencions = agenteDeAtencion;
        }
        private void HVIDA_Load(object sender, EventArgs e)
        {
            ConexionMySQL conexion = new ConexionMySQL();
            string consulta = "SELECT form2.Id1 AS ID, form2.DNIDELAGENTE AS DNI, form2.NACIOPAIS AS `NACIO EN`, form2.PROVINCIADENAC AS `PCIA DE NACIMIENTO`, form2.PARTIDO AS `PARTIDO DE NACIMIENTO`, " +
                              "DATE_FORMAT(form2.FCHANACI, '%Y-%m-%d') AS `FECHA DE NACIMIENTO`, form2.ESTADOCIVIL AS `ESTADO CIVIL`, form2.MAXIMONIVELESTUDIOS AS `MAXIMO NIVEL DE ESTUDIOS`, " +
                              "form2.TITULOSECUNDARIO AS `TITULO SECUNDARIO`, form2.OTORGADOPORSECUNDARIO AS `ESCUELA QUE OTORGO EL TITULO SECUNDARIO`, form2.TITULOTECNICO AS `TITULO TECNICO`, " +
                              "form2.TIULOTENICOOTORGADPOR AS `ESCUELA QUE OTORGO EL TITULO TECNICO`, form2.TITULOUNIVERSITARIO AS `TITULO UNIVERSITARIO`, form2.TITULOUNIVERSITARIOOTORGADOPOR AS `UNIVERSIDAD QUE OTORGO EL TITULO`, " +
                              "form2.PRESTOSERVICIOS AS `PRESTO SERVICIOS MILITARES`, form2.ARMA, form2.ESPECIALIDADARMAMILITAR AS `ESPECIALIDAD MILITAR`, form2.GRADO, form2.DESTINO, form2.MATRICULA, " +
                              "form2.cartaciudadania AS `CARTA DE CIUDADANIA`, DATE_FORMAT(form2.fechadeciudadania, '%Y-%m-%d') AS `FECHA DE CIUDADANIA`, form2.OTORGADACIUDAD AS `OTORGO EN`, form2.JUEZQLAOTORGO AS `JUEZ QUE OTORGO LA CARTA`, ESTUDIOSENCURSO AS 'ESTUDIOS EN CURSO',TITULODELESTUDIOENCURSO AS 'TITULO DE ESTUDIO EN CURSO', causalexcepcion AS 'CAUSAL DE EXCEPCION DE SERVICIOS MILITARES' " +
                              "FROM form2";
            ListView miListView = new ListView();
            conexion.CargarResultadosConsulta(consulta, hdevida);
        
        }
        private void CARGAR_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (verificador.VerificarControles(this.Controls))
            {
                string A1 = _dnis.ToString();
                string A2 = PAISNACIMIENTO.Text;
                string A3 = PROVINCIANACIMIENTO.Text;
                string A4 = PARTIDONACIMIENTO.Text;
                DateTime A5 = FECHANACIMIENTO.Value;
                string A6 = ESTADOCIVIL.Text;
                string A7 = MAXIMOESTUDIO.Text;
                string A8 = TITULOSECUNDARIO.Text;
                string A9 = ESCUELASECUNDARIA.Text;
                string A10 = TITULOTECNICO.Text;
                string A11 = TITULOTECNICOOTORGADOPOR.Text;
                string A12 = TITULOUNIVERSITARIO.Text;
                string A13 = TITULOUNIVERSITARIOOTORGADOPOR.Text;
                string A14 = PRESTOSERVICIOSMILITARES.Text;
                string A15 = ARMA.Text;
                string A16 = ESPECIALIDAD.Text;
                string A17 = GRADO.Text;
                string A18 = DESTINO.Text;
                string A19 = MATRICULA.Text;
                string A20 = CARTADECIUDANIA.Text;
                DateTime A21 = FECHADECARTACIUDADANIA.Value;
                string A22 = OTORGADALACARTAEN.Text;
                string A23 = juezfederal.Text;
                string A24 = ESTUDIANDONUEVO.ValueMember;
                string A25 = QESTUDIANUEVO.Text;
                string A26 = CAUSALEXCEPCION.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.INSERTATDatosVida1(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, A17, A18, A19, A20, A21, A22, A23, A24, A25, A26);
                 string consulta = "SELECT form2.Id1 AS ID, form2.DNIDELAGENTE AS DNI, form2.NACIOPAIS AS `NACIO EN`, form2.PROVINCIADENAC AS `PCIA DE NACIMIENTO`, form2.PARTIDO AS `PARTIDO DE NACIMIENTO`, " +
                             "DATE_FORMAT(form2.FCHANACI, '%Y-%m-%d') AS `FECHA DE NACIMIENTO`, form2.ESTADOCIVIL AS `ESTADO CIVIL`, form2.MAXIMONIVELESTUDIOS AS `MAXIMO NIVEL DE ESTUDIOS`, " +
                             "form2.TITULOSECUNDARIO AS `TITULO SECUNDARIO`, form2.OTORGADOPORSECUNDARIO AS `ESCUELA QUE OTORGO EL TITULO SECUNDARIO`, form2.TITULOTECNICO AS `TITULO TECNICO`, " +
                             "form2.TIULOTENICOOTORGADPOR AS `ESCUELA QUE OTORGO EL TITULO TECNICO`, form2.TITULOUNIVERSITARIO AS `TITULO UNIVERSITARIO`, form2.TITULOUNIVERSITARIOOTORGADOPOR AS `UNIVERSIDAD QUE OTORGO EL TITULO`, " +
                             "form2.PRESTOSERVICIOS AS `PRESTO SERVICIOS MILITARES`, form2.ARMA, form2.ESPECIALIDADARMAMILITAR AS `ESPECIALIDAD MILITAR`, form2.GRADO, form2.DESTINO, form2.MATRICULA, " +
                             "form2.cartaciudadania AS `CARTA DE CIUDADANIA`, form2.fechadeciudadania AS `FECHA DE CIUDADANIA`, form2.OTORGADACIUDAD AS `OTORGO EN`, form2.JUEZQLAOTORGO AS `JUEZ QUE OTORGO LA CARTA`, ESTUDIOSENCURSO AS 'ESTUDIOS EN CURSO',TITULODELESTUDIOENCURSO AS 'TITULO DE ESTUDIO EN CURSO', causalexcepcion AS 'CAUSAL DE EXCEPCION DE SERVICIOS MILITARES' " +
                             "FROM form2";
                ListView miListView = new ListView();
                ControlHelper.LimpiarControles(this);
                conexion.CargarResultadosConsulta(consulta, hdevida);
            }
            else
            {
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }    
        private void EDITARDATOS_Click(object sender, EventArgs e)
        {
            VERIFICARCONTR verificador = new VERIFICARCONTR();
            if (verificador.VerificarControles(this.Controls))
            {
                string A1 = _dnis.ToString();
                string A2 = PAISNACIMIENTO.Text;
                string A3 = PROVINCIANACIMIENTO.Text;
                string A4 = PARTIDONACIMIENTO.Text;
                DateTime A5 = FECHANACIMIENTO.Value;
                string A6 = ESTADOCIVIL.Text;
                string A7 = MAXIMOESTUDIO.Text;
                string A8 = TITULOSECUNDARIO.Text;
                string A9 = ESCUELASECUNDARIA.Text;
                string A10 = TITULOTECNICO.Text;
                string A11 = TITULOTECNICOOTORGADOPOR.Text;
                string A12 = TITULOUNIVERSITARIO.Text;
                string A13 = TITULOUNIVERSITARIOOTORGADOPOR.Text;
                string A14 = PRESTOSERVICIOSMILITARES.Text;
                string A15 = ARMA.Text;
                string A16 = ESPECIALIDAD.Text;
                string A17 = GRADO.Text;
                string A18 = DESTINO.Text;
                string A19 = MATRICULA.Text;
                string A20 = CARTADECIUDANIA.Text;
                DateTime A21 = FECHADECARTACIUDADANIA.Value;
                string A22 = OTORGADALACARTAEN.Text;
                string A23 = juezfederal.Text;
                string A24 = ESTUDIANDONUEVO.ValueMember;
                string A25 = QESTUDIANUEVO.Text;
                string A26 = CAUSALEXCEPCION.Text;
                ConexionMySQL conexion = new ConexionMySQL();
                conexion.ActualizarDatosVida1(A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, A17, A18, A19, A20, A21, A22, A23, A24, A25, A26);
                //, OTORGADOPORSECUNDAR1:OTORGADOPORSECUNDAR1


                string consulta = "SELECT form2.Id1 AS ID, form2.DNIDELAGENTE AS DNI, form2.NACIOPAIS AS `NACIO EN`, form2.PROVINCIADENAC AS `PCIA DE NACIMIENTO`, form2.PARTIDO AS `PARTIDO DE NACIMIENTO`, " +
                             "DATE_FORMAT(form2.FCHANACI, '%Y-%m-%d') AS `FECHA DE NACIMIENTO`, form2.ESTADOCIVIL AS `ESTADO CIVIL`, form2.MAXIMONIVELESTUDIOS AS `MAXIMO NIVEL DE ESTUDIOS`, " +
                             "form2.TITULOSECUNDARIO AS `TITULO SECUNDARIO`, form2.OTORGADOPORSECUNDARIO AS `ESCUELA QUE OTORGO EL TITULO SECUNDARIO`, form2.TITULOTECNICO AS `TITULO TECNICO`, " +
                             "form2.TIULOTENICOOTORGADPOR AS `ESCUELA QUE OTORGO EL TITULO TECNICO`, form2.TITULOUNIVERSITARIO AS `TITULO UNIVERSITARIO`, form2.TITULOUNIVERSITARIOOTORGADOPOR AS `UNIVERSIDAD QUE OTORGO EL TITULO`, " +
                             "form2.PRESTOSERVICIOS AS `PRESTO SERVICIOS MILITARES`, form2.ARMA, form2.ESPECIALIDADARMAMILITAR AS `ESPECIALIDAD MILITAR`, form2.GRADO, form2.DESTINO, form2.MATRICULA, " +
                             "form2.cartaciudadania AS `CARTA DE CIUDADANIA`, DATE_FORMAT(form2.fechadeciudadania, '%Y-%m-%d') AS `FECHA DE CIUDADANIA`, form2.OTORGADACIUDAD AS `OTORGO EN`, form2.JUEZQLAOTORGO AS `JUEZ QUE OTORGO LA CARTA`, ESTUDIOSENCURSO AS 'ESTUDIOS EN CURSO',TITULODELESTUDIOENCURSO AS 'TITULO DE ESTUDIO EN CURSO' " +
                             "FROM form2";
                ListView miListView = new ListView();
                ControlHelper.LimpiarControles(this);
                conexion.CargarResultadosConsulta(consulta, hdevida);

            }
            else
            {
                MessageBox.Show("Por favor complete los campos faltantes.");
            }
        }
        private void Hdevida_DoubleClick(object sender, EventArgs e)
        {            
            ListViewItem selectedItem = hdevida.SelectedItems[0];
            string columna0 = selectedItem.SubItems[0].Text;
            string columna1 = selectedItem.SubItems[1].Text;
            string columna2 = selectedItem.SubItems[2].Text;
            string columna3 = selectedItem.SubItems[3].Text;
            string columna4 = selectedItem.SubItems[4].Text;        
            string fechaTexto1 = selectedItem.SubItems[5].Text;
            string formatoFecha = "yyyy-MM-dd";
            DateTime columna5;
            if (DateTime.TryParseExact(fechaTexto1, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna5))
            {
                string fechaFormateada = columna5.ToString("yyyy-MM-dd");
                FECHADECARTACIUDADANIA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna6 = selectedItem.SubItems[6].Text;
            string columna7 = selectedItem.SubItems[7].Text;
            string columna8 = selectedItem.SubItems[8].Text;
            string columna9 = selectedItem.SubItems[9].Text;
            string columna10 = selectedItem.SubItems[10].Text;
            string columna11 = selectedItem.SubItems[11].Text;
            string columna12 = selectedItem.SubItems[12].Text;
            string columna13 = selectedItem.SubItems[13].Text;
            string columna14 = selectedItem.SubItems[14].Text;
            string columna15 = selectedItem.SubItems[15].Text;
            string columna16 = selectedItem.SubItems[16].Text;
            string columna17 = selectedItem.SubItems[17].Text;
            string columna18 = selectedItem.SubItems[18].Text;
            string columna19 = selectedItem.SubItems[19].Text;
            string columna20 = selectedItem.SubItems[20].Text;  
            string fechaTexto2 = selectedItem.SubItems[21].Text;
            string formatoFecha1 = "yyyy-MM-dd";
            DateTime columna21;
            if (DateTime.TryParseExact(fechaTexto2, formatoFecha1, CultureInfo.InvariantCulture, DateTimeStyles.None, out columna21))
            {
                string fechaFormateada = columna21.ToString("dd/MM/yyyy");
                FECHADECARTACIUDADANIA.Value = DateTime.ParseExact(fechaFormateada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            string columna22 = selectedItem.SubItems[22].Text;
            string columna23 = selectedItem.SubItems[23].Text;
            string columna24 = selectedItem.SubItems[24].Text;
            string columna25 = selectedItem.SubItems[25].Text;
            string columna26 = selectedItem.SubItems[26].Text;
            idx.Text = columna0;        
            PAISNACIMIENTO.Text = columna2;
            PROVINCIANACIMIENTO.Text = columna3;
            PARTIDONACIMIENTO.Text = columna4;
            FECHANACIMIENTO.Value = columna5;
            ESTADOCIVIL.Text = columna6;
            MAXIMOESTUDIO.Text = columna7;
            TITULOSECUNDARIO.Text = columna8;
            ESCUELASECUNDARIA.Text = columna9;
            TITULOTECNICO.Text = columna10;
            TITULOTECNICOOTORGADOPOR.Text = columna11;
            TITULOUNIVERSITARIO.Text = columna12;   
            TITULOUNIVERSITARIOOTORGADOPOR.Text = columna13;
            PRESTOSERVICIOSMILITARES.Text = columna14;
            this.ARMA.Text = columna15;
            ESPECIALIDAD.Text = columna16;
            this.GRADO.Text = columna17;
            DESTINO.Text = columna18;
            MATRICULA.Text = columna19;            
            FECHADECARTACIUDADANIA.Value = columna21;
            OTORGADALACARTAEN.Text = columna22;
            juezfederal.Text = columna23;
            this.ESTUDIANDONUEVO.Text = columna24;
            QESTUDIANUEVO.Text = columna25;
            CARTADECIUDANIA.Text = columna20;
            CAUSALEXCEPCION.Text = columna26;
        }
        private void Hdevida_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem selectedItem = hdevida.SelectedItems[0]; // Obtén el elemento seleccionado
                // Obtén el valor del campo "idt" del elemento seleccionado
                string idtValue = selectedItem.SubItems[0].Text;
                // Muestra un cuadro de diálogo para confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Deseas eliminar el dato con IDT " + idtValue + "?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Elimina el elemento del ListView
                    hdevida.Items.Remove(selectedItem);
                    ConexionMySQL conexion = new ConexionMySQL();
                    {
                        conexion.Conectar();
                        // Consulta SQL para eliminar el registro
                        string query = "DELETE FROM form2 WHERE Id1 = @idt";
                        using (MySqlCommand command = new MySqlCommand(query, conexion.GetConnection()))
                        {
                            command.Parameters.AddWithValue("@idt", idtValue);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = _dnis.ToString(); // Obtener el nombre de la carpeta adicional desde otra fuente (por ejemplo, otro formulario)

            rellenahoja1 formFiller = new rellenahoja1(nombreCarpeta);
            formFiller.FillPdfForm(_dnis.ToString());
        }

        private void Hdevida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
