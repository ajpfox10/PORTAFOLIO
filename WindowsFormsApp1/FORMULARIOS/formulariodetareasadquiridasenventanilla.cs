using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.MODULOS;

namespace WindowsFormsApp1
{
    public partial class formulariodetareasadquiridasenventanilla : Form
    {
        public Int64 Dnis_;
        public string Agentedeatencions_;
        private readonly PersonaLEVENTOS personaLEVENTOS;
        private readonly ConexionMySQL conexionMySQL;

        public formulariodetareasadquiridasenventanilla(Int64 DNI, string agenteDeAtencion)
        {
            InitializeComponent();
            Dnis_ = DNI;
            Agentedeatencions_ = agenteDeAtencion;
            conexionMySQL = new ConexionMySQL();
            personaLEVENTOS = new PersonaLEVENTOS(apellido1, this.DNI, PORDNI, PORAPELLIDO, Agentedeatencions_, Dnis_);
            CargarComboBoxTipoDeTramite();
        }

        private void CargarComboBoxTipoDeTramite()
        {
            string consulta = "SELECT ID, TIPODETRAMITE AS `TIPO DE TRAMITE` FROM tipotramite";
            DataTable dataTable = conexionMySQL.EjecutarConsulta(consulta);
            TAREAS.DataSource = dataTable;
            TAREAS.DisplayMember = "TIPO DE TRAMITE";
            TAREAS.ValueMember = "ID";
        }

        private void buttonObtenerValor_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(TAREAS.SelectedValue);
            string tramiteSeleccionado = TAREAS.Text;
            MessageBox.Show($"ID seleccionado: {idSeleccionado}\nTrámite seleccionado: {tramiteSeleccionado}");
        }

        private void CARGARTAREA_Click(object sender, EventArgs e)
        {
            if (TAREAS.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una tarea.", "Campo requerido");
                return;
            }

            if (string.IsNullOrEmpty(COMENTARIODETAREA.Text))
            {
                MessageBox.Show("Por favor, ingrese un comentario.", "Campo requerido");
                return;
            }

            using (ConexionMySQL conexion = new ConexionMySQL())
            {
                conexionMySQL.Insertar(Agentedeatencions_, (int)Dnis_, (int)TAREAS.SelectedValue, DateTime.Now, COMENTARIODETAREA.Text);
                recarga(Agentedeatencions_);
            }

            COMENTARIODETAREA.Text = "";
        }

        private void recarga(string Agentedeatencions_)
        {
            // Cargar todos los datos en el DataTable
            this.tareasadquiridiasTableAdapter.Fill(this.dataSet1.tareasadquiridias);

            // Filtrar los datos en memoria usando LINQ
            var filasFiltradas = this.dataSet1.tareasadquiridias.AsEnumerable()
                                        .Where(row => row.Field<int>("ESTADO") == 0 &&
                                                      row.Field<string>("AGENTEDETRABAJO") == Agentedeatencions_);

            // Crear un nuevo DataTable con las filas filtradas
            DataTable dtFiltrado = filasFiltradas.Any() ? filasFiltradas.CopyToDataTable() : this.dataSet1.tareasadquiridias.Clone();

            // Limpiar el DataGridView y cargar solo las filas filtradas
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dtFiltrado;
        }


        private void formulariodetareasadquiridasenventanilla_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.tareasadquiridias' Puede moverla o quitarla según sea necesario.
            this.tareasadquiridiasTableAdapter.Fill(this.dataSet1.tareasadquiridias);
            recarga(Agentedeatencions_);
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
                conexionMySQL.ActualizarDatosTAREAS(id, "1", DateTime.Now);
                recarga(Agentedeatencions_);
            }
        }
    }
}
