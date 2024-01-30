using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;


namespace WindowsFormsApp1
{
        public class CargarComboBoxes
    {
        private ConexionMySQL conexion = new ConexionMySQL();
        public void PCIA(ComboBox combo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT provincia, provincia_id FROM localidades1", conexion.conexion);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                combo.DataSource = dt;
                combo.DisplayMember = "provincia";
                combo.ValueMember = "provincia_id";         
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }
        }
        public void CargarPartidos(ComboBox combo, string provincia_id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT municipio, municipio_id FROM localidades1 WHERE provincia_id = @provincia_id", conexion.conexion);
            cmd.Parameters.AddWithValue("@provincia_id", provincia_id);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                combo.DataSource = dt;
                combo.DisplayMember = "municipio";
                combo.ValueMember = "municipio_id";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar partidos: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }
        }
        public void CargarLocalidades(ComboBox combo, int municipio_id)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT nombre, idlocalidad FROM localidades1 WHERE municipio_id = @municipio_id", conexion.conexion);
            cmd.Parameters.AddWithValue("@municipio_id", municipio_id);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                combo.DataSource = dt;
                combo.DisplayMember = "nombre";
                combo.ValueMember = "idlocalidad";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar localidades: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }
        }
        public void ministerios(ComboBox combo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT ministerios.ID, ministerios.MINISTERIO FROM ministerios", conexion.conexion);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dt.Columns["ID"].DataType = typeof(int);
                combo.DataSource = dt;
                combo.DisplayMember = "MINISTERIO";
                combo.ValueMember = "ID";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar ministerios: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }


        }
        public void regimenhorario(ComboBox combo)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT regimenhorario.ID, regimenhorario.REGIMENHORARIO FROM regimenhorario", conexion.conexion); try
                {
                    conexion.Conectar();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                dt.Columns["ID"].DataType = typeof(int);
                combo.DataSource = dt;
                combo.DisplayMember = "REGIMENHORARIO";
                combo.ValueMember = "ID";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar regimen horario: " + ex.Message);
                }
                finally
                {
                    conexion.Dispose();
                }
        }
        public void CATEGORIA(ComboBox combo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT categoria.ID, categoria.CATEGORIA FROM categoria", conexion.conexion);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dt.Columns["ID"].DataType = typeof(int);
                combo.DataSource = dt;
                combo.DisplayMember = "CATEGORIA";
                combo.ValueMember = "ID";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar categoria: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }


        }
        public void nomenclador(ComboBox combo)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT nomenclador.id, nomenclador.cargo, nomenclador.tareas FROM nomenclador", conexion.conexion);
            try
            {
                conexion.Conectar();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dt.Columns["id"].DataType = typeof(int);
                combo.DataSource = dt;
                combo.DisplayMember = "cargo";
                combo.ValueMember = "ID";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al cargar nomenclador: " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }


        }
         }
}