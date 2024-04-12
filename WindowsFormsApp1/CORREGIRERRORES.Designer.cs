namespace WindowsFormsApp1
{
    partial class CORREGIRERRORES
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SEXO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Regimenhorario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LEY = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PCIAS = new System.Windows.Forms.ComboBox();
            this.PARTIDOS = new System.Windows.Forms.ComboBox();
            this.LOCALIDADES = new System.Windows.Forms.ComboBox();
            this.cmbColumna = new System.Windows.Forms.ComboBox();
            this.cambio = new System.Windows.Forms.Button();
            this.txtNuevoValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.OCUPACION = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.datosactualizados = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 120);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(133, 17);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "BUSQUEDA POR DNI";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.RadioButton1_Click);
            // 
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(208, 86);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(283, 21);
            this.apellido1.TabIndex = 22;
            this.apellido1.SelectedIndexChanged += new System.EventHandler(this.Apellido1_SelectedIndexChanged_1);
            this.apellido1.SelectedValueChanged += new System.EventHandler(this.Apellido1_SelectedValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(21, 67);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(166, 17);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "BUSQUEDA POR APELLIDO";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.RadioButton2_Click);
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
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(207, 39);
            this.DNI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // SEXO
            // 
            this.SEXO.FormattingEnabled = true;
            this.SEXO.Items.AddRange(new object[] {
            "F",
            "M "});
            this.SEXO.Location = new System.Drawing.Point(565, 55);
            this.SEXO.Name = "SEXO";
            this.SEXO.Size = new System.Drawing.Size(121, 21);
            this.SEXO.TabIndex = 27;
            this.SEXO.SelectedIndexChanged += new System.EventHandler(this.SEXO_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "SEXO";
            // 
            // Regimenhorario
            // 
            this.Regimenhorario.FormattingEnabled = true;
            this.Regimenhorario.Items.AddRange(new object[] {
            "30",
            "36 P",
            "36 G",
            "36 ",
            "48",
            "24"});
            this.Regimenhorario.Location = new System.Drawing.Point(715, 56);
            this.Regimenhorario.Name = "Regimenhorario";
            this.Regimenhorario.Size = new System.Drawing.Size(114, 21);
            this.Regimenhorario.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(719, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "REGIMEN HORARIO";
            // 
            // LEY
            // 
            this.LEY.FormattingEnabled = true;
            this.LEY.Location = new System.Drawing.Point(853, 57);
            this.LEY.Name = "LEY";
            this.LEY.Size = new System.Drawing.Size(299, 21);
            this.LEY.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(982, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "LEY";
            // 
            // PCIAS
            // 
            this.PCIAS.FormattingEnabled = true;
            this.PCIAS.Location = new System.Drawing.Point(722, 97);
            this.PCIAS.Name = "PCIAS";
            this.PCIAS.Size = new System.Drawing.Size(225, 21);
            this.PCIAS.TabIndex = 33;
            // 
            // PARTIDOS
            // 
            this.PARTIDOS.FormattingEnabled = true;
            this.PARTIDOS.Location = new System.Drawing.Point(722, 124);
            this.PARTIDOS.Name = "PARTIDOS";
            this.PARTIDOS.Size = new System.Drawing.Size(225, 21);
            this.PARTIDOS.TabIndex = 34;
            this.PARTIDOS.SelectedIndexChanged += new System.EventHandler(this.PARTIDOS_SelectedIndexChanged);
            // 
            // LOCALIDADES
            // 
            this.LOCALIDADES.FormattingEnabled = true;
            this.LOCALIDADES.Location = new System.Drawing.Point(722, 151);
            this.LOCALIDADES.Name = "LOCALIDADES";
            this.LOCALIDADES.Size = new System.Drawing.Size(225, 21);
            this.LOCALIDADES.TabIndex = 35;
            this.LOCALIDADES.SelectedIndexChanged += new System.EventHandler(this.LOCALIDADES_SelectedIndexChanged);
            // 
            // cmbColumna
            // 
            this.cmbColumna.FormattingEnabled = true;
            this.cmbColumna.Location = new System.Drawing.Point(21, 174);
            this.cmbColumna.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbColumna.Name = "cmbColumna";
            this.cmbColumna.Size = new System.Drawing.Size(182, 21);
            this.cmbColumna.TabIndex = 36;
            // 
            // cambio
            // 
            this.cambio.Location = new System.Drawing.Point(161, 224);
            this.cambio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cambio.Name = "cambio";
            this.cambio.Size = new System.Drawing.Size(95, 21);
            this.cambio.TabIndex = 37;
            this.cambio.Text = "CAMBIAR";
            this.cambio.UseVisualStyleBackColor = true;
            this.cambio.Click += new System.EventHandler(this.Cambio_Click);
            // 
            // txtNuevoValor
            // 
            this.txtNuevoValor.Location = new System.Drawing.Point(222, 174);
            this.txtNuevoValor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNuevoValor.Name = "txtNuevoValor";
            this.txtNuevoValor.Size = new System.Drawing.Size(215, 20);
            this.txtNuevoValor.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "PROVINCIA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(605, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "PARTIDO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(605, 151);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "LOCALIDAD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "DATO A CAMBIAR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 156);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "NUEVO DATO";
            // 
            // OCUPACION
            // 
            this.OCUPACION.FormattingEnabled = true;
            this.OCUPACION.Location = new System.Drawing.Point(722, 204);
            this.OCUPACION.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OCUPACION.Name = "OCUPACION";
            this.OCUPACION.Size = new System.Drawing.Size(323, 21);
            this.OCUPACION.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(851, 189);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "OCUPACION";
            // 
            // datosactualizados
            // 
            this.datosactualizados.HideSelection = false;
            this.datosactualizados.Location = new System.Drawing.Point(21, 292);
            this.datosactualizados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datosactualizados.Name = "datosactualizados";
            this.datosactualizados.Size = new System.Drawing.Size(1131, 107);
            this.datosactualizados.TabIndex = 46;
            this.datosactualizados.UseCompatibleStateImageBehavior = false;
            this.datosactualizados.View = System.Windows.Forms.View.Details;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 267);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(304, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "DATO CARGADO ACTUALMENTE EN EL CAMPO ELEGIDO ";
            // 
            // CORREGIRERRORES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 533);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.datosactualizados);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.OCUPACION);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNuevoValor);
            this.Controls.Add(this.cambio);
            this.Controls.Add(this.cmbColumna);
            this.Controls.Add(this.LOCALIDADES);
            this.Controls.Add(this.PARTIDOS);
            this.Controls.Add(this.PCIAS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LEY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Regimenhorario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SEXO);
            this.Controls.Add(this.groupBox1);
            this.Name = "CORREGIRERRORES";
            this.Text = "CORREGIR ERRORES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CORREGIRERRORES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox SEXO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Regimenhorario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox LEY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox PCIAS;
        private System.Windows.Forms.ComboBox PARTIDOS;
        private System.Windows.Forms.ComboBox LOCALIDADES;
        private System.Windows.Forms.ComboBox cmbColumna;
        private System.Windows.Forms.Button cambio;
        private System.Windows.Forms.TextBox txtNuevoValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox OCUPACION;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView datosactualizados;
        private System.Windows.Forms.Label label12;
    }
}