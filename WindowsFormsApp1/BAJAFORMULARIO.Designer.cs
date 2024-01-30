namespace WindowsFormsApp1
{
    partial class BAJAFORMULARIO
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
            this.ALTABAJAS = new System.Windows.Forms.CheckBox();
            this.DARDEBAJA = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ALTASBAJAS1 = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
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
            this.radioButton1.Size = new System.Drawing.Size(140, 20);
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
            this.apellido1.Location = new System.Drawing.Point(208, 86);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(283, 21);
            this.apellido1.TabIndex = 22;
            this.apellido1.SelectedIndexChanged += new System.EventHandler(this.apellido1_SelectedIndexChanged);
            this.apellido1.SelectedValueChanged += new System.EventHandler(this.apellido1_SelectedValueChanged_1);
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
            // ALTABAJAS
            // 
            this.ALTABAJAS.AutoSize = true;
            this.ALTABAJAS.Location = new System.Drawing.Point(547, 77);
            this.ALTABAJAS.Margin = new System.Windows.Forms.Padding(2);
            this.ALTABAJAS.Name = "ALTABAJAS";
            this.ALTABAJAS.Size = new System.Drawing.Size(60, 21);
            this.ALTABAJAS.TabIndex = 27;
            this.ALTABAJAS.Text = "ALTA";
            this.ALTABAJAS.UseVisualStyleBackColor = true;
            // 
            // DARDEBAJA
            // 
            this.DARDEBAJA.Location = new System.Drawing.Point(766, 88);
            this.DARDEBAJA.Name = "DARDEBAJA";
            this.DARDEBAJA.Size = new System.Drawing.Size(75, 40);
            this.DARDEBAJA.TabIndex = 28;
            this.DARDEBAJA.Text = "BAJAR";
            this.DARDEBAJA.UseVisualStyleBackColor = true;
            this.DARDEBAJA.Visible = false;
            this.DARDEBAJA.Click += new System.EventHandler(this.DARDEBAJA_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(847, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "DAR DE ALTA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ALTASBAJAS1
            // 
            this.ALTASBAJAS1.AutoSize = true;
            this.ALTASBAJAS1.Location = new System.Drawing.Point(63, 156);
            this.ALTASBAJAS1.Name = "ALTASBAJAS1";
            this.ALTASBAJAS1.Size = new System.Drawing.Size(231, 21);
            this.ALTASBAJAS1.TabIndex = 30;
            this.ALTASBAJAS1.Text = "ESTADO DEL AGENTE TILDADO ALTA ";
            this.ALTASBAJAS1.UseVisualStyleBackColor = true;
            // 
            // bajaformulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 484);
            this.Controls.Add(this.ALTASBAJAS1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DARDEBAJA);
            this.Controls.Add(this.ALTABAJAS);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "bajaformulario";
            this.Text = "FORMULARIO DE BAJA ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.bajaformulario_Load);
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
        private System.Windows.Forms.CheckBox ALTABAJAS;
        private System.Windows.Forms.Button DARDEBAJA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ALTASBAJAS1;
    }
}