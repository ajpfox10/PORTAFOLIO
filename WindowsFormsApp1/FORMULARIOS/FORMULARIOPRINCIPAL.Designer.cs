namespace WindowsFormsApp1
{
    partial class FORMULARIOPRINCIPAL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MESAENTRADA = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.AGENTE = new System.Windows.Forms.ComboBox();
            this.BOTONCARGAFAMILIA = new System.Windows.Forms.Button();
            this.CARGADAMICILIO = new System.Windows.Forms.Button();
            this.FORMULARIODESIGNACION = new System.Windows.Forms.Button();
            this.CARGARFAMILIA = new System.Windows.Forms.Button();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.BONIFICACIONS = new System.Windows.Forms.Button();
            this.CUMPLEAÑOSS = new System.Windows.Forms.Button();
            this.GESTIONRRHH = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnpedidos = new System.Windows.Forms.Button();
            this.BOTONBAJA = new System.Windows.Forms.Button();
            this.CORREGIRERRORES = new System.Windows.Forms.Button();
            this.TAREASASIGNAR = new System.Windows.Forms.Button();
            this.ASIGNACIONTAREAS = new System.Windows.Forms.Button();
            this.FOTOTARJETA = new System.Windows.Forms.Button();
            this.CPOSTULANTES = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.cargaresoluciones1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MESAENTRADA
            // 
            this.MESAENTRADA.Location = new System.Drawing.Point(397, 239);
            this.MESAENTRADA.Name = "MESAENTRADA";
            this.MESAENTRADA.Size = new System.Drawing.Size(118, 38);
            this.MESAENTRADA.TabIndex = 17;
            this.MESAENTRADA.Text = "MESA DE ENTRADA";
            this.MESAENTRADA.UseVisualStyleBackColor = true;
            this.MESAENTRADA.Click += new System.EventHandler(this.MESAENTRADA_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(574, 69);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(127, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "AGENTE DE ATENCION";
            // 
            // AGENTE
            // 
            this.AGENTE.DisplayMember = "nameuser";
            this.AGENTE.FormattingEnabled = true;
            this.AGENTE.Location = new System.Drawing.Point(578, 90);
            this.AGENTE.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.AGENTE.Name = "AGENTE";
            this.AGENTE.Size = new System.Drawing.Size(123, 21);
            this.AGENTE.TabIndex = 15;
            this.AGENTE.ValueMember = "nameuser";
            // 
            // BOTONCARGAFAMILIA
            // 
            this.BOTONCARGAFAMILIA.Location = new System.Drawing.Point(257, 198);
            this.BOTONCARGAFAMILIA.Name = "BOTONCARGAFAMILIA";
            this.BOTONCARGAFAMILIA.Size = new System.Drawing.Size(120, 34);
            this.BOTONCARGAFAMILIA.TabIndex = 14;
            this.BOTONCARGAFAMILIA.Text = "CARGAR HOJA DE VIDA";
            this.BOTONCARGAFAMILIA.UseVisualStyleBackColor = true;
            this.BOTONCARGAFAMILIA.Click += new System.EventHandler(this.BOTONCARGAFAMILIA_Click);
            // 
            // CARGADAMICILIO
            // 
            this.CARGADAMICILIO.Location = new System.Drawing.Point(531, 196);
            this.CARGADAMICILIO.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CARGADAMICILIO.Name = "CARGADAMICILIO";
            this.CARGADAMICILIO.Size = new System.Drawing.Size(127, 38);
            this.CARGADAMICILIO.TabIndex = 13;
            this.CARGADAMICILIO.Text = "CARGA DE DOMICLIO";
            this.CARGADAMICILIO.UseVisualStyleBackColor = true;
            this.CARGADAMICILIO.Click += new System.EventHandler(this.CARGADAMICILIO_Click);
            // 
            // FORMULARIODESIGNACION
            // 
            this.FORMULARIODESIGNACION.Location = new System.Drawing.Point(257, 239);
            this.FORMULARIODESIGNACION.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.FORMULARIODESIGNACION.Name = "FORMULARIODESIGNACION";
            this.FORMULARIODESIGNACION.Size = new System.Drawing.Size(120, 38);
            this.FORMULARIODESIGNACION.TabIndex = 12;
            this.FORMULARIODESIGNACION.Text = "FORMULARIO DE DESIGNACION";
            this.FORMULARIODESIGNACION.UseVisualStyleBackColor = true;
            this.FORMULARIODESIGNACION.Click += new System.EventHandler(this.FORMULARIODESIGNACION_Click);
            // 
            // CARGARFAMILIA
            // 
            this.CARGARFAMILIA.Location = new System.Drawing.Point(397, 196);
            this.CARGARFAMILIA.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CARGARFAMILIA.Name = "CARGARFAMILIA";
            this.CARGARFAMILIA.Size = new System.Drawing.Size(118, 38);
            this.CARGARFAMILIA.TabIndex = 11;
            this.CARGARFAMILIA.Text = "CARGAR FAMILIA";
            this.CARGARFAMILIA.UseVisualStyleBackColor = true;
            this.CARGARFAMILIA.Click += new System.EventHandler(this.CARGARFAMILIA_Click);
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(207, 39);
            this.DNI.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(284, 20);
            this.DNI.TabIndex = 10;
            this.DNI.Text = "0";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(281, 17);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(122, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "INGRESE AQUI EL DNI";
            // 
            // BONIFICACIONS
            // 
            this.BONIFICACIONS.Location = new System.Drawing.Point(133, 199);
            this.BONIFICACIONS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BONIFICACIONS.Name = "BONIFICACIONS";
            this.BONIFICACIONS.Size = new System.Drawing.Size(101, 35);
            this.BONIFICACIONS.TabIndex = 18;
            this.BONIFICACIONS.Text = "BONIFICACION";
            this.BONIFICACIONS.UseVisualStyleBackColor = true;
            this.BONIFICACIONS.Click += new System.EventHandler(this.BONIFICACIONS_Click);
            // 
            // CUMPLEAÑOSS
            // 
            this.CUMPLEAÑOSS.Location = new System.Drawing.Point(134, 240);
            this.CUMPLEAÑOSS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CUMPLEAÑOSS.Name = "CUMPLEAÑOSS";
            this.CUMPLEAÑOSS.Size = new System.Drawing.Size(100, 36);
            this.CUMPLEAÑOSS.TabIndex = 19;
            this.CUMPLEAÑOSS.Text = "CUMPLEAÑOS";
            this.CUMPLEAÑOSS.UseVisualStyleBackColor = true;
            this.CUMPLEAÑOSS.Click += new System.EventHandler(this.CUMPLEAÑOSS_Click);
            // 
            // GESTIONRRHH
            // 
            this.GESTIONRRHH.Location = new System.Drawing.Point(888, 199);
            this.GESTIONRRHH.Name = "GESTIONRRHH";
            this.GESTIONRRHH.Size = new System.Drawing.Size(161, 36);
            this.GESTIONRRHH.TabIndex = 20;
            this.GESTIONRRHH.Text = "GESTION DE RRHH";
            this.GESTIONRRHH.UseVisualStyleBackColor = true;
            this.GESTIONRRHH.Click += new System.EventHandler(this.GESTIONRRHH_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "APELLIDO Y NOMBRE";
            // 
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(208, 86);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(283, 21);
            this.apellido1.TabIndex = 22;
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(21, 44);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(133, 17);
            this.PORDNI.TabIndex = 23;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR DNI";
            this.PORDNI.UseVisualStyleBackColor = true;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(21, 66);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(166, 17);
            this.PORAPELLIDO.TabIndex = 24;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUEDA POR APELLIDO";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(34, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 120);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
            // 
            // btnpedidos
            // 
            this.btnpedidos.Location = new System.Drawing.Point(531, 239);
            this.btnpedidos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnpedidos.Name = "btnpedidos";
            this.btnpedidos.Size = new System.Drawing.Size(127, 38);
            this.btnpedidos.TabIndex = 26;
            this.btnpedidos.Text = "PEDIDOS";
            this.btnpedidos.UseVisualStyleBackColor = true;
            this.btnpedidos.Click += new System.EventHandler(this.Btnpedidos_Click);
            // 
            // BOTONBAJA
            // 
            this.BOTONBAJA.Location = new System.Drawing.Point(674, 240);
            this.BOTONBAJA.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.BOTONBAJA.Name = "BOTONBAJA";
            this.BOTONBAJA.Size = new System.Drawing.Size(199, 36);
            this.BOTONBAJA.TabIndex = 27;
            this.BOTONBAJA.Text = "DAR DE BAJA U ALTA";
            this.BOTONBAJA.UseVisualStyleBackColor = true;
            this.BOTONBAJA.Click += new System.EventHandler(this.BOTONBAJA_Click);
            // 
            // CORREGIRERRORES
            // 
            this.CORREGIRERRORES.Location = new System.Drawing.Point(674, 199);
            this.CORREGIRERRORES.Name = "CORREGIRERRORES";
            this.CORREGIRERRORES.Size = new System.Drawing.Size(199, 35);
            this.CORREGIRERRORES.TabIndex = 28;
            this.CORREGIRERRORES.Text = "CORREGIR ERRORES DE CARGA";
            this.CORREGIRERRORES.UseVisualStyleBackColor = true;
            this.CORREGIRERRORES.Click += new System.EventHandler(this.CORREGIRERRORES_Click);
            // 
            // TAREASASIGNAR
            // 
            this.TAREASASIGNAR.Location = new System.Drawing.Point(531, 294);
            this.TAREASASIGNAR.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TAREASASIGNAR.Name = "TAREASASIGNAR";
            this.TAREASASIGNAR.Size = new System.Drawing.Size(127, 33);
            this.TAREASASIGNAR.TabIndex = 29;
            this.TAREASASIGNAR.Text = "TAREAS ASIGNADAS";
            this.TAREASASIGNAR.UseVisualStyleBackColor = true;
            this.TAREASASIGNAR.Click += new System.EventHandler(this.TAREASASIGNAR_Click);
            // 
            // ASIGNACIONTAREAS
            // 
            this.ASIGNACIONTAREAS.Location = new System.Drawing.Point(133, 295);
            this.ASIGNACIONTAREAS.Name = "ASIGNACIONTAREAS";
            this.ASIGNACIONTAREAS.Size = new System.Drawing.Size(101, 32);
            this.ASIGNACIONTAREAS.TabIndex = 30;
            this.ASIGNACIONTAREAS.Text = "ASIGNACION DE TAREAS";
            this.ASIGNACIONTAREAS.UseVisualStyleBackColor = true;
            this.ASIGNACIONTAREAS.Visible = false;
            this.ASIGNACIONTAREAS.Click += new System.EventHandler(this.ASIGNACIONTAREAS_Click);
            // 
            // FOTOTARJETA
            // 
            this.FOTOTARJETA.Location = new System.Drawing.Point(888, 241);
            this.FOTOTARJETA.Name = "FOTOTARJETA";
            this.FOTOTARJETA.Size = new System.Drawing.Size(161, 35);
            this.FOTOTARJETA.TabIndex = 31;
            this.FOTOTARJETA.Text = "FOTO TARJETA";
            this.FOTOTARJETA.UseVisualStyleBackColor = true;
            this.FOTOTARJETA.Click += new System.EventHandler(this.FOTOTARJETA_Click);
            // 
            // CPOSTULANTES
            // 
            this.CPOSTULANTES.Location = new System.Drawing.Point(888, 294);
            this.CPOSTULANTES.Name = "CPOSTULANTES";
            this.CPOSTULANTES.Size = new System.Drawing.Size(161, 33);
            this.CPOSTULANTES.TabIndex = 32;
            this.CPOSTULANTES.Text = "CARGAR POSTULANTES";
            this.CPOSTULANTES.UseVisualStyleBackColor = true;
            this.CPOSTULANTES.Click += new System.EventHandler(this.CPOSTULANTES_Click);
            // 
            // cargaresoluciones1
            // 
            this.cargaresoluciones1.Location = new System.Drawing.Point(674, 294);
            this.cargaresoluciones1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cargaresoluciones1.Name = "cargaresoluciones1";
            this.cargaresoluciones1.Size = new System.Drawing.Size(199, 32);
            this.cargaresoluciones1.TabIndex = 33;
            this.cargaresoluciones1.Text = "UNIR RESOLUCIONES";
            this.cargaresoluciones1.UseVisualStyleBackColor = true;
            this.cargaresoluciones1.Click += new System.EventHandler(this.cargaresoluciones_Click);
            // 
            // FORMULARIOPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1213, 456);
            this.Controls.Add(this.cargaresoluciones1);
            this.Controls.Add(this.CPOSTULANTES);
            this.Controls.Add(this.FOTOTARJETA);
            this.Controls.Add(this.ASIGNACIONTAREAS);
            this.Controls.Add(this.TAREASASIGNAR);
            this.Controls.Add(this.CORREGIRERRORES);
            this.Controls.Add(this.BOTONBAJA);
            this.Controls.Add(this.btnpedidos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GESTIONRRHH);
            this.Controls.Add(this.CUMPLEAÑOSS);
            this.Controls.Add(this.BONIFICACIONS);
            this.Controls.Add(this.MESAENTRADA);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.AGENTE);
            this.Controls.Add(this.BOTONCARGAFAMILIA);
            this.Controls.Add(this.CARGADAMICILIO);
            this.Controls.Add(this.FORMULARIODESIGNACION);
            this.Controls.Add(this.CARGARFAMILIA);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FORMULARIOPRINCIPAL";
            this.Text = "FORMULARIO PRINCIPAL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FORMULARIOPRINCIPAL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button MESAENTRADA;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox AGENTE;
        internal System.Windows.Forms.Button BOTONCARGAFAMILIA;
        internal System.Windows.Forms.Button CARGADAMICILIO;
        internal System.Windows.Forms.Button FORMULARIODESIGNACION;
        internal System.Windows.Forms.Button CARGARFAMILIA;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button BONIFICACIONS;
        private System.Windows.Forms.Button CUMPLEAÑOSS;
        private System.Windows.Forms.Button GESTIONRRHH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnpedidos;
        private System.Windows.Forms.Button BOTONBAJA;
        private System.Windows.Forms.Button CORREGIRERRORES;
        private System.Windows.Forms.Button TAREASASIGNAR;
        private System.Windows.Forms.Button ASIGNACIONTAREAS;
        private System.Windows.Forms.Button FOTOTARJETA;
        private System.Windows.Forms.Button CPOSTULANTES;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button cargaresoluciones1;
    }
}