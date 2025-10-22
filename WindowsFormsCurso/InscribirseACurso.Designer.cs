namespace WindowsFormsCurso
{
    partial class InscribirseACurso
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
            dataGridViewCursos = new DataGridView();
            buttonInscribirse = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCursos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCursos
            // 
            dataGridViewCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCursos.Location = new Point(12, 12);
            dataGridViewCursos.Name = "dataGridViewCursos";
            dataGridViewCursos.Size = new Size(590, 263);
            dataGridViewCursos.TabIndex = 0;
            // 
            // buttonInscribirse
            // 
            buttonInscribirse.Location = new Point(527, 281);
            buttonInscribirse.Name = "buttonInscribirse";
            buttonInscribirse.Size = new Size(75, 23);
            buttonInscribirse.TabIndex = 1;
            buttonInscribirse.Text = "Inscribirse";
            buttonInscribirse.UseVisualStyleBackColor = true;
            buttonInscribirse.Click += buttonInscribirse_Click;
            // 
            // InscribirseACurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 313);
            Controls.Add(buttonInscribirse);
            Controls.Add(dataGridViewCursos);
            Name = "InscribirseACurso";
            Text = "Form1";
            Load += Cursos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCursos;
        private Button buttonInscribirse;
    }
}