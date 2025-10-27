namespace WindowsFormsCurso
{
    partial class PersonaDetalle
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
            label3 = new Label();
            planDropDown = new ComboBox();
            label2 = new Label();
            textBoxDireccion = new TextBox();
            label1 = new Label();
            tipoPersonaDropDown = new ComboBox();
            AnioCalendarioLabel = new Label();
            cupoLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            idComisionLabel = new Label();
            legajoNumericUpDown = new NumericUpDown();
            textBoxTelefono = new TextBox();
            dateTimePickerFechaNacimiento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)legajoNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 230);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 33;
            label3.Text = "Tipo Persona";
            // 
            // planDropDown
            // 
            planDropDown.FormattingEnabled = true;
            planDropDown.Location = new Point(183, 285);
            planDropDown.Margin = new Padding(3, 4, 3, 4);
            planDropDown.Name = "planDropDown";
            planDropDown.Size = new Size(285, 28);
            planDropDown.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 124);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 30;
            label2.Text = "Telefono";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.Location = new Point(183, 32);
            textBoxDireccion.Margin = new Padding(3, 4, 3, 4);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(285, 27);
            textBoxDireccion.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 35);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 28;
            label1.Text = "Direccion";
            // 
            // tipoPersonaDropDown
            // 
            tipoPersonaDropDown.FormattingEnabled = true;
            tipoPersonaDropDown.Location = new Point(184, 230);
            tipoPersonaDropDown.Margin = new Padding(3, 4, 3, 4);
            tipoPersonaDropDown.Name = "tipoPersonaDropDown";
            tipoPersonaDropDown.Size = new Size(285, 28);
            tipoPersonaDropDown.TabIndex = 26;
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(32, 184);
            AnioCalendarioLabel.Margin = new Padding(2, 0, 2, 0);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(128, 20);
            AnioCalendarioLabel.TabIndex = 25;
            AnioCalendarioLabel.Text = "Fecha Nacimiento";
            // 
            // cupoLabel
            // 
            cupoLabel.AutoSize = true;
            cupoLabel.Location = new Point(32, 293);
            cupoLabel.Margin = new Padding(2, 0, 2, 0);
            cupoLabel.Name = "cupoLabel";
            cupoLabel.Size = new Size(37, 20);
            cupoLabel.TabIndex = 24;
            cupoLabel.Text = "Plan";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(393, 365);
            cancelarButton.Margin = new Padding(2, 3, 2, 3);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(91, 29);
            cancelarButton.TabIndex = 22;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(288, 365);
            aceptarButton.Margin = new Padding(2, 3, 2, 3);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(91, 29);
            aceptarButton.TabIndex = 21;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // idComisionLabel
            // 
            idComisionLabel.AutoSize = true;
            idComisionLabel.Location = new Point(32, 79);
            idComisionLabel.Margin = new Padding(2, 0, 2, 0);
            idComisionLabel.Name = "idComisionLabel";
            idComisionLabel.Size = new Size(54, 20);
            idComisionLabel.TabIndex = 19;
            idComisionLabel.Text = "Legajo";
            // 
            // legajoNumericUpDown
            // 
            legajoNumericUpDown.Location = new Point(183, 77);
            legajoNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            legajoNumericUpDown.Name = "legajoNumericUpDown";
            legajoNumericUpDown.Size = new Size(286, 27);
            legajoNumericUpDown.TabIndex = 20;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(184, 124);
            textBoxTelefono.Margin = new Padding(3, 4, 3, 4);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(285, 27);
            textBoxTelefono.TabIndex = 34;
            // 
            // dateTimePickerFechaNacimiento
            // 
            dateTimePickerFechaNacimiento.Location = new Point(183, 179);
            dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            dateTimePickerFechaNacimiento.Size = new Size(284, 27);
            dateTimePickerFechaNacimiento.TabIndex = 35;
            // 
            // PersonaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 443);
            Controls.Add(dateTimePickerFechaNacimiento);
            Controls.Add(textBoxTelefono);
            Controls.Add(label3);
            Controls.Add(planDropDown);
            Controls.Add(label2);
            Controls.Add(textBoxDireccion);
            Controls.Add(label1);
            Controls.Add(tipoPersonaDropDown);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(cupoLabel);
            Controls.Add(legajoNumericUpDown);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(idComisionLabel);
            Name = "PersonaDetalle";
            Text = "Persona Detalle";
            Load += Persona_Load;
            ((System.ComponentModel.ISupportInitialize)legajoNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private ComboBox planDropDown;
        private Label label2;
        private TextBox textBoxDireccion;
        private Label label1;
        private ComboBox tipoPersonaDropDown;
        private Label AnioCalendarioLabel;
        private Label cupoLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label idComisionLabel;
        private NumericUpDown legajoNumericUpDown;
        private TextBox textBoxTelefono;
        private DateTimePicker dateTimePickerFechaNacimiento;
    }
}