namespace WindowsForms
{
    partial class CursoDetalle
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
            idComisionNumericUpDown = new NumericUpDown();
            idComisionLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            idMateriaLabel = new Label();
            idMateriaNumericUpDown = new NumericUpDown();
            AnioCalendarioLabel = new Label();
            AnioCalendarioNumericUpDown = new NumericUpDown();
            cupoLabel = new Label();
            cupoNumericUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)idComisionNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idMateriaNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AnioCalendarioNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cupoNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // idComisionNumericUpDown
            // 
            idComisionNumericUpDown.Location = new Point(149, 87);
            idComisionNumericUpDown.Margin = new Padding(2);
            idComisionNumericUpDown.Name = "idComisionNumericUpDown";
            idComisionNumericUpDown.Size = new Size(125, 27);
            idComisionNumericUpDown.TabIndex = 0;
            // 
            // idComisionLabel
            // 
            idComisionLabel.AutoSize = true;
            idComisionLabel.Location = new Point(26, 94);
            idComisionLabel.Margin = new Padding(2, 0, 2, 0);
            idComisionLabel.Name = "idComisionLabel";
            idComisionLabel.Size = new Size(84, 20);
            idComisionLabel.TabIndex = 1;
            idComisionLabel.Text = "idComision";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(273, 266);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(92, 29);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(378, 266);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(92, 29);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // idMateriaLabel
            // 
            idMateriaLabel.AutoSize = true;
            idMateriaLabel.Location = new Point(26, 50);
            idMateriaLabel.Margin = new Padding(2, 0, 2, 0);
            idMateriaLabel.Name = "idMateriaLabel";
            idMateriaLabel.Size = new Size(73, 20);
            idMateriaLabel.TabIndex = 5;
            idMateriaLabel.Text = "idMateria";
            // 
            // idMateriaNumericUpDown
            // 
            idMateriaNumericUpDown.Location = new Point(149, 43);
            idMateriaNumericUpDown.Margin = new Padding(2);
            idMateriaNumericUpDown.Name = "idMateriaNumericUpDown";
            idMateriaNumericUpDown.Size = new Size(125, 27);
            idMateriaNumericUpDown.TabIndex = 1;
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(26, 142);
            AnioCalendarioLabel.Margin = new Padding(2, 0, 2, 0);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(114, 20);
            AnioCalendarioLabel.TabIndex = 9;
            AnioCalendarioLabel.Text = "Anio calendario";
            // 
            // AnioCalendarioNumericUpDown
            // 
            AnioCalendarioNumericUpDown.Location = new Point(149, 142);
            AnioCalendarioNumericUpDown.Margin = new Padding(2);
            AnioCalendarioNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            AnioCalendarioNumericUpDown.Name = "AnioCalendarioNumericUpDown";
            AnioCalendarioNumericUpDown.Size = new Size(125, 27);
            AnioCalendarioNumericUpDown.TabIndex = 0;
            AnioCalendarioNumericUpDown.TabStop = false;
            AnioCalendarioNumericUpDown.TextChanged += AnioCalendarioNumericUpDown_TextChanged;
            AnioCalendarioNumericUpDown.ValueChanged += AnioCalendarioNumericUpDown_ValueChanged;
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(26, 197);
            cupoLabel.Margin = new Padding(2, 0, 2, 0);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(44, 20);
            cupoLabel.TabIndex = 7;
            cupoLabel.Text = "Cupo";
            cupoLabel.Click += cupoLabel_Click;
            // 
            // cupoNumericUpDown
            // 
            cupoNumericUpDown.Location = new Point(149, 197);
            cupoNumericUpDown.Margin = new Padding(2);
            cupoNumericUpDown.Name = "cupoNumericUpDown";
            cupoNumericUpDown.Size = new Size(125, 27);
            cupoNumericUpDown.TabIndex = 2;
            cupoNumericUpDown.TextChanged += cupoNumericUpDown_TextChanged;
            cupoNumericUpDown.ValueChanged += cupoNumericUpDown_ValueChanged;
            // 
            // CursoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 315);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(AnioCalendarioNumericUpDown);
            Controls.Add(cupoLabel);
            Controls.Add(cupoNumericUpDown);
            Controls.Add(idMateriaLabel);
            Controls.Add(idMateriaNumericUpDown);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idComisionLabel);
            Controls.Add(idComisionNumericUpDown);
            Margin = new Padding(2);
            Name = "CursoDetalle";
            Text = "Curso";
            Load += CursoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)idComisionNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)idMateriaNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)AnioCalendarioNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)cupoNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown idComisionNumericUpDown;
        private Label idComisionLabel;

        private Button aceptarButton;
        private Button cancelarButton;

        private Label idMateriaLabel;
        private NumericUpDown idMateriaNumericUpDown;

        private Label cupoLabel;
        private NumericUpDown cupoNumericUpDown;

        private Label AnioCalendarioLabel;
        private NumericUpDown AnioCalendarioNumericUpDown;

        private TextBox textBox1;
    }
}