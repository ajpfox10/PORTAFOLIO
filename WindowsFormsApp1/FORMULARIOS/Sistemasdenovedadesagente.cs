using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class Sistemasdenovedadesagente : Form   
    {
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly PersonaLEVENTOS personaLEVENTOS;
        private readonly ConexionMySQL conexionMySQL;
        public Sistemasdenovedadesagente(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;//ActualizarDatosNOVEDADES
            Agentedeatencions_ = agenteDeAtencion;
            conexionMySQL = new ConexionMySQL();
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
        }
        private void Sistemasdenovedadesagente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet2.inconvenientesagentes' Puede moverla o quitarla según sea necesario.
            this.inconvenientesagentesTableAdapter.Fill(this.dataSet2.inconvenientesagentes);
            List<Control> controles = new List<Control> { apellynombre, legajo, DNI, legajohecho, REALIZODOMICILIO, JURADASALARIO };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALRIO" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }
        private void CARGARTAREA_Click(object sender, EventArgs e)
        {         
            if (string.IsNullOrEmpty(COMENTARIODETAREA.Text))
            {
                MessageBox.Show("Por favor, ingrese un comentario.", "Campo requerido");
                return;
            }
            using (ConexionMySQL conexion = new ConexionMySQL())
            {
                conexionMySQL.ActualizarDatosNOVEDADES((int)Dnis_, Agentedeatencions_, COMENTARIODETAREA.Text);
                recarga(Agentedeatencions_);
            }
            COMENTARIODETAREA.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Yellow;
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.DefaultCellStyle.BackColor = Color.White;
                }

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                row.DefaultCellStyle.BackColor = Color.Yellow;

                var valorPrimeraColumna = row.Cells[0].Value.ToString();
                int id = int.Parse(valorPrimeraColumna);
                conexionMySQL.ActualizarDatosTAREASnovedades(id, "1", DateTime.Now);
                recarga(Agentedeatencions_);
            }
        }
        private void DNI_TextChanged(object sender, EventArgs e)
        {
            DNI1.Text = DNI.Text;
        }
        private void DNI1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DNI.Text))
            {
                // Intenta convertir el valor ingresado a un entero.
                if (Int64.TryParse(DNI.Text, out Int64 nuevoDnisValor))
                {
                    // Actualiza el valor de Dnis_.
                    Dnis_ = nuevoDnisValor;

                    // Realiza la actualización de los datos en tu formulario con el nuevo valor de Dnis_.
                    ActualizarDatosConNuevoDnis();
                }
                else
                {
                    MessageBox.Show("El valor ingresado no es válido. Debe ser un número de DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ActualizarDatosConNuevoDnis()
        {
            this.BackColor = Color.MediumPurple;
            List<Control> controles = new List<Control> { apellynombre, legajo, DNI, legajohecho, REALIZODOMICILIO, JURADASALARIO, foto };
            List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALRIO", "foto" };
            ConsultaMySQL consulta = new ConsultaMySQL("SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO, personal.foto FROM personal WHERE personal.dni = '" + Dnis_ + "'", controles, nombresColumnas);
            consulta.EjecutarConsulta();
            consulta.Dispose();
        }
        private void recarga(string Agentedeatencions_)
        {
            // Cargar todos los datos en el DataTable
            this.inconvenientesagentesTableAdapter.Fill(this.dataSet2.inconvenientesagentes);
           
            // Filtrar los datos en memoria usando LINQ
            var filasFiltradas = this.dataSet2.inconvenientesagentes.AsEnumerable()
                                        .Where(row => row.Field<int>("ESTADO") == 0 &&
                                                      row.Field<int>("dniagente") == Dnis_);

            // Crear un nuevo DataTable con las filas filtradas
            DataTable dtFiltrado = filasFiltradas.Any() ? filasFiltradas.CopyToDataTable() : this.dataSet2.inconvenientesagentes.Clone();

            // Limpiar el DataGridView y cargar solo las filas filtradas
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtFiltrado;
        }
    }
}
