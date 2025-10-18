namespace WindowsFormsCurso
{
    partial class PlanDetalle
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
            especialidadDropDown = new ComboBox();
            DescripcionRichTextBox = new RichTextBox();
            descripcionLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            especialidadLabel = new Label();
            SuspendLayout();
            // 
            // especialidadDropDown
            // 
            especialidadDropDown.FormattingEnabled = true;
            especialidadDropDown.Location = new Point(115, 78);
            especialidadDropDown.Name = "especialidadDropDown";
            especialidadDropDown.Size = new Size(272, 23);
            especialidadDropDown.TabIndex = 32;
            // 
            // DescripcionRichTextBox
            // 
            DescripcionRichTextBox.Location = new Point(115, 12);
            DescripcionRichTextBox.Name = "DescripcionRichTextBox";
            DescripcionRichTextBox.Size = new Size(272, 60);
            DescripcionRichTextBox.TabIndex = 31;
            DescripcionRichTextBox.Text = "";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(15, 15);
            descripcionLabel.Margin = new Padding(2, 0, 2, 0);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(69, 15);
            descripcionLabel.TabIndex = 28;
            descripcionLabel.Text = "Descripcion";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(202, 118);
            cancelarButton.Margin = new Padding(2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(80, 22);
            cancelarButton.TabIndex = 27;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click_1;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(101, 118);
            aceptarButton.Margin = new Padding(2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(80, 22);
            aceptarButton.TabIndex = 26;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click_1;
            // 
            // especialidadLabel
            // 
            especialidadLabel.AutoSize = true;
            especialidadLabel.Location = new Point(15, 81);
            especialidadLabel.Margin = new Padding(2, 0, 2, 0);
            especialidadLabel.Name = "especialidadLabel";
            especialidadLabel.Size = new Size(72, 15);
            especialidadLabel.TabIndex = 24;
            especialidadLabel.Text = "Especialidad";
            // 
            // PlanDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 155);
            Controls.Add(especialidadDropDown);
            Controls.Add(DescripcionRichTextBox);
            Controls.Add(descripcionLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(especialidadLabel);
            Name = "PlanDetalle";
            Text = "Form1";
            Load += Plan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox especialidadDropDown;
        private RichTextBox DescripcionRichTextBox;
        private Label HorasSemanalesLabel;
        private NumericUpDown horasSemanalesNumericUpDown;
        private Label horasTotalesLabel;
        private NumericUpDown horasTotalesNumericUpDown;
        private Label descripcionLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private Label especialidadLabel;
    }
}