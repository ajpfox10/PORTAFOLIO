namespace WindowsFormsApp1
{
    partial class BONIFICACIONES
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
            this.FECHAALTA = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.FECHABAJA = new System.Windows.Forms.DateTimePicker();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.DECRETO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MOTIVO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.observaciones = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EXPEDIENTE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boni = new System.Windows.Forms.ListView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.CARGARDATOS = new System.Windows.Forms.Button();
            this.EDITARDATOS = new System.Windows.Forms.Button();
            this.CARGARPDF = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FECHAALTA
            // 
            this.FECHAALTA.CustomFormat = "yyyy-MM-dd";
            this.FECHAALTA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHAALTA.Location = new System.Drawing.Point(34, 38);
            this.FECHAALTA.Margin = new System.Windows.Forms.Padding(2);
            this.FECHAALTA.Name = "FECHAALTA";
            this.FECHAALTA.Size = new System.Drawing.Size(135, 20);
            this.FECHAALTA.TabIndex = 0;
            this.FECHAALTA.Value = new System.DateTime(2023, 6, 15, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FECHA DE ALTA";
            // 
            // FECHABAJA
            // 
            this.FECHABAJA.CustomFormat = "yyyy-MM-dd";
            this.FECHABAJA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FECHABAJA.Location = new System.Drawing.Point(183, 38);
            this.FECHABAJA.Margin = new System.Windows.Forms.Padding(2);
            this.FECHABAJA.Name = "FECHABAJA";
            this.FECHABAJA.Size = new System.Drawing.Size(135, 20);
            this.FECHABAJA.TabIndex = 2;
            this.FECHABAJA.Value = new System.DateTime(2023, 6, 15, 0, 0, 0, 0);
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(198, 21);
            this.autoLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(89, 13);
            this.autoLabel1.TabIndex = 3;
            this.autoLabel1.Text = "FECHA DE BAJA";
            // 
            // DECRETO
            // 
            this.DECRETO.Location = new System.Drawing.Point(327, 40);
            this.DECRETO.Margin = new System.Windows.Forms.Padding(2);
            this.DECRETO.Name = "DECRETO";
            this.DECRETO.Size = new System.Drawing.Size(135, 20);
            this.DECRETO.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "DECRETO";
            // 
            // MOTIVO
            // 
            this.MOTIVO.Location = new System.Drawing.Point(471, 41);
            this.MOTIVO.Margin = new System.Windows.Forms.Padding(2);
            this.MOTIVO.Name = "MOTIVO";
            this.MOTIVO.Size = new System.Drawing.Size(135, 20);
            this.MOTIVO.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "MOTIVO";
            // 
            // observaciones
            // 
            this.observaciones.Location = new System.Drawing.Point(613, 42);
            this.observaciones.Margin = new System.Windows.Forms.Padding(2);
            this.observaciones.Name = "observaciones";
            this.observaciones.Size = new System.Drawing.Size(135, 20);
            this.observaciones.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(628, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "OBSERVACIONES";
            // 
            // EXPEDIENTE
            // 
            this.EXPEDIENTE.Location = new System.Drawing.Point(756, 42);
            this.EXPEDIENTE.Margin = new System.Windows.Forms.Padding(2);
            this.EXPEDIENTE.Name = "EXPEDIENTE";
            this.EXPEDIENTE.Size = new System.Drawing.Size(135, 20);
            this.EXPEDIENTE.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(771, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "EXPEDIENTE";
            // 
            // boni
            // 
            this.boni.HideSelection = false;
            this.boni.Location = new System.Drawing.Point(34, 120);
            this.boni.Margin = new System.Windows.Forms.Padding(2);
            this.boni.Name = "boni";
            this.boni.Size = new System.Drawing.Size(970, 225);
            this.boni.TabIndex = 12;
            this.boni.UseCompatibleStateImageBehavior = false;
            this.boni.View = System.Windows.Forms.View.Details;
            this.boni.DoubleClick += new System.EventHandler(this.Boni_DoubleClick);
            this.boni.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Boni_MouseDoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(34, 374);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(969, 162);
            this.webBrowser1.TabIndex = 13;
            // 
            // CARGARDATOS
            // 
            this.CARGARDATOS.Location = new System.Drawing.Point(613, 75);
            this.CARGARDATOS.Margin = new System.Windows.Forms.Padding(2);
            this.CARGARDATOS.Name = "CARGARDATOS";
            this.CARGARDATOS.Size = new System.Drawing.Size(86, 31);
            this.CARGARDATOS.TabIndex = 14;
            this.CARGARDATOS.Text = "CARGAR DATOS";
            this.CARGARDATOS.UseVisualStyleBackColor = true;
            this.CARGARDATOS.Click += new System.EventHandler(this.CARGARDATOS_Click);
            // 
            // EDITARDATOS
            // 
            this.EDITARDATOS.Location = new System.Drawing.Point(703, 75);
            this.EDITARDATOS.Margin = new System.Windows.Forms.Padding(2);
            this.EDITARDATOS.Name = "EDITARDATOS";
            this.EDITARDATOS.Size = new System.Drawing.Size(85, 31);
            this.EDITARDATOS.TabIndex = 15;
            this.EDITARDATOS.Text = "EDITAR DATOS";
            this.EDITARDATOS.UseVisualStyleBackColor = true;
            this.EDITARDATOS.Click += new System.EventHandler(this.EDITARDATOS_Click);
            // 
            // CARGARPDF
            // 
            this.CARGARPDF.Location = new System.Drawing.Point(792, 75);
            this.CARGARPDF.Margin = new System.Windows.Forms.Padding(2);
            this.CARGARPDF.Name = "CARGARPDF";
            this.CARGARPDF.Size = new System.Drawing.Size(81, 31);
            this.CARGARPDF.TabIndex = 16;
            this.CARGARPDF.Text = "CARGAR PDF";
            this.CARGARPDF.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(908, 40);
            this.ID.Margin = new System.Windows.Forms.Padding(2);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(68, 20);
            this.ID.TabIndex = 17;
            this.ID.Text = "0";
            // 
            // BONIFICACIONES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 606);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.CARGARPDF);
            this.Controls.Add(this.EDITARDATOS);
            this.Controls.Add(this.CARGARDATOS);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.boni);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EXPEDIENTE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.observaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MOTIVO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DECRETO);
            this.Controls.Add(this.autoLabel1);
            this.Controls.Add(this.FECHABAJA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FECHAALTA);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BONIFICACIONES";
            this.Text = "BONIFICACIONES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BONIFICACIONES_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FECHAALTA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FECHABAJA;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private System.Windows.Forms.TextBox DECRETO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MOTIVO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox observaciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EXPEDIENTE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView boni;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button CARGARDATOS;
        private System.Windows.Forms.Button EDITARDATOS;
        private System.Windows.Forms.Button CARGARPDF;
        private System.Windows.Forms.TextBox ID;
    }
}