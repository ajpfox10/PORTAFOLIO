using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Sistemasdenovedadesagente : Form
    {
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly ConexionMySQL conexionMySQL;

        public Sistemasdenovedadesagente(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            conexionMySQL = new ConexionMySQL();
        }

        private void Sistemasdenovedadesagente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.tareasadquiridias' Puede moverla o quitarla según sea necesario.
            this.tareasadquiridiasTableAdapter.Fill(this.dataSet1.tareasadquiridias);
            try
            {
              //   Carga los datos en la tabla 'dataSet2.inconvenientesagentes'
                this.tareasadquiridiasTableAdapter.Fill(this.dataSet1.tareasadquiridias);

                List<Control> controles = new List<Control> { apellynombre, legajo, DNI, legajohecho, REALIZODOMICILIO, JURADASALARIO };
                List<string> nombresColumnas = new List<string> { "apellynombre", "legajo", "dni", "LEGAJO ECHO", "REALIZO CAMBIO DE DOMICILIO", "JURADASALRIO" };

                string query = $"SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO " +
                               $"FROM personal WHERE personal.dni = '{Dnis_}'";

                DataTable resultado = conexionMySQL.EjecutarConsulta(query);
                // Asume que tienes una función para llenar los controles con los datos del DataTable
                LlenarControlesConDatos(resultado, controles, nombresColumnas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CARGARTAREA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(COMENTARIODETAREA.Text))
            {
                MessageBox.Show("Por favor, ingrese un comentario.", "Campo requerido");
                return;
            }

            try
            {
                conexionMySQL.ActualizarDatosNOVEDADES((int)Dnis_, Agentedeatencions_, COMENTARIODETAREA.Text);
                recarga(Agentedeatencions_);
                COMENTARIODETAREA.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la tarea: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            string query = $"SELECT personal.`apelldo y nombre`, personal.Legajo, personal.dni, personal.`Legajo Hecho`, personal.realizodomicilio, personal.JURADASALARIO, personal.foto " +
                           $"FROM personal WHERE personal.dni = '{Dnis_}'";

            DataTable resultado = conexionMySQL.EjecutarConsulta(query);
            LlenarControlesConDatos(resultado, controles, nombresColumnas);
        }

        private void recarga(string Agentedeatencions_)
        {
            try
            {
                // Cargar todos los datos en el DataTable
                this.tareasadquiridiasTableAdapter.Fill(this.dataSet1.tareasadquiridias);

                // Filtrar los datos en memoria usando LINQ
                var filasFiltradas = this.dataSet1.tareasadquiridias.AsEnumerable()
                                            .Where(row => row.Field<int>("ESTADO") == 0 &&
                                                          row.Field<long>("dniagente") == Dnis_);

                // Crear un nuevo DataTable con las filas filtradas
                DataTable dtFiltrado = filasFiltradas.Any() ? filasFiltradas.CopyToDataTable() : this.dataSet1.tareasadquiridias.Clone();

                // Limpiar el DataGridView y cargar solo las filas filtradas
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dtFiltrado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al recargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarControlesConDatos(DataTable resultado, List<Control> controles, List<string> nombresColumnas)
        {
            // Asume que el DataTable tiene solo una fila de resultados y llena los controles
            if (resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];
                for (int i = 0; i < controles.Count; i++)
                {
                    if (fila[nombresColumnas[i]] != DBNull.Value)
                    {
                        controles[i].Text = fila[nombresColumnas[i]].ToString();
                    }
                }
            }
        }
    }
}
