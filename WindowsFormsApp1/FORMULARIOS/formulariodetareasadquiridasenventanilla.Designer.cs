
namespace WindowsFormsApp1
{
    partial class formulariodetareasadquiridasenventanilla
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DNI1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.DNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.legajo = new System.Windows.Forms.TextBox();
            this.apellynombre = new System.Windows.Forms.TextBox();
            this.TAREAS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.COMENTARIODETAREA = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CARGARTAREA = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tareasadquiridiasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new WindowsFormsApp1.DataSet1();
            this.tareasadquiridiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tareasadquiridiasTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.tareasadquiridiasTableAdapter();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHADEADQUISICION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRAMITE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGENTEDETRABAJO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelldoYNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aGENTEDETRABAJODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aGENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRAMITEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eSTADODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareasadquiridiasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareasadquiridiasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DNI1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Location = new System.Drawing.Point(538, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1094, 114);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCION";
            // 
            // DNI1
            // 
            this.DNI1.Location = new System.Drawing.Point(500, 72);
            this.DNI1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DNI1.Name = "DNI1";
            this.DNI1.Size = new System.Drawing.Size(148, 26);
            this.DNI1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "HAGA DOBLE CLIK EN ESTE DNI PARA CAMBIAR EL AGENTE";
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(18, 15);
            this.PORDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(336, 24);
            this.PORDNI.TabIndex = 35;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR APELLIDO Y NOMBRE";
            this.PORDNI.UseVisualStyleBackColor = true;
            this.PORDNI.Visible = false;
            // 
            // PORAPELLIDO
            // 
            this.PORAPELLIDO.AutoSize = true;
            this.PORAPELLIDO.Location = new System.Drawing.Point(18, 29);
            this.PORAPELLIDO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORAPELLIDO.Name = "PORAPELLIDO";
            this.PORAPELLIDO.Size = new System.Drawing.Size(313, 24);
            this.PORAPELLIDO.TabIndex = 34;
            this.PORAPELLIDO.TabStop = true;
            this.PORAPELLIDO.Text = "BUSQUE POR APELLIDO Y NOMBRE";
            this.PORAPELLIDO.UseVisualStyleBackColor = true;
            // 
            // apellido1
            // 
            this.apellido1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.apellido1.FormattingEnabled = true;
            this.apellido1.Location = new System.Drawing.Point(369, 29);
            this.apellido1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apellido1.Name = "apellido1";
            this.apellido1.Size = new System.Drawing.Size(338, 28);
            this.apellido1.TabIndex = 32;
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(735, 31);
            this.DNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(202, 26);
            this.DNI.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "LEGAJO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "APELLIDO Y NOMBRE";
            // 
            // legajo
            // 
            this.legajo.Location = new System.Drawing.Point(368, 38);
            this.legajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.legajo.Name = "legajo";
            this.legajo.Size = new System.Drawing.Size(112, 26);
            this.legajo.TabIndex = 14;
            // 
            // apellynombre
            // 
            this.apellynombre.Location = new System.Drawing.Point(39, 38);
            this.apellynombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apellynombre.Name = "apellynombre";
            this.apellynombre.Size = new System.Drawing.Size(290, 26);
            this.apellynombre.TabIndex = 12;
            // 
            // TAREAS
            // 
            this.TAREAS.FormattingEnabled = true;
            this.TAREAS.Location = new System.Drawing.Point(28, 128);
            this.TAREAS.Name = "TAREAS";
            this.TAREAS.Size = new System.Drawing.Size(241, 28);
            this.TAREAS.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "TAREAS ADQUIRIDA";
            // 
            // COMENTARIODETAREA
            // 
            this.COMENTARIODETAREA.Location = new System.Drawing.Point(28, 214);
            this.COMENTARIODETAREA.Name = "COMENTARIODETAREA";
            this.COMENTARIODETAREA.Size = new System.Drawing.Size(492, 136);
            this.COMENTARIODETAREA.TabIndex = 21;
            this.COMENTARIODETAREA.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "COMENTARIO DE LA TAREA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(802, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "TAREAS QUE TENGO";
            // 
            // CARGARTAREA
            // 
            this.CARGARTAREA.Location = new System.Drawing.Point(842, 182);
            this.CARGARTAREA.Name = "CARGARTAREA";
            this.CARGARTAREA.Size = new System.Drawing.Size(117, 52);
            this.CARGARTAREA.TabIndex = 25;
            this.CARGARTAREA.Text = "CARGAR TAREA";
            this.CARGARTAREA.UseVisualStyleBackColor = true;
            this.CARGARTAREA.Click += new System.EventHandler(this.CARGARTAREA_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.apelldoYNombreDataGridViewTextBoxColumn,
            this.aGENTEDETRABAJODataGridViewTextBoxColumn,
            this.aGENTEDataGridViewTextBoxColumn,
            this.tRAMITEDataGridViewTextBoxColumn,
            this.eSTADODataGridViewTextBoxColumn,
            this.mEMODataGridViewTextBoxColumn,
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tareasadquiridiasBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(28, 412);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1604, 232);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // tareasadquiridiasBindingSource1
            // 
            this.tareasadquiridiasBindingSource1.DataMember = "tareasadquiridias";
            this.tareasadquiridiasBindingSource1.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tareasadquiridiasBindingSource
            // 
            this.tareasadquiridiasBindingSource.DataMember = "tareasadquiridias";
            // 
            // tareasadquiridiasTableAdapter
            // 
            this.tareasadquiridiasTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn3.HeaderText = "id";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AGENTE";
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // ESTADO
            // 
            this.ESTADO.DataPropertyName = "ESTADO";
            this.ESTADO.HeaderText = "ESTADO";
            this.ESTADO.MinimumWidth = 8;
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.Width = 150;
            // 
            // FECHADEADQUISICION
            // 
            this.FECHADEADQUISICION.DataPropertyName = "FECHADEADQUISICION";
            this.FECHADEADQUISICION.HeaderText = "FECHADEADQUISICION";
            this.FECHADEADQUISICION.MinimumWidth = 8;
            this.FECHADEADQUISICION.Name = "FECHADEADQUISICION";
            this.FECHADEADQUISICION.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn2.HeaderText = "id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "MEMO";
            this.MEMO.MinimumWidth = 8;
            this.MEMO.Name = "MEMO";
            this.MEMO.Width = 150;
            // 
            // TRAMITE
            // 
            this.TRAMITE.DataPropertyName = "TRAMITE";
            this.TRAMITE.HeaderText = "TRAMITE";
            this.TRAMITE.MinimumWidth = 8;
            this.TRAMITE.Name = "TRAMITE";
            this.TRAMITE.Width = 150;
            // 
            // AGENTEDETRABAJO
            // 
            this.AGENTEDETRABAJO.DataPropertyName = "AGENTEDETRABAJO";
            this.AGENTEDETRABAJO.HeaderText = "AGENTEDETRABAJO";
            this.AGENTEDETRABAJO.MinimumWidth = 8;
            this.AGENTEDETRABAJO.Name = "AGENTEDETRABAJO";
            this.AGENTEDETRABAJO.Width = 150;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // apelldoYNombreDataGridViewTextBoxColumn
            // 
            this.apelldoYNombreDataGridViewTextBoxColumn.DataPropertyName = "Apelldo y Nombre";
            this.apelldoYNombreDataGridViewTextBoxColumn.HeaderText = "Apellido y Nombre";
            this.apelldoYNombreDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.apelldoYNombreDataGridViewTextBoxColumn.Name = "apelldoYNombreDataGridViewTextBoxColumn";
            this.apelldoYNombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.apelldoYNombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // aGENTEDETRABAJODataGridViewTextBoxColumn
            // 
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.DataPropertyName = "AGENTEDETRABAJO";
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.HeaderText = "AGENTE DE TRABAJO";
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.Name = "aGENTEDETRABAJODataGridViewTextBoxColumn";
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.ReadOnly = true;
            this.aGENTEDETRABAJODataGridViewTextBoxColumn.Width = 150;
            // 
            // aGENTEDataGridViewTextBoxColumn
            // 
            this.aGENTEDataGridViewTextBoxColumn.DataPropertyName = "AGENTE";
            this.aGENTEDataGridViewTextBoxColumn.HeaderText = "AGENTE";
            this.aGENTEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.aGENTEDataGridViewTextBoxColumn.Name = "aGENTEDataGridViewTextBoxColumn";
            this.aGENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aGENTEDataGridViewTextBoxColumn.Width = 150;
            // 
            // tRAMITEDataGridViewTextBoxColumn
            // 
            this.tRAMITEDataGridViewTextBoxColumn.DataPropertyName = "TRAMITE";
            this.tRAMITEDataGridViewTextBoxColumn.HeaderText = "TRAMITE";
            this.tRAMITEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.tRAMITEDataGridViewTextBoxColumn.Name = "tRAMITEDataGridViewTextBoxColumn";
            this.tRAMITEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRAMITEDataGridViewTextBoxColumn.Width = 150;
            // 
            // eSTADODataGridViewTextBoxColumn
            // 
            this.eSTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO";
            this.eSTADODataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.eSTADODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eSTADODataGridViewTextBoxColumn.Name = "eSTADODataGridViewTextBoxColumn";
            this.eSTADODataGridViewTextBoxColumn.ReadOnly = true;
            this.eSTADODataGridViewTextBoxColumn.Width = 150;
            // 
            // mEMODataGridViewTextBoxColumn
            // 
            this.mEMODataGridViewTextBoxColumn.DataPropertyName = "MEMO";
            this.mEMODataGridViewTextBoxColumn.HeaderText = "MEMO";
            this.mEMODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mEMODataGridViewTextBoxColumn.Name = "mEMODataGridViewTextBoxColumn";
            this.mEMODataGridViewTextBoxColumn.ReadOnly = true;
            this.mEMODataGridViewTextBoxColumn.Width = 150;
            // 
            // fECHADEADQUISICIONDataGridViewTextBoxColumn
            // 
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.DataPropertyName = "FECHADEADQUISICION";
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.HeaderText = "FECHA DE ADQUISICION";
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.Name = "fECHADEADQUISICIONDataGridViewTextBoxColumn";
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADEADQUISICIONDataGridViewTextBoxColumn.Width = 150;
            // 
            // formulariodetareasadquiridasenventanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1778, 725);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CARGARTAREA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.COMENTARIODETAREA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TAREAS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.legajo);
            this.Controls.Add(this.apellynombre);
            this.Name = "formulariodetareasadquiridasenventanilla";
            this.Text = "TAREAS ADQUIRIDAS EN VENTANILLA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formulariodetareasadquiridasenventanilla_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareasadquiridiasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tareasadquiridiasBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DNI1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox legajo;
        private System.Windows.Forms.TextBox apellynombre;
        private System.Windows.Forms.ComboBox TAREAS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox COMENTARIODETAREA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button CARGARTAREA;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tareasadquiridiasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn tAREAADQUIRIDADataGridViewTextBoxColumn;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tareasadquiridiasBindingSource1;
        private DataSet1TableAdapters.tareasadquiridiasTableAdapter tareasadquiridiasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHADEADQUISICION;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRAMITE;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGENTEDETRABAJO;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelldoYNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aGENTEDETRABAJODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aGENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRAMITEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSTADODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADEADQUISICIONDataGridViewTextBoxColumn;
    }
}