namespace WindowsFormsApp1
{
    partial class CARGARFAMILIA
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
            this.ID = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.DATOSCARGAFAMILIA = new System.Windows.Forms.Button();
            this.sexo = new System.Windows.Forms.ComboBox();
            this.PROFESION = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.jubilacion = new System.Windows.Forms.ComboBox();
            this.CAJADEJUBILACION = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.fechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.Label3 = new System.Windows.Forms.Label();
            this.VIVE = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.APEELIDOYNOMBRE = new System.Windows.Forms.TextBox();
            this.PARENTESCO = new System.Windows.Forms.ComboBox();
            this.FAMILIAS = new System.Windows.Forms.ListView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CARGARPDF = new System.Windows.Forms.Button();
            this.Cargafamilia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(1763, 34);
            this.ID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(48, 26);
            this.ID.TabIndex = 60;
            this.ID.Text = "0";
            this.ID.Visible = false;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(0, 0);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 68;
            // 
            // DATOSCARGAFAMILIA
            // 
            this.DATOSCARGAFAMILIA.Location = new System.Drawing.Point(14, 115);
            this.DATOSCARGAFAMILIA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DATOSCARGAFAMILIA.Name = "DATOSCARGAFAMILIA";
            this.DATOSCARGAFAMILIA.Size = new System.Drawing.Size(216, 69);
            this.DATOSCARGAFAMILIA.TabIndex = 57;
            this.DATOSCARGAFAMILIA.Text = "CARGA DATOS";
            this.DATOSCARGAFAMILIA.UseVisualStyleBackColor = true;
            this.DATOSCARGAFAMILIA.Click += new System.EventHandler(this.DATOSCARGAFAMILIA_Click);
            // 
            // sexo
            // 
            this.sexo.FormattingEnabled = true;
            this.sexo.Items.AddRange(new object[] {
            "F",
            "M",
            "X"});
            this.sexo.Location = new System.Drawing.Point(1630, 34);
            this.sexo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sexo.Name = "sexo";
            this.sexo.Size = new System.Drawing.Size(108, 28);
            this.sexo.TabIndex = 56;
            // 
            // PROFESION
            // 
            this.PROFESION.Location = new System.Drawing.Point(1418, 37);
            this.PROFESION.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PROFESION.Name = "PROFESION";
            this.PROFESION.Size = new System.Drawing.Size(204, 26);
            this.PROFESION.TabIndex = 55;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(1222, 11);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(160, 20);
            this.Label7.TabIndex = 54;
            this.Label7.Text = "INDICAR QUE CAJA";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(1072, 12);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(107, 20);
            this.Label5.TabIndex = 53;
            this.Label5.Text = "¿JUBILADO?";
            // 
            // jubilacion
            // 
            this.jubilacion.FormattingEnabled = true;
            this.jubilacion.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.jubilacion.Location = new System.Drawing.Point(1072, 37);
            this.jubilacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jubilacion.Name = "jubilacion";
            this.jubilacion.Size = new System.Drawing.Size(108, 28);
            this.jubilacion.TabIndex = 52;
            // 
            // CAJADEJUBILACION
            // 
            this.CAJADEJUBILACION.Location = new System.Drawing.Point(1210, 38);
            this.CAJADEJUBILACION.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CAJADEJUBILACION.Name = "CAJADEJUBILACION";
            this.CAJADEJUBILACION.Size = new System.Drawing.Size(196, 26);
            this.CAJADEJUBILACION.TabIndex = 51;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(784, 11);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(194, 20);
            this.Label4.TabIndex = 50;
            this.Label4.Text = "FECHA DE NACIMIENTO";
            // 
            // fechanacimiento
            // 
            this.fechanacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechanacimiento.Location = new System.Drawing.Point(740, 37);
            this.fechanacimiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fechanacimiento.Name = "fechanacimiento";
            this.fechanacimiento.Size = new System.Drawing.Size(298, 26);
            this.fechanacimiento.TabIndex = 49;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(616, 11);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 20);
            this.Label3.TabIndex = 48;
            this.Label3.Text = "¿VIVE?";
            // 
            // VIVE
            // 
            this.VIVE.FormattingEnabled = true;
            this.VIVE.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.VIVE.Location = new System.Drawing.Point(604, 35);
            this.VIVE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VIVE.Name = "VIVE";
            this.VIVE.Size = new System.Drawing.Size(104, 28);
            this.VIVE.TabIndex = 47;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(322, 11);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(177, 20);
            this.Label2.TabIndex = 46;
            this.Label2.Text = "APELLIDO Y NOMBRE";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(64, 11);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(118, 20);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "PARENTESCO";
            // 
            // APEELIDOYNOMBRE
            // 
            this.APEELIDOYNOMBRE.Location = new System.Drawing.Point(256, 35);
            this.APEELIDOYNOMBRE.Name = "APEELIDOYNOMBRE";
            this.APEELIDOYNOMBRE.Size = new System.Drawing.Size(300, 26);
            this.APEELIDOYNOMBRE.TabIndex = 44;
            this.APEELIDOYNOMBRE.UseWaitCursor = true;
            // 
            // PARENTESCO
            // 
            this.PARENTESCO.FormattingEnabled = true;
            this.PARENTESCO.Items.AddRange(new object[] {
            "PADRE",
            "MADRE",
            "ESPOSO",
            "ESPOSA",
            "CONVIVIENTE",
            "HIJO",
            "HIJA",
            "HERMANO",
            "HERMANA"});
            this.PARENTESCO.Location = new System.Drawing.Point(22, 34);
            this.PARENTESCO.Name = "PARENTESCO";
            this.PARENTESCO.Size = new System.Drawing.Size(204, 28);
            this.PARENTESCO.TabIndex = 43;
            // 
            // FAMILIAS
            // 
            this.FAMILIAS.HideSelection = false;
            this.FAMILIAS.Location = new System.Drawing.Point(12, 203);
            this.FAMILIAS.Name = "FAMILIAS";
            this.FAMILIAS.Size = new System.Drawing.Size(1880, 182);
            this.FAMILIAS.TabIndex = 61;
            this.FAMILIAS.UseCompatibleStateImageBehavior = false;
            this.FAMILIAS.View = System.Windows.Forms.View.Details;
            this.FAMILIAS.DoubleClick += new System.EventHandler(this.FAMILIAS_DoubleClick);
            this.FAMILIAS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FAMILIAS_MouseDoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(14, 403);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1878, 354);
            this.webBrowser1.TabIndex = 62;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(1654, 11);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(54, 20);
            this.Label8.TabIndex = 66;
            this.Label8.Text = "SEXO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1462, 11);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 64;
            this.label9.Text = "PROFESION";
            // 
            // CARGARPDF
            // 
            this.CARGARPDF.Location = new System.Drawing.Point(481, 115);
            this.CARGARPDF.Name = "CARGARPDF";
            this.CARGARPDF.Size = new System.Drawing.Size(176, 69);
            this.CARGARPDF.TabIndex = 67;
            this.CARGARPDF.Text = "CARGAR PDF";
            this.CARGARPDF.UseVisualStyleBackColor = true;
            this.CARGARPDF.Click += new System.EventHandler(this.CARGARPDF_Click);
            // 
            // Cargafamilia
            // 
            this.Cargafamilia.Location = new System.Drawing.Point(247, 115);
            this.Cargafamilia.Name = "Cargafamilia";
            this.Cargafamilia.Size = new System.Drawing.Size(199, 69);
            this.Cargafamilia.TabIndex = 69;
            this.Cargafamilia.Text = "EDITAR DATOS";
            this.Cargafamilia.UseVisualStyleBackColor = true;
            this.Cargafamilia.Click += new System.EventHandler(this.Cargafamilia_Click);
            // 
            // CARGARFAMILIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 906);
            this.Controls.Add(this.Cargafamilia);
            this.Controls.Add(this.CARGARPDF);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.FAMILIAS);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DATOSCARGAFAMILIA);
            this.Controls.Add(this.sexo);
            this.Controls.Add(this.PROFESION);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.jubilacion);
            this.Controls.Add(this.CAJADEJUBILACION);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.fechanacimiento);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.VIVE);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.APEELIDOYNOMBRE);
            this.Controls.Add(this.PARENTESCO);
            this.Name = "CARGARFAMILIA";
            this.Text = "CARGAR DE FAMILIA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CARGARFAMILIA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox ID;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button DATOSCARGAFAMILIA;
        internal System.Windows.Forms.ComboBox sexo;
        internal System.Windows.Forms.TextBox PROFESION;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox jubilacion;
        internal System.Windows.Forms.TextBox CAJADEJUBILACION;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DateTimePicker fechanacimiento;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox VIVE;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox APEELIDOYNOMBRE;
        internal System.Windows.Forms.ComboBox PARENTESCO;
        private System.Windows.Forms.ListView FAMILIAS;
        private System.Windows.Forms.WebBrowser webBrowser1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button CARGARPDF;
        private System.Windows.Forms.Button Cargafamilia;
    }
}