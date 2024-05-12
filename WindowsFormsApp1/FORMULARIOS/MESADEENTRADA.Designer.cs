namespace WindowsFormsApp1
{
    partial class MESADEENTRADA
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
            this.Button1 = new System.Windows.Forms.Button();
            this.DATOSANALIZAR = new System.Windows.Forms.RichTextBox();
            this.CONSULTASVIEJAS = new System.Windows.Forms.ListView();
            this.RESOLUCIONES = new System.Windows.Forms.ListView();
            this.EXPEDIENTES = new System.Windows.Forms.ListView();
            this.PEDIDOS = new System.Windows.Forms.ListView();
            this.citaciones = new System.Windows.Forms.ListView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.textoadjuntars = new System.Windows.Forms.RichTextBox();
            this.PEDIDORESOLUCIONES = new System.Windows.Forms.CheckBox();
            this.CARGARPEDIDO = new System.Windows.Forms.Button();
            this.PEDIDONUMERODEEXPEDIENTE = new System.Windows.Forms.CheckBox();
            this.IOMA = new System.Windows.Forms.CheckBox();
            this.RESETCONTRASEÑAS = new System.Windows.Forms.CheckBox();
            this.Certificadodetrabajo = new System.Windows.Forms.CheckBox();
            this.CERTIFICADODEROTACION = new System.Windows.Forms.CheckBox();
            this.CERTITRABAJOCONHORARIOS = new System.Windows.Forms.CheckBox();
            this.REALIZODOMICILIO = new System.Windows.Forms.CheckBox();
            this.legajohecho = new System.Windows.Forms.CheckBox();
            this.scaners = new System.Windows.Forms.Button();
            this.EXPLICACIONDADA = new System.Windows.Forms.RichTextBox();
            this.MOTIVODECONSULTA = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolcitaciones = new System.Windows.Forms.ToolTip(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.apellynombre = new System.Windows.Forms.TextBox();
            this.legajo = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(12, 26);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(167, 34);
            this.Button1.TabIndex = 54;
            this.Button1.Text = "CARGAR CONSULTA";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // DATOSANALIZAR
            // 
            this.DATOSANALIZAR.Location = new System.Drawing.Point(597, 574);
            this.DATOSANALIZAR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DATOSANALIZAR.Name = "DATOSANALIZAR";
            this.DATOSANALIZAR.Size = new System.Drawing.Size(631, 78);
            this.DATOSANALIZAR.TabIndex = 53;
            this.DATOSANALIZAR.Text = "";
            // 
            // CONSULTASVIEJAS
            // 
            this.CONSULTASVIEJAS.FullRowSelect = true;
            this.CONSULTASVIEJAS.HideSelection = false;
            this.CONSULTASVIEJAS.Location = new System.Drawing.Point(597, 430);
            this.CONSULTASVIEJAS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CONSULTASVIEJAS.Name = "CONSULTASVIEJAS";
            this.CONSULTASVIEJAS.ShowItemToolTips = true;
            this.CONSULTASVIEJAS.Size = new System.Drawing.Size(1766, 118);
            this.CONSULTASVIEJAS.TabIndex = 52;
            this.CONSULTASVIEJAS.UseCompatibleStateImageBehavior = false;
            this.CONSULTASVIEJAS.View = System.Windows.Forms.View.Details;
            this.CONSULTASVIEJAS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CONSULTASVIEJAS_MouseClick);
            this.CONSULTASVIEJAS.MouseLeave += new System.EventHandler(this.CONSULTASVIEJAS_MouseLeave);
            this.CONSULTASVIEJAS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CONSULTASVIEJAS_MouseMove);
            // 
            // RESOLUCIONES
            // 
            this.RESOLUCIONES.FullRowSelect = true;
            this.RESOLUCIONES.HideSelection = false;
            this.RESOLUCIONES.Location = new System.Drawing.Point(597, 348);
            this.RESOLUCIONES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RESOLUCIONES.Name = "RESOLUCIONES";
            this.RESOLUCIONES.ShowItemToolTips = true;
            this.RESOLUCIONES.Size = new System.Drawing.Size(1766, 78);
            this.RESOLUCIONES.TabIndex = 51;
            this.toolcitaciones.SetToolTip(this.RESOLUCIONES, "CITACIONES");
            this.RESOLUCIONES.UseCompatibleStateImageBehavior = false;
            this.RESOLUCIONES.DoubleClick += new System.EventHandler(this.RESOLUCIONES_DoubleClick);
            this.RESOLUCIONES.MouseLeave += new System.EventHandler(this.RESOLUCIONES_MouseLeave);
            this.RESOLUCIONES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RESOLUCIONES_MouseMove);
            // 
            // EXPEDIENTES
            // 
            this.EXPEDIENTES.FullRowSelect = true;
            this.EXPEDIENTES.HideSelection = false;
            this.EXPEDIENTES.Location = new System.Drawing.Point(597, 262);
            this.EXPEDIENTES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EXPEDIENTES.Name = "EXPEDIENTES";
            this.EXPEDIENTES.ShowItemToolTips = true;
            this.EXPEDIENTES.Size = new System.Drawing.Size(1766, 80);
            this.EXPEDIENTES.TabIndex = 50;
            this.EXPEDIENTES.UseCompatibleStateImageBehavior = false;
            this.EXPEDIENTES.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EXPEDIENTES_MouseClick);
            this.EXPEDIENTES.MouseLeave += new System.EventHandler(this.EXPEDIENTES_MouseLeave);
            this.EXPEDIENTES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EXPEDIENTES_MouseMove);
            // 
            // PEDIDOS
            // 
            this.PEDIDOS.FullRowSelect = true;
            this.PEDIDOS.HideSelection = false;
            this.PEDIDOS.Location = new System.Drawing.Point(597, 170);
            this.PEDIDOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PEDIDOS.Name = "PEDIDOS";
            this.PEDIDOS.ShowItemToolTips = true;
            this.PEDIDOS.Size = new System.Drawing.Size(1766, 89);
            this.PEDIDOS.TabIndex = 49;
            this.PEDIDOS.UseCompatibleStateImageBehavior = false;
            this.PEDIDOS.DoubleClick += new System.EventHandler(this.PEDIDOS_DoubleClick);
            this.PEDIDOS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PEDIDOS_MouseClick);
            this.PEDIDOS.MouseLeave += new System.EventHandler(this.PEDIDOS_MouseLeave);
            this.PEDIDOS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PEDIDOS_MouseMove);
            // 
            // citaciones
            // 
            this.citaciones.FullRowSelect = true;
            this.citaciones.HideSelection = false;
            this.citaciones.Location = new System.Drawing.Point(597, 68);
            this.citaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.citaciones.Name = "citaciones";
            this.citaciones.ShowItemToolTips = true;
            this.citaciones.Size = new System.Drawing.Size(1766, 98);
            this.citaciones.TabIndex = 48;
            this.toolcitaciones.SetToolTip(this.citaciones, "CITACIONES");
            this.citaciones.UseCompatibleStateImageBehavior = false;
            this.citaciones.View = System.Windows.Forms.View.Details;
            this.citaciones.DoubleClick += new System.EventHandler(this.Citaciones_DoubleClick);
            this.citaciones.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Citaciones_MouseClick);
            this.citaciones.MouseLeave += new System.EventHandler(this.Citaciones_MouseLeave);
            this.citaciones.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Citaciones_MouseMove);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.textoadjuntars);
            this.GroupBox1.Controls.Add(this.PEDIDORESOLUCIONES);
            this.GroupBox1.Controls.Add(this.CARGARPEDIDO);
            this.GroupBox1.Controls.Add(this.PEDIDONUMERODEEXPEDIENTE);
            this.GroupBox1.Controls.Add(this.IOMA);
            this.GroupBox1.Controls.Add(this.RESETCONTRASEÑAS);
            this.GroupBox1.Controls.Add(this.Certificadodetrabajo);
            this.GroupBox1.Controls.Add(this.CERTIFICADODEROTACION);
            this.GroupBox1.Controls.Add(this.CERTITRABAJOCONHORARIOS);
            this.GroupBox1.Location = new System.Drawing.Point(5, 364);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupBox1.Size = new System.Drawing.Size(588, 185);
            this.GroupBox1.TabIndex = 47;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "PEDIDOS";
            // 
            // textoadjuntars
            // 
            this.textoadjuntars.Location = new System.Drawing.Point(460, 84);
            this.textoadjuntars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textoadjuntars.Name = "textoadjuntars";
            this.textoadjuntars.Size = new System.Drawing.Size(89, 78);
            this.textoadjuntars.TabIndex = 19;
            this.textoadjuntars.Text = "";
            // 
            // PEDIDORESOLUCIONES
            // 
            this.PEDIDORESOLUCIONES.AutoSize = true;
            this.PEDIDORESOLUCIONES.Location = new System.Drawing.Point(105, 155);
            this.PEDIDORESOLUCIONES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PEDIDORESOLUCIONES.Name = "PEDIDORESOLUCIONES";
            this.PEDIDORESOLUCIONES.Size = new System.Drawing.Size(210, 20);
            this.PEDIDORESOLUCIONES.TabIndex = 18;
            this.PEDIDORESOLUCIONES.Text = "PEDIDO DE RESOLUCIONES";
            this.PEDIDORESOLUCIONES.UseVisualStyleBackColor = true;
            // 
            // CARGARPEDIDO
            // 
            this.CARGARPEDIDO.Location = new System.Drawing.Point(0, 60);
            this.CARGARPEDIDO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CARGARPEDIDO.Name = "CARGARPEDIDO";
            this.CARGARPEDIDO.Size = new System.Drawing.Size(100, 54);
            this.CARGARPEDIDO.TabIndex = 11;
            this.CARGARPEDIDO.Text = "CARGAR PEDIDO";
            this.CARGARPEDIDO.UseVisualStyleBackColor = true;
            this.CARGARPEDIDO.Click += new System.EventHandler(this.CARGARPEDIDO_Click);
            // 
            // PEDIDONUMERODEEXPEDIENTE
            // 
            this.PEDIDONUMERODEEXPEDIENTE.AutoSize = true;
            this.PEDIDONUMERODEEXPEDIENTE.Location = new System.Drawing.Point(105, 132);
            this.PEDIDONUMERODEEXPEDIENTE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PEDIDONUMERODEEXPEDIENTE.Name = "PEDIDONUMERODEEXPEDIENTE";
            this.PEDIDONUMERODEEXPEDIENTE.Size = new System.Drawing.Size(275, 20);
            this.PEDIDONUMERODEEXPEDIENTE.TabIndex = 17;
            this.PEDIDONUMERODEEXPEDIENTE.Text = "PEDIDO DE NUMERO DE EXPEDIENTE";
            this.PEDIDONUMERODEEXPEDIENTE.UseVisualStyleBackColor = true;
            // 
            // IOMA
            // 
            this.IOMA.AutoSize = true;
            this.IOMA.Location = new System.Drawing.Point(105, 14);
            this.IOMA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IOMA.Name = "IOMA";
            this.IOMA.Size = new System.Drawing.Size(62, 20);
            this.IOMA.TabIndex = 12;
            this.IOMA.Text = "IOMA";
            this.IOMA.UseVisualStyleBackColor = true;
            // 
            // RESETCONTRASEÑAS
            // 
            this.RESETCONTRASEÑAS.AutoSize = true;
            this.RESETCONTRASEÑAS.Location = new System.Drawing.Point(105, 107);
            this.RESETCONTRASEÑAS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RESETCONTRASEÑAS.Name = "RESETCONTRASEÑAS";
            this.RESETCONTRASEÑAS.Size = new System.Drawing.Size(213, 20);
            this.RESETCONTRASEÑAS.TabIndex = 16;
            this.RESETCONTRASEÑAS.Text = "RESETEO DE CONTRASEÑA";
            this.RESETCONTRASEÑAS.UseVisualStyleBackColor = true;
            // 
            // Certificadodetrabajo
            // 
            this.Certificadodetrabajo.AutoSize = true;
            this.Certificadodetrabajo.Location = new System.Drawing.Point(105, 36);
            this.Certificadodetrabajo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Certificadodetrabajo.Name = "Certificadodetrabajo";
            this.Certificadodetrabajo.Size = new System.Drawing.Size(206, 20);
            this.Certificadodetrabajo.TabIndex = 13;
            this.Certificadodetrabajo.Text = "CERTIFICADO DE TRABAJO";
            this.Certificadodetrabajo.UseVisualStyleBackColor = true;
            // 
            // CERTIFICADODEROTACION
            // 
            this.CERTIFICADODEROTACION.AutoSize = true;
            this.CERTIFICADODEROTACION.Location = new System.Drawing.Point(105, 84);
            this.CERTIFICADODEROTACION.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CERTIFICADODEROTACION.Name = "CERTIFICADODEROTACION";
            this.CERTIFICADODEROTACION.Size = new System.Drawing.Size(213, 20);
            this.CERTIFICADODEROTACION.TabIndex = 15;
            this.CERTIFICADODEROTACION.Text = "CERTIFICADO DE ROTACION";
            this.CERTIFICADODEROTACION.UseVisualStyleBackColor = true;
            // 
            // CERTITRABAJOCONHORARIOS
            // 
            this.CERTITRABAJOCONHORARIOS.AutoSize = true;
            this.CERTITRABAJOCONHORARIOS.Location = new System.Drawing.Point(105, 60);
            this.CERTITRABAJOCONHORARIOS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CERTITRABAJOCONHORARIOS.Name = "CERTITRABAJOCONHORARIOS";
            this.CERTITRABAJOCONHORARIOS.Size = new System.Drawing.Size(324, 20);
            this.CERTITRABAJOCONHORARIOS.TabIndex = 14;
            this.CERTITRABAJOCONHORARIOS.Text = "CERTIFICACION DE TRABAJO CON HORARIOS";
            this.CERTITRABAJOCONHORARIOS.UseVisualStyleBackColor = true;
            // 
            // REALIZODOMICILIO
            // 
            this.REALIZODOMICILIO.AutoSize = true;
            this.REALIZODOMICILIO.Location = new System.Drawing.Point(603, 43);
            this.REALIZODOMICILIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.REALIZODOMICILIO.Name = "REALIZODOMICILIO";
            this.REALIZODOMICILIO.Size = new System.Drawing.Size(171, 20);
            this.REALIZODOMICILIO.TabIndex = 46;
            this.REALIZODOMICILIO.Text = "CAMBIO DE DOMICILIO";
            this.REALIZODOMICILIO.UseVisualStyleBackColor = true;
            // 
            // legajohecho
            // 
            this.legajohecho.AutoSize = true;
            this.legajohecho.Location = new System.Drawing.Point(466, 43);
            this.legajohecho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.legajohecho.Name = "legajohecho";
            this.legajohecho.Size = new System.Drawing.Size(122, 20);
            this.legajohecho.TabIndex = 45;
            this.legajohecho.Text = "LEGAJO ECHO";
            this.legajohecho.UseVisualStyleBackColor = true;
            // 
            // scaners
            // 
            this.scaners.Location = new System.Drawing.Point(5, 306);
            this.scaners.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scaners.Name = "scaners";
            this.scaners.Size = new System.Drawing.Size(151, 44);
            this.scaners.TabIndex = 44;
            this.scaners.Text = "SCANNEAR DOCUMENTACION";
            this.scaners.UseVisualStyleBackColor = true;
            // 
            // EXPLICACIONDADA
            // 
            this.EXPLICACIONDADA.Location = new System.Drawing.Point(297, 66);
            this.EXPLICACIONDADA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EXPLICACIONDADA.Name = "EXPLICACIONDADA";
            this.EXPLICACIONDADA.Size = new System.Drawing.Size(296, 230);
            this.EXPLICACIONDADA.TabIndex = 42;
            this.EXPLICACIONDADA.Text = "";
            // 
            // MOTIVODECONSULTA
            // 
            this.MOTIVODECONSULTA.Location = new System.Drawing.Point(5, 66);
            this.MOTIVODECONSULTA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MOTIVODECONSULTA.Name = "MOTIVODECONSULTA";
            this.MOTIVODECONSULTA.Size = new System.Drawing.Size(288, 230);
            this.MOTIVODECONSULTA.TabIndex = 41;
            this.MOTIVODECONSULTA.Text = "";
            // 
            // toolcitaciones
            // 
            this.toolcitaciones.AutoPopDelay = 100000;
            this.toolcitaciones.InitialDelay = 5;
            this.toolcitaciones.IsBalloon = true;
            this.toolcitaciones.ReshowDelay = 100;
            this.toolcitaciones.ShowAlways = true;
            this.toolcitaciones.ToolTipTitle = "CITACIONES";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(11, 670);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(18, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(2350, 500);
            this.webBrowser1.TabIndex = 55;
            // 
            // apellynombre
            // 
            this.apellynombre.Location = new System.Drawing.Point(360, 10);
            this.apellynombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.apellynombre.Name = "apellynombre";
            this.apellynombre.Size = new System.Drawing.Size(232, 22);
            this.apellynombre.TabIndex = 56;
            // 
            // legajo
            // 
            this.legajo.Location = new System.Drawing.Point(360, 39);
            this.legajo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.legajo.Name = "legajo";
            this.legajo.Size = new System.Drawing.Size(89, 22);
            this.legajo.TabIndex = 57;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(663, 10);
            this.dni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(89, 22);
            this.dni.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "AGENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "DNI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "LEGAJO";
            // 
            // MESADEENTRADA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 765);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.legajo);
            this.Controls.Add(this.apellynombre);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.DATOSANALIZAR);
            this.Controls.Add(this.CONSULTASVIEJAS);
            this.Controls.Add(this.RESOLUCIONES);
            this.Controls.Add(this.EXPEDIENTES);
            this.Controls.Add(this.PEDIDOS);
            this.Controls.Add(this.citaciones);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.REALIZODOMICILIO);
            this.Controls.Add(this.legajohecho);
            this.Controls.Add(this.scaners);
            this.Controls.Add(this.EXPLICACIONDADA);
            this.Controls.Add(this.MOTIVODECONSULTA);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MESADEENTRADA";
            this.Text = "MESADEENTRADA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MESADEENTRADA_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.RichTextBox DATOSANALIZAR;
        internal System.Windows.Forms.ListView CONSULTASVIEJAS;
        internal System.Windows.Forms.ListView RESOLUCIONES;
        internal System.Windows.Forms.ListView EXPEDIENTES;
        internal System.Windows.Forms.ListView PEDIDOS;
        internal System.Windows.Forms.ListView citaciones;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox PEDIDORESOLUCIONES;
        internal System.Windows.Forms.Button CARGARPEDIDO;
        internal System.Windows.Forms.CheckBox PEDIDONUMERODEEXPEDIENTE;
        internal System.Windows.Forms.CheckBox IOMA;
        internal System.Windows.Forms.CheckBox RESETCONTRASEÑAS;
        internal System.Windows.Forms.CheckBox Certificadodetrabajo;
        internal System.Windows.Forms.CheckBox CERTIFICADODEROTACION;
        internal System.Windows.Forms.CheckBox CERTITRABAJOCONHORARIOS;
        internal System.Windows.Forms.CheckBox REALIZODOMICILIO;
        internal System.Windows.Forms.CheckBox legajohecho;
        internal System.Windows.Forms.Button scaners;
        internal System.Windows.Forms.RichTextBox EXPLICACIONDADA;
        internal System.Windows.Forms.RichTextBox MOTIVODECONSULTA;
        private System.Windows.Forms.RichTextBox textoadjuntars;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.ToolTip toolcitaciones;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox apellynombre;
        private System.Windows.Forms.TextBox legajo;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}