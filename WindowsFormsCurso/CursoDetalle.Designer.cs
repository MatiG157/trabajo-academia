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
            label1 = new Label();
            textBoxDescripcion = new TextBox();
            label2 = new Label();
            profesorDropDown = new ComboBox();
            colorDialog1 = new ColorDialog();
            cargosDropDown = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)AnioCalendarioNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cupoNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // idComisionLabel
            // 
            idComisionLabel.AutoSize = true;
            idComisionLabel.Location = new Point(23, 108);
            idComisionLabel.Margin = new Padding(2, 0, 2, 0);
            idComisionLabel.Name = "idComisionLabel";
            idComisionLabel.Size = new Size(58, 15);
            idComisionLabel.TabIndex = 1;
            idComisionLabel.Text = "Comision";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(247, 292);
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
            cancelarButton.Location = new Point(339, 292);
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
            materiaLabel.Location = new Point(23, 76);
            materiaLabel.Margin = new Padding(2, 0, 2, 0);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(47, 15);
            materiaLabel.TabIndex = 5;
            materiaLabel.Text = "Materia";
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(23, 195);
            AnioCalendarioLabel.Margin = new Padding(2, 0, 2, 0);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(90, 15);
            AnioCalendarioLabel.TabIndex = 9;
            AnioCalendarioLabel.Text = "Anio calendario";
            // 
            // AnioCalendarioNumericUpDown
            // 
            AnioCalendarioNumericUpDown.Location = new Point(130, 193);
            AnioCalendarioNumericUpDown.Margin = new Padding(2);
            AnioCalendarioNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            AnioCalendarioNumericUpDown.Name = "AnioCalendarioNumericUpDown";
            AnioCalendarioNumericUpDown.Size = new Size(250, 23);
            AnioCalendarioNumericUpDown.TabIndex = 0;
            AnioCalendarioNumericUpDown.TabStop = false;
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(23, 227);
            cupoLabel.Margin = new Padding(2, 0, 2, 0);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(36, 15);
            cupoLabel.TabIndex = 7;
            cupoLabel.Text = "Cupo";
            // 
            // cupoNumericUpDown
            // 
            cupoNumericUpDown.Location = new Point(130, 225);
            cupoNumericUpDown.Margin = new Padding(2);
            cupoNumericUpDown.Name = "cupoNumericUpDown";
            cupoNumericUpDown.Size = new Size(250, 23);
            cupoNumericUpDown.TabIndex = 2;
            // 
            // comisionesDropDown
            // 
            comisionesDropDown.FormattingEnabled = true;
            comisionesDropDown.Location = new Point(130, 105);
            comisionesDropDown.Name = "comisionesDropDown";
            comisionesDropDown.Size = new Size(250, 23);
            comisionesDropDown.TabIndex = 10;
            // 
            // materiaDropDown
            // 
            materiaDropDown.FormattingEnabled = true;
            materiaDropDown.Location = new Point(130, 73);
            materiaDropDown.Name = "materiaDropDown";
            materiaDropDown.Size = new Size(250, 23);
            materiaDropDown.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 44);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 12;
            label1.Text = "Descripcion";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.Location = new Point(130, 41);
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(250, 23);
            textBoxDescripcion.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 139);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 14;
            label2.Text = "Profesor";
            // 
            // profesorDropDown
            // 
            profesorDropDown.FormattingEnabled = true;
            profesorDropDown.Location = new Point(130, 136);
            profesorDropDown.Name = "profesorDropDown";
            profesorDropDown.Size = new Size(250, 23);
            profesorDropDown.TabIndex = 15;
            // 
            // cargosDropDown
            // 
            cargosDropDown.FormattingEnabled = true;
            cargosDropDown.Location = new Point(130, 165);
            cargosDropDown.Name = "cargosDropDown";
            cargosDropDown.Size = new Size(250, 23);
            cargosDropDown.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 168);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 17;
            label3.Text = "Cargo";
            // 
            // CursoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 325);
            Controls.Add(label3);
            Controls.Add(cargosDropDown);
            Controls.Add(profesorDropDown);
            Controls.Add(label2);
            Controls.Add(textBoxDescripcion);
            Controls.Add(label1);
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
        private Label label1;
        private TextBox textBoxDescripcion;
        private Label label2;
        private ComboBox profesorDropDown;
        private ColorDialog colorDialog1;
        private ComboBox cargosDropDown;
        private Label label3;
    }
}