namespace WindowsFormsApp1
{
    partial class ASIGNARTAREAS
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
            this.Label2 = new System.Windows.Forms.Label();
            this.AGENTE = new System.Windows.Forms.ComboBox();
            this.ASIGNATAREA = new System.Windows.Forms.Button();
            this.TAREASASIGNARS = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TAREASACCINAR = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.ESTUDIODEDATOS = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(73, 73);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(138, 13);
            this.Label2.TabIndex = 18;
            this.Label2.Text = "AGENTE DE ASIGNACION";
            // 
            // AGENTE
            // 
            this.AGENTE.DisplayMember = "nameuser";
            this.AGENTE.FormattingEnabled = true;
            this.AGENTE.Location = new System.Drawing.Point(69, 94);
            this.AGENTE.Margin = new System.Windows.Forms.Padding(2);
            this.AGENTE.Name = "AGENTE";
            this.AGENTE.Size = new System.Drawing.Size(143, 21);
            this.AGENTE.TabIndex = 17;
            this.AGENTE.ValueMember = "nameuser";
            // 
            // ASIGNATAREA
            // 
            this.ASIGNATAREA.Location = new System.Drawing.Point(89, 138);
            this.ASIGNATAREA.Margin = new System.Windows.Forms.Padding(2);
            this.ASIGNATAREA.Name = "ASIGNATAREA";
            this.ASIGNATAREA.Size = new System.Drawing.Size(96, 18);
            this.ASIGNATAREA.TabIndex = 19;
            this.ASIGNATAREA.Text = "ASIGNAR TAREA";
            this.ASIGNATAREA.UseVisualStyleBackColor = true;
            this.ASIGNATAREA.Click += new System.EventHandler(this.ASIGNATAREA_Click);
            // 
            // TAREASASIGNARS
            // 
            this.TAREASASIGNARS.Location = new System.Drawing.Point(266, 66);
            this.TAREASASIGNARS.Margin = new System.Windows.Forms.Padding(2);
            this.TAREASASIGNARS.Name = "TAREASASIGNARS";
            this.TAREASASIGNARS.Size = new System.Drawing.Size(305, 130);
            this.TAREASASIGNARS.TabIndex = 20;
            this.TAREASASIGNARS.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "TAREAS A ASIGNAR";
            // 
            // TAREASACCINAR
            // 
            this.TAREASACCINAR.HideSelection = false;
            this.TAREASACCINAR.Location = new System.Drawing.Point(8, 222);
            this.TAREASACCINAR.Margin = new System.Windows.Forms.Padding(2);
            this.TAREASACCINAR.Name = "TAREASACCINAR";
            this.TAREASACCINAR.Size = new System.Drawing.Size(1151, 231);
            this.TAREASACCINAR.TabIndex = 23;
            this.TAREASACCINAR.UseCompatibleStateImageBehavior = false;
            this.TAREASACCINAR.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TAREASACCINAR_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 205);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "TAREAS ASIGNADAS";
            // 
            // ESTUDIODEDATOS
            // 
            this.ESTUDIODEDATOS.Location = new System.Drawing.Point(764, 66);
            this.ESTUDIODEDATOS.Margin = new System.Windows.Forms.Padding(2);
            this.ESTUDIODEDATOS.Name = "ESTUDIODEDATOS";
            this.ESTUDIODEDATOS.Size = new System.Drawing.Size(395, 140);
            this.ESTUDIODEDATOS.TabIndex = 25;
            this.ESTUDIODEDATOS.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(917, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "DATOS A ANALIZAR";
            // 
            // ASIGNARTAREAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 853);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ESTUDIODEDATOS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TAREASACCINAR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TAREASASIGNARS);
            this.Controls.Add(this.ASIGNATAREA);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.AGENTE);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ASIGNARTAREAS";
            this.Text = "ASIGNAR TAREAS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ASIGNARTAREAS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox AGENTE;
        private System.Windows.Forms.Button ASIGNATAREA;
        private System.Windows.Forms.RichTextBox TAREASASIGNARS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView TAREASACCINAR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ESTUDIODEDATOS;
        private System.Windows.Forms.Label label4;
    }
}