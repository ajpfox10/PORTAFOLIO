namespace WindowsFormsApp1
{
    partial class CARGADEDOMICILIO
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
            this.Button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.EDITARDATOS = new System.Windows.Forms.Button();
            this.CARGADATOS = new System.Windows.Forms.Button();
            this.EMAIL = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.TELCONTACTO = new System.Windows.Forms.TextBox();
            this.TELEMERGENCIA = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.OTRASCARACTERISTICAS = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.depto = new System.Windows.Forms.TextBox();
            this.piso = new System.Windows.Forms.TextBox();
            this.numero = new System.Windows.Forms.TextBox();
            this.calle = new System.Windows.Forms.TextBox();
            this.LOCALIDAD = new System.Windows.Forms.ComboBox();
            this.PARTIDO = new System.Windows.Forms.ComboBox();
            this.PCIA = new System.Windows.Forms.ComboBox();
            this.CARDADEDOMICILIO = new System.Windows.Forms.ListView();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(1341, 171);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(142, 51);
            this.Button1.TabIndex = 57;
            this.Button1.Text = "CARGAR PDF ";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(592, 196);
            this.ID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(148, 26);
            this.ID.TabIndex = 56;
            this.ID.Text = "0";
            this.ID.Visible = false;
            // 
            // EDITARDATOS
            // 
            this.EDITARDATOS.Location = new System.Drawing.Point(1341, 112);
            this.EDITARDATOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EDITARDATOS.Name = "EDITARDATOS";
            this.EDITARDATOS.Size = new System.Drawing.Size(142, 49);
            this.EDITARDATOS.TabIndex = 54;
            this.EDITARDATOS.Text = "EDITAR DATOS";
            this.EDITARDATOS.UseVisualStyleBackColor = true;
            this.EDITARDATOS.Click += new System.EventHandler(this.EDITARDATOS_Click);
            // 
            // CARGADATOS
            // 
            this.CARGADATOS.Location = new System.Drawing.Point(1341, 48);
            this.CARGADATOS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CARGADATOS.Name = "CARGADATOS";
            this.CARGADATOS.Size = new System.Drawing.Size(142, 54);
            this.CARGADATOS.TabIndex = 53;
            this.CARGADATOS.Text = "CARGAR DATOS";
            this.CARGADATOS.UseVisualStyleBackColor = true;
            this.CARGADATOS.Click += new System.EventHandler(this.CARGADATOS_Click);
            // 
            // EMAIL
            // 
            this.EMAIL.Location = new System.Drawing.Point(1102, 87);
            this.EMAIL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Size = new System.Drawing.Size(222, 26);
            this.EMAIL.TabIndex = 51;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(1121, 48);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(175, 20);
            this.Label11.TabIndex = 50;
            this.Label11.Text = "EMAIL DE CONTACTO";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(304, 196);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(155, 20);
            this.Label10.TabIndex = 49;
            this.Label10.Text = "TEL DE CONTACTO";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(32, 196);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(178, 20);
            this.Label9.TabIndex = 48;
            this.Label9.Text = "TEL DE EMERGENCIA";
            // 
            // TELCONTACTO
            // 
            this.TELCONTACTO.Location = new System.Drawing.Point(270, 221);
            this.TELCONTACTO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TELCONTACTO.Name = "TELCONTACTO";
            this.TELCONTACTO.Size = new System.Drawing.Size(222, 26);
            this.TELCONTACTO.TabIndex = 47;
            // 
            // TELEMERGENCIA
            // 
            this.TELEMERGENCIA.Location = new System.Drawing.Point(12, 221);
            this.TELEMERGENCIA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TELEMERGENCIA.Name = "TELEMERGENCIA";
            this.TELEMERGENCIA.Size = new System.Drawing.Size(222, 26);
            this.TELEMERGENCIA.TabIndex = 46;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(866, 31);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(219, 20);
            this.Label8.TabIndex = 45;
            this.Label8.Text = "OTRAS CARACTERISTICAS";
            // 
            // OTRASCARACTERISTICAS
            // 
            this.OTRASCARACTERISTICAS.Location = new System.Drawing.Point(834, 56);
            this.OTRASCARACTERISTICAS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OTRASCARACTERISTICAS.Multiline = true;
            this.OTRASCARACTERISTICAS.Name = "OTRASCARACTERISTICAS";
            this.OTRASCARACTERISTICAS.Size = new System.Drawing.Size(256, 204);
            this.OTRASCARACTERISTICAS.TabIndex = 44;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(523, 114);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(63, 20);
            this.Label7.TabIndex = 43;
            this.Label7.Text = "DEPTO";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(436, 114);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(47, 20);
            this.Label6.TabIndex = 42;
            this.Label6.Text = "PISO";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(286, 114);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 20);
            this.Label5.TabIndex = 41;
            this.Label5.Text = "NUMERO";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(74, 114);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(99, 20);
            this.Label4.TabIndex = 40;
            this.Label4.Text = "DIRECCION";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(576, 33);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(101, 20);
            this.Label3.TabIndex = 39;
            this.Label3.Text = "LOCALIDAD";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(338, 33);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 20);
            this.Label2.TabIndex = 38;
            this.Label2.Text = "PARTIDO";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(74, 33);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(97, 20);
            this.Label1.TabIndex = 37;
            this.Label1.Text = "PROVINCIA";
            // 
            // depto
            // 
            this.depto.Location = new System.Drawing.Point(516, 139);
            this.depto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.depto.Name = "depto";
            this.depto.Size = new System.Drawing.Size(74, 26);
            this.depto.TabIndex = 36;
            // 
            // piso
            // 
            this.piso.Location = new System.Drawing.Point(430, 139);
            this.piso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.piso.Name = "piso";
            this.piso.Size = new System.Drawing.Size(62, 26);
            this.piso.TabIndex = 35;
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(270, 139);
            this.numero.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(104, 26);
            this.numero.TabIndex = 34;
            // 
            // calle
            // 
            this.calle.Location = new System.Drawing.Point(12, 139);
            this.calle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calle.Name = "calle";
            this.calle.Size = new System.Drawing.Size(222, 26);
            this.calle.TabIndex = 33;
            // 
            // LOCALIDAD
            // 
            this.LOCALIDAD.DisplayMember = "nombre";
            this.LOCALIDAD.FormattingEnabled = true;
            this.LOCALIDAD.Location = new System.Drawing.Point(516, 56);
            this.LOCALIDAD.Name = "LOCALIDAD";
            this.LOCALIDAD.Size = new System.Drawing.Size(240, 28);
            this.LOCALIDAD.TabIndex = 32;
            this.LOCALIDAD.ValueMember = "idlocalidad";
            // 
            // PARTIDO
            // 
            this.PARTIDO.DisplayMember = "municipio";
            this.PARTIDO.FormattingEnabled = true;
            this.PARTIDO.Location = new System.Drawing.Point(270, 56);
            this.PARTIDO.Name = "PARTIDO";
            this.PARTIDO.Size = new System.Drawing.Size(222, 28);
            this.PARTIDO.TabIndex = 31;
            this.PARTIDO.ValueMember = "municipio_id";
            this.PARTIDO.SelectedIndexChanged += new System.EventHandler(this.PARTIDO_SelectedIndexChanged);
            // 
            // PCIA
            // 
            this.PCIA.DisplayMember = "provincia";
            this.PCIA.FormattingEnabled = true;
            this.PCIA.Location = new System.Drawing.Point(12, 56);
            this.PCIA.Name = "PCIA";
            this.PCIA.Size = new System.Drawing.Size(222, 28);
            this.PCIA.TabIndex = 30;
            this.PCIA.ValueMember = "provincia_id";
            this.PCIA.SelectedIndexChanged += new System.EventHandler(this.PCIA_SelectedIndexChanged);
            // 
            // CARDADEDOMICILIO
            // 
            this.CARDADEDOMICILIO.HideSelection = false;
            this.CARDADEDOMICILIO.Location = new System.Drawing.Point(12, 305);
            this.CARDADEDOMICILIO.Name = "CARDADEDOMICILIO";
            this.CARDADEDOMICILIO.Size = new System.Drawing.Size(1620, 246);
            this.CARDADEDOMICILIO.TabIndex = 59;
            this.CARDADEDOMICILIO.UseCompatibleStateImageBehavior = false;
            this.CARDADEDOMICILIO.View = System.Windows.Forms.View.Details;
            this.CARDADEDOMICILIO.DoubleClick += new System.EventHandler(this.CARDADEDOMICILIO_DoubleClick);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 557);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1620, 350);
            this.webBrowser1.TabIndex = 60;
            // 
            // CARGADEDOMICILIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.CARDADEDOMICILIO);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.EDITARDATOS);
            this.Controls.Add(this.CARGADATOS);
            this.Controls.Add(this.EMAIL);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.TELCONTACTO);
            this.Controls.Add(this.TELEMERGENCIA);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.OTRASCARACTERISTICAS);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.depto);
            this.Controls.Add(this.piso);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.calle);
            this.Controls.Add(this.LOCALIDAD);
            this.Controls.Add(this.PARTIDO);
            this.Controls.Add(this.PCIA);
            this.Name = "CARGADEDOMICILIO";
            this.Text = "CARGA DE DOMICILIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CARGADEDOMICILIO_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox ID;
        internal System.Windows.Forms.Button EDITARDATOS;
        internal System.Windows.Forms.Button CARGADATOS;
        internal System.Windows.Forms.TextBox EMAIL;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox TELCONTACTO;
        internal System.Windows.Forms.TextBox TELEMERGENCIA;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox OTRASCARACTERISTICAS;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox depto;
        internal System.Windows.Forms.TextBox piso;
        internal System.Windows.Forms.TextBox numero;
        internal System.Windows.Forms.TextBox calle;
        internal System.Windows.Forms.ComboBox LOCALIDAD;
        internal System.Windows.Forms.ComboBox PARTIDO;
        internal System.Windows.Forms.ComboBox PCIA;
        private System.Windows.Forms.ListView CARDADEDOMICILIO;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}