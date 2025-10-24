namespace WindowsFormsCurso
{
    partial class NotaDetalle
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
            numericUpDownNota = new NumericUpDown();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNota).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownNota
            // 
            numericUpDownNota.Location = new Point(12, 12);
            numericUpDownNota.Name = "numericUpDownNota";
            numericUpDownNota.Size = new Size(268, 23);
            numericUpDownNota.TabIndex = 0;
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(55, 62);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(75, 23);
            buttonAceptar.TabIndex = 1;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(149, 62);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(75, 23);
            buttonCancelar.TabIndex = 2;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // NotaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(292, 97);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(numericUpDownNota);
            Name = "NotaDetalle";
            Text = "Nota Detalle";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNota).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown numericUpDownNota;
        private Button buttonAceptar;
        private Button buttonCancelar;
    }
}