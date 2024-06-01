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
            this.cargars = new System.Windows.Forms.Button();
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.apellynombre = new System.Windows.Forms.TextBox();
            this.legajo = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.DNI1 = new System.Windows.Forms.TextBox();
            this.JURADASALRIO = new System.Windows.Forms.CheckBox();
            this.foto = new System.Windows.Forms.CheckBox();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cargars
            // 
            this.cargars.Location = new System.Drawing.Point(9, 21);
            this.cargars.Name = "cargars";
            this.cargars.Size = new System.Drawing.Size(125, 27);
            this.cargars.TabIndex = 54;
            this.cargars.Text = "CARGAR CONSULTA";
            this.cargars.UseVisualStyleBackColor = true;
            // 
            // DATOSANALIZAR
            // 
            this.DATOSANALIZAR.Location = new System.Drawing.Point(448, 472);
            this.DATOSANALIZAR.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DATOSANALIZAR.Name = "DATOSANALIZAR";
            this.DATOSANALIZAR.Size = new System.Drawing.Size(474, 64);
            this.DATOSANALIZAR.TabIndex = 53;
            this.DATOSANALIZAR.Text = "";
            // 
            // CONSULTASVIEJAS
            // 
            this.CONSULTASVIEJAS.FullRowSelect = true;
            this.CONSULTASVIEJAS.HideSelection = false;
            this.CONSULTASVIEJAS.Location = new System.Drawing.Point(448, 372);
            this.CONSULTASVIEJAS.Name = "CONSULTASVIEJAS";
            this.CONSULTASVIEJAS.ShowItemToolTips = true;
            this.CONSULTASVIEJAS.Size = new System.Drawing.Size(1325, 96);
            this.CONSULTASVIEJAS.TabIndex = 52;
            this.CONSULTASVIEJAS.UseCompatibleStateImageBehavior = false;
            this.CONSULTASVIEJAS.View = System.Windows.Forms.View.Details;
            // 
            // RESOLUCIONES
            // 
            this.RESOLUCIONES.FullRowSelect = true;
            this.RESOLUCIONES.HideSelection = false;
            this.RESOLUCIONES.Location = new System.Drawing.Point(448, 305);
            this.RESOLUCIONES.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.RESOLUCIONES.Name = "RESOLUCIONES";
            this.RESOLUCIONES.ShowItemToolTips = true;
            this.RESOLUCIONES.Size = new System.Drawing.Size(1325, 64);
            this.RESOLUCIONES.TabIndex = 51;
            this.toolcitaciones.SetToolTip(this.RESOLUCIONES, "CITACIONES");
            this.RESOLUCIONES.UseCompatibleStateImageBehavior = false;
            // 
            // EXPEDIENTES
            // 
            this.EXPEDIENTES.FullRowSelect = true;
            this.EXPEDIENTES.HideSelection = false;
            this.EXPEDIENTES.Location = new System.Drawing.Point(448, 239);
            this.EXPEDIENTES.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.EXPEDIENTES.Name = "EXPEDIENTES";
            this.EXPEDIENTES.ShowItemToolTips = true;
            this.EXPEDIENTES.Size = new System.Drawing.Size(1325, 66);
            this.EXPEDIENTES.TabIndex = 50;
            this.EXPEDIENTES.UseCompatibleStateImageBehavior = false;
            // 
            // PEDIDOS
            // 
            this.PEDIDOS.FullRowSelect = true;
            this.PEDIDOS.HideSelection = false;
            this.PEDIDOS.Location = new System.Drawing.Point(448, 164);
            this.PEDIDOS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PEDIDOS.Name = "PEDIDOS";
            this.PEDIDOS.ShowItemToolTips = true;
            this.PEDIDOS.Size = new System.Drawing.Size(1325, 73);
            this.PEDIDOS.TabIndex = 49;
            this.PEDIDOS.UseCompatibleStateImageBehavior = false;
            // 
            // citaciones
            // 
            this.citaciones.FullRowSelect = true;
            this.citaciones.HideSelection = false;
            this.citaciones.Location = new System.Drawing.Point(448, 77);
            this.citaciones.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.citaciones.Name = "citaciones";
            this.citaciones.ShowItemToolTips = true;
            this.citaciones.Size = new System.Drawing.Size(1325, 81);
            this.citaciones.TabIndex = 48;
            this.toolcitaciones.SetToolTip(this.citaciones, "CITACIONES");
            this.citaciones.UseCompatibleStateImageBehavior = false;
            this.citaciones.View = System.Windows.Forms.View.Details;
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
            this.GroupBox1.Location = new System.Drawing.Point(4, 296);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.GroupBox1.Size = new System.Drawing.Size(441, 150);
            this.GroupBox1.TabIndex = 47;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "PEDIDOS";
            // 
            // textoadjuntars
            // 
            this.textoadjuntars.Location = new System.Drawing.Point(345, 68);
            this.textoadjuntars.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textoadjuntars.Name = "textoadjuntars";
            this.textoadjuntars.Size = new System.Drawing.Size(68, 64);
            this.textoadjuntars.TabIndex = 19;
            this.textoadjuntars.Text = "";
            // 
            // PEDIDORESOLUCIONES
            // 
            this.PEDIDORESOLUCIONES.AutoSize = true;
            this.PEDIDORESOLUCIONES.Location = new System.Drawing.Point(79, 126);
            this.PEDIDORESOLUCIONES.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PEDIDORESOLUCIONES.Name = "PEDIDORESOLUCIONES";
            this.PEDIDORESOLUCIONES.Size = new System.Drawing.Size(179, 21);
            this.PEDIDORESOLUCIONES.TabIndex = 18;
            this.PEDIDORESOLUCIONES.Text = "PEDIDO DE RESOLUCIONES";
            this.PEDIDORESOLUCIONES.UseVisualStyleBackColor = true;
            // 
            // CARGARPEDIDO
            // 
            this.CARGARPEDIDO.Location = new System.Drawing.Point(0, 49);
            this.CARGARPEDIDO.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CARGARPEDIDO.Name = "CARGARPEDIDO";
            this.CARGARPEDIDO.Size = new System.Drawing.Size(75, 44);
            this.CARGARPEDIDO.TabIndex = 11;
            this.CARGARPEDIDO.Text = "CARGAR PEDIDO";
            this.CARGARPEDIDO.UseVisualStyleBackColor = true;
            this.CARGARPEDIDO.Click += new System.EventHandler(this.CARGARPEDIDO_Click);
            // 
            // PEDIDONUMERODEEXPEDIENTE
            // 
            this.PEDIDONUMERODEEXPEDIENTE.AutoSize = true;
            this.PEDIDONUMERODEEXPEDIENTE.Location = new System.Drawing.Point(79, 107);
            this.PEDIDONUMERODEEXPEDIENTE.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.PEDIDONUMERODEEXPEDIENTE.Name = "PEDIDONUMERODEEXPEDIENTE";
            this.PEDIDONUMERODEEXPEDIENTE.Size = new System.Drawing.Size(232, 21);
            this.PEDIDONUMERODEEXPEDIENTE.TabIndex = 17;
            this.PEDIDONUMERODEEXPEDIENTE.Text = "PEDIDO DE NUMERO DE EXPEDIENTE";
            this.PEDIDONUMERODEEXPEDIENTE.UseVisualStyleBackColor = true;
            // 
            // IOMA
            // 
            this.IOMA.AutoSize = true;
            this.IOMA.Location = new System.Drawing.Point(79, 12);
            this.IOMA.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.IOMA.Name = "IOMA";
            this.IOMA.Size = new System.Drawing.Size(60, 21);
            this.IOMA.TabIndex = 12;
            this.IOMA.Text = "IOMA";
            this.IOMA.UseVisualStyleBackColor = true;
            // 
            // RESETCONTRASEÑAS
            // 
            this.RESETCONTRASEÑAS.AutoSize = true;
            this.RESETCONTRASEÑAS.Location = new System.Drawing.Point(79, 87);
            this.RESETCONTRASEÑAS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.RESETCONTRASEÑAS.Name = "RESETCONTRASEÑAS";
            this.RESETCONTRASEÑAS.Size = new System.Drawing.Size(179, 21);
            this.RESETCONTRASEÑAS.TabIndex = 16;
            this.RESETCONTRASEÑAS.Text = "RESETEO DE CONTRASEÑA";
            this.RESETCONTRASEÑAS.UseVisualStyleBackColor = true;
            // 
            // Certificadodetrabajo
            // 
            this.Certificadodetrabajo.AutoSize = true;
            this.Certificadodetrabajo.Location = new System.Drawing.Point(79, 29);
            this.Certificadodetrabajo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Certificadodetrabajo.Name = "Certificadodetrabajo";
            this.Certificadodetrabajo.Size = new System.Drawing.Size(174, 21);
            this.Certificadodetrabajo.TabIndex = 13;
            this.Certificadodetrabajo.Text = "CERTIFICADO DE TRABAJO";
            this.Certificadodetrabajo.UseVisualStyleBackColor = true;
            // 
            // CERTIFICADODEROTACION
            // 
            this.CERTIFICADODEROTACION.AutoSize = true;
            this.CERTIFICADODEROTACION.Location = new System.Drawing.Point(79, 68);
            this.CERTIFICADODEROTACION.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CERTIFICADODEROTACION.Name = "CERTIFICADODEROTACION";
            this.CERTIFICADODEROTACION.Size = new System.Drawing.Size(181, 21);
            this.CERTIFICADODEROTACION.TabIndex = 15;
            this.CERTIFICADODEROTACION.Text = "CERTIFICADO DE ROTACION";
            this.CERTIFICADODEROTACION.UseVisualStyleBackColor = true;
            // 
            // CERTITRABAJOCONHORARIOS
            // 
            this.CERTITRABAJOCONHORARIOS.AutoSize = true;
            this.CERTITRABAJOCONHORARIOS.Location = new System.Drawing.Point(79, 49);
            this.CERTITRABAJOCONHORARIOS.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.CERTITRABAJOCONHORARIOS.Name = "CERTITRABAJOCONHORARIOS";
            this.CERTITRABAJOCONHORARIOS.Size = new System.Drawing.Size(270, 21);
            this.CERTITRABAJOCONHORARIOS.TabIndex = 14;
            this.CERTITRABAJOCONHORARIOS.Text = "CERTIFICACION DE TRABAJO CON HORARIOS";
            this.CERTITRABAJOCONHORARIOS.UseVisualStyleBackColor = true;
            // 
            // REALIZODOMICILIO
            // 
            this.REALIZODOMICILIO.AutoSize = true;
            this.REALIZODOMICILIO.Location = new System.Drawing.Point(378, 6);
            this.REALIZODOMICILIO.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.REALIZODOMICILIO.Name = "REALIZODOMICILIO";
            this.REALIZODOMICILIO.Size = new System.Drawing.Size(150, 21);
            this.REALIZODOMICILIO.TabIndex = 46;
            this.REALIZODOMICILIO.Text = "CAMBIO DE DOMICILIO";
            this.REALIZODOMICILIO.UseVisualStyleBackColor = true;
            // 
            // legajohecho
            // 
            this.legajohecho.AutoSize = true;
            this.legajohecho.Location = new System.Drawing.Point(521, 6);
            this.legajohecho.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.legajohecho.Name = "legajohecho";
            this.legajohecho.Size = new System.Drawing.Size(107, 21);
            this.legajohecho.TabIndex = 45;
            this.legajohecho.Text = "LEGAJO ECHO";
            this.legajohecho.UseVisualStyleBackColor = true;
            // 
            // scaners
            // 
            this.scaners.Location = new System.Drawing.Point(4, 248);
            this.scaners.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.scaners.Name = "scaners";
            this.scaners.Size = new System.Drawing.Size(113, 36);
            this.scaners.TabIndex = 44;
            this.scaners.Text = "SCANNEAR DOCUMENTACION";
            this.scaners.UseVisualStyleBackColor = true;
            // 
            // EXPLICACIONDADA
            // 
            this.EXPLICACIONDADA.Location = new System.Drawing.Point(223, 53);
            this.EXPLICACIONDADA.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.EXPLICACIONDADA.Name = "EXPLICACIONDADA";
            this.EXPLICACIONDADA.Size = new System.Drawing.Size(223, 187);
            this.EXPLICACIONDADA.TabIndex = 42;
            this.EXPLICACIONDADA.Text = "";
            // 
            // MOTIVODECONSULTA
            // 
            this.MOTIVODECONSULTA.Location = new System.Drawing.Point(4, 53);
            this.MOTIVODECONSULTA.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MOTIVODECONSULTA.Name = "MOTIVODECONSULTA";
            this.MOTIVODECONSULTA.Size = new System.Drawing.Size(217, 187);
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
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(8, 545);
            this.webBrowser.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.webBrowser.MinimumSize = new System.Drawing.Size(13, 13);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1763, 406);
            this.webBrowser.TabIndex = 55;
            // 
            // apellynombre
            // 
            this.apellynombre.Location = new System.Drawing.Point(201, 7);
            this.apellynombre.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.apellynombre.Name = "apellynombre";
            this.apellynombre.Size = new System.Drawing.Size(175, 20);
            this.apellynombre.TabIndex = 56;
            // 
            // legajo
            // 
            this.legajo.Location = new System.Drawing.Point(201, 32);
            this.legajo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.legajo.Name = "legajo";
            this.legajo.Size = new System.Drawing.Size(68, 20);
            this.legajo.TabIndex = 57;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(445, 13);
            this.dni.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(68, 20);
            this.dni.TabIndex = 58;
            this.dni.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "AGENTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "DNI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "LEGAJO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PORDNI);
            this.groupBox2.Controls.Add(this.apellido1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.PORAPELLIDO);
            this.groupBox2.Controls.Add(this.DNI1);
            this.groupBox2.Controls.Add(this.dni);
            this.groupBox2.Location = new System.Drawing.Point(618, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 63);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SETS";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(7, 12);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(332, 20);
            this.PORDNI.TabIndex = 23;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR DNI O HAGA DOBLE CLIK PARA CAMBIAR";
            this.PORDNI.UseVisualStyleBackColor = true;
            // 
            // apellido1
            // 
            this.apellido1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(177, 36);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(283, 21);
            this.apellido1.TabIndex = 22;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(7, 36);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(173, 20);
            this.PORAPELLIDO.TabIndex = 24;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUEDA POR APELLIDO";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // DNI1
            // 
            this.DNI1.Location = new System.Drawing.Point(336, 12);
            this.DNI1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DNI1.Name = "DNI1";
            this.DNI1.Size = new System.Drawing.Size(78, 20);
            this.DNI1.TabIndex = 10;
            this.DNI1.Text = "0";
            // 
            // JURADASALRIO
            // 
            this.JURADASALRIO.AutoSize = true;
            this.JURADASALRIO.Location = new System.Drawing.Point(271, 32);
            this.JURADASALRIO.Margin = new System.Windows.Forms.Padding(2);
            this.JURADASALRIO.Name = "JURADASALRIO";
            this.JURADASALRIO.Size = new System.Drawing.Size(197, 21);
            this.JURADASALRIO.TabIndex = 63;
            this.JURADASALRIO.Text = "DECLARACION JURADA SALRIO";
            this.JURADASALRIO.UseVisualStyleBackColor = true;
            // 
            // foto
            // 
            this.foto.AutoSize = true;
            this.foto.Location = new System.Drawing.Point(465, 33);
            this.foto.Margin = new System.Windows.Forms.Padding(2);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(62, 21);
            this.foto.TabIndex = 64;
            this.foto.Text = "FOTO";
            this.foto.UseVisualStyleBackColor = true;
            // 
            // MESADEENTRADA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 621);
            this.Controls.Add(this.foto);
            this.Controls.Add(this.JURADASALRIO);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.legajo);
            this.Controls.Add(this.apellynombre);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.cargars);
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
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "MESADEENTRADA";
            this.Text = "MESADEENTRADA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button cargars;
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
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox apellynombre;
        private System.Windows.Forms.TextBox legajo;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        internal System.Windows.Forms.TextBox DNI1;
        internal System.Windows.Forms.CheckBox JURADASALRIO;
        private System.Windows.Forms.CheckBox foto;
    }
}