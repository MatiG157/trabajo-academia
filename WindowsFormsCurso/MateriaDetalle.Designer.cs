namespace WindowsFormsCurso
{
    partial class MateriaDetalle
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
            descripcionLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            DescripcionRichTextBox = new RichTextBox();
            planLabel = new Label();
            planDropDown = new ComboBox();
            horasTotalesNumericUpDown = new NumericUpDown();
            horasTotalesLabel = new Label();
            horasSemanalesNumericUpDown = new NumericUpDown();
            HorasSemanalesLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)horasTotalesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)horasSemanalesNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new Point(29, 29);
            descripcionLabel.Margin = new Padding(2, 0, 2, 0);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(87, 20);
            descripcionLabel.TabIndex = 17;
            descripcionLabel.Text = "Descripcion";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(242, 268);
            cancelarButton.Margin = new Padding(2, 3, 2, 3);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(91, 29);
            cancelarButton.TabIndex = 16;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(127, 268);
            aceptarButton.Margin = new Padding(2, 3, 2, 3);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(91, 29);
            aceptarButton.TabIndex = 15;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // DescripcionRichTextBox
            // 
            DescripcionRichTextBox.Location = new Point(154, 26);
            DescripcionRichTextBox.Margin = new Padding(3, 4, 3, 4);
            DescripcionRichTextBox.Name = "DescripcionRichTextBox";
            DescripcionRichTextBox.Size = new Size(310, 79);
            DescripcionRichTextBox.TabIndex = 20;
            DescripcionRichTextBox.Text = "";
            // 
            // planLabel
            // 
            planLabel.AutoSize = true;
            planLabel.Location = new Point(29, 219);
            planLabel.Margin = new Padding(2, 0, 2, 0);
            planLabel.Name = "planLabel";
            planLabel.Size = new Size(37, 20);
            planLabel.TabIndex = 13;
            planLabel.Text = "Plan";
            // 
            // planDropDown
            // 
            planDropDown.FormattingEnabled = true;
            planDropDown.Location = new Point(154, 216);
            planDropDown.Margin = new Padding(3, 4, 3, 4);
            planDropDown.Name = "planDropDown";
            planDropDown.Size = new Size(150, 28);
            planDropDown.TabIndex = 22;
            // 
            // horasTotalesNumericUpDown
            // 
            horasTotalesNumericUpDown.Location = new Point(154, 174);
            horasTotalesNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            horasTotalesNumericUpDown.Name = "horasTotalesNumericUpDown";
            horasTotalesNumericUpDown.Size = new Size(151, 27);
            horasTotalesNumericUpDown.TabIndex = 14;
            // 
            // horasTotalesLabel
            // 
            horasTotalesLabel.AutoSize = true;
            horasTotalesLabel.Location = new Point(29, 176);
            horasTotalesLabel.Margin = new Padding(2, 0, 2, 0);
            horasTotalesLabel.Name = "horasTotalesLabel";
            horasTotalesLabel.Size = new Size(97, 20);
            horasTotalesLabel.TabIndex = 18;
            horasTotalesLabel.Text = "Horas totales";
            // 
            // horasSemanalesNumericUpDown
            // 
            horasSemanalesNumericUpDown.Location = new Point(154, 129);
            horasSemanalesNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            horasSemanalesNumericUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            horasSemanalesNumericUpDown.Name = "horasSemanalesNumericUpDown";
            horasSemanalesNumericUpDown.Size = new Size(151, 27);
            horasSemanalesNumericUpDown.TabIndex = 10;
            horasSemanalesNumericUpDown.TabStop = false;
            // 
            // HorasSemanalesLabel
            // 
            HorasSemanalesLabel.AutoSize = true;
            HorasSemanalesLabel.Location = new Point(29, 131);
            HorasSemanalesLabel.Margin = new Padding(2, 0, 2, 0);
            HorasSemanalesLabel.Name = "HorasSemanalesLabel";
            HorasSemanalesLabel.Size = new Size(121, 20);
            HorasSemanalesLabel.TabIndex = 19;
            HorasSemanalesLabel.Text = "Horas semanales";
            // 
            // MateriaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 312);
            Controls.Add(planDropDown);
            Controls.Add(DescripcionRichTextBox);
            Controls.Add(HorasSemanalesLabel);
            Controls.Add(horasSemanalesNumericUpDown);
            Controls.Add(horasTotalesLabel);
            Controls.Add(horasTotalesNumericUpDown);
            Controls.Add(descripcionLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(planLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MateriaDetalle";
            Text = "Detalle materia";
            Load += Materia_Load;
            ((System.ComponentModel.ISupportInitialize)horasTotalesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)horasSemanalesNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label descripcionLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private RichTextBox DescripcionRichTextBox;
        private Label planLabel;
        private ComboBox planDropDown;
        private NumericUpDown horasTotalesNumericUpDown;
        private Label horasTotalesLabel;
        private NumericUpDown horasSemanalesNumericUpDown;
        private Label HorasSemanalesLabel;
    }
}