
namespace WindowsFormsApp1
{
    partial class stass
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalConsultas = new System.Windows.Forms.TextBox();
            this.consultar = new System.Windows.Forms.Button();
            this.ESTADISTICADIARIAS = new System.Windows.Forms.Button();
            this.EXPORTAREXCELL = new System.Windows.Forms.Button();
            this.comboBoxAgente = new System.Windows.Forms.ComboBox();
            this.btnEstadisticasPorAgente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PORAÑOYPORMES = new System.Windows.Forms.Button();
            this.PORAÑOPORMESPORAGENTE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(11, 77);
            this.comboBoxMes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(106, 21);
            this.comboBoxMes.TabIndex = 0;
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032"});
            this.comboBoxAnio.Location = new System.Drawing.Point(11, 30);
            this.comboBoxAnio.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(106, 21);
            this.comboBoxAnio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AÑO";
            // 
            // dataGridViewStats
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStats.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStats.Location = new System.Drawing.Point(185, 62);
            this.dataGridViewStats.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewStats.Name = "dataGridViewStats";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStats.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewStats.RowHeadersWidth = 62;
            this.dataGridViewStats.Size = new System.Drawing.Size(1593, 188);
            this.dataGridViewStats.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TOTALES";
            // 
            // textBoxTotalConsultas
            // 
            this.textBoxTotalConsultas.Location = new System.Drawing.Point(185, 31);
            this.textBoxTotalConsultas.Name = "textBoxTotalConsultas";
            this.textBoxTotalConsultas.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalConsultas.TabIndex = 5;
            // 
            // consultar
            // 
            this.consultar.Location = new System.Drawing.Point(11, 155);
            this.consultar.Name = "consultar";
            this.consultar.Size = new System.Drawing.Size(75, 23);
            this.consultar.TabIndex = 6;
            this.consultar.Text = "CONSULTAR";
            this.consultar.UseVisualStyleBackColor = true;
            this.consultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // ESTADISTICADIARIAS
            // 
            this.ESTADISTICADIARIAS.Location = new System.Drawing.Point(11, 184);
            this.ESTADISTICADIARIAS.Name = "ESTADISTICADIARIAS";
            this.ESTADISTICADIARIAS.Size = new System.Drawing.Size(146, 40);
            this.ESTADISTICADIARIAS.TabIndex = 7;
            this.ESTADISTICADIARIAS.Text = "ESTADISTICAS DIARIAS";
            this.ESTADISTICADIARIAS.UseVisualStyleBackColor = true;
            this.ESTADISTICADIARIAS.Click += new System.EventHandler(this.btnEstadisticasDiarias_Click);
            // 
            // EXPORTAREXCELL
            // 
            this.EXPORTAREXCELL.Location = new System.Drawing.Point(11, 265);
            this.EXPORTAREXCELL.Name = "EXPORTAREXCELL";
            this.EXPORTAREXCELL.Size = new System.Drawing.Size(146, 26);
            this.EXPORTAREXCELL.TabIndex = 8;
            this.EXPORTAREXCELL.Text = "EXPORTAR A EXCELL";
            this.EXPORTAREXCELL.UseVisualStyleBackColor = true;
            this.EXPORTAREXCELL.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // comboBoxAgente
            // 
            this.comboBoxAgente.FormattingEnabled = true;
            this.comboBoxAgente.Location = new System.Drawing.Point(11, 116);
            this.comboBoxAgente.Name = "comboBoxAgente";
            this.comboBoxAgente.Size = new System.Drawing.Size(106, 21);
            this.comboBoxAgente.TabIndex = 9;
            // 
            // btnEstadisticasPorAgente
            // 
            this.btnEstadisticasPorAgente.Location = new System.Drawing.Point(11, 230);
            this.btnEstadisticasPorAgente.Name = "btnEstadisticasPorAgente";
            this.btnEstadisticasPorAgente.Size = new System.Drawing.Size(146, 29);
            this.btnEstadisticasPorAgente.TabIndex = 10;
            this.btnEstadisticasPorAgente.Text = "POR AGENTE";
            this.btnEstadisticasPorAgente.UseVisualStyleBackColor = true;
            this.btnEstadisticasPorAgente.Click += new System.EventHandler(this.btnEstadisticasPorAgente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "MES";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "AGENTE";
            // 
            // PORAÑOYPORMES
            // 
            this.PORAÑOYPORMES.Location = new System.Drawing.Point(11, 307);
            this.PORAÑOYPORMES.Name = "PORAÑOYPORMES";
            this.PORAÑOYPORMES.Size = new System.Drawing.Size(146, 23);
            this.PORAÑOYPORMES.TabIndex = 13;
            this.PORAÑOYPORMES.Text = "POR AÑO Y POR MES";
            this.PORAÑOYPORMES.UseVisualStyleBackColor = true;
            this.PORAÑOYPORMES.Click += new System.EventHandler(this.btnEstadisticasPorAnioMes_Click);
            // 
            // PORAÑOPORMESPORAGENTE
            // 
            this.PORAÑOPORMESPORAGENTE.Location = new System.Drawing.Point(11, 348);
            this.PORAÑOPORMESPORAGENTE.Name = "PORAÑOPORMESPORAGENTE";
            this.PORAÑOPORMESPORAGENTE.Size = new System.Drawing.Size(146, 36);
            this.PORAÑOPORMESPORAGENTE.TabIndex = 14;
            this.PORAÑOPORMESPORAGENTE.Text = "POR AÑO POR MES POR AGENTE";
            this.PORAÑOPORMESPORAGENTE.UseVisualStyleBackColor = true;
            this.PORAÑOPORMESPORAGENTE.Click += new System.EventHandler(this.btnEstadisticasPorAnioMesAgente_Click);
            // 
            // stass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 630);
            this.Controls.Add(this.PORAÑOPORMESPORAGENTE);
            this.Controls.Add(this.PORAÑOYPORMES);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEstadisticasPorAgente);
            this.Controls.Add(this.comboBoxAgente);
            this.Controls.Add(this.EXPORTAREXCELL);
            this.Controls.Add(this.ESTADISTICADIARIAS);
            this.Controls.Add(this.consultar);
            this.Controls.Add(this.textBoxTotalConsultas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.comboBoxMes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "stass";
            this.Text = "STAST ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StatsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.ComboBox comboBoxAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalConsultas;
        private System.Windows.Forms.Button consultar;
        private System.Windows.Forms.Button ESTADISTICADIARIAS;
        private System.Windows.Forms.Button EXPORTAREXCELL;
        private System.Windows.Forms.ComboBox comboBoxAgente;
        private System.Windows.Forms.Button btnEstadisticasPorAgente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PORAÑOYPORMES;
        private System.Windows.Forms.Button PORAÑOPORMESPORAGENTE;
    }
}