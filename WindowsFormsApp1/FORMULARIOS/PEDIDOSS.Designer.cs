namespace WindowsFormsApp1
{
    partial class PEDIDOSS
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
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.DNI2 = new System.Windows.Forms.Label();
            this.richpedidos = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PEDIDOSSS = new System.Windows.Forms.ListView();
            this.CBTRA = new System.Windows.Forms.Button();
            this.BIOMA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(365, 22);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(79, 20);
            this.textBoxDNI.TabIndex = 3;
            // 
            // DNI2
            // 
            this.DNI2.AutoSize = true;
            this.DNI2.Location = new System.Drawing.Point(385, 7);
            this.DNI2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.DNI2.Name = "DNI2";
            this.DNI2.Size = new System.Drawing.Size(26, 13);
            this.DNI2.TabIndex = 4;
            this.DNI2.Text = "DNI";
            // 
            // richpedidos
            // 
            this.richpedidos.Location = new System.Drawing.Point(549, 22);
            this.richpedidos.Margin = new System.Windows.Forms.Padding(1);
            this.richpedidos.Name = "richpedidos";
            this.richpedidos.Size = new System.Drawing.Size(290, 54);
            this.richpedidos.TabIndex = 5;
            this.richpedidos.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "PEDIDOS";
            // 
            // PEDIDOSSS
            // 
            this.PEDIDOSSS.FullRowSelect = true;
            this.PEDIDOSSS.HideSelection = false;
            this.PEDIDOSSS.Location = new System.Drawing.Point(17, 126);
            this.PEDIDOSSS.Margin = new System.Windows.Forms.Padding(2);
            this.PEDIDOSSS.Name = "PEDIDOSSS";
            this.PEDIDOSSS.ShowItemToolTips = true;
            this.PEDIDOSSS.Size = new System.Drawing.Size(1423, 262);
            this.PEDIDOSSS.TabIndex = 50;
            this.PEDIDOSSS.UseCompatibleStateImageBehavior = false;
            this.PEDIDOSSS.Click += new System.EventHandler(this.PEDIDOSSS_Click);
            this.PEDIDOSSS.DoubleClick += new System.EventHandler(this.PEDIDOSSS_DoubleClick);
            // 
            // CBTRA
            // 
            this.CBTRA.Location = new System.Drawing.Point(35, 7);
            this.CBTRA.Margin = new System.Windows.Forms.Padding(2);
            this.CBTRA.Name = "CBTRA";
            this.CBTRA.Size = new System.Drawing.Size(107, 49);
            this.CBTRA.TabIndex = 51;
            this.CBTRA.Text = "GENERAR CERTIFICADO DE TRABAJO";
            this.CBTRA.UseVisualStyleBackColor = true;
            this.CBTRA.Click += new System.EventHandler(this.CBTRA_Click);
            // 
            // BIOMA
            // 
            this.BIOMA.Location = new System.Drawing.Point(146, 7);
            this.BIOMA.Margin = new System.Windows.Forms.Padding(2);
            this.BIOMA.Name = "BIOMA";
            this.BIOMA.Size = new System.Drawing.Size(79, 49);
            this.BIOMA.TabIndex = 52;
            this.BIOMA.Text = "IOMA";
            this.BIOMA.UseVisualStyleBackColor = true;
            this.BIOMA.Click += new System.EventHandler(this.BIOMA_Click);
            // 
            // PEDIDOSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 701);
            this.Controls.Add(this.BIOMA);
            this.Controls.Add(this.CBTRA);
            this.Controls.Add(this.PEDIDOSSS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richpedidos);
            this.Controls.Add(this.DNI2);
            this.Controls.Add(this.textBoxDNI);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "PEDIDOSS";
            this.Text = "PEDIDOSS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PEDIDOSS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label DNI2;
        private System.Windows.Forms.RichTextBox richpedidos;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ListView PEDIDOSSS;
        private System.Windows.Forms.Button CBTRA;
        private System.Windows.Forms.Button BIOMA;
    }
}