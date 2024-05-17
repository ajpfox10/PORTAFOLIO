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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewFaltantes = new System.Windows.Forms.ListView();
            this.upa4sinfoto = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.UPA18SINFOTO = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Visor
            // 
            this.Visor.Location = new System.Drawing.Point(1104, 340);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(546, 686);
            this.Visor.TabIndex = 0;
            this.Visor.TabStop = false;
            // 
            // VisorArbol
            // 
            this.VisorArbol.Location = new System.Drawing.Point(1101, 51);
            this.VisorArbol.Name = "VisorArbol";
            this.VisorArbol.Size = new System.Drawing.Size(547, 241);
            this.VisorArbol.TabIndex = 1;
            this.VisorArbol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.VisorArbol_AfterSelect);
            this.VisorArbol.Click += new System.EventHandler(this.TimerActualizarRuta_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(780, 185);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SETS";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(32, 68);
            this.PORDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(196, 24);
            this.PORDNI.TabIndex = 23;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR DNI";
            this.PORDNI.UseVisualStyleBackColor = true;
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
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(32, 103);
            this.PORAPELLIDO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(247, 24);
            this.PORAPELLIDO.TabIndex = 24;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUEDA POR APELLIDO";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1282, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "ARCHIVOS DEL AGENTE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1340, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "ARCHIVO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(477, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "HOSPITAL SIN FOTO";
            // 
            // listViewFaltantes
            // 
            this.listViewFaltantes.HideSelection = false;
            this.listViewFaltantes.Location = new System.Drawing.Point(18, 340);
            this.listViewFaltantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewFaltantes.Name = "listViewFaltantes";
            this.listViewFaltantes.Size = new System.Drawing.Size(1044, 186);
            this.listViewFaltantes.TabIndex = 31;
            this.listViewFaltantes.UseCompatibleStateImageBehavior = false;
            this.listViewFaltantes.View = System.Windows.Forms.View.List;
            // 
            // upa4sinfoto
            // 
            this.upa4sinfoto.HideSelection = false;
            this.upa4sinfoto.Location = new System.Drawing.Point(18, 579);
            this.upa4sinfoto.Name = "upa4sinfoto";
            this.upa4sinfoto.Size = new System.Drawing.Size(1044, 127);
            this.upa4sinfoto.TabIndex = 32;
            this.upa4sinfoto.UseCompatibleStateImageBehavior = false;
            this.upa4sinfoto.View = System.Windows.Forms.View.List;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "UPA 4 SIN FOTO";
            // 
            // UPA18SINFOTO
            // 
            this.UPA18SINFOTO.HideSelection = false;
            this.UPA18SINFOTO.Location = new System.Drawing.Point(18, 759);
            this.UPA18SINFOTO.Name = "UPA18SINFOTO";
            this.UPA18SINFOTO.Size = new System.Drawing.Size(1044, 127);
            this.UPA18SINFOTO.TabIndex = 34;
            this.UPA18SINFOTO.UseCompatibleStateImageBehavior = false;
            this.UPA18SINFOTO.View = System.Windows.Forms.View.List;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(523, 726);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "UPA 18 SIN FOTO";
            // 
            // FOTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1671, 1050);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UPA18SINFOTO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.upa4sinfoto);
            this.Controls.Add(this.listViewFaltantes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Visor;
        private System.Windows.Forms.TreeView VisorArbol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox DNI;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewFaltantes;
        private System.Windows.Forms.ListView upa4sinfoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView UPA18SINFOTO;
        private System.Windows.Forms.Label label7;
    }
}