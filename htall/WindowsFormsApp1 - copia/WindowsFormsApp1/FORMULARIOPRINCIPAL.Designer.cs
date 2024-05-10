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
            this.MESAENTRADA = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.AGENTE = new System.Windows.Forms.ComboBox();
            this.BOTONCARGAFAMILIA = new System.Windows.Forms.Button();
            this.CARGADAMICILIO = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.CARGARFAMILIA = new System.Windows.Forms.Button();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.BONIFICACIONS = new System.Windows.Forms.Button();
            this.CUMPLEAÑOSS = new System.Windows.Forms.Button();
            this.GESTIONRRHH = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnpedidos = new System.Windows.Forms.Button();
            this.BOTONBAJA = new System.Windows.Forms.Button();
            this.CORREGIRERRORES = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MESAENTRADA
            // 
            this.MESAENTRADA.Location = new System.Drawing.Point(397, 239);
            this.MESAENTRADA.Name = "MESAENTRADA";
            this.MESAENTRADA.Size = new System.Drawing.Size(118, 37);
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
            this.AGENTE.Margin = new System.Windows.Forms.Padding(2);
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
            this.CARGADAMICILIO.Location = new System.Drawing.Point(531, 197);
            this.CARGADAMICILIO.Margin = new System.Windows.Forms.Padding(2);
            this.CARGADAMICILIO.Name = "CARGADAMICILIO";
            this.CARGADAMICILIO.Size = new System.Drawing.Size(127, 37);
            this.CARGADAMICILIO.TabIndex = 13;
            this.CARGADAMICILIO.Text = "CARGA DE DOMICLIO";
            this.CARGADAMICILIO.UseVisualStyleBackColor = true;
            this.CARGADAMICILIO.Click += new System.EventHandler(this.CARGADAMICILIO_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(257, 239);
            this.Button1.Margin = new System.Windows.Forms.Padding(2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(120, 37);
            this.Button1.TabIndex = 12;
            this.Button1.Text = "FORMULARIO DE DESIGNACION";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // CARGARFAMILIA
            // 
            this.CARGARFAMILIA.Location = new System.Drawing.Point(397, 197);
            this.CARGARFAMILIA.Margin = new System.Windows.Forms.Padding(2);
            this.CARGARFAMILIA.Name = "CARGARFAMILIA";
            this.CARGARFAMILIA.Size = new System.Drawing.Size(118, 37);
            this.CARGARFAMILIA.TabIndex = 11;
            this.CARGARFAMILIA.Text = "CARGAR FAMILIA";
            this.CARGARFAMILIA.UseVisualStyleBackColor = true;
            this.CARGARFAMILIA.Click += new System.EventHandler(this.CARGARFAMILIA_Click);
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(207, 39);
            this.DNI.Margin = new System.Windows.Forms.Padding(2);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(284, 20);
            this.DNI.TabIndex = 10;
            this.DNI.Text = "0";
            this.DNI.TextChanged += new System.EventHandler(this.DNI_TextChanged);
            this.DNI.Validating += new System.ComponentModel.CancelEventHandler(this.DNI_Validating);
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
            this.BONIFICACIONS.Margin = new System.Windows.Forms.Padding(2);
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
            this.CUMPLEAÑOSS.Margin = new System.Windows.Forms.Padding(2);
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
            this.apellido1.SelectedIndexChanged += new System.EventHandler(this.apellido1_SelectedIndexChanged_1);
            this.apellido1.SelectedValueChanged += new System.EventHandler(this.apellido1_SelectedValueChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(140, 20);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "BUSQUEDA POR DNI";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(21, 67);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(173, 20);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "BUSQUEDA POR APELLIDO";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.radioButton2);
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
            this.btnpedidos.Margin = new System.Windows.Forms.Padding(2);
            this.btnpedidos.Name = "btnpedidos";
            this.btnpedidos.Size = new System.Drawing.Size(127, 37);
            this.btnpedidos.TabIndex = 26;
            this.btnpedidos.Text = "PEDIDOS";
            this.btnpedidos.UseVisualStyleBackColor = true;
            this.btnpedidos.Click += new System.EventHandler(this.btnpedidos_Click);
            // 
            // BOTONBAJA
            // 
            this.BOTONBAJA.Location = new System.Drawing.Point(674, 240);
            this.BOTONBAJA.Margin = new System.Windows.Forms.Padding(2);
            this.BOTONBAJA.Name = "BOTONBAJA";
            this.BOTONBAJA.Size = new System.Drawing.Size(199, 36);
            this.BOTONBAJA.TabIndex = 27;
            this.BOTONBAJA.Text = "DAR DE BAJA U ALTA";
            this.BOTONBAJA.UseVisualStyleBackColor = true;
            this.BOTONBAJA.Click += new System.EventHandler(this.BOTONBAJA_Click);
            // 
            // CORREGIRERRORES
            // 
            this.CORREGIRERRORES.Location = new System.Drawing.Point(674, 197);
            this.CORREGIRERRORES.Name = "CORREGIRERRORES";
            this.CORREGIRERRORES.Size = new System.Drawing.Size(199, 37);
            this.CORREGIRERRORES.TabIndex = 28;
            this.CORREGIRERRORES.Text = "CORREGIR ERRORES DE CARGA";
            this.CORREGIRERRORES.UseVisualStyleBackColor = true;
            this.CORREGIRERRORES.Click += new System.EventHandler(this.CORREGIRERRORES_Click);
            // 
            // FORMULARIOPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1162, 633);
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
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.CARGARFAMILIA);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button CARGARFAMILIA;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button BONIFICACIONS;
        private System.Windows.Forms.Button CUMPLEAÑOSS;
        private System.Windows.Forms.Button GESTIONRRHH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnpedidos;
        private System.Windows.Forms.Button BOTONBAJA;
        private System.Windows.Forms.Button CORREGIRERRORES;
    }
}