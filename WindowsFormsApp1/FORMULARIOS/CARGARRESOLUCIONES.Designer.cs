
namespace WindowsFormsApp1.FORMULARIOS
{
    partial class CARGARRESOLUCIONES
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
            this.resolucionesd = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CANTIDADS = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.VISORRESO = new System.Windows.Forms.WebBrowser();
            this.FECHADERESOLUCION = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TIPORESOLUCION = new System.Windows.Forms.ComboBox();
            this.CARGARESO = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.RESOTRABAJAR = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resolucionesd
            // 
            this.resolucionesd.HideSelection = false;
            this.resolucionesd.Location = new System.Drawing.Point(694, 71);
            this.resolucionesd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resolucionesd.Name = "resolucionesd";
            this.resolucionesd.Size = new System.Drawing.Size(391, 410);
            this.resolucionesd.TabIndex = 0;
            this.resolucionesd.UseCompatibleStateImageBehavior = false;
            this.resolucionesd.DoubleClick += new System.EventHandler(this.resolucionesd_DoubleClick);
            this.resolucionesd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.resolucionesd_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESOLUCIONES SIN ANEXAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(692, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CANTIDAD DE RESOLUCIONES SIN ANEXAR";
            // 
            // CANTIDADS
            // 
            this.CANTIDADS.Location = new System.Drawing.Point(939, 32);
            this.CANTIDADS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CANTIDADS.Name = "CANTIDADS";
            this.CANTIDADS.Size = new System.Drawing.Size(40, 20);
            this.CANTIDADS.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 74);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "HAGA DOBLE CLIK EN ESTE DNI PARA CAMBIAR EL AGENTE";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(12, 10);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(226, 17);
            this.PORDNI.TabIndex = 35;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR APELLIDO Y NOMBRE";
            this.PORDNI.UseVisualStyleBackColor = true;
            this.PORDNI.Visible = false;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(11, 29);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(211, 17);
            this.PORAPELLIDO.TabIndex = 34;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUE POR APELLIDO Y NOMBRE";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // apellido1
            // 
            this.apellido1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(241, 27);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(227, 21);
            this.apellido1.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "APELLIDO Y NOMBRE";
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(332, 52);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(136, 20);
            this.DNI.TabIndex = 1;
            this.DNI.DoubleClick += new System.EventHandler(this.DNI_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 17;
            // 
            // VISORRESO
            // 
            this.VISORRESO.Location = new System.Drawing.Point(8, 129);
            this.VISORRESO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VISORRESO.MinimumSize = new System.Drawing.Size(13, 13);
            this.VISORRESO.Name = "VISORRESO";
            this.VISORRESO.Size = new System.Drawing.Size(624, 442);
            this.VISORRESO.TabIndex = 18;
            // 
            // FECHADERESOLUCION
            // 
            this.FECHADERESOLUCION.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHADERESOLUCION.Location = new System.Drawing.Point(153, 97);
            this.FECHADERESOLUCION.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FECHADERESOLUCION.Name = "FECHADERESOLUCION";
            this.FECHADERESOLUCION.Size = new System.Drawing.Size(87, 20);
            this.FECHADERESOLUCION.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "FECHA DE RESOLUCION";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "ACTO DE :";
            // 
            // TIPORESOLUCION
            // 
            this.TIPORESOLUCION.FormattingEnabled = true;
            this.TIPORESOLUCION.Location = new System.Drawing.Point(345, 96);
            this.TIPORESOLUCION.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TIPORESOLUCION.Name = "TIPORESOLUCION";
            this.TIPORESOLUCION.Size = new System.Drawing.Size(213, 21);
            this.TIPORESOLUCION.TabIndex = 21;
            // 
            // CARGARESO
            // 
            this.CARGARESO.Location = new System.Drawing.Point(576, 88);
            this.CARGARESO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CARGARESO.Name = "CARGARESO";
            this.CARGARESO.Size = new System.Drawing.Size(66, 24);
            this.CARGARESO.TabIndex = 23;
            this.CARGARESO.Text = "CARGAR";
            this.CARGARESO.UseVisualStyleBackColor = true;
            this.CARGARESO.Click += new System.EventHandler(this.CARGARESO_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(692, 493);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "RESOLUCION A TRABAJAR";
            // 
            // RESOTRABAJAR
            // 
            this.RESOTRABAJAR.Location = new System.Drawing.Point(694, 513);
            this.RESOTRABAJAR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RESOTRABAJAR.Name = "RESOTRABAJAR";
            this.RESOTRABAJAR.Size = new System.Drawing.Size(145, 20);
            this.RESOTRABAJAR.TabIndex = 25;
            // 
            // CARGARRESOLUCIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 567);
            this.Controls.Add(this.RESOTRABAJAR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CARGARESO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TIPORESOLUCION);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FECHADERESOLUCION);
            this.Controls.Add(this.VISORRESO);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CANTIDADS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resolucionesd);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CARGARRESOLUCIONES";
            this.Text = "CARGAR RESOLUCIONES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CARGARRESOLUCIONES_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resolucionesd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CANTIDADS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.WebBrowser VISORRESO;
        private System.Windows.Forms.DateTimePicker FECHADERESOLUCION;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox TIPORESOLUCION;
        private System.Windows.Forms.Button CARGARESO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RESOTRABAJAR;
    }
}