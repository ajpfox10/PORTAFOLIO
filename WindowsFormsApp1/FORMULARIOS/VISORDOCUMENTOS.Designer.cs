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
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.VisorArbol = new System.Windows.Forms.TreeView();
            this.Visor = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 120);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
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
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(208, 86);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(283, 21);
            this.apellido1.TabIndex = 22;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(21, 67);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(166, 17);
            this.PORAPELLIDO.TabIndex = 24;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUEDA POR APELLIDO";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
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
            // VisorArbol
            // 
            this.VisorArbol.Location = new System.Drawing.Point(641, 12);
            this.VisorArbol.Margin = new System.Windows.Forms.Padding(2);
            this.VisorArbol.Name = "VisorArbol";
            this.VisorArbol.Size = new System.Drawing.Size(366, 158);
            this.VisorArbol.TabIndex = 35;
            // 
            // Visor
            // 
            this.Visor.Location = new System.Drawing.Point(25, 140);
            this.Visor.Margin = new System.Windows.Forms.Padding(2);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(364, 446);
            this.Visor.TabIndex = 34;
            this.Visor.TabStop = false;
            // 
            // BAJAFORMULARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.VisorArbol);
            this.Controls.Add(this.Visor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BAJAFORMULARIO";
            this.Text = "FORMULARIO DE DOCUMENTOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TreeView VisorArbol;
        private System.Windows.Forms.PictureBox Visor;
    }
}