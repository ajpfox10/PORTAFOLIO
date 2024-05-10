using iText.StyledXmlParser.Css.Selector.Item;
using iText.StyledXmlParser.Jsoup.Select;
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
using WindowsFormsApp1.MODULOS;
namespace WindowsFormsApp1
{
    public partial class CORREGIRERRORES : Form
    {
        public static Int64 _dnis { get; set; }
        public CORREGIRERRORES()
        {
            InitializeComponent();
            // Manejar el evento SelectedIndexChanged para el ComboBox principal
               cmbColumna.SelectedIndexChanged += CmbColumna_SelectedIndexChanged;
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
           
            DNI.Text = "0";
            apellido1.Text = "";
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {

           
            DNI.Text = "0";
            apellido1.Text = "";
        }

        
      





        private void DNI_TextChanged(object sender, EventArgs e)
        {
            ValidateDNI();
        }

        private void DNI_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton1.Checked)
            {
                ValidateDNI();
            }
        }

        private void ValidateDNI()
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Debes primero elegir cómo buscar si por DNI o por apellido antes de completar el campo.");
                DNI.Text="0";
                apellido1.Text = "";
                return;
            }

            if (!string.IsNullOrWhiteSpace(DNI.Text) && long.TryParse(DNI.Text, out long dniNumber))
            {
                _dnis = dniNumber;
                // Resto de la lógica de validación del DNI
            }
            else
            {
                _dnis = 0;
                MessageBox.Show("El campo DNI no es válido. Debe ingresar un número válido.");
            }
        }

        private void apellido1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                ValidateRadioButtonSelection();
                // Resto de la lógica para apellido1_SelectedIndexChanged_1
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();
                // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
                // Asigna el DNI al cuadro de texto "DNI"
                DNI.Text = dni;
                _dnis = Convert.ToInt64(DNI.Text);
                ConstruirConsulta();
            }
        }

        private void apellido1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (apellido1.SelectedItem != null)
            {
                ValidateRadioButtonSelection();
                
                // Resto de la lógica para apellido1_SelectedValueChanged
                string apellidoSeleccionado = apellido1.SelectedItem.ToString();
                // Realiza una consulta para obtener el DNI correspondiente al apellido seleccionado
                string consultaDNI = $"SELECT dni FROM personal WHERE `apelldo y nombre` = '{apellidoSeleccionado}'";
                var conexion = new ConexionMySQL();
                string dni = conexion.EjecutarConsulta(consultaDNI, "dni").FirstOrDefault();
                // Asigna el DNI al cuadro de texto "DNI"
                DNI.Text = dni;

                _dnis = Convert.ToInt64(DNI.Text);
                ConstruirConsulta();

            }
        }

        private void ValidateRadioButtonSelection()
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Debes primero elegir cómo buscar elegir la opción APELLIDO antes de completar el campo.");
                DNI.Text = "0";
                apellido1.Text = string.Empty;
                //apellido1.Items.Clear();
            }
        }









































        private void CORREGIRERRORES_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.MediumPurple;
            var conexion = new ConexionMySQL();
            PCIAS.SelectedIndexChanged += PCIAS_SelectedIndexChanged;

            try
            {
                // Cargar ComboBox "apellido1"
                apellido1.DropDownStyle = ComboBoxStyle.DropDown;
                string consultaa = "SELECT personal.`apelldo y nombre` AS APELLIDO, personal.dni FROM personal ORDER BY APELLIDO DESC";
                List<string> valoresApellido = conexion.EjecutarConsulta(consultaa, "APELLIDO");
                List<string> valoresDNI = conexion.EjecutarConsulta(consultaa, "DNI");

                apellido1.Items.Clear();
                var diccionarioDNI = new Dictionary<string, string>();

                for (int i = 0; i < valoresApellido.Count; i++)
                {
                    diccionarioDNI[valoresDNI[i]] = valoresApellido[i];
                }

                apellido1.Items.AddRange(valoresApellido.ToArray());
                apellido1.Tag = diccionarioDNI;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox 'apellido1': " + ex.Message);
            }

            try
            {
                // Cargar ComboBox "LEY"
                LEY.DropDownStyle = ComboBoxStyle.DropDown;
                string consultas = "SELECT ley.ley , ley.IDLEY FROM ley ORDER BY LEY DESC";
                List<string> valoresLEY = conexion.EjecutarConsulta(consultas, "LEY");
                List<string> valoresIDLEY = conexion.EjecutarConsulta(consultas, "IDLEY");

                LEY.Items.Clear();
                var diccionarioLEY = new Dictionary<string, string>();

                for (int i = 0; i < valoresLEY.Count; i++)
                {
                    diccionarioLEY[valoresIDLEY[i]] = valoresLEY[i];
                }

                LEY.Items.AddRange(valoresLEY.ToArray());
                LEY.Tag = diccionarioLEY;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox 'LEY': " + ex.Message);
            }

            try
            {
                // Cargar ComboBox "PCIAS"
                PCIAS.DropDownStyle = ComboBoxStyle.DropDown;
                string consultat = "SELECT localidades1.provincia, localidades1.provincia_id FROM localidades1 GROUP BY localidades1.provincia, localidades1.provincia_id;";

                List<string> nombresProvincias = conexion.EjecutarConsulta(consultat, "provincia");

                PCIAS.Items.Clear();
                var diccionarioProvincias = new Dictionary<string, string>();

                foreach (var nombreProvincia in nombresProvincias)
                {
                    diccionarioProvincias[nombreProvincia] = ObtenerIdProvinciaDesdeNombre(nombreProvincia);
                }

                PCIAS.Items.AddRange(diccionarioProvincias.Keys.ToArray());
                PCIAS.Tag = diccionarioProvincias;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox 'PCIAS': " + ex.Message);
            }

            try
            {
                OCUPACION.DropDownStyle = ComboBoxStyle.DropDown;
                string consultaq = "SELECT OCUPACION.Ocupacion , OCUPACION.IDESPECIALIDAD FROM OCUPACION ORDER BY Ocupacion ASC"; // Cambiado a ASC para ordenar alfabéticamente
                List<string> valoresocupacion = conexion.EjecutarConsulta(consultaq, "Ocupacion");
                List<string> valoresIDESPECIALIDAD = conexion.EjecutarConsulta(consultaq, "IDESPECIALIDAD");

                OCUPACION.Items.Clear();
                var diccionarioOCUPACION = new Dictionary<string, string>();

                for (int i = 0; i < valoresocupacion.Count; i++)
                {
                    diccionarioOCUPACION[valoresIDESPECIALIDAD[i]] = valoresocupacion[i];
                }

                valoresocupacion.Sort(); // Ordenar alfabéticamente
                OCUPACION.Items.AddRange(valoresocupacion.ToArray());
                OCUPACION.Tag = diccionarioOCUPACION;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox 'OCUPACION': " + ex.Message);
            }

            try
            {
                // Cargar ComboBox "cmbColumna"
                // Cargar ComboBox "cmbColumna" alfabéticamente
                List<string> nombresColumnas = conexion.ObtenerNombresColumnasTablaPersonal();
                nombresColumnas = nombresColumnas.Where(columna => columna != "Activo").ToList();

                nombresColumnas.Sort(); // Ordenar alfabéticamente

                cmbColumna.Items.AddRange(nombresColumnas.ToArray());

                if (cmbColumna.Items.Count > 0)
                {
                    cmbColumna.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los nombres de columnas: {ex.Message}");
            }
            finally
            {
                // Liberar recursos
                conexion.Dispose();
            }
        }
        private string ObtenerIdProvinciaDesdeNombre(string nombreProvincia)
        {
            try
            {
                var conexion = new ConexionMySQL();
                // Consulta SQL para obtener el ID de la provincia a partir del nombre
                string consultaIdProvincia = $"SELECT provincia_id FROM localidades1 WHERE provincia = '{nombreProvincia}';";

                // Ejecutar la consulta para obtener el ID de la provincia
                List<string> idProvincia = conexion.EjecutarConsulta(consultaIdProvincia, "provincia_id");

                // Devolver el primer resultado (asumiendo que la consulta devuelve un solo resultado)
                return idProvincia.FirstOrDefault();
          
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el ID de la provincia: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                return "ID no encontrado";
            }
    
        }
        private void PCIAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = Color.MediumPurple;
                var conexion = new ConexionMySQL();
                // Obtener el nombre seleccionado de la provincia
                string nombreProvinciaSeleccionada = PCIAS.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(nombreProvinciaSeleccionada))
                {
                    // Recuperar el diccionario desde la propiedad Tag
                    var diccionarioProvincias = (Dictionary<string, string>)PCIAS.Tag;

                    // Obtener el ID de provincia usando el nombre de provincia seleccionado
                    string idProvinciaSeleccionada = diccionarioProvincias.ContainsKey(nombreProvinciaSeleccionada) ? diccionarioProvincias[nombreProvinciaSeleccionada] : "ID no encontrado";

                    // Consulta SQL para obtener los municipios de la provincia seleccionada
                    string consultaMunicipios = $"SELECT municipio, municipio_id FROM localidades1 WHERE provincia_id = '{idProvinciaSeleccionada}';";

                    // Obtener los valores de los municipios
                    List<string> valoresMunicipios = conexion.EjecutarConsulta(consultaMunicipios, "municipio");
                    List<string> valoresIdMunicipios = conexion.EjecutarConsulta(consultaMunicipios, "municipio_id");

                    Console.WriteLine("Provincia Seleccionada: " + idProvinciaSeleccionada);

                    // Limpiar ComboBox de municipios
                    PARTIDOS.Items.Clear();

                    // Llenar el ComboBox de municipios con los nuevos valores
                    var diccionarioMunicipios = new Dictionary<string, string>();
                    for (int i = 0; i < valoresMunicipios.Count; i++)
                    {
                        diccionarioMunicipios[valoresMunicipios[i]] = valoresIdMunicipios[i];
                    }

                    PARTIDOS.Items.AddRange(diccionarioMunicipios.Keys.ToArray());
                    PARTIDOS.Tag = diccionarioMunicipios; // Guardar el diccionario en el Tag para referencia futura
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox de municipios: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }
        private void PARTIDOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el municipio_id seleccionado
                var diccionarioMunicipios = (Dictionary<string, string>)PARTIDOS.Tag;
                string municipioIdSeleccionado = diccionarioMunicipios.ContainsKey(PARTIDOS.SelectedItem?.ToString()) ? diccionarioMunicipios[PARTIDOS.SelectedItem?.ToString()] : "ID no encontrado";
                var conexion = new ConexionMySQL();
                // Consulta SQL para obtener las localidades del municipio seleccionado
                string consultaLocalidades = $"SELECT localidades1.nombre, localidades1.idlocalidad FROM localidades1 WHERE municipio_id = '{municipioIdSeleccionado}';";

                // Obtener los valores de las localidades
                List<string> valoresLocalidades = conexion.EjecutarConsulta(consultaLocalidades, "nombre");
                List<string> valoresIdLocalidades = conexion.EjecutarConsulta(consultaLocalidades, "idlocalidad");

                // Limpiar ComboBox de localidades
                LOCALIDADES.Items.Clear();

                // Llenar el ComboBox de localidades con los nuevos valores
                var diccionarioLocalidades = new Dictionary<string, string>();
                for (int i = 0; i < valoresLocalidades.Count; i++)
                {
                    diccionarioLocalidades[valoresLocalidades[i]] = valoresIdLocalidades[i];
                }

                LOCALIDADES.Items.AddRange(diccionarioLocalidades.Keys.ToArray());
                LOCALIDADES.Tag = diccionarioLocalidades; // Guardar el diccionario en el Tag para referencia futura
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar los valores en el ComboBox de localidades: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }
        private void LOCALIDADES_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var conexion = new ConexionMySQL();
                // Obtener el localidad_id seleccionado
                var diccionarioLocalidades = (Dictionary<string, string>)LOCALIDADES.Tag;
                string localidadIdSeleccionado = diccionarioLocalidades.ContainsKey(LOCALIDADES.SelectedItem?.ToString()) ? diccionarioLocalidades[LOCALIDADES.SelectedItem?.ToString()] : "ID no encontrado";

                // Puedes usar localidadIdSeleccionado como desees
                Console.WriteLine("Localidad Seleccionada: " + localidadIdSeleccionado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el localidad_id seleccionado: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }
        private void cambio_Click(object sender, EventArgs e)
        {
            var conexion = new ConexionMySQL();
            string columna = cmbColumna.SelectedItem.ToString();
            string valorSeleccionado = cmbColumna.SelectedItem.ToString();
            // Evaluar el valor seleccionado y ejecutar el código correspondiente
            if (valorSeleccionado == "Sexo")
            {
                string nuevoValor = ""; // Declarar la variable fuera de los bloques if

                if (SEXO.ValueMember == "F")
                {
                    nuevoValor = "1";
                }
                else if (SEXO.ValueMember == "M")
                {
                    nuevoValor = "2";
                }

                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis));
            }
            else if (valorSeleccionado == "Ley")
            {
               // Cambia 'TuTabla' y el valor de id según tus necesidades

                string valorSeleccionado1 = LEY.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(valorSeleccionado1))
                {
                    // Obtener el diccionario del Tag
                    Dictionary<string, string> diccionarioLEY = LEY.Tag as Dictionary<string, string>;

                    // Verificar si el valor seleccionado existe en el diccionario
                    if (diccionarioLEY != null && diccionarioLEY.ContainsValue(valorSeleccionado1))
                    {
                        // Obtener la clave (IDESPECIALIDAD) asociada al valor seleccionado (Ocupacion)
                        string idLEY = diccionarioLEY.FirstOrDefault(x => x.Value == valorSeleccionado1).Key;

                        // Imprimir en la consola el valor de idEspecialidad
                        Console.WriteLine("Valor de IDOCUPACION obtenido del diccionario: " + idLEY);

                        string nuevoValor = idLEY;

                        // Llamada al método de la clase ManejadorModificacion
                        conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
                        Console.WriteLine("Valor Seleccionado en idEspecialidad: " + nuevoValor);
                    }
                    else
                    {
                        Console.WriteLine("El valor seleccionado en LEY no existe en el diccionario.");
                    }
                }
                else
                {
                    Console.WriteLine("El valor seleccionado en LEY es nulo o vacío. Mensaje adicional aquí.");
                }
            }
            else if (valorSeleccionado == "Regimen Horario")
            {
                string nuevoValor = REGIMENHORARIO.ValueMember;
                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
            }
            else if (valorSeleccionado == "ocupacion")
            {
                string valorSeleccionado1 = OCUPACION.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(valorSeleccionado1))
                {
                    // Obtener el diccionario del Tag
                    Dictionary<string, string> diccionarioOCUPACION = OCUPACION.Tag as Dictionary<string, string>;
                    // Verificar si el valor seleccionado existe en el diccionario
                    if (diccionarioOCUPACION != null && diccionarioOCUPACION.ContainsValue(valorSeleccionado1))
                    {
                        // Obtener la clave (IDESPECIALIDAD) asociada al valor seleccionado (Ocupacion)
                        string idEspecialidad = diccionarioOCUPACION.FirstOrDefault(x => x.Value == valorSeleccionado1).Key;
                        // Imprimir en la consola el valor de idEspecialidad
                        Console.WriteLine("Valor de IDOCUPACION obtenido del diccionario: " + idEspecialidad);
                        string nuevoValor = idEspecialidad;
                        // Llamada al método de la clase ManejadorModificacion
                        conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
                        Console.WriteLine("Valor Seleccionado en IDOCUPACION: " + nuevoValor);
                    }
                    else
                    {
                        Console.WriteLine("El valor seleccionado en OCUPACION no existe en el diccionario.");
                    }
                }
                else
                {
                    Console.WriteLine("El valor seleccionado en OCUPACION es nulo o vacío. Mensaje adicional aquí.");
                }
            }
            else if (valorSeleccionado == "provincia")
            {
                string nuevoValor = PCIAS.ValueMember;
                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades

            }
            else if (valorSeleccionado == "Partido")
            {
                string nuevoValor = PARTIDOS.ValueMember;
                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
            }
            else if (valorSeleccionado == "Localidad")
            {
                string nuevoValor = LOCALIDADES.ValueMember;
                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
            }
            else
            {
                string nuevoValor = txtNuevoValor.Text;
                // Llamada al método de la clase ManejadorModificacion
                conexion.ModificarRegistro("personal", columna, nuevoValor, Convert.ToInt32(_dnis)); // Cambia 'TuTabla' y el valor de id según tus necesidades
            }
            ConstruirConsulta();
        }
        private void CmbColumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el valor seleccionado en el ComboBox principal
            string seleccion = cmbColumna.SelectedItem?.ToString();

            // Verificar si la selección es nula o vacía antes de continuar
            if (string.IsNullOrEmpty(seleccion))
            {
                // Manejar el caso en que la selección es nula o vacía
                return;
            }

            // Deshabilitar todos los ComboBox
            SEXO.Enabled = false;
            REGIMENHORARIO.Enabled = false;
            LEY.Enabled = false;
            PCIAS.Enabled = false;
            PARTIDOS.Enabled = false;
            LOCALIDADES.Enabled = false;
            OCUPACION.Enabled = false;

            // Verificar el valor seleccionado y habilitar el ComboBox correspondiente
            switch (seleccion.ToLower())
            {
                case "sexo":
                    SEXO.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "provincia":
                    PCIAS.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "localidad":
                    LOCALIDADES.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "ocupacion":
                    OCUPACION.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "partido":
                    PARTIDOS.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "regimen horario":
                    REGIMENHORARIO.Enabled = true;
                    ConstruirConsulta();
                    break;
                case "ley":
                    LEY.Enabled = true;
                    ConstruirConsulta();
                    break;
                default:
                    // Manejar otros casos si es necesario
                    break;
            }
        }
        private void EjecutarConsulta(string consulta)
        {
            try
            {
                // Utilizar la instancia de ConexionMySQL para ejecutar la consulta
                using (ConexionMySQL conexion = new ConexionMySQL())
                {
                    DataTable dataTable = conexion.EjecutarConsulta(consulta);

                    // Limpia las filas existentes en el ListView
                    datosactualizados.Items.Clear();
                    datosactualizados.Columns.Clear(); // Limpiar las columnas

                    // Agregar las columnas al ListView si aún no se han agregado
                    if (dataTable.Columns.Count > 0)
                    {
                        // Agregar las columnas al ListView
                        foreach (DataColumn columna in dataTable.Columns)
                        {
                            datosactualizados.Columns.Add(columna.ColumnName);
                        }

                        // Agregar las filas a ListView
                        foreach (DataRow fila in dataTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(fila[0].ToString());
                            // Agregar más subítems según sea necesario
                            for (int i = 1; i < dataTable.Columns.Count; i++)
                            {
                                item.SubItems.Add(fila[i].ToString());
                            }
                            datosactualizados.Items.Add(item);
                        }

                        // Autoajustar el ancho de las columnas al tamaño del encabezado
                        foreach (ColumnHeader columna in datosactualizados.Columns)
                        {
                            columna.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConstruirConsulta()
        {
            try
            {
                // Obtener el nombre de la columna seleccionada en cmbColumna
                string columnaSeleccionada = cmbColumna.SelectedItem.ToString();

                // Construir la consulta SQL basada en el tipo de columna seleccionada
                string consulta = ConstruirConsultaSegunTipo(columnaSeleccionada);

                // Ejecutar la consulta y actualizar el ListView
                EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al construir la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para construir la consulta según el tipo de columna
        private string ConstruirConsultaSegunTipo(string nombreColumna)
        {
            switch (nombreColumna.ToLower())
            {
                case "sexo":
                    return $"SELECT personal.`{nombreColumna}` as 'IDENTIFICADOR' , sexo.SEXO FROM personal INNER JOIN sexo ON personal.SEXO = sexo.ID WHERE dni = {_dnis} ";
                case "ocupacion":
                    return $"SELECT personal.`{nombreColumna}` as 'ID OCUPACION', ocupacion.Ocupacion as 'OCUPACION' FROM personal INNER JOIN ocupacion ON personal.ocupacion = ocupacion.IDESPECIALIDAD WHERE dni = {_dnis}";
                case "ley":
                    return $"SELECT personal.`{nombreColumna}` as 'ID LEY', ley.Ley as 'LEY' FROM ley INNER JOIN personal ON ley.IDLEY = personal.Ley WHERE dni = {_dnis}";
                case "Regimen Horario":
                    return $"SELECT personal.`{nombreColumna}` FROM personal WHERE dni = {_dnis}";
                case "provincia":
                    return $"SELECT personal.`{nombreColumna}` as 'PROVINCIA', localidades1.municipio as 'PARTIDO', localidades1.nombre as 'LOCALIDAD' FROM personal INNER JOIN localidades1 ON (personal.Partido = localidades1.municipio_id) AND (personal.Localidad = localidades1.idlocalidad) AND (personal.`{nombreColumna}`= localidades1.provincia_id) WHERE dni = {_dnis}";

                // Puedes agregar más casos para otros tipos de columnas aquí...
                default:
                    return $"SELECT personal.`{nombreColumna}` FROM personal WHERE dni = {_dnis}";

                    // Tratamiento por defecto si el tipo de columna no se reconoce
                    //  throw new ArgumentException("Tipo de columna no reconocido");

            }

        }
    }
}