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
            comboBoxCursos.Location = new Point(67, 16);
            comboBoxCursos.Margin = new Padding(3, 4, 3, 4);
            comboBoxCursos.Name = "comboBoxCursos";
            comboBoxCursos.Size = new Size(244, 28);
            comboBoxCursos.TabIndex = 0;
            // 
            // buttonFiltrar
            // 
            buttonFiltrar.Location = new Point(319, 15);
            buttonFiltrar.Margin = new Padding(3, 4, 3, 4);
            buttonFiltrar.Name = "buttonFiltrar";
            buttonFiltrar.Size = new Size(86, 31);
            buttonFiltrar.TabIndex = 1;
            buttonFiltrar.Text = "Filtrar";
            buttonFiltrar.UseVisualStyleBackColor = true;
            buttonFiltrar.Click += buttonFiltrar_Click;
            // 
            // dataGridViewAlumnos
            // 
            dataGridViewAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlumnos.Location = new Point(14, 55);
            dataGridViewAlumnos.Margin = new Padding(3, 4, 3, 4);
            dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            dataGridViewAlumnos.RowHeadersWidth = 51;
            dataGridViewAlumnos.Size = new Size(810, 349);
            dataGridViewAlumnos.TabIndex = 2;
            // 
            // buttonPonerNota
            // 
            buttonPonerNota.Location = new Point(693, 412);
            buttonPonerNota.Margin = new Padding(3, 4, 3, 4);
            buttonPonerNota.Name = "buttonPonerNota";
            buttonPonerNota.Size = new Size(131, 31);
            buttonPonerNota.TabIndex = 3;
            buttonPonerNota.Text = "Poner Nota";
            buttonPonerNota.UseVisualStyleBackColor = true;
            buttonPonerNota.Click += buttonPonerNota_Click;
            // 
            // cursoLabel
            // 
            cursoLabel.AutoSize = true;
            cursoLabel.Location = new Point(14, 21);
            cursoLabel.Name = "cursoLabel";
            cursoLabel.Size = new Size(46, 20);
            cursoLabel.TabIndex = 6;
            cursoLabel.Text = "Curso";
            // 
            // PonerNotas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 459);
            Controls.Add(cursoLabel);
            Controls.Add(buttonPonerNota);
            Controls.Add(dataGridViewAlumnos);
            Controls.Add(buttonFiltrar);
            Controls.Add(comboBoxCursos);
            Margin = new Padding(3, 4, 3, 4);
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