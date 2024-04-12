namespace WindowsFormsApp1
{
    partial class Tareas
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
            this.TAREASASIGNADAS = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.TAREASAREALIZAR = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COMENTARIOS = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TAREASASIGNADAS
            // 
            this.TAREASASIGNADAS.HideSelection = false;
            this.TAREASASIGNADAS.Location = new System.Drawing.Point(8, 86);
            this.TAREASASIGNADAS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TAREASASIGNADAS.Name = "TAREASASIGNADAS";
            this.TAREASASIGNADAS.Size = new System.Drawing.Size(1103, 179);
            this.TAREASASIGNADAS.TabIndex = 0;
            this.TAREASASIGNADAS.UseCompatibleStateImageBehavior = false;
            this.TAREASASIGNADAS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TAREASASIGNADAS_MouseClick);
            this.TAREASASIGNADAS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TAREASASIGNADAS_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(498, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TAREAS ASIGNADAS";
            // 
            // TAREASAREALIZAR
            // 
            this.TAREASAREALIZAR.Location = new System.Drawing.Point(22, 306);
            this.TAREASAREALIZAR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TAREASAREALIZAR.Name = "TAREASAREALIZAR";
            this.TAREASAREALIZAR.Size = new System.Drawing.Size(719, 174);
            this.TAREASAREALIZAR.TabIndex = 2;
            this.TAREASAREALIZAR.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "TAREA A REALIZAR";
            // 
            // COMENTARIOS
            // 
            this.COMENTARIOS.Location = new System.Drawing.Point(835, 306);
            this.COMENTARIOS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.COMENTARIOS.Name = "COMENTARIOS";
            this.COMENTARIOS.Size = new System.Drawing.Size(276, 174);
            this.COMENTARIOS.TabIndex = 4;
            this.COMENTARIOS.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(859, 280);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "COMENTARIO DEL AGENTE REALIZADOR";
            // 
            // Tareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 523);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.COMENTARIOS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TAREASAREALIZAR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TAREASASIGNADAS);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Tareas";
            this.Text = "Tareas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Tareas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TAREASASIGNADAS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TAREASAREALIZAR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox COMENTARIOS;
        private System.Windows.Forms.Label label3;
    }
}