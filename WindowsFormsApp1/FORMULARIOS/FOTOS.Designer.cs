namespace WindowsFormsApp1
{
    partial class FOTOS
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
            this.Visor = new System.Windows.Forms.PictureBox();
            this.VisorArbol = new System.Windows.Forms.TreeView();
            this.CARGARFOTO = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Visor
            // 
            this.Visor.Location = new System.Drawing.Point(121, 228);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(486, 549);
            this.Visor.TabIndex = 0;
            this.Visor.TabStop = false;
            // 
            // VisorArbol
            // 
            this.VisorArbol.Location = new System.Drawing.Point(715, 228);
            this.VisorArbol.Name = "VisorArbol";
            this.VisorArbol.Size = new System.Drawing.Size(486, 193);
            this.VisorArbol.TabIndex = 1;
            this.VisorArbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.VisorArbol_AfterSelect);
            this.VisorArbol.Click += new System.EventHandler(this.TimerActualizarRuta_Tick);
            // 
            // CARGARFOTO
            // 
            this.CARGARFOTO.Location = new System.Drawing.Point(904, 147);
            this.CARGARFOTO.Name = "CARGARFOTO";
            this.CARGARFOTO.Size = new System.Drawing.Size(113, 41);
            this.CARGARFOTO.TabIndex = 2;
            this.CARGARFOTO.Text = "CARGAR FOTO";
            this.CARGARFOTO.UseVisualStyleBackColor = true;
            this.CARGARFOTO.Click += new System.EventHandler(this.CARGARFOTO_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(121, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(693, 148);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(28, 54);
            this.PORDNI.Margin = new System.Windows.Forms.Padding(4);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(162, 20);
            this.PORDNI.TabIndex = 23;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR DNI";
            this.PORDNI.UseVisualStyleBackColor = true;
            // 
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(277, 106);
            this.apellido1.Margin = new System.Windows.Forms.Padding(4);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(376, 24);
            this.apellido1.TabIndex = 22;
            this.apellido1.SelectedIndexChanged += new System.EventHandler(this.Apellido1_SelectedIndexChanged_1);
            this.apellido1.SelectedValueChanged += new System.EventHandler(this.Apellido1_SelectedValueChanged);
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(28, 82);
            this.PORAPELLIDO.Margin = new System.Windows.Forms.Padding(4);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(203, 20);
            this.PORAPELLIDO.TabIndex = 24;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUEDA POR APELLIDO";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "APELLIDO Y NOMBRE";
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(276, 48);
            this.DNI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(377, 22);
            this.DNI.TabIndex = 10;
            this.DNI.Text = "0";
            this.DNI.TextChanged += new System.EventHandler(this.DNI_TextChanged);
            this.DNI.Validating += new System.ComponentModel.CancelEventHandler(this.DNI_Validating);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(375, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(147, 16);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "INGRESE AQUI EL DNI";
            // 
            // FOTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 837);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CARGARFOTO);
            this.Controls.Add(this.VisorArbol);
            this.Controls.Add(this.Visor);
            this.Name = "FOTOS";
            this.Text = "FOTOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Fotoss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Visor;
        private System.Windows.Forms.TreeView VisorArbol;
        private System.Windows.Forms.Button CARGARFOTO;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Timer timer;
    }
}