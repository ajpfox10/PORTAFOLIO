﻿namespace WindowsFormsApp1
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
            this.REGIMENHORARIO = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Location = new System.Drawing.Point(33, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(780, 185);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 68);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(196, 24);
            this.radioButton1.TabIndex = 23;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "BUSQUEDA POR DNI";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(312, 132);
            this.apellido1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(422, 28);
            this.apellido1.TabIndex = 22;
            this.apellido1.SelectedIndexChanged += new System.EventHandler(this.apellido1_SelectedIndexChanged_1);
            this.apellido1.SelectedValueChanged += new System.EventHandler(this.apellido1_SelectedValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(32, 103);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(247, 24);
            this.radioButton2.TabIndex = 24;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "BUSQUEDA POR APELLIDO";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "APELLIDO Y NOMBRE";
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(310, 60);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(424, 26);
            this.DNI.TabIndex = 10;
            this.DNI.Text = "0";
            this.DNI.TextChanged += new System.EventHandler(this.DNI_TextChanged);
            this.DNI.Validating += new System.ComponentModel.CancelEventHandler(this.DNI_Validating);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(422, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(183, 20);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "INGRESE AQUI EL DNI";
            // 
            // SEXO
            // 
            this.SEXO.FormattingEnabled = true;
            this.SEXO.Items.AddRange(new object[] {
            "F",
            "M "});
            this.SEXO.Location = new System.Drawing.Point(848, 85);
            this.SEXO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SEXO.Name = "SEXO";
            this.SEXO.Size = new System.Drawing.Size(180, 28);
            this.SEXO.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(908, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "SEXO";
            // 
            // REGIMENHORARIO
            // 
            this.REGIMENHORARIO.FormattingEnabled = true;
            this.REGIMENHORARIO.Items.AddRange(new object[] {
            "30",
            "36 P",
            "36 G",
            "36 ",
            "48",
            "24"});
            this.REGIMENHORARIO.Location = new System.Drawing.Point(1072, 86);
            this.REGIMENHORARIO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.REGIMENHORARIO.Name = "REGIMENHORARIO";
            this.REGIMENHORARIO.Size = new System.Drawing.Size(169, 28);
            this.REGIMENHORARIO.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1078, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "REGIMEN HORARIO";
            // 
            // LEY
            // 
            this.LEY.FormattingEnabled = true;
            this.LEY.Location = new System.Drawing.Point(1280, 88);
            this.LEY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LEY.Name = "LEY";
            this.LEY.Size = new System.Drawing.Size(446, 28);
            this.LEY.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1473, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "LEY";
            // 
            // PCIAS
            // 
            this.PCIAS.FormattingEnabled = true;
            this.PCIAS.Location = new System.Drawing.Point(1083, 149);
            this.PCIAS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PCIAS.Name = "PCIAS";
            this.PCIAS.Size = new System.Drawing.Size(336, 28);
            this.PCIAS.TabIndex = 33;
            // 
            // PARTIDOS
            // 
            this.PARTIDOS.FormattingEnabled = true;
            this.PARTIDOS.Location = new System.Drawing.Point(1083, 191);
            this.PARTIDOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PARTIDOS.Name = "PARTIDOS";
            this.PARTIDOS.Size = new System.Drawing.Size(336, 28);
            this.PARTIDOS.TabIndex = 34;
            this.PARTIDOS.SelectedIndexChanged += new System.EventHandler(this.PARTIDOS_SelectedIndexChanged);
            // 
            // LOCALIDADES
            // 
            this.LOCALIDADES.FormattingEnabled = true;
            this.LOCALIDADES.Location = new System.Drawing.Point(1083, 232);
            this.LOCALIDADES.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LOCALIDADES.Name = "LOCALIDADES";
            this.LOCALIDADES.Size = new System.Drawing.Size(336, 28);
            this.LOCALIDADES.TabIndex = 35;
            this.LOCALIDADES.SelectedIndexChanged += new System.EventHandler(this.LOCALIDADES_SelectedIndexChanged);
            // 
            // cmbColumna
            // 
            this.cmbColumna.FormattingEnabled = true;
            this.cmbColumna.Location = new System.Drawing.Point(32, 267);
            this.cmbColumna.Name = "cmbColumna";
            this.cmbColumna.Size = new System.Drawing.Size(271, 28);
            this.cmbColumna.TabIndex = 36;
            // 
            // cambio
            // 
            this.cambio.Location = new System.Drawing.Point(241, 345);
            this.cambio.Name = "cambio";
            this.cambio.Size = new System.Drawing.Size(143, 32);
            this.cambio.TabIndex = 37;
            this.cambio.Text = "CAMBIAR";
            this.cambio.UseVisualStyleBackColor = true;
            this.cambio.Click += new System.EventHandler(this.cambio_Click);
            // 
            // txtNuevoValor
            // 
            this.txtNuevoValor.Location = new System.Drawing.Point(333, 267);
            this.txtNuevoValor.Name = "txtNuevoValor";
            this.txtNuevoValor.Size = new System.Drawing.Size(320, 26);
            this.txtNuevoValor.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(908, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "PROVINCIA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(908, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "PARTIDO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(908, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "LOCALIDAD";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "DATO A CAMBIAR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(425, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "NUEVO DATO";
            // 
            // OCUPACION
            // 
            this.OCUPACION.FormattingEnabled = true;
            this.OCUPACION.Location = new System.Drawing.Point(1083, 314);
            this.OCUPACION.Name = "OCUPACION";
            this.OCUPACION.Size = new System.Drawing.Size(482, 28);
            this.OCUPACION.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1276, 291);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 20);
            this.label11.TabIndex = 45;
            this.label11.Text = "OCUPACION";
            // 
            // datosactualizados
            // 
            this.datosactualizados.HideSelection = false;
            this.datosactualizados.Location = new System.Drawing.Point(32, 449);
            this.datosactualizados.Name = "datosactualizados";
            this.datosactualizados.Size = new System.Drawing.Size(1694, 163);
            this.datosactualizados.TabIndex = 46;
            this.datosactualizados.UseCompatibleStateImageBehavior = false;
            this.datosactualizados.View = System.Windows.Forms.View.Details;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(453, 20);
            this.label12.TabIndex = 47;
            this.label12.Text = "DATO CARGADO ACTUALMENTE EN EL CAMPO ELEGIDO ";
            // 
            // CORREGIRERRORES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 820);
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
            this.Controls.Add(this.REGIMENHORARIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SEXO);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ComboBox REGIMENHORARIO;
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