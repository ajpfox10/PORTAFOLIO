
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resolucionesd
            // 
            this.resolucionesd.HideSelection = false;
            this.resolucionesd.Location = new System.Drawing.Point(1041, 110);
            this.resolucionesd.Name = "resolucionesd";
            this.resolucionesd.Size = new System.Drawing.Size(584, 628);
            this.resolucionesd.TabIndex = 0;
            this.resolucionesd.UseCompatibleStateImageBehavior = false;
            this.resolucionesd.Click += new System.EventHandler(this.resolucionesd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1038, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "RESOLUCIONES SIN ANEXAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1038, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CANTIDAD DE RESOLUCIONES SIN ANEXAR";
            // 
            // CANTIDADS
            // 
            this.CANTIDADS.Location = new System.Drawing.Point(1409, 50);
            this.CANTIDADS.Name = "CANTIDADS";
            this.CANTIDADS.Size = new System.Drawing.Size(58, 20);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(935, 114);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "HAGA DOBLE CLIK EN ESTE DNI PARA CAMBIAR EL AGENTE";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(18, 15);
            this.PORDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(233, 20);
            this.PORDNI.TabIndex = 35;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR APELLIDO Y NOMBRE";
            this.PORDNI.UseVisualStyleBackColor = true;
            this.PORDNI.Visible = false;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(17, 44);
            this.PORAPELLIDO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(218, 20);
            this.PORAPELLIDO.TabIndex = 34;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUE POR APELLIDO Y NOMBRE";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // apellido1
            // 
            this.apellido1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(362, 42);
            this.apellido1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(338, 28);
            this.apellido1.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(443, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "APELLIDO Y NOMBRE";
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(498, 80);
            this.DNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(202, 20);
            this.DNI.TabIndex = 1;
            this.DNI.DoubleClick += new System.EventHandler(this.DNI_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 273);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 17;
            // 
            // VISORRESO
            // 
            this.VISORRESO.Location = new System.Drawing.Point(12, 198);
            this.VISORRESO.MinimumSize = new System.Drawing.Size(20, 20);
            this.VISORRESO.Name = "VISORRESO";
            this.VISORRESO.Size = new System.Drawing.Size(936, 680);
            this.VISORRESO.TabIndex = 18;
            // 
            // FECHADERESOLUCION
            // 
            this.FECHADERESOLUCION.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHADERESOLUCION.Location = new System.Drawing.Point(229, 150);
            this.FECHADERESOLUCION.Name = "FECHADERESOLUCION";
            this.FECHADERESOLUCION.Size = new System.Drawing.Size(128, 20);
            this.FECHADERESOLUCION.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "FECHA DE RESOLUCION";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(394, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "ACTO DE :";
            // 
            // TIPORESOLUCION
            // 
            this.TIPORESOLUCION.FormattingEnabled = true;
            this.TIPORESOLUCION.Location = new System.Drawing.Point(517, 147);
            this.TIPORESOLUCION.Name = "TIPORESOLUCION";
            this.TIPORESOLUCION.Size = new System.Drawing.Size(318, 28);
            this.TIPORESOLUCION.TabIndex = 21;
            // 
            // CARGARESO
            // 
            this.CARGARESO.Location = new System.Drawing.Point(864, 136);
            this.CARGARESO.Name = "CARGARESO";
            this.CARGARESO.Size = new System.Drawing.Size(99, 37);
            this.CARGARESO.TabIndex = 23;
            this.CARGARESO.Text = "CARGAR";
            this.CARGARESO.UseVisualStyleBackColor = true;
            this.CARGARESO.Click += new System.EventHandler(this.CARGARESO_Click);
            // 
            // CARGARRESOLUCIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 859);
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
    }
}