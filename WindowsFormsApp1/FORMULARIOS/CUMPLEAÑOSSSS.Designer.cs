
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
            this.SuspendLayout();
            // 
            // CARGA
            // 
            this.CARGA.Location = new System.Drawing.Point(70, 112);
            this.CARGA.Name = "CARGA";
            this.CARGA.Size = new System.Drawing.Size(132, 49);
            this.CARGA.TabIndex = 7;
            this.CARGA.Text = "CARGAR DATOS";
            this.CARGA.UseVisualStyleBackColor = true;
            this.CARGA.Click += new System.EventHandler(this.CARGA_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "FECHA A ANALIZAR";
            // 
            // FECHAANALIZAR
            // 
            this.FECHAANALIZAR.CustomFormat = "yyyy-MM-dd";
            this.FECHAANALIZAR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FECHAANALIZAR.Location = new System.Drawing.Point(21, 60);
            this.FECHAANALIZAR.Name = "FECHAANALIZAR";
            this.FECHAANALIZAR.Size = new System.Drawing.Size(200, 20);
            this.FECHAANALIZAR.TabIndex = 5;
            // 
            // ANTIGUEDAD
            // 
            this.ANTIGUEDAD.HideSelection = false;
            this.ANTIGUEDAD.Location = new System.Drawing.Point(264, 368);
            this.ANTIGUEDAD.Name = "ANTIGUEDAD";
            this.ANTIGUEDAD.Size = new System.Drawing.Size(1368, 389);
            this.ANTIGUEDAD.TabIndex = 9;
            this.ANTIGUEDAD.UseCompatibleStateImageBehavior = false;
            this.ANTIGUEDAD.View = System.Windows.Forms.View.Details;
            // 
            // CARGARS
            // 
            this.CARGARS.Location = new System.Drawing.Point(70, 544);
            this.CARGARS.Name = "CARGARS";
            this.CARGARS.Size = new System.Drawing.Size(110, 49);
            this.CARGARS.TabIndex = 10;
            this.CARGARS.Text = "ANTIGUEDAD";
            this.CARGARS.UseVisualStyleBackColor = true;
            this.CARGARS.Click += new System.EventHandler(this.CARGARS_Click);
            // 
            // CUMPLES
            // 
            this.CUMPLES.HideSelection = false;
            this.CUMPLES.Location = new System.Drawing.Point(264, 25);
            this.CUMPLES.Name = "CUMPLES";
            this.CUMPLES.Size = new System.Drawing.Size(1368, 303);
            this.CUMPLES.TabIndex = 8;
            this.CUMPLES.UseCompatibleStateImageBehavior = false;
            this.CUMPLES.View = System.Windows.Forms.View.Details;
            // 
            // CUMPLEAÑOSSSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 687);
            this.Controls.Add(this.CARGARS);
            this.Controls.Add(this.ANTIGUEDAD);
            this.Controls.Add(this.CUMPLES);
            this.Controls.Add(this.CARGA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FECHAANALIZAR);
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
    }
}