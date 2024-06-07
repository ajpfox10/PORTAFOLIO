
namespace WindowsFormsApp1
{
    partial class Sistemasdenovedadesagente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PORDNI = new System.Windows.Forms.RadioButton();
            this.foto = new System.Windows.Forms.CheckBox();
            this.JURADASALARIO = new System.Windows.Forms.CheckBox();
            this.REALIZODOMICILIO = new System.Windows.Forms.CheckBox();
            this.legajohecho = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CARGARTAREA = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.COMENTARIODETAREA = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DNI1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PORAPELLIDO = new System.Windows.Forms.RadioButton();
            this.apellido1 = new System.Windows.Forms.ComboBox();
            this.DNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.legajo = new System.Windows.Forms.TextBox();
            this.apellynombre = new System.Windows.Forms.TextBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechadeinicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inconvenientesagentesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new WindowsFormsApp1.DataSet2();
            this.inconvenientesagentesTableAdapter = new WindowsFormsApp1.DataSet2TableAdapters.inconvenientesagentesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inconvenientesagentesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // PORDNI
            // 
            this.PORDNI.AutoSize = true;
            this.PORDNI.Location = new System.Drawing.Point(18, 29);
            this.PORDNI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PORDNI.Name = "PORDNI";
            this.PORDNI.Size = new System.Drawing.Size(336, 24);
            this.PORDNI.TabIndex = 35;
            this.PORDNI.TabStop = true;
            this.PORDNI.Text = "BUSQUEDA POR APELLIDO Y NOMBRE";
            this.PORDNI.UseVisualStyleBackColor = true;
            this.PORDNI.Visible = false;
            // 
            // foto
            // 
            this.foto.AutoSize = true;
            this.foto.Location = new System.Drawing.Point(24, 67);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(78, 24);
            this.foto.TabIndex = 47;
            this.foto.Text = "FOTO";
            this.foto.UseVisualStyleBackColor = true;
            // 
            // JURADASALARIO
            // 
            this.JURADASALARIO.AutoSize = true;
            this.JURADASALARIO.Location = new System.Drawing.Point(143, 67);
            this.JURADASALARIO.Name = "JURADASALARIO";
            this.JURADASALARIO.Size = new System.Drawing.Size(323, 24);
            this.JURADASALARIO.TabIndex = 46;
            this.JURADASALARIO.Text = "DECLARACION JURADA DE SALARIO";
            this.JURADASALARIO.UseVisualStyleBackColor = true;
            // 
            // REALIZODOMICILIO
            // 
            this.REALIZODOMICILIO.AutoSize = true;
            this.REALIZODOMICILIO.Location = new System.Drawing.Point(200, 100);
            this.REALIZODOMICILIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.REALIZODOMICILIO.Name = "REALIZODOMICILIO";
            this.REALIZODOMICILIO.Size = new System.Drawing.Size(193, 24);
            this.REALIZODOMICILIO.TabIndex = 45;
            this.REALIZODOMICILIO.Text = "REALIZO DOMICILIO";
            this.REALIZODOMICILIO.UseVisualStyleBackColor = true;
            // 
            // legajohecho
            // 
            this.legajohecho.AutoSize = true;
            this.legajohecho.Location = new System.Drawing.Point(25, 100);
            this.legajohecho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.legajohecho.Name = "legajohecho";
            this.legajohecho.Size = new System.Drawing.Size(153, 24);
            this.legajohecho.TabIndex = 44;
            this.legajohecho.Text = "LEGAJO ECHO ";
            this.legajohecho.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechadeinicioDataGridViewTextBoxColumn,
            this.memoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inconvenientesagentesBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(14, 407);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1604, 232);
            this.dataGridView1.TabIndex = 43;
            // 
            // CARGARTAREA
            // 
            this.CARGARTAREA.Location = new System.Drawing.Point(542, 209);
            this.CARGARTAREA.Name = "CARGARTAREA";
            this.CARGARTAREA.Size = new System.Drawing.Size(224, 36);
            this.CARGARTAREA.TabIndex = 42;
            this.CARGARTAREA.Text = "CARGAR NOVEDAD";
            this.CARGARTAREA.UseVisualStyleBackColor = true;
            this.CARGARTAREA.Click += new System.EventHandler(this.CARGARTAREA_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(692, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "NOVEDADES DEL AGENTE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "NOVEDAD";
            // 
            // COMENTARIODETAREA
            // 
            this.COMENTARIODETAREA.Location = new System.Drawing.Point(14, 209);
            this.COMENTARIODETAREA.Name = "COMENTARIODETAREA";
            this.COMENTARIODETAREA.Size = new System.Drawing.Size(492, 136);
            this.COMENTARIODETAREA.TabIndex = 39;
            this.COMENTARIODETAREA.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DNI1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PORDNI);
            this.groupBox1.Controls.Add(this.PORAPELLIDO);
            this.groupBox1.Controls.Add(this.apellido1);
            this.groupBox1.Controls.Add(this.DNI);
            this.groupBox1.Location = new System.Drawing.Point(524, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1094, 114);
            this.groupBox1.TabIndex = 32;
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
            this.DNI1.TextChanged += new System.EventHandler(this.DNI1_TextChanged);
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
            this.DNI.TextChanged += new System.EventHandler(this.DNI_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "LEGAJO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 186);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "APELLIDO Y NOMBRE";
            // 
            // legajo
            // 
            this.legajo.Location = new System.Drawing.Point(354, 33);
            this.legajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.legajo.Name = "legajo";
            this.legajo.Size = new System.Drawing.Size(112, 26);
            this.legajo.TabIndex = 33;
            // 
            // apellynombre
            // 
            this.apellynombre.Location = new System.Drawing.Point(25, 33);
            this.apellynombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apellynombre.Name = "apellynombre";
            this.apellynombre.Size = new System.Drawing.Size(290, 26);
            this.apellynombre.TabIndex = 31;
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
            // fechadeinicioDataGridViewTextBoxColumn
            // 
            this.fechadeinicioDataGridViewTextBoxColumn.DataPropertyName = "fechadeinicio";
            this.fechadeinicioDataGridViewTextBoxColumn.HeaderText = "FECHA DE ALTA INCONVENIENTE";
            this.fechadeinicioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fechadeinicioDataGridViewTextBoxColumn.Name = "fechadeinicioDataGridViewTextBoxColumn";
            this.fechadeinicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechadeinicioDataGridViewTextBoxColumn.Width = 150;
            // 
            // memoDataGridViewTextBoxColumn
            // 
            this.memoDataGridViewTextBoxColumn.DataPropertyName = "memo";
            this.memoDataGridViewTextBoxColumn.HeaderText = "MEMO";
            this.memoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.memoDataGridViewTextBoxColumn.Name = "memoDataGridViewTextBoxColumn";
            this.memoDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoDataGridViewTextBoxColumn.Width = 150;
            // 
            // inconvenientesagentesBindingSource
            // 
            this.inconvenientesagentesBindingSource.DataMember = "inconvenientesagentes";
            this.inconvenientesagentesBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inconvenientesagentesTableAdapter
            // 
            this.inconvenientesagentesTableAdapter.ClearBeforeFill = true;
            // 
            // Sistemasdenovedadesagente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1754, 854);
            this.Controls.Add(this.foto);
            this.Controls.Add(this.JURADASALARIO);
            this.Controls.Add(this.REALIZODOMICILIO);
            this.Controls.Add(this.legajohecho);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CARGARTAREA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.COMENTARIODETAREA);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.legajo);
            this.Controls.Add(this.apellynombre);
            this.Name = "Sistemasdenovedadesagente";
            this.Text = "SISTEMAS DE NOVEDADES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sistemasdenovedadesagente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inconvenientesagentesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton PORDNI;
        private System.Windows.Forms.CheckBox foto;
        private System.Windows.Forms.CheckBox JURADASALARIO;
        private System.Windows.Forms.CheckBox REALIZODOMICILIO;
        private System.Windows.Forms.CheckBox legajohecho;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CARGARTAREA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox COMENTARIODETAREA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DNI1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton PORAPELLIDO;
        private System.Windows.Forms.ComboBox apellido1;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox legajo;
        private System.Windows.Forms.TextBox apellynombre;
        private DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource inconvenientesagentesBindingSource;
        private DataSet2TableAdapters.inconvenientesagentesTableAdapter inconvenientesagentesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechadeinicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoDataGridViewTextBoxColumn;
    }
}