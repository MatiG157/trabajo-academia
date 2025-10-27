namespace WindowsFormsCurso
{
    partial class VerNotas
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
            dataGridViewNotas = new DataGridView();
            buttonCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotas).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewNotas
            // 
            dataGridViewNotas.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridViewNotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotas.Location = new Point(12, 12);
            dataGridViewNotas.Name = "dataGridViewNotas";
            dataGridViewNotas.Size = new Size(776, 293);
            dataGridViewNotas.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(713, 315);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(75, 23);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // VerNotas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FondoWinForm;
            ClientSize = new Size(800, 348);
            Controls.Add(buttonCerrar);
            Controls.Add(dataGridViewNotas);
            Name = "VerNotas";
            Text = "Notas";
            Load += Load_Notas;
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewNotas;
        private Button buttonCerrar;
    }
}