
namespace WindowsFormsApp1
{
    partial class CUMPLEAÑOSSSS
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
            this.CARGA = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FECHAANALIZAR = new System.Windows.Forms.DateTimePicker();
            this.ANTIGUEDAD = new System.Windows.Forms.ListView();
            this.CARGARS = new System.Windows.Forms.Button();
            this.CUMPLES = new System.Windows.Forms.ListView();
            this.cmbColumnas = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.cmbColumnas2 = new System.Windows.Forms.ComboBox();
            this.txtValorFiltrar2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CARGA
            // 
            this.CARGA.Location = new System.Drawing.Point(47, 73);
            this.CARGA.Margin = new System.Windows.Forms.Padding(2);
            this.CARGA.Name = "CARGA";
            this.CARGA.Size = new System.Drawing.Size(88, 32);
            this.CARGA.TabIndex = 7;
            this.CARGA.Text = "CARGAR DATOS";
            this.CARGA.UseVisualStyleBackColor = true;
            this.CARGA.Click += new System.EventHandler(this.CARGA_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "FECHA A ANALIZAR";
            // 
            // FECHAANALIZAR
            // 
            this.FECHAANALIZAR.CustomFormat = "yyyy-MM-dd";
            this.FECHAANALIZAR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FECHAANALIZAR.Location = new System.Drawing.Point(14, 39);
            this.FECHAANALIZAR.Margin = new System.Windows.Forms.Padding(2);
            this.FECHAANALIZAR.Name = "FECHAANALIZAR";
            this.FECHAANALIZAR.Size = new System.Drawing.Size(135, 20);
            this.FECHAANALIZAR.TabIndex = 5;
            // 
            // ANTIGUEDAD
            // 
            this.ANTIGUEDAD.HideSelection = false;
            this.ANTIGUEDAD.Location = new System.Drawing.Point(176, 239);
            this.ANTIGUEDAD.Margin = new System.Windows.Forms.Padding(2);
            this.ANTIGUEDAD.Name = "ANTIGUEDAD";
            this.ANTIGUEDAD.Size = new System.Drawing.Size(974, 254);
            this.ANTIGUEDAD.TabIndex = 9;
            this.ANTIGUEDAD.UseCompatibleStateImageBehavior = false;
            this.ANTIGUEDAD.View = System.Windows.Forms.View.Details;
            // 
            // CARGARS
            // 
            this.CARGARS.Location = new System.Drawing.Point(47, 258);
            this.CARGARS.Margin = new System.Windows.Forms.Padding(2);
            this.CARGARS.Name = "CARGARS";
            this.CARGARS.Size = new System.Drawing.Size(88, 32);
            this.CARGARS.TabIndex = 10;
            this.CARGARS.Text = "ANTIGUEDAD";
            this.CARGARS.UseVisualStyleBackColor = true;
            this.CARGARS.Click += new System.EventHandler(this.CARGA_Click);
            // 
            // CUMPLES
            // 
            this.CUMPLES.HideSelection = false;
            this.CUMPLES.Location = new System.Drawing.Point(176, 16);
            this.CUMPLES.Margin = new System.Windows.Forms.Padding(2);
            this.CUMPLES.Name = "CUMPLES";
            this.CUMPLES.Size = new System.Drawing.Size(974, 198);
            this.CUMPLES.TabIndex = 8;
            this.CUMPLES.UseCompatibleStateImageBehavior = false;
            this.CUMPLES.View = System.Windows.Forms.View.Details;
            // 
            // cmbColumnas
            // 
            this.cmbColumnas.FormattingEnabled = true;
            this.cmbColumnas.Location = new System.Drawing.Point(28, 295);
            this.cmbColumnas.Name = "cmbColumnas";
            this.cmbColumnas.Size = new System.Drawing.Size(121, 21);
            this.cmbColumnas.TabIndex = 11;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(28, 322);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(121, 20);
            this.txtBuscar.TabIndex = 12;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // cmbColumnas2
            // 
            this.cmbColumnas2.FormattingEnabled = true;
            this.cmbColumnas2.Location = new System.Drawing.Point(28, 348);
            this.cmbColumnas2.Name = "cmbColumnas2";
            this.cmbColumnas2.Size = new System.Drawing.Size(121, 21);
            this.cmbColumnas2.TabIndex = 13;
            // 
            // txtValorFiltrar2
            // 
            this.txtValorFiltrar2.Location = new System.Drawing.Point(26, 375);
            this.txtValorFiltrar2.Name = "txtValorFiltrar2";
            this.txtValorFiltrar2.Size = new System.Drawing.Size(123, 20);
            this.txtValorFiltrar2.TabIndex = 14;
            // 
            // CUMPLEAÑOSSSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 537);
            this.Controls.Add(this.txtValorFiltrar2);
            this.Controls.Add(this.cmbColumnas2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.cmbColumnas);
            this.Controls.Add(this.CARGARS);
            this.Controls.Add(this.ANTIGUEDAD);
            this.Controls.Add(this.CUMPLES);
            this.Controls.Add(this.CARGA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FECHAANALIZAR);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CUMPLEAÑOSSSS";
            this.Text = "CUMPLEAÑOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CARGA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FECHAANALIZAR;
        private System.Windows.Forms.ListView ANTIGUEDAD;
        private System.Windows.Forms.Button CARGARS;
        private System.Windows.Forms.ListView CUMPLES;
        private System.Windows.Forms.ComboBox cmbColumnas;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ComboBox cmbColumnas2;
        private System.Windows.Forms.TextBox txtValorFiltrar2;
    }
}