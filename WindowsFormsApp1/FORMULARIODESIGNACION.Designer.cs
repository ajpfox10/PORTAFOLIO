namespace WindowsFormsApp1
{
    partial class FORMULARIODESIGNACION
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
            this.RESOLUCION = new System.Windows.Forms.TextBox();
            this.DEPENDENCIA = new System.Windows.Forms.TextBox();
            this.BAJA = new System.Windows.Forms.DateTimePicker();
            this.MOTIVODEBAJA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Regimenhorario = new System.Windows.Forms.ComboBox();
            this.CATEGORIA = new System.Windows.Forms.ComboBox();
            this.CARGOS = new System.Windows.Forms.ComboBox();
            this.Ministerios = new System.Windows.Forms.ComboBox();
            this.IFGRA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.DESIGNACIONESSS = new System.Windows.Forms.ListView();
            this.EDITARDATOS = new System.Windows.Forms.Button();
            this.CARGARDATOS = new System.Windows.Forms.Button();
            this.INGRESO = new System.Windows.Forms.DateTimePicker();
            this.CARGARPDF = new System.Windows.Forms.Button();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ALTACARGOS = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.EDITARBAJA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.ALTACARGOS.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RESOLUCION
            // 
            this.RESOLUCION.Location = new System.Drawing.Point(12, 77);
            this.RESOLUCION.Name = "RESOLUCION";
            this.RESOLUCION.Size = new System.Drawing.Size(160, 26);
            this.RESOLUCION.TabIndex = 0;
            // 
            // DEPENDENCIA
            // 
            this.DEPENDENCIA.Location = new System.Drawing.Point(681, 79);
            this.DEPENDENCIA.Name = "DEPENDENCIA";
            this.DEPENDENCIA.Size = new System.Drawing.Size(178, 26);
            this.DEPENDENCIA.TabIndex = 3;
            // 
            // BAJA
            // 
            this.BAJA.CustomFormat = "dd/mm/yyyy";
            this.BAJA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BAJA.Location = new System.Drawing.Point(54, 127);
            this.BAJA.Name = "BAJA";
            this.BAJA.Size = new System.Drawing.Size(200, 26);
            this.BAJA.TabIndex = 6;
            this.BAJA.Value = new System.DateTime(2023, 6, 4, 0, 0, 0, 0);
            // 
            // MOTIVODEBAJA
            // 
            this.MOTIVODEBAJA.Location = new System.Drawing.Point(54, 50);
            this.MOTIVODEBAJA.Name = "MOTIVODEBAJA";
            this.MOTIVODEBAJA.Size = new System.Drawing.Size(217, 26);
            this.MOTIVODEBAJA.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "RESOLUCION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "FECHA DE NOMBRAMIENTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "MINISTERIO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "DEPENDENCIA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(941, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "CARGO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1112, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "CATEGORIA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "FECHA DE BAJA ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "MOTIVO DE BAJA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1228, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "REGIMEN HORARIO";
            // 
            // Regimenhorario
            // 
            this.Regimenhorario.FormattingEnabled = true;
            this.Regimenhorario.Location = new System.Drawing.Point(1232, 81);
            this.Regimenhorario.Name = "Regimenhorario";
            this.Regimenhorario.Size = new System.Drawing.Size(161, 28);
            this.Regimenhorario.TabIndex = 17;
            // 
            // CATEGORIA
            // 
            this.CATEGORIA.FormattingEnabled = true;
            this.CATEGORIA.Location = new System.Drawing.Point(1105, 79);
            this.CATEGORIA.Name = "CATEGORIA";
            this.CATEGORIA.Size = new System.Drawing.Size(121, 28);
            this.CATEGORIA.TabIndex = 18;
            // 
            // CARGOS
            // 
            this.CARGOS.FormattingEnabled = true;
            this.CARGOS.Location = new System.Drawing.Point(865, 79);
            this.CARGOS.Name = "CARGOS";
            this.CARGOS.Size = new System.Drawing.Size(234, 28);
            this.CARGOS.TabIndex = 19;
            // 
            // Ministerios
            // 
            this.Ministerios.FormattingEnabled = true;
            this.Ministerios.Location = new System.Drawing.Point(430, 79);
            this.Ministerios.Name = "Ministerios";
            this.Ministerios.Size = new System.Drawing.Size(235, 28);
            this.Ministerios.TabIndex = 20;
            // 
            // IFGRA
            // 
            this.IFGRA.Location = new System.Drawing.Point(569, 156);
            this.IFGRA.Name = "IFGRA";
            this.IFGRA.Size = new System.Drawing.Size(402, 26);
            this.IFGRA.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(603, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(336, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "INFORME GRAFICO DEL NOMBRAMIENTO ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1050, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 23;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(987, 156);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(100, 26);
            this.ID.TabIndex = 24;
            // 
            // DESIGNACIONESSS
            // 
            this.DESIGNACIONESSS.HideSelection = false;
            this.DESIGNACIONESSS.Location = new System.Drawing.Point(6, 21);
            this.DESIGNACIONESSS.Name = "DESIGNACIONESSS";
            this.DESIGNACIONESSS.Size = new System.Drawing.Size(1865, 384);
            this.DESIGNACIONESSS.TabIndex = 25;
            this.DESIGNACIONESSS.UseCompatibleStateImageBehavior = false;
            this.DESIGNACIONESSS.View = System.Windows.Forms.View.Details;
        
            this.DESIGNACIONESSS.DoubleClick += new System.EventHandler(this.DESIGNACIONESSS_DoubleClick);
            this.DESIGNACIONESSS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DESIGNACIONESSS_MouseDoubleClick);
            // 
            // EDITARDATOS
            // 
            this.EDITARDATOS.Location = new System.Drawing.Point(1256, 140);
            this.EDITARDATOS.Name = "EDITARDATOS";
            this.EDITARDATOS.Size = new System.Drawing.Size(153, 42);
            this.EDITARDATOS.TabIndex = 26;
            this.EDITARDATOS.Text = "EDITARDATOS";
            this.EDITARDATOS.UseVisualStyleBackColor = true;
            this.EDITARDATOS.Click += new System.EventHandler(this.EDITARDATOS_Click);
            // 
            // CARGARDATOS
            // 
            this.CARGARDATOS.Location = new System.Drawing.Point(1093, 140);
            this.CARGARDATOS.Name = "CARGARDATOS";
            this.CARGARDATOS.Size = new System.Drawing.Size(157, 42);
            this.CARGARDATOS.TabIndex = 27;
            this.CARGARDATOS.Text = "CARGAR DATOS";
            this.CARGARDATOS.UseVisualStyleBackColor = true;
            this.CARGARDATOS.Click += new System.EventHandler(this.CARGARDATOS_Click);
            // 
            // INGRESO
            // 
            this.INGRESO.AccessibleName = "CARTA OTORGADA EL DIA";
            this.INGRESO.CustomFormat = "yyyy-MM-dd";
            this.INGRESO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.INGRESO.Location = new System.Drawing.Point(179, 77);
            this.INGRESO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.INGRESO.Name = "INGRESO";
            this.INGRESO.Size = new System.Drawing.Size(234, 26);
            this.INGRESO.TabIndex = 126;
            this.INGRESO.Value = new System.DateTime(2023, 6, 8, 0, 0, 0, 0);
            // 
            // CARGARPDF
            // 
            this.CARGARPDF.Location = new System.Drawing.Point(1427, 140);
            this.CARGARPDF.Name = "CARGARPDF";
            this.CARGARPDF.Size = new System.Drawing.Size(145, 42);
            this.CARGARPDF.TabIndex = 127;
            this.CARGARPDF.Text = "CARGAR PDF";
            this.CARGARPDF.UseVisualStyleBackColor = true;
            this.CARGARPDF.Click += new System.EventHandler(this.CARGARPDF_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(119, 150);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(175, 69);
            this.trackBar2.TabIndex = 129;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 15);
            this.label12.TabIndex = 131;
            this.label12.Text = "FORMULARIO DE DESIGNACION";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(254, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(206, 15);
            this.label13.TabIndex = 132;
            this.label13.Text = "FORMULARIO DE AGRUPAMIENTO";
            // 
            // ALTACARGOS
            // 
            this.ALTACARGOS.Controls.Add(this.tabPage1);
            this.ALTACARGOS.Controls.Add(this.tabPage2);
            this.ALTACARGOS.Location = new System.Drawing.Point(12, 188);
            this.ALTACARGOS.Name = "ALTACARGOS";
            this.ALTACARGOS.SelectedIndex = 0;
            this.ALTACARGOS.Size = new System.Drawing.Size(1900, 643);
            this.ALTACARGOS.TabIndex = 133;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DESIGNACIONESSS);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1892, 610);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ALTA DE CARGO";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.EDITARBAJA);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1892, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BAJA DE CARGO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.MOTIVODEBAJA);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.BAJA);
            this.panel1.Location = new System.Drawing.Point(572, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 178);
            this.panel1.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1020, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 20);
            this.label15.TabIndex = 135;
            this.label15.Text = "ID ";
            // 
            // EDITARBAJA
            // 
            this.EDITARBAJA.Location = new System.Drawing.Point(933, 160);
            this.EDITARBAJA.Name = "EDITARBAJA";
            this.EDITARBAJA.Size = new System.Drawing.Size(138, 45);
            this.EDITARBAJA.TabIndex = 17;
            this.EDITARBAJA.Text = "EDITAR BAJA ";
            this.EDITARBAJA.UseVisualStyleBackColor = true;
            this.EDITARBAJA.Click += new System.EventHandler(this.EDITARBAJA_Click);
            // 
            // FORMULARIODESIGNACION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 823);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ALTACARGOS);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.CARGARPDF);
            this.Controls.Add(this.INGRESO);
            this.Controls.Add(this.CARGARDATOS);
            this.Controls.Add(this.EDITARDATOS);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.IFGRA);
            this.Controls.Add(this.Ministerios);
            this.Controls.Add(this.CARGOS);
            this.Controls.Add(this.CATEGORIA);
            this.Controls.Add(this.Regimenhorario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DEPENDENCIA);
            this.Controls.Add(this.RESOLUCION);
            this.Name = "FORMULARIODESIGNACION";
            this.Text = "FORMULARIO DESIGNACION";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FORMULARIODESIGNACION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ALTACARGOS.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RESOLUCION;
        private System.Windows.Forms.TextBox DEPENDENCIA;
        private System.Windows.Forms.DateTimePicker BAJA;
        private System.Windows.Forms.TextBox MOTIVODEBAJA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Regimenhorario;
        private System.Windows.Forms.ComboBox CATEGORIA;
        private System.Windows.Forms.ComboBox CARGOS;
        private System.Windows.Forms.ComboBox Ministerios;
        private System.Windows.Forms.TextBox IFGRA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.ListView DESIGNACIONESSS;
        private System.Windows.Forms.Button EDITARDATOS;
        private System.Windows.Forms.Button CARGARDATOS;
        internal System.Windows.Forms.DateTimePicker INGRESO;
        private System.Windows.Forms.Button CARGARPDF;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl ALTACARGOS;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button EDITARBAJA;
    }
}