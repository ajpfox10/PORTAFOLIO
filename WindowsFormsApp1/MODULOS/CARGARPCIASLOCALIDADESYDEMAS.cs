using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class CargarComboBoxes
    {
        private readonly ConexionMySQL conexion = new ConexionMySQL();
        public string pcia1;
        public string localidad1;
        public string municipio1;
        private ComboBox comboBoxProvincia;
        private ComboBox comboBoxMunicipio;
        public CargarComboBoxes(ComboBox provinciaComboBox, ComboBox municipioComboBox)
        {
            comboBoxProvincia = provinciaComboBox;
            comboBoxMunicipio = municipioComboBox;
        }
        public void CargarLocalidadesPorPartidoEnComboBox(string partidoId, ComboBox comboBoxLocalidad)
        {
            CargarComboBoxDesdeConsulta($"SELECT nombre, idlocalidad FROM localidades1 WHERE municipio_id = '{partidoId}'", "nombre", "idlocalidad", comboBoxLocalidad);
        }
        public void CargarProvinciasEnComboBox(ComboBox comboBox)
        {
            CargarComboBoxDesdeConsulta("SELECT DISTINCT provincia, provincia_id FROM localidades1", "provincia", "provincia_id", comboBox);
        }
        public void CargarMunicipiosPorProvinciaEnComboBox(string provinciaId, ComboBox comboBoxMunicipio)
        {
            CargarComboBoxDesdeConsulta($"SELECT DISTINCT municipio, municipio_id FROM localidades1 WHERE provincia_id = '{provinciaId}'", "municipio", "municipio_id", comboBoxMunicipio);
        }
        public void ManejarCambioPartido(object sender, EventArgs e, ComboBox comboBoxLocalidad)
        {
            ComboBox partidoComboBox = (ComboBox)sender;

            if (partidoComboBox.SelectedItem != null)
            {
                string partidoSeleccionado = partidoComboBox.SelectedValue?.ToString();

                if (partidoSeleccionado != null)
                {
                    string consultaIdPartido = $"SELECT municipio_id FROM localidades1 WHERE municipio_id = '{partidoSeleccionado}'";
                    string partidoId = "";

                    try
                    {
                        DataTable resultadoIdPartido = conexion.EjecutarConsulta(consultaIdPartido);

                        if (resultadoIdPartido != null && resultadoIdPartido.Rows.Count > 0)
                        {
                            partidoId = resultadoIdPartido.Rows[0]["municipio_id"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al obtener el ID del partido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CargarLocalidadesPorPartidoEnComboBox(partidoId, comboBoxLocalidad);
                }
            }
        }
        public void ManejarCambioProvincia(object sender, EventArgs e, ComboBox comboBoxMunicipio)
        {
            ComboBox provinciaComboBox = (ComboBox)sender;

            if (provinciaComboBox.SelectedItem != null)
            {
                string provinciaSeleccionada = provinciaComboBox.SelectedValue?.ToString();

                if (provinciaSeleccionada != null)
                {
                    string consultaIdProvincia = $"SELECT provincia_id FROM localidades1 WHERE provincia_id = '{provinciaSeleccionada}'";
                    string provinciaId = "";

                    try
                    {
                        DataTable resultadoIdProvincia = conexion.EjecutarConsulta(consultaIdProvincia);

                        if (resultadoIdProvincia != null && resultadoIdProvincia.Rows.Count > 0)
                        {
                            provinciaId = resultadoIdProvincia.Rows[0]["provincia_id"].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al obtener el ID de la provincia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CargarMunicipiosPorProvinciaEnComboBox(provinciaId, comboBoxMunicipio);
                }
            }
        }
        public void CargarMinisterios(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT Ministerios.ID, Ministerios.MINISTERIO FROM Ministerios", "MINISTERIO", "ID", combo);
        }
        public void CargarRegimenHorario(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT Regimenhorario.ID, Regimenhorario.`REGIMEN HORARIO` AS 'REGIMEN HORARIO' FROM Regimenhorario", "REGIMEN HORARIO", "ID", combo);
        }
        public void CargarCategoria(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT categoria.ID, categoria.CATEGORIA FROM categoria", "CATEGORIA", "ID", combo);
        }
        public void Nomenclador(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT Nomenclador.id, Nomenclador.cargo, Nomenclador.tareas FROM Nomenclador", "cargo", "id", combo);
        }
        public void Leyr(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT ley.Ley, ley.IDLEY, ley.leyactiva FROM ley", "Ley", "IDLEY", combo);
        }
        public void CargarOcupacion(int OcupacionId, ComboBox comboBoxOcupacion)
        {
            CargarComboBoxDesdeConsulta("SELECT ocupacion.Ocupacion, ocupacion.leyreglamentada, ocupacion.insalubre, ocupacion.IDESPECIALIDAD, ocupacion.activo FROM ocupacion WHERE(((ocupacion.activo) = -1))", "Ocupacion", "IDESPECIALIDAD", comboBoxOcupacion);
        }
        public void ManejarLeya(object sender, EventArgs e, ComboBox comboBoxOcupacion)
        {
            ComboBox LeyCombobox = (ComboBox)sender;

            if (LeyCombobox.SelectedItem != null)
            {
                string leySeleccionada = LeyCombobox.SelectedItem.ToString();

                string consultaIdOcupacion = $"SELECT ocupacion.Ocupacion, ocupacion.leyreglamentada, ocupacion.insalubre, ocupacion.IDESPECIALIDAD, ocupacion.activo FROM ocupacion WHERE ocupacion.leyreglamentada = '{leySeleccionada}' AND ocupacion.activo = -1";
                int OcupacionId = 0;

                try
                {
                    DataTable resultadoIdOcupacion = conexion.EjecutarConsulta(consultaIdOcupacion);

                    if (resultadoIdOcupacion != null && resultadoIdOcupacion.Rows.Count > 0)
                    {
                        OcupacionId = Convert.ToInt32(resultadoIdOcupacion.Rows[0]["IDESPECIALIDAD"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el ID de la ocupación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CargarOcupacion(OcupacionId, comboBoxOcupacion);
            }
        }
        public void CargarSector(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT sector.Sector, sector.IDSECTOR FROM sector", "Sector", "IDSECTOR", combo);
        }
        public void CargarEspecialidadesMedicas(ComboBox combo)
        {
            CargarComboBoxDesdeConsulta("SELECT especialidaddesmedicas.Id, especialidaddesmedicas.especialidad, especialidaddesmedicas.`profesion de referencia` FROM especialidaddesmedicas", "especialidad", "Id", combo);
        }
        private void CargarComboBoxDesdeConsulta(string consulta, string displayMember, string valueMember, ComboBox combo)
        {
            ConexionMySQL conexion = new ConexionMySQL();

            try
            {
                // Ejecutar la consulta y cargar los datos en un nuevo DataTable
                DataTable dt = conexion.EjecutarConsulta(consulta);

                // Clonar la estructura del DataTable original
                DataTable newData = dt.Clone();

                // Cambiar el tipo de datos de la columna valueMember en la estructura clonada
                newData.Columns[valueMember].DataType = typeof(string);

                // Copiar los datos del DataTable original al nuevo DataTable
                foreach (DataRow row in dt.Rows)
                {
                    newData.ImportRow(row);
                }

                // Asignar el nuevo DataTable al DataSource del ComboBox
                combo.DataSource = newData;
                combo.DisplayMember = displayMember;
                combo.ValueMember = valueMember;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al cargar ComboBox: {ex.Message}");
            }
            finally
            {
                conexion.Dispose();
            }
        }
    }
}