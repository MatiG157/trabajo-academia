namespace WindowsFormsCurso
{
    partial class PonerNotas
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
            comboBoxCursos = new ComboBox();
            buttonFiltrar = new Button();
            dataGridViewAlumnos = new DataGridView();
            buttonPonerNota = new Button();
            cursoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlumnos).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCursos
            // 
            comboBoxCursos.FormattingEnabled = true;
            comboBoxCursos.Location = new Point(59, 12);
            comboBoxCursos.Name = "comboBoxCursos";
            comboBoxCursos.Size = new Size(214, 23);
            comboBoxCursos.TabIndex = 0;
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(279, 11);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(75, 23);
            buttonFiltrar.TabIndex = 1;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // dataGridViewAlumnos
            // 
            dataGridViewAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlumnos.Location = new Point(12, 41);
            dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            dataGridViewAlumnos.Size = new Size(709, 262);
            dataGridViewAlumnos.TabIndex = 2;
            // 
            // buttonPonerNota
            // 
            buttonPonerNota.Location = new Point(646, 309);
            buttonPonerNota.Name = "buttonPonerNota";
            buttonPonerNota.Size = new Size(75, 23);
            buttonPonerNota.TabIndex = 3;
            buttonPonerNota.Text = "Poner Nota";
            buttonPonerNota.UseVisualStyleBackColor = true;
            buttonPonerNota.Click += buttonPonerNota_Click;
            // 
            // cursoLabel
            // 
            cursoLabel.AutoSize = true;
            cursoLabel.Location = new Point(12, 16);
            cursoLabel.Name = "cursoLabel";
            cursoLabel.Size = new Size(38, 15);
            cursoLabel.TabIndex = 6;
            cursoLabel.Text = "Curso";
            // 
            // PonerNotas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(733, 344);
            Controls.Add(cursoLabel);
            Controls.Add(buttonPonerNota);
            Controls.Add(dataGridViewAlumnos);
            Controls.Add(buttonFiltrar);
            Controls.Add(comboBoxCursos);
            Name = "PonerNotas";
            Text = "Poner notas";
            Load += Poner_notas_load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCursos;
        private Button buttonFiltrar;
        private DataGridView dataGridViewAlumnos;
        private Button buttonPonerNota;
        private Label cursoLabel;
    }
}