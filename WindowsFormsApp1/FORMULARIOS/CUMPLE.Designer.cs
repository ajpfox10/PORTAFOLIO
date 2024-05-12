namespace WindowsFormsApp1
{
    partial class CUMPLESS
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
            this.FECHAANALIZAR = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.CARGA = new System.Windows.Forms.Button();
            this.CUMPLES = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // FECHAANALIZAR
            // 
            this.FECHAANALIZAR.CustomFormat = "yyyy-MM-dd";
            this.FECHAANALIZAR.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FECHAANALIZAR.Location = new System.Drawing.Point(209, 120);
            this.FECHAANALIZAR.Name = "FECHAANALIZAR";
            this.FECHAANALIZAR.Size = new System.Drawing.Size(200, 26);
            this.FECHAANALIZAR.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "FECHA A ANALIZAR";
            // 
            // CARGA
            // 
            this.CARGA.Location = new System.Drawing.Point(523, 97);
            this.CARGA.Name = "CARGA";
            this.CARGA.Size = new System.Drawing.Size(132, 49);
            this.CARGA.TabIndex = 3;
            this.CARGA.Text = "CARGAR DATOS";
            this.CARGA.UseVisualStyleBackColor = true;
            this.CARGA.Click += new System.EventHandler(this.CARGA_Click);
            // 
            // CUMPLES
            // 
            this.CUMPLES.HideSelection = false;
            this.CUMPLES.Location = new System.Drawing.Point(31, 236);
            this.CUMPLES.Name = "CUMPLES";
            this.CUMPLES.Size = new System.Drawing.Size(1368, 303);
            this.CUMPLES.TabIndex = 4;
            this.CUMPLES.UseCompatibleStateImageBehavior = false;
            this.CUMPLES.View = System.Windows.Forms.View.Details;
            // 
            // CUMPLESS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1428, 778);
            this.Controls.Add(this.CUMPLES);
            this.Controls.Add(this.CARGA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FECHAANALIZAR);
            this.Name = "CUMPLESS";
            this.Text = "CUMPLEAÑOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FECHAANALIZAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CARGA;
        private System.Windows.Forms.ListView CUMPLES;
    }
}