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
            this.textBoxDNI.Location = new System.Drawing.Point(548, 34);
            this.textBoxDNI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(116, 26);
            this.textBoxDNI.TabIndex = 3;
            // 
            // DNI2
            // 
            this.DNI2.AutoSize = true;
            this.DNI2.Location = new System.Drawing.Point(578, 11);
            this.DNI2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DNI2.Name = "DNI2";
            this.DNI2.Size = new System.Drawing.Size(37, 20);
            this.DNI2.TabIndex = 4;
            this.DNI2.Text = "DNI";
            // 
            // richpedidos
            // 
            this.richpedidos.Location = new System.Drawing.Point(824, 34);
            this.richpedidos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richpedidos.Name = "richpedidos";
            this.richpedidos.Size = new System.Drawing.Size(433, 81);
            this.richpedidos.TabIndex = 5;
            this.richpedidos.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(722, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "PEDIDOS";
            // 
            // PEDIDOSSS
            // 
            this.PEDIDOSSS.FullRowSelect = true;
            this.PEDIDOSSS.HideSelection = false;
            this.PEDIDOSSS.Location = new System.Drawing.Point(26, 194);
            this.PEDIDOSSS.Name = "PEDIDOSSS";
            this.PEDIDOSSS.ShowItemToolTips = true;
            this.PEDIDOSSS.Size = new System.Drawing.Size(1465, 401);
            this.PEDIDOSSS.TabIndex = 50;
            this.PEDIDOSSS.UseCompatibleStateImageBehavior = false;
            this.PEDIDOSSS.Click += new System.EventHandler(this.PEDIDOSSS_Click);
            this.PEDIDOSSS.DoubleClick += new System.EventHandler(this.PEDIDOSSS_DoubleClick);
            // 
            // CBTRA
            // 
            this.CBTRA.Location = new System.Drawing.Point(52, 11);
            this.CBTRA.Name = "CBTRA";
            this.CBTRA.Size = new System.Drawing.Size(160, 75);
            this.CBTRA.TabIndex = 51;
            this.CBTRA.Text = "GENERAR CERTIFICADO DE TRABAJO";
            this.CBTRA.UseVisualStyleBackColor = true;
            this.CBTRA.Click += new System.EventHandler(this.CBTRA_Click);
            // 
            // BIOMA
            // 
            this.BIOMA.Location = new System.Drawing.Point(219, 11);
            this.BIOMA.Name = "BIOMA";
            this.BIOMA.Size = new System.Drawing.Size(118, 75);
            this.BIOMA.TabIndex = 52;
            this.BIOMA.Text = "IOMA";
            this.BIOMA.UseVisualStyleBackColor = true;
            this.BIOMA.Click += new System.EventHandler(this.BIOMA_Click);
            // 
            // PEDIDOSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 638);
            this.Controls.Add(this.BIOMA);
            this.Controls.Add(this.CBTRA);
            this.Controls.Add(this.PEDIDOSSS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richpedidos);
            this.Controls.Add(this.DNI2);
            this.Controls.Add(this.textBoxDNI);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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