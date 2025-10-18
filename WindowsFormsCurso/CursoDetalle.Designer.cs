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
            idComisionLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            materiaLabel = new Label();
            AnioCalendarioLabel = new Label();
            AnioCalendarioNumericUpDown = new NumericUpDown();
            cupoLabel = new Label();
            cupoNumericUpDown = new NumericUpDown();
            comisionesDropDown = new ComboBox();
            materiaDropDown = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)AnioCalendarioNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cupoNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // idComisionLabel
            // 
            idComisionLabel.AutoSize = true;
            idComisionLabel.Location = new Point(23, 70);
            idComisionLabel.Margin = new Padding(2, 0, 2, 0);
            idComisionLabel.Name = "idComisionLabel";
            idComisionLabel.Size = new Size(58, 15);
            idComisionLabel.TabIndex = 1;
            idComisionLabel.Text = "Comision";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(239, 200);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(331, 200);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Location = new Point(23, 38);
            materiaLabel.Margin = new Padding(2, 0, 2, 0);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(47, 15);
            materiaLabel.TabIndex = 5;
            materiaLabel.Text = "Materia";
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(23, 106);
            AnioCalendarioLabel.Margin = new Padding(2, 0, 2, 0);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(90, 15);
            AnioCalendarioLabel.TabIndex = 9;
            AnioCalendarioLabel.Text = "Anio calendario";
            // 
            // AnioCalendarioNumericUpDown
            // 
            AnioCalendarioNumericUpDown.Location = new Point(130, 106);
            AnioCalendarioNumericUpDown.Margin = new Padding(2);
            AnioCalendarioNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            AnioCalendarioNumericUpDown.Name = "AnioCalendarioNumericUpDown";
            AnioCalendarioNumericUpDown.Size = new Size(250, 23);
            AnioCalendarioNumericUpDown.TabIndex = 0;
            AnioCalendarioNumericUpDown.TabStop = false;
            AnioCalendarioNumericUpDown.TextChanged += AnioCalendarioNumericUpDown_TextChanged;
            AnioCalendarioNumericUpDown.ValueChanged += AnioCalendarioNumericUpDown_ValueChanged;
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(23, 148);
            cupoLabel.Margin = new Padding(2, 0, 2, 0);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(36, 15);
            cupoLabel.TabIndex = 7;
            cupoLabel.Text = "Cupo";
            cupoLabel.Click += cupoLabel_Click;
            // 
            // cupoNumericUpDown
            // 
            cupoNumericUpDown.Location = new Point(130, 148);
            cupoNumericUpDown.Margin = new Padding(2);
            cupoNumericUpDown.Name = "cupoNumericUpDown";
            cupoNumericUpDown.Size = new Size(250, 23);
            cupoNumericUpDown.TabIndex = 2;
            cupoNumericUpDown.TextChanged += cupoNumericUpDown_TextChanged;
            cupoNumericUpDown.ValueChanged += cupoNumericUpDown_ValueChanged;
            // 
            // comisionesDropDown
            // 
            comisionesDropDown.FormattingEnabled = true;
            comisionesDropDown.Location = new Point(130, 67);
            comisionesDropDown.Name = "comisionesDropDown";
            comisionesDropDown.Size = new Size(250, 23);
            comisionesDropDown.TabIndex = 10;
            // 
            // materiaDropDown
            // 
            materiaDropDown.FormattingEnabled = true;
            materiaDropDown.Location = new Point(130, 32);
            materiaDropDown.Name = "materiaDropDown";
            materiaDropDown.Size = new Size(250, 23);
            materiaDropDown.TabIndex = 11;
            // 
            // CursoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 236);
            Controls.Add(materiaDropDown);
            Controls.Add(comisionesDropDown);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(AnioCalendarioNumericUpDown);
            Controls.Add(cupoLabel);
            Controls.Add(cupoNumericUpDown);
            Controls.Add(materiaLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idComisionLabel);
            Margin = new Padding(2);
            Name = "CursoDetalle";
            Text = "Detalle curso";
            Load += CursoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)AnioCalendarioNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)cupoNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label idComisionLabel;

        private Button aceptarButton;
        private Button cancelarButton;

        private Label materiaLabel;

        private Label cupoLabel;
        private NumericUpDown cupoNumericUpDown;

        private Label AnioCalendarioLabel;
        private NumericUpDown AnioCalendarioNumericUpDown;

        private TextBox textBox1;
        private ComboBox comisionesDropDown;
        private ComboBox materiaDropDown;
    }
}