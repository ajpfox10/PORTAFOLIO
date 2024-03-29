﻿using iText.StyledXmlParser.Jsoup.Select;
using MySql.Data.MySqlClient;
 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WindowsFormsApp1
    {
        public class ConexionMySQL : IDisposable
        {
            private readonly string connectionString;
            public MySqlConnection conexion;
     
        public ConexionMySQL()
            {
                connectionString = "Server=127.0.0.1;port=3306;username=superusuario;password=tronador101110;database=personalv3;";
                conexion = new MySqlConnection(connectionString);
            }
        public DataTable EjecutarConsulta(string consulta)
        {
            DataTable dataTable = new DataTable();

            try
            {
                Conectar();

                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return dataTable;
        }
        public void Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }
        public MySqlConnection GetConnection()
        {
            return conexion;
        }
        public void Dispose()
        {
            if (conexion != null)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }
        public IQueryable<string> ObtenerUsuarios()
            {
                var usuarios = Enumerable.Empty<string>().AsQueryable();
                Conectar();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    MySqlCommand comando = new MySqlCommand("SELECT nameuser FROM Usuarios", conexion);
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        usuarios = usuarios.Concat(new[] { reader.GetString(0) });
                    }
                    reader.Close();
                }
            Dispose();
                return usuarios;
            }
        public void ActualizarCierreDeCitacion(int id)
        {
            // Obtener la fecha y hora actual en el formato deseado
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // Construir la consulta SQL para actualizar el campo "cierredecitacion"
            string query = "UPDATE citaciones SET cierredecitacion = @fechaActual WHERE id = @id";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@fechaActual", fechaActual);
            cmd.Parameters.AddWithValue("@id", id);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("La citación con ID " + id + " ha sido actualizada con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se actualizó ninguna fila
                MessageBox.Show("No se pudo actualizar la citación con ID " + id + ".", "Error al actualizar");
            }
        }        
        public void AgregarConsulta(string motivo, string explicacion, string dni, string atendidoPor)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO consultas (MOTIVODECONSULTA, EXPLICACIONDADA, DNI, ATENDIDOPOR) " +
                           "VALUES (@motivo, @explicacion, @dni, @atendidoPor)";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@motivo", motivo);
            cmd.Parameters.AddWithValue("@explicacion", explicacion);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", atendidoPor);

            // Abrir la conexión a la base de datos
            Conectar();

            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();

            // Cerrar la conexión a la base de datos
            Dispose();

            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }
        public void InsertarDatos(string calle1, string numero1, string piso1, string depto1, string partido, string localidad, string telefono, string email, string dni, string tele, string otrosss)
        {

            // Construir la consulta SQL para insertar los datos en la tabla "form3"
            string query = "INSERT INTO form3 (calle, numero, piso, depto, partido, localidad, TELCELCONTA, EMAILOFICIAL, DNIAGENTE, telemergen, otras) " +
                           "VALUES (@calle, @numero, @piso, @depto, @partido, @localidad, @telefono, @email, @dni, @tele, @otros )";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@calle", calle1);
            cmd.Parameters.AddWithValue("@numero", numero1);
            cmd.Parameters.AddWithValue("@piso", piso1);
            cmd.Parameters.AddWithValue("@depto", depto1);
            cmd.Parameters.AddWithValue("@partido", partido);
            cmd.Parameters.AddWithValue("@localidad", localidad);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tele", tele);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@otros", otrosss);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo insertar
                MessageBox.Show("No se pudo insertar los datos.", "Error al insertar");
            }
        }       
        public void CargarResultadosConsulta(string consulta, ListView controlListView)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            controlListView.Clear();
            // Obtiene los nombres de los campos de la consulta
            List<string> nombresCampos = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                nombresCampos.Add(reader.GetName(i));
            }
            // Agrega los nombres de los campos como títulos de las columnas en el ListView
            controlListView.Columns.Clear();
            foreach (string nombreCampo in nombresCampos)
            {
                controlListView.Columns.Add(nombreCampo);
            }
            // Agrega los datos de las filas al ListView
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader[0].ToString());

                for (int i = 1; i < reader.FieldCount; i++)
                {
                    item.SubItems.Add(reader[i].ToString());
                }
                controlListView.Items.Add(item);
            }
            controlListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            reader.Close();
            conn.Close();
    }
        public void ActualizarDatos(string calle1, string numero1, string piso1, string depto1, string partido, string localidad, string telefono, string email, string ID, string tele, string otross)
        {
            // Construir la consulta SQL para actualizar los datos en la tabla "form3"
            string query = "UPDATE form3 SET calle = @calle, numero = @numero, piso = @piso, depto = @depto, partido = @partido, " +
                "localidad = @localidad, telcelconta = @telefono, emailoficial = @email, TELEMERGEN = @tele, " +
                "otras = @otro WHERE ID = @ID";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@calle", calle1);
            cmd.Parameters.AddWithValue("@numero", numero1);
            cmd.Parameters.AddWithValue("@piso", piso1);
            cmd.Parameters.AddWithValue("@depto", depto1);
            cmd.Parameters.AddWithValue("@partido", partido);
            cmd.Parameters.AddWithValue("@localidad", localidad);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tele", tele);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@otro", otross);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo actualizar
                MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
            }
        }
        public void InsertarDatosdomicilio(string DNIAGENTE1, string PARENTESCO1, string NOMBREYAPELLIDO1, string VIVE1, DateTime FECHA1, string JUB1, string CAJAJUBILACION1, string PROFESION1, string SEXO1)
        {

            // Construir la consulta SQL para insertar los datos en la tabla "form3"
            string query = "INSERT INTO form1 (DNIAGENTE, PARENTESCO, NOMBREYAPELLIDO, VIVE, FECHA, JUB, CAJAJUBILACION, PROFESION, SEXO) " +
                           "VALUES (@DNIAGNTE, @PARENTESCO, @NOMBREYAPELLIDO, @VIVE, @FECHA, @JUB, @CAJAJUBILACION, @PROFESION, @SEXO)";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@DNIAGNTE", DNIAGENTE1);
            cmd.Parameters.AddWithValue("@PARENTESCO", PARENTESCO1);
            cmd.Parameters.AddWithValue("@NOMBREYAPELLIDO", NOMBREYAPELLIDO1);
            cmd.Parameters.AddWithValue("@VIVE", VIVE1);
            cmd.Parameters.AddWithValue("@FECHA", FECHA1);
            cmd.Parameters.AddWithValue("@JUB", JUB1);
            cmd.Parameters.AddWithValue("@CAJAJUBILACION", CAJAJUBILACION1);
            cmd.Parameters.AddWithValue("@PROFESION", PROFESION1);
            cmd.Parameters.AddWithValue("@sexo", SEXO1);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo insertar
                MessageBox.Show("No se pudo insertar los datos.", "Error al insertar");
            }
        }
        public void ActualizarCIERREDEPEDIDO(int id,int dniss,string entregada)
        {
            // Obtener la fecha y hora actual en el formato deseado
            string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Construir la consulta SQL para actualizar el campo "cierredecitacion"
            string query = "UPDATE pedidos SET fechaactual = @fechaActual, agenteqretiro= @dnis, activa=@ENTREGADA WHERE id = @id";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@fechaActual", fechaActual);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@dnis", dniss);
            cmd.Parameters.AddWithValue("@ENTREGADA", entregada);
            // Abrir la conexión a la base de datos
            Conectar();

            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();

            // Cerrar la conexión a la base de datos
            Dispose();

            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("El pedido  con ID " + id + " ha sido actualizado con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se actualizó ninguna fila
                MessageBox.Show("No se pudo actualizar el pedido con ID " + id + ".", "Error al actualizar");
            }
        }
        public void ActualizarDatosFAMILIA(string PARENTESCOSS, string NOMBRESS, string VIVESS, DateTime FECHASSS, string CAJAJUBILACIONS, string PROFESIONS, string SEXOS, string ID1, string JUBS)
        {
            string query = "UPDATE form1 SET parentesco = @parentesco, NOMBREYAPELLIDO = @NOMBREYAPELLIDO, VIVE = @VIVE, FECHA = @FECHA, CAJAJUBILACION = @CAJAJUBILACION, JUB=@JUBS, " +
                "PROFESION = @PROFESION, SEXO = @SEXO " +
                "WHERE idx = @ID1";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@parentesco", PARENTESCOSS);
            cmd.Parameters.AddWithValue("@NOMBREYAPELLIDO", NOMBRESS);
            cmd.Parameters.AddWithValue("@VIVE", VIVESS);
            cmd.Parameters.AddWithValue("@FECHA", FECHASSS);
            cmd.Parameters.AddWithValue("@CAJAJUBILACION", CAJAJUBILACIONS);
            cmd.Parameters.AddWithValue("@PROFESION", PROFESIONS);
            cmd.Parameters.AddWithValue("@SEXO", SEXOS);
            cmd.Parameters.AddWithValue("@ID1", ID1);
            cmd.Parameters.AddWithValue("@JUBS", JUBS);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo actualizar
                MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
            }
        }
        public void ActualizarDatosVida1(string A1, string A2, string A3, string A4, DateTime A5, string A6, string A7, string A8, string A9, string A10, string A11, string A12, string A13, string A14, string A15, string A16, string A17, string A18, string A19, string A20, DateTime A21, string A22, string A23, string A24, string A25, string A26)
        {
            string query = "UPDATE form2 SET " +
            "DNIDELAGENTE = @DNI, " +
            "NACIOPAIS = @NACIO_EN, " +
            "PROVINCIADENAC = @PCIA_DE_NACIMIENTO, " +
            "PARTIDO = @PARTIDO_DE_NACIMIENTO, " +
            "FCHANACI = @FECHA_DE_NACIMIENTO, " +
            "ESTADOCIVIL = @ESTADO_CIVIL, " +
            "MAXIMONIVELESTUDIOS = @MAXIMO_NIVEL_DE_ESTUDIOS, " +
            "TITULOSECUNDARIO = @TITULO_SECUNDARIO, " +
            "OTORGADOPORSECUNDARIO = @ESCUELA_QUE_OTORGO_EL_TITULO_SECUNDARIO, " +
            "TITULOTECNICO = @TITULO_TECNICO, " +
            "TIULOTENICOOTORGADPOR = @ESCUELA_QUE_OTORGO_EL_TITULO_TECNICO, " +
            "TITULOUNIVERSITARIO = @TITULO_UNIVERSITARIO, " +
            "TITULOUNIVERSITARIOOTORGADOPOR = @UNIVERSIDAD_QUE_OTORGO_EL_TITULO, " +
            "PRESTOSERVICIOS = @PRESTO_SERVICIOS_MILITARES, " +
            "ARMA = @ARMA, " +
            "ESPECIALIDADARMAMILITAR = @ESPECIALIDAD_MILITAR, " +
            "GRADO = @GRADO, " +
            "DESTINO = @DESTINO, " +
            "MATRICULA = @MATRICULA, " +
            "cartaciudadania = @CARTA_DE_CIUDADANIA, " +
            "fechadeciudadania = @FECHA_DE_CIUDADANIA, " +
            "OTORGADACIUDAD = @OTORGO_EN, " +
            "ESTUDIOSENCURSO=@ESTUDIO," +
            "TITULODELESTUDIOENCURSO=@QESTUDIA," +
            "causalexcepcion=@CAUSAL," +
            "JUEZQLAOTORGO = @JUEZ_QUE_OTORGO_LA_CARTA ";
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@DNI", A1);
                cmd.Parameters.AddWithValue("@NACIO_EN", A2);
                cmd.Parameters.AddWithValue("@PCIA_DE_NACIMIENTO", A3);
                cmd.Parameters.AddWithValue("@PARTIDO_DE_NACIMIENTO", A4);
                cmd.Parameters.AddWithValue("@FECHA_DE_NACIMIENTO", A5);
                cmd.Parameters.AddWithValue("@ESTADO_CIVIL", A6);
                cmd.Parameters.AddWithValue("@MAXIMO_NIVEL_DE_ESTUDIOS", A7);
                cmd.Parameters.AddWithValue("@TITULO_SECUNDARIO", A8);
                cmd.Parameters.AddWithValue("@ESCUELA_QUE_OTORGO_EL_TITULO_SECUNDARIO", A9);
                cmd.Parameters.AddWithValue("@TITULO_TECNICO", A10);
                cmd.Parameters.AddWithValue("@ESCUELA_QUE_OTORGO_EL_TITULO_TECNICO", A11);
                cmd.Parameters.AddWithValue("@TITULO_UNIVERSITARIO", A12);
                cmd.Parameters.AddWithValue("@UNIVERSIDAD_QUE_OTORGO_EL_TITULO", A13);
                cmd.Parameters.AddWithValue("@PRESTO_SERVICIOS_MILITARES", A14);
                cmd.Parameters.AddWithValue("@ARMA", A15);
                cmd.Parameters.AddWithValue("@ESPECIALIDAD_MILITAR", A16);
                cmd.Parameters.AddWithValue("@GRADO", A17);
                cmd.Parameters.AddWithValue("@DESTINO", A18);
                cmd.Parameters.AddWithValue("@MATRICULA", A19);
                cmd.Parameters.AddWithValue("@CARTA_DE_CIUDADANIA", A20);
                cmd.Parameters.AddWithValue("@FECHA_DE_CIUDADANIA", A21);
                cmd.Parameters.AddWithValue("@OTORGO_EN", A22);
                cmd.Parameters.AddWithValue("@JUEZ_QUE_OTORGO_LA_CARTA", A23);
                cmd.Parameters.AddWithValue("@ESTUDIO", A24);
                cmd.Parameters.AddWithValue("@QESTUDIA", A25);
                cmd.Parameters.AddWithValue("@CAUSAL", A26);
                // Abrir la conexión a la base de datos
                Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
            }
        }
    }
        public void INSERTATDatosVida1(string A1, string A2, string A3, string A4, DateTime A5, string A6, string A7, string A8, string A9, string A10, string A11, string A12, string A13, string A14, string A15, string A16, string A17, string A18, string A19, string A20, DateTime A21, string A22, string A23, string A24, string A25, string A26)
        {
            string query = "INSERT INTO form2 (DNIDELAGENTE, NACIOPAIS, PROVINCIADENAC, PARTIDO, FCHANACI, ESTADOCIVIL, MAXIMONIVELESTUDIOS, TITULOSECUNDARIO, OTORGADOPORSECUNDARIO, TITULOTECNICO, TIULOTENICOOTORGADPOR, TITULOUNIVERSITARIO, TITULOUNIVERSITARIOOTORGADOPOR, PRESTOSERVICIOS, ARMA, ESPECIALIDADARMAMILITAR, GRADO, DESTINO, MATRICULA, cartaciudadania, fechadeciudadania, OTORGADACIUDAD, JUEZQLAOTORGO, ESTUDIOSENCURSO, TITULODELESTUDIOENCURSO, causalexcepcion ) " +
            "VALUES (@DNI, @NACIO_EN, @PCIA_DE_NACIMIENTO, @PARTIDO_DE_NACIMIENTO, @FECHA_DE_NACIMIENTO, @ESTADO_CIVIL, @MAXIMO_NIVEL_DE_ESTUDIOS, @TITULO_SECUNDARIO, @ESCUELA_QUE_OTORGO_EL_TITULO_SECUNDARIO, @TITULO_TECNICO, @ESCUELA_QUE_OTORGO_EL_TITULO_TECNICO, @TITULO_UNIVERSITARIO, @UNIVERSIDAD_QUE_OTORGO_EL_TITULO, @PRESTO_SERVICIOS_MILITARES, @ARMA, @ESPECIALIDAD_MILITAR, @GRADO, @DESTINO, @MATRICULA, @CARTA_DE_CIUDADANIA, @FECHA_DE_CIUDADANIA, @OTORGO_EN, @JUEZ_QUE_OTORGO_LA_CARTA, @ESTUDIOENCURSO, @QESTUDIA, @CAUSAL)";
            //"TITULODELESTUDIOENCURSO=@QESTUDIA," +
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@DNI", A1);
                cmd.Parameters.AddWithValue("@NACIO_EN", A2);
                cmd.Parameters.AddWithValue("@PCIA_DE_NACIMIENTO", A3);
                cmd.Parameters.AddWithValue("@PARTIDO_DE_NACIMIENTO", A4);
                cmd.Parameters.AddWithValue("@FECHA_DE_NACIMIENTO", A5);
                cmd.Parameters.AddWithValue("@ESTADO_CIVIL", A6);
                cmd.Parameters.AddWithValue("@MAXIMO_NIVEL_DE_ESTUDIOS", A7);
                cmd.Parameters.AddWithValue("@TITULO_SECUNDARIO", A8);
                cmd.Parameters.AddWithValue("@ESCUELA_QUE_OTORGO_EL_TITULO_SECUNDARIO", A9);
                cmd.Parameters.AddWithValue("@TITULO_TECNICO", A10);
                cmd.Parameters.AddWithValue("@ESCUELA_QUE_OTORGO_EL_TITULO_TECNICO", A11);
                cmd.Parameters.AddWithValue("@TITULO_UNIVERSITARIO", A12);
                cmd.Parameters.AddWithValue("@UNIVERSIDAD_QUE_OTORGO_EL_TITULO", A13);
                cmd.Parameters.AddWithValue("@PRESTO_SERVICIOS_MILITARES", A14);
                cmd.Parameters.AddWithValue("@ARMA", A15);
                cmd.Parameters.AddWithValue("@ESPECIALIDAD_MILITAR", A16);
                cmd.Parameters.AddWithValue("@GRADO", A17);
                cmd.Parameters.AddWithValue("@DESTINO", A18);
                cmd.Parameters.AddWithValue("@MATRICULA", A19);
                cmd.Parameters.AddWithValue("@CARTA_DE_CIUDADANIA", A20);
                cmd.Parameters.AddWithValue("@FECHA_DE_CIUDADANIA", A21);
                cmd.Parameters.AddWithValue("@OTORGO_EN", A22);
                cmd.Parameters.AddWithValue("@JUEZ_QUE_OTORGO_LA_CARTA", A23);
                cmd.Parameters.AddWithValue("@ESTUDIOENCURSO", A24);
                cmd.Parameters.AddWithValue("@QESTUDIA", A25);
                cmd.Parameters.AddWithValue("@CAUSAL", A26);
                // Abrir la conexión a la base de datos
                Conectar();
                // Ejecutar la consulta SQL
                int filasAfectadas = cmd.ExecuteNonQuery();
                // Cerrar la conexión a la base de datos
                Dispose();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
                }
            }
        }
        public void INSERTARDATOSIFGRA(string A2, string A3, DateTime A4, int A5, int A6, string A8, string A9, string A11, string A12)
        {
            string query = "INSERT INTO cargosdeinicio (cargosdeinicio.CARGODEINICIOS, cargosdeinicio.MINISTERIODEDESIGNACION, cargosdeinicio.FECHADEDESIGNACION, cargosdeinicio.CATEGORIA, cargosdeinicio.REGIMENHORARIO, cargosdeinicio.DEPENDENCIA, cargosdeinicio.RESOLUCION, cargosdeinicio.DNIAGENTE, cargosdeinicio.ifgradenombramiento ) " +
            "VALUES (@CARGODEINICIOS, @MINISTERIOSDEDESIGNACION, @FECHADEDESIGNACION, @CATEGORIA, @REGIMENHORARIO, @DEPENDENCIA, @RESOLUCION, @DNIAGENTE, @if)";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@CARGODEINICIOS", A2);
                cmd.Parameters.AddWithValue("@MINISTERIOSDEDESIGNACION", A3);
                cmd.Parameters.AddWithValue("@FECHADEDESIGNACION", A4);
                cmd.Parameters.AddWithValue("@CATEGORIA", A5);
                cmd.Parameters.AddWithValue("@REGIMENHORARIO", A6);
                cmd.Parameters.AddWithValue("@DEPENDENCIA", A8);
                cmd.Parameters.AddWithValue("@RESOLUCION", A9);
                cmd.Parameters.AddWithValue("@DNIAGENTE", A11);
                cmd.Parameters.AddWithValue("@if", A12);

                // Abrir la conexión a la base de datos
                Conectar();
                // Ejecutar la consulta SQL
                int filasAfectadas = cmd.ExecuteNonQuery();
                // Cerrar la conexión a la base de datos
                Dispose();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
                }
            }
        }
        public void INSERTARDATOSBONIFICACIONES(DateTime A2, DateTime A3, DateTime A4, string A5, string A6, string A8, int A9, string A11, string A12)
        {
            string query = "INSERT INTO BONIFICACIONES (bonificaciones.FECHAALTA, bonificaciones.FECHABAJA, bonificaciones.FECHA, bonificaciones.DECRETO, bonificaciones.MOTIVO, bonificaciones.EXPEDIENTE, bonificaciones.AÑO, bonificaciones.OBSERVACIONES, bonificaciones.DNIAGENTE ) " +
                       "VALUES (@FECHAALTA, @FECHABAJA, @FECHAD, @DECRETO, @MOTIVO, @EXPEDIENTE, @AÑO, @OBSERVACIONES, @DNIAGENTE)";
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@FECHAALTA", A2);
                cmd.Parameters.AddWithValue("@FECHABAJA", A3);
                cmd.Parameters.AddWithValue("@FECHAD", A4);
                cmd.Parameters.AddWithValue("@DECRETO", A5);
                cmd.Parameters.AddWithValue("@MOTIVO", A6);
                cmd.Parameters.AddWithValue("@EXPEDIENTE", A8);
                cmd.Parameters.AddWithValue("@AÑO", A9);
                cmd.Parameters.AddWithValue("@OBSERVACIONES", A11);
                cmd.Parameters.AddWithValue("@DNIAGENTE", A12);

                // Abrir la conexión a la base de datos
                Conectar();
                // Ejecutar la consulta SQL
                int filasAfectadas = cmd.ExecuteNonQuery();
                // Cerrar la conexión a la base de datos
                Dispose();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
                }
            }
        }
        public void ActualizarDatosbonificacioness(DateTime A2, DateTime A3, DateTime A4, string A5, string A6, string A7, int A8, string A9, string A10)
        {
            string query = "UPDATE bonificaciones SET FECHAALTA = @FECHAALTA, FECHABAJA = @FECHABAJA, FECHA = @FECHA, DECRETO = @DECRETO, MOTIVO = @MOTIVO, EXPEDIENTE=@EXPEDIENTE, AÑO=@AÑO, OBSERVACIONES=@OBSERVACIONES " +
                "WHERE ID = @ID";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@FECHAALTA", A2);
            cmd.Parameters.AddWithValue("@FECHABAJA", A3);
            cmd.Parameters.AddWithValue("@FECHA", A4);
            cmd.Parameters.AddWithValue("@DECRETO", A5);
            cmd.Parameters.AddWithValue("@MOTIVO", A6);
            cmd.Parameters.AddWithValue("@EXPEDIENTE", A7);
            cmd.Parameters.AddWithValue("@AÑO", A8);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", A9);
            cmd.Parameters.AddWithValue("@ID", A10);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo actualizar
                MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
            }
        }
        public void ActualizarDatosdesignaciones(string A2, string A3, DateTime A4, int A5, int A6, DateTime A7, string A8, string A9, string A10, string A12)
        {
            string query = "UPDATE cargosdeinicio SET CARGODEINICIOS = @FECHAALTA, MINISTERIODEDESIGNACION = @FECHABAJA, FECHADEDESIGNACION = @FECHA, CATEGORIA = @DECRETO, REGIMENHORARIO = @MOTIVO, FECHADEBAJA=@EXPEDIENTE, DEPENDENCIA=@DEPENDENCIA, RESOLUCION=@AÑO, MOTIVODEBAJA=@OBSERVACIONES, IFGRADENOMBRAMIENTO=@IFGRA" +
                "WHERE ID = @ID";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@FECHAALTA", A2);
            cmd.Parameters.AddWithValue("@FECHABAJA", A3);
            cmd.Parameters.AddWithValue("@FECHA", A4);
            cmd.Parameters.AddWithValue("@DECRETO", A5);
            cmd.Parameters.AddWithValue("@MOTIVO", A6);
            cmd.Parameters.AddWithValue("@EXPEDIENTE", A7);
            cmd.Parameters.AddWithValue("@DEPENDENCIA", A8) ;
            cmd.Parameters.AddWithValue("@AÑO", A9);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", A10);
            cmd.Parameters.AddWithValue("@IFGRA", A12);

            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("Los datos han sido actualizados con éxito.", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se pudo actualizar
                MessageBox.Show("No se pudo actualizar los datos.", "Error al actualizar");
            }
        }
         // Método para ejecutar una consulta SQL y obtener una lista de valores de una columna específica
        public List<string> EjecutarConsulta(string consulta, string nombreColumna)
            {
                List<string> valoresColumna = new List<string>();

                try
                {
                    Conectar();
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    MySqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal(nombreColumna)))
                        {
                            valoresColumna.Add(reader[nombreColumna].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
                }
                finally
                {
                    if (conexion.State == ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }

                return valoresColumna;
            }
        public void Agregarnotasexpedientes(long dni, string atendidoPor, string notanumero, string año, string reparticion, string memo, string save)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO ccoodegdeba (agente, agentequetramito, notanumero, año, memo, reparticion, save) " +
                           "VALUES (@dni, @atendidoPor, @notanumero, @año, @memo, @reparticion, @save)";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", atendidoPor);
            cmd.Parameters.AddWithValue("@notanumero", notanumero);
            cmd.Parameters.AddWithValue("@año", año);
            cmd.Parameters.AddWithValue("@reparticion", reparticion);
            cmd.Parameters.AddWithValue("@memo", memo);
            cmd.Parameters.AddWithValue("@save", save);
   
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }
        public void Agregarexpedientes(long dni, string atendidoPor, string notanumero, string año, string memo, string save)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO expedientes (agente, agentequetramito, año, expedientenumero, memo, archivo) " +
                           "VALUES (@dni, @atendidoPor, @año, @notanumero, @memo, @save)";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", atendidoPor);
            cmd.Parameters.AddWithValue("@notanumero", notanumero);
            cmd.Parameters.AddWithValue("@año", año);
            cmd.Parameters.AddWithValue("@memo", memo);
            cmd.Parameters.AddWithValue("@save", save);

            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }
        public void CARGADECITACION(long dni, string CITADOPOR, string MOTIVACION, string CITACIONACTIVA, DateTime fechadecitacion)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO CITACIONES (DNI, CITADOPOR, MOTIVODECITACION, CITACIONACTIVA, fechadecitacion) " +
                           "VALUES (@dni, @atendidoPor, @año, @notanumero, @memo";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", CITADOPOR);
            cmd.Parameters.AddWithValue("@notanumero", MOTIVACION);
            cmd.Parameters.AddWithValue("@año", CITACIONACTIVA);
            cmd.Parameters.AddWithValue("@memo", fechadecitacion);
          

            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }
        public IQueryable<string> certificadodetrabajo(long dni)
        {
            List<string> resultados = new List<string>();

            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "SELECT personal.`apelldo y nombre`, personal.dni, ocupacion.Ocupacion, personal.`Fecha de Ingreso`, personal.fechadenom, personal.`Regimen Horario`, ley.Ley, personal.Legajo, personal.dependencia FROM (ley INNER JOIN personal ON ley.IDLEY = personal.Ley) INNER JOIN ocupacion ON personal.ocupacion = ocupacion.IDESPECIALIDAD WHERE personal.dni = @dni";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@dni", dni);

            try
            {
                // Abrir la conexión a la base de datos
                Conectar();

                // Ejecutar la consulta y obtener un lector de datos
                using (var reader = cmd.ExecuteReader())
                {
                    // Verificar si hay filas en el resultado
                    if (reader.HasRows)
                    {
                        // Iterar a través de las filas y agregar los resultados a la lista
                        while (reader.Read())
                        {
                            // Puedes ajustar este código según la estructura de tu consulta SQL
                            resultados.Add(reader["apelldo y nombre"].ToString());
                            resultados.Add(reader["dni"].ToString());
                            resultados.Add(reader["Ocupacion"].ToString());
                            resultados.Add(reader["Fecha de Ingreso"].ToString());
                            resultados.Add(reader["fechadenom"].ToString());
                            resultados.Add(reader["Regimen Horario"].ToString());
                            resultados.Add(reader["Ley"].ToString());
                            resultados.Add(reader["Legajo"].ToString());
                            resultados.Add(reader["Dependencia"].ToString());
                        }
                    }
                }
            }
            finally
            {
                // Asegurarse de cerrar la conexión después de su uso
                Dispose();
            }

            return resultados.AsQueryable();
        }
        public void ActualizarESTADOAGENTE(int activo, long _dniss)
        {
            // Construir la consulta SQL para actualizar el campo "cierredecitacion"
            string query = "UPDATE personal SET activo = @activo WHERE dni = @dnis";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Parameters.AddWithValue("@dnis", _dniss);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("El AGENTE HA SI DADO DE BAJA CONTROLE LA BAJA EN SIAPE , SISTEMA DE SUELDO", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se actualizó ninguna fila
                MessageBox.Show("No se pudo actualizar la baja del agente");
            }
        }
        public void ActualizarESTADOAGENTE1(int activo, long _dniss)
        {
            // Construir la consulta SQL para actualizar el campo "cierredecitacion"
            string query = "UPDATE personal SET activo = @activo WHERE dni = @dnis";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@activo", activo);
            cmd.Parameters.AddWithValue("@dnis", _dniss);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("El AGENTE HA SI DADO DE ALTA CONTROLE EL ALTA EN SIAPE , SISTEMA DE SUELDO", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se actualizó ninguna fila
                MessageBox.Show("No se pudo actualizar la baja del agente");
            }
        }
        public void ModificarRegistro(string tabla, string columna, string nuevoValor, int id)
        {
            // Construir la consulta SQL para actualizar el campo "cierredecitacion"
         
            string query = $"UPDATE {tabla} SET `{columna}` = @NuevoValor WHERE dni = @Id";
            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@NuevoValor", nuevoValor);
            cmd.Parameters.AddWithValue("@Id", id);
            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de actualización
                MessageBox.Show("SI El AGENTE HA SI DADO DE ALTA CONTROLE EL ALTA EN SIAPE , SISTEMA DE SUELDO SI LE DIO DE BAJA LO MISMO ", "Actualización exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se actualizó ninguna fila
                MessageBox.Show("No se pudo actualizar la baja del agente");
            }
           
        }
        public List<string> ObtenerNombresColumnasTablaPersonal()
        {
            var nombresColumnas = new List<string>();

            try
            {
                Conectar();

                if (conexion.State == ConnectionState.Open)
                {
                    // Consulta para obtener los nombres de columnas de la tabla "personal"
                    string consulta = "SHOW COLUMNS FROM personal";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        var reader = comando.ExecuteReader();
                        while (reader.Read())
                        {
                            // El nombre de la columna está en la primera posición de la respuesta
                            nombresColumnas.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los nombres de columnas: {ex.Message}");
            }
            finally
            {
                Dispose();
            }

            return nombresColumnas;
        }
        public void AgregarnotasexpedientesDIRE(long dni, string atendidoPor, string notanumero, string año, string reparticion, string memo, string save)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO ccoodegdeba (agente, agentequetramito, notanumero, año, memo, reparticion, save) " +
                           "VALUES (@dni, @atendidoPor, @notanumero, @año, @memo, @reparticion, @save)";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", atendidoPor);
            cmd.Parameters.AddWithValue("@notanumero", notanumero);
            cmd.Parameters.AddWithValue("@año", año);
            cmd.Parameters.AddWithValue("@reparticion", reparticion);
            cmd.Parameters.AddWithValue("@memo", memo);
            cmd.Parameters.AddWithValue("@save", save);

            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }
        public void AgregarexpedientesDIRE(long dni, string atendidoPor, string notanumero, string año, string memo, string save)
        {
            // Construir la consulta SQL para insertar los datos en la tabla "consulta"
            string query = "INSERT INTO expedientes (agente, agentequetramito, año, expedientenumero, memo, archivo) " +
                           "VALUES (@dni, @atendidoPor, @año, @notanumero, @memo, @save)";

            // Crear el objeto MySqlCommand con la consulta y la conexión a la base de datos
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            // Agregar los parámetros a la consulta
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@atendidoPor", atendidoPor);
            cmd.Parameters.AddWithValue("@notanumero", notanumero);
            cmd.Parameters.AddWithValue("@año", año);
            cmd.Parameters.AddWithValue("@memo", memo);
            cmd.Parameters.AddWithValue("@save", save);

            // Abrir la conexión a la base de datos
            Conectar();
            // Ejecutar la consulta SQL
            int filasAfectadas = cmd.ExecuteNonQuery();
            // Cerrar la conexión a la base de datos
            Dispose();
            if (filasAfectadas > 0)
            {
                // Mostrar mensaje de confirmación de inserción
                MessageBox.Show("Los datos de la consulta han sido agregados con éxito.", "Inserción exitosa");
            }
            else
            {
                // Mostrar mensaje de error si no se insertó ninguna fila
                MessageBox.Show("No se pudo agregar la consulta.", "Error al agregar");
            }
        }

    }
}




